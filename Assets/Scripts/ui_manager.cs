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

    public GameObject text_title_grades;

    public Text textInfo;
    public Text textTitleGrades;

    //Imagenes y/o Fondos
    public GameObject image_information;
    public GameObject image_controls;
    public GameObject image_menu;
    public GameObject image_notebook;

    bool validate_screen_status;

    //Jugador
    // Start is called before the first frame update
    void Start()
    {
        textInfo.GetComponent<Text>();
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
        text_title_grades.SetActive(false);
        image_notebook.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            validate_screen_status = true;
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
        validate_screen_status = false;
        image_notebook.SetActive(false);
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
        image_notebook.SetActive(false);

        textInfo.text = "Este juego esta diseñado para el aprendizaje de lógica computacional de esta manera podrás poner aprueba tu conocimiento para resolver problemas a través de la lógica, \n\n recuerda dentro del colegio encontraras información a través de pistas y objetos que tendrás que recolectar de igual manera pondrás a prueba el conocimiento que obtengas durante esta aventura por medio pequeños ejercicios.";

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
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);
        button_menu.SetActive(true);
        image_notebook.SetActive(false);

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
        image_notebook.SetActive(false);
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
        image_notebook.SetActive(false);
    }
    public void back()
    {
        button_play.SetActive(true);
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
        image_notebook.SetActive(false);
        if (validate_screen_status == true)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
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
        image_notebook.SetActive(false);
    }
    public void next()
    {
        textInfo.text = "\n\nNo olvides algunos profesores del videojuego te darán información para que puedas continuar con tu ruta de aprendizaje.\n\n\n ¡Que comience la aventura a través de esta ruta de aprendizaje!";
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
        image_notebook.SetActive(false);
    }
    public void buttonNotebooks()
    {
        menu.SetActive(false);
        menuPausa.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(true);
        image_controls.SetActive(false);
        button_back.SetActive(false);
        Time.timeScale = 0f;
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        button_menu_objects.SetActive(false);
        button_menu_tracks.SetActive(false);
        image_notebook.SetActive(true);
    }
}
