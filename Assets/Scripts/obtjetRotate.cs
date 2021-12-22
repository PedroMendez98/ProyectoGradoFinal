using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class obtjetRotate : MonoBehaviour
{

    public GameObject objeto;
    public GameObject  image, panel;
    bool enter;
    GUIStyle style;
    public Font ScoreFont;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        style = new GUIStyle();
    }

    // Update is called once per frame
    void Update()
    {
        objeto.transform.Rotate(0, 10, 0);
        if (Input.GetKeyDown("e"))
        {
            image.SetActive(true); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
            enter = false;
            image.SetActive(false);
        }
    }
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
