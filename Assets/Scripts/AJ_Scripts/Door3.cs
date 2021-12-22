using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door3 : MonoBehaviour
{
    float smooth = 1.0f , x;
    float doorOpenAngle = 20.0001f;
    private bool open, enter, key;
    private Vector3 defaultRot, openRot;
    public GameObject door, panel;
    GUIStyle style;
    public Font ScoreFont;
    public AudioClip openDoor;
    public AudioClip closeDoor;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        defaultRot = transform.localPosition;
        x = defaultRot.x + doorOpenAngle;
        openRot = new Vector3(x, defaultRot.y, defaultRot.z);
        panel.SetActive(false);
        style = new GUIStyle();
        audioSource = door.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, openRot, Time.deltaTime * smooth);
            key = false;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultRot, Time.deltaTime * smooth);
            key = true;
        }
        if (Input.GetKeyDown("f") && enter)
        {
            open = !open;
            if (open)
            {
                smooth = 1.1f;
                audioSource.clip = openDoor;
                audioSource.Play();
            }
            else
            {
                smooth = 2.1f;
                audioSource.clip = closeDoor;
                audioSource.Play();

            }
        } 
    }
    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            enter = true;
        }
        if (other.gameObject.tag == "Door")
        {
            AudioSource.PlayClipAtPoint(closeDoor, transform.position, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
            enter = false;
        }
        if (other.gameObject.tag == "Door")
        {
            AudioSource.PlayClipAtPoint(openDoor, transform.position, 1);
        }
    }
    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;

        if (enter && key)
        {
            // Se muestra el mensaje de interaccion

            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Abrir", style);
        }
        if (enter && !key)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Cerrar", style);
        }
    }
}

