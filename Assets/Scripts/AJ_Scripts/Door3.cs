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
        /* Checking if the door is open or not. If it is open, it will set the key to false. If it is
        not open, it will set the key to true. */
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
        /* Checking if the player is pressing the F key and if the player is entering the door. If the
        player is pressing the F key and entering the door, the door will open. If the player is
        pressing the F key and entering the door, the door will close. */
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
    /// <summary>
    /// When the player enters the trigger, the panel is set to active and the enter variable is set to
    /// true
    /// </summary>
    /// <param name="Collider">The collider that is hit by the raycast.</param>
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
        if (other.gameObject.tag == "Door")
        {
            AudioSource.PlayClipAtPoint(openDoor, transform.position, 1);
        }
    }
    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;

        /* Checking if the player is entering the door and if the key is true. If the player is
        entering the door and the key is true, it will display the text "F Abrir" on the screen. */
        if (enter && key)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Abrir", style);
        }
        /* Checking if the player is entering the door and if the key is false. If the player is
        entering the door and the key is false, it will display the text "F Cerrar" on the screen. */
        if (enter && !key)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Cerrar", style);
        }
    }
}

