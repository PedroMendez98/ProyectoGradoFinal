using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    //Menus
    public GameObject menu;
    public GameObject menuPausa;

    //Botones 
    public GameObject button_next;
    public GameObject button_abourt;
    public GameObject button_play;
    public GameObject button_information;
    public GameObject button_close;
    public GameObject button_back;
    public GameObject button_menu;
    public GameObject button_menu_tracks;
    public GameObject button_menu_objects;

    //Imagenes y/o Fondos
    public GameObject image_information;
    public GameObject image_controls;
    public GameObject image_menu;

    //Jugador
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        menuPausa.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            menuPause();
        }
    }
    public void startGame()
    {
        button_play.SetActive(true);
        menu.SetActive(false);
        image_information.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(true);
        Time.timeScale = 1f;

    }
    public void startInfo()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(true);
        button_next.SetActive(true);
        button_close.SetActive(true);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(true);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);

    }
    public void close()
    {
        button_play.SetActive(true);
        menu.SetActive(false);
        Time.timeScale=1f;
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(true);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);
    }
    public void screenControls()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(true);
        image_controls.SetActive(true);
        menuPausa.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);
    }
    void menuPause()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(true);
        button_back.SetActive(false);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);
    }
    public void back()
    {
        button_play.SetActive(true);
        menu.SetActive(true);
        Time.timeScale = 1f;
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(true);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);
    }
    public void enterMenu()
    {
        menu.SetActive(false);
        menuPausa.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(true);
        image_controls.SetActive(false);
        button_back.SetActive(false);
        Time.timeScale = 0f;
        button_menu.SetActive(true);
        image_menu.SetActive(true);
        button_menu_objects.SetActive(true);
        button_menu_tracks.SetActive(true);
    }
}
