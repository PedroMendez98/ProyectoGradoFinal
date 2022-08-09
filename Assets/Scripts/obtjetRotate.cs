using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class obtjetRotate : MonoBehaviour
{

    public GameObject objeto, panelNotebook;
    public Text textTitle;
    public Text textInfoNote;
    bool enter;
    GUIStyle style;
    public Font ScoreFont;
    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
    }

   /// <summary>
   /// The Update function is called every frame
   /// </summary>
    void Update()
    {
        objeto.transform.Rotate(0, 10, 0); 
    }
    /// <summary>
    /// If the player enters the trigger, set the enter variable to true
    /// </summary>
    /// <param name="Collider">The collider that is being entered.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }
    /// <summary>
    /// If the player leaves the trigger area, the panel is deactivated
    /// </summary>
    /// <param name="Collider">The collider that is used to detect the player.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
            panelNotebook.SetActive(false);
        }
    }
    /// <summary>
    /// If the player presses the 'E' key, the function will display the text "E Pista!" on the screen
    /// </summary>
    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;

        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'E' Pista!", style);
        }
    }
}
