using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour
{
    float smooth = 1.0f, y;
    float doorOpenAngle = 90.0f;
    private bool open, enter, key;
    private Vector3 openRot, defaultRot;
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
        y = defaultRot.y - doorOpenAngle;
        openRot = new Vector3(defaultRot.x, y, defaultRot.z);
        panel.SetActive(false);
        style = new GUIStyle();
        audioSource = door.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {   
        /* Checking if the door is open or not. If it is open, it will set the key to false. If it is
        not open, it will set the key to true. */
        if (open)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            key = false;
        }
        else
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
            key = true;
        }
        /* Checking if the player is pressing the "f" key and if the player is in the trigger. If both
        are true, it will open the door. If the door is already open, it will close the door. */
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
    
   /// <summary>
   /// When the player enters the trigger, the panel is set to active and the boolean enter is set to
   /// true
   /// </summary>
   /// <param name="Collider">The collider that is hit by the raycast.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            panel.SetActive(true);
            enter = true;
        }
        if (other.gameObject.tag == "Door")
        {
            AudioSource.PlayClipAtPoint(closeDoor, transform.position, 1);
        }
    }
    /// <summary>
    /// When the player exits the trigger, the panel is deactivated and the boolean is set to false
    /// </summary>
    /// <param name="Collider">The collider that is being exited.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
            enter = false;
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

        /* Checking if the player is in the trigger and if the door is closed. If both are true, it
        will display the text "F Abrir" on the screen. */
        if (enter && key)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Abrir", style);
        }
       /* Checking if the player is in the trigger and if the door is open. If both are true, it will
       display the text "F Cerrar" on the screen. */
        if(enter && !key)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Cerrar", style);
        }
    }
}

