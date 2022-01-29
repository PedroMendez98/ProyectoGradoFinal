
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
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
