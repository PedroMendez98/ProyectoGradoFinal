using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    [SerializeField]
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
    public Button button_backB;
    public GameObject button_menu;
    public GameObject button_close_2;

    public GameObject text_title_grades;

    public Text textInfo;
    public Text textTitleGrades;
    public GameObject miniMap;


    //Imagenes y/o Fondos
    public GameObject image_information;
    public GameObject image_controls;
    public GameObject image_menu;
    public Button Bnext;
    public GameObject image_notebook;
    public GameObject mini_map;

    bool validate_screen_status;

    //Jugador
    // Start is called before the first frame update
    public void Start()
    {
        button_close_2.SetActive(false);
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
        text_title_grades.SetActive(false);
        image_notebook.SetActive(false);
        mini_map.SetActive(false);
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
        mini_map.SetActive(true);                   
    }
    public void startInfo()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(true);
        button_next.SetActive(true);
        button_close_2.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(true);
        mini_map.SetActive(false);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        image_notebook.SetActive(false);
        button_backB.GetComponent<Button>().onClick.AddListener(backPause);
        Bnext.GetComponent<Button>().onClick.AddListener(next);
        textInfo.text = "Este juego está diseñado para el aprendizaje de lógica computacional, de esta manera podrás poner aprueba tú conocimiento para resolver problemas a través de la lógica, \n\n recuerda, dentro del colegio encontraras información a través de pistas y objetos que tendrás que recolectar, de igual manera pondrás a prueba el conocimiento que obtengas durante esta aventura por medio pequeños ejercicios.";

    }
    public void startInfo2()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(true);
        button_next.SetActive(true);
        button_close_2.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(true);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        image_notebook.SetActive(false);
        mini_map.SetActive(false);
        Bnext.GetComponent<Button>().onClick.AddListener(next);
        textInfo.text = "Este juego está diseñado para el aprendizaje de lógica computacional, de esta manera podrás poner aprueba tú conocimiento para resolver problemas a través de la lógica, \n\n recuerda; dentro del colegio encontrarás información a través de pistas y objetos que tendrás que recolectar, de igual manera pondrás a prueba el conocimiento que obtengas durante está aventura, por medio de pequeños ejercicios.";
                                                                                                                                                                                                                                                                                                                   
    }
    public void close()
    {
        textInfo.GetComponent<Text>();
        menu.SetActive(false);
        menuPausa.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(true);
        image_menu.SetActive(false);
        text_title_grades.SetActive(false);
        image_notebook.SetActive(false);
        button_play.SetActive(false);
        Time.timeScale = 1f;
        mini_map.SetActive(true);
    }
    public void closeStart()
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
        text_title_grades.SetActive(false);
        image_notebook.SetActive(false);
        button_play.SetActive(true);
        button_close_2.SetActive(false);
        miniMap.SetActive(false);
    }
    public void screenControls()
    {
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close_2.SetActive(true);
        button_close.SetActive(false);
        image_controls.SetActive(true);
        menuPausa.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
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
        image_notebook.SetActive(false);
        mini_map.SetActive(false);
    }
    public void back()
    {
        button_play.SetActive(true);
        Time.timeScale = 1f;
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        button_close_2.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(false);
        button_menu.SetActive(true);
        image_menu.SetActive(false);
        image_notebook.SetActive(false);
        miniMap.SetActive(false);
        mini_map.SetActive(true);
        if (validate_screen_status == true)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
    public void backPause()
    {
        button_menu.SetActive(false);
        mini_map.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
    public void enterMenu()
    {
        menu.SetActive(false);
        menuPausa.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(false);
        image_controls.SetActive(false);
        button_back.SetActive(false);
        Time.timeScale = 0f;
        button_menu.SetActive(true);
        image_menu.SetActive(true);
        image_notebook.SetActive(false);
    }
    public void next()
    {
        textInfo.text = "\n\nNo olvides que algunos profesores del videojuego te darán información para que puedas continuar con tu ruta de aprendizaje.\n\n\n ¡Que comience la aventura a través de está ruta de aprendizaje!";
        button_play.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(false);
        Bnext.GetComponent<Button>().onClick.AddListener(imagenMiniMap);
        image_information.SetActive(true);
        button_close.SetActive(false);
        button_close_2.SetActive(false);
        image_controls.SetActive(false);
        menuPausa.SetActive(false);
        button_back.SetActive(true);
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        image_notebook.SetActive(false);
        miniMap.SetActive(false);
    }
    public void buttonNotebooks()
    {
        menu.SetActive(false);
        menuPausa.SetActive(false);
        image_information.SetActive(false);
        button_next.SetActive(false);
        button_close.SetActive(true);
        button_close_2.SetActive(false);
        image_controls.SetActive(false);
        button_back.SetActive(false);
        Time.timeScale = 0f;
        button_menu.SetActive(false);
        image_menu.SetActive(false);
        image_notebook.SetActive(true);
        mini_map.SetActive(false);
    }
    public void imagenMiniMap()
    {
        miniMap.SetActive(true);
        Time.timeScale = 0f;
        textInfo.text = "";
        
    }
    public void exitAplicattion()
    {
        Application.Quit();
    }
    
}
                     