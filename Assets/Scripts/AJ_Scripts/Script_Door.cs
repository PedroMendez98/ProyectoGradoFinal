using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Door : MonoBehaviour
{
    float smooth = 1.0f;
    float doorOpenAngle = 90.0f;
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
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
        panel.SetActive(false);
        style = new GUIStyle();
        audioSource = door.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            key = false;
        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
            key = true;
        }
        if (Input.GetKeyDown("f") && enter)
        {
            open = !open;
            if (open)
            {
                smooth = 1.0f;
                audioSource.clip = openDoor;
                audioSource.Play();
            }
            else
            {
                smooth = 2.0f;
                audioSource.clip = closeDoor;
                audioSource.Play();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            enter = true;
            panel.SetActive(true);
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
            enter = false;
            panel.SetActive(false);
        }
        if(other.gameObject.tag == "Door")
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
