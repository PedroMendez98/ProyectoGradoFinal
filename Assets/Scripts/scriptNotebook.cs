
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNotebook : MonoBehaviour
{
    public GameObject objetoNoteBook;
    bool enter;
    GUIStyle style;
    public Font ScoreFont;

    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle: 10f, yAngle: 0, zAngle: 0);
    }
    /* Checking if the player is within the trigger area. */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }
    /// <summary>
    /// If the player leaves the trigger area, the boolean variable enter is set to false
    /// </summary>
    /// <param name="Collider">The collider that is being used to detect the player.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
    /// <summary>
    /// If the player presses the F key, the function will check if the player is within a certain
    /// distance of the object, and if so, it will display a message on the screen
    /// </summary>
    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;

        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Pista!", style);
        }
    }
}
