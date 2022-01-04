using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    public GameObject menu;
    public GameObject button_abourt;
    public GameObject button_play;
    public GameObject button_information;
    public GameObject image_information;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        image_information.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        button_play.SetActive(true);
        menu.SetActive(false);
        image_information.SetActive(false);
    }
    public void startInfo()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(true);
    }
}
