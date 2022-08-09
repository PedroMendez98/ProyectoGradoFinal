using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    public float sensitivity = 10.0f;

    public Transform target;
    Vector3 mouseDelta = Vector3.zero;
    Vector3 amount = Vector3.zero;

    Vector3 camPos = Vector3.zero;
    public Vector3 addPos = new Vector3(0, 1.63f, 0);

    RaycastHit hit;
    float hitDistance = 0;

    float tanFOV;

    Camera cam;
    Vector3 lookAt = Vector3.zero;

    Vector3 cameraPosition = Vector3.zero;
    Vector3 cameraPositioNotOcc = Vector3.zero;
    Quaternion cameraRotation = Quaternion.identity;

    Vector3 screenCenter = Vector3.zero;
    Vector3 up = Vector3.zero;
    Vector3 right = Vector3.zero;

    Vector3[] corners = new Vector3[5];



    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        float halfFOV = cam.fieldOfView * 0.5f * Mathf.Deg2Rad;
        tanFOV = Mathf.Tan(halfFOV) * cam.nearClipPlane;

    }

    // Update is called once per frame
    void Update()
    {
        screenCenter = (cameraRotation * Vector3.forward) * cam.nearClipPlane;
        up = (cameraRotation * Vector3.up) * tanFOV;
        right = (cameraRotation * Vector3.right) * tanFOV * cam.aspect;

        corners[0] = cameraPosition + screenCenter - up - right;
        corners[1] = cameraPosition + screenCenter + up - right;
        corners[2] = cameraPosition + screenCenter + up + right;
        corners[3] = cameraPosition + screenCenter - up + right;
        corners[4] = cameraPosition + screenCenter;

        hitDistance = 10000000;

        for (int i = 0; i < 5; i++)
        {
            /* Checking if the camera is hitting a wall. */
            if (Physics.Linecast(target.transform.position + addPos, corners[i], out hit))
            {
                Debug.DrawLine(target.transform.position + addPos, corners[i], Color.red);

                Debug.DrawRay(hit.point, Vector3.up * 0.05f, Color.white);

                hitDistance = Mathf.Min(hitDistance, hit.distance);
            }
            else
            {
                Debug.DrawLine(target.transform.position + addPos, corners[i], Color.blue);
            }
            /* A fix for when the camera is too close to the wall. */
            if(hitDistance > 999999)
            {
                hitDistance = 0;
            }
        }
    }
    void LateUpdate()
    {
        /* Setting the mouseDelta to the mouse's x, y, and scroll wheel. */
        mouseDelta.Set(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"),
            Input.GetAxisRaw("Mouse ScrollWheel"));

        amount += -mouseDelta * sensitivity;
        amount.z = Mathf.Clamp(amount.z, 50, 100);
        amount.y = Mathf.Clamp(amount.y, 10, 89);

        /* Rotating the camera. */
        cameraRotation = Quaternion.AngleAxis(-amount.x, Vector3.up) *
            Quaternion.AngleAxis(amount.y, Vector3.right);

        lookAt = cameraRotation * Vector3.forward;

        cameraPosition = target.transform.position + addPos - lookAt * amount.z * 0.1f;

        cameraPositioNotOcc = target.transform.position + addPos - lookAt * hitDistance;

        /* This is a fix for when the camera is too close to the wall. */
        if (hitDistance < cam.nearClipPlane * 2.5f)
        {
            cameraPositioNotOcc -= lookAt * cam.nearClipPlane;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, Time.deltaTime * 10.0f);

        /* This is a fix for when the camera is too close to the wall. */
        if (hitDistance > 0)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPositioNotOcc, Time.deltaTime * 10.0f); ;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * 10.0f);
        }
    }
}
