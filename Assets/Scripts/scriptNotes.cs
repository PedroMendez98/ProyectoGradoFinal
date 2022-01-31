using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptNotes : MonoBehaviour
{
    string tags;
    public GameObject panelNotebook;
    public GameObject notebookLogic;

    public GameObject text_title;
    public GameObject text_info_note;

    public GameObject button_exit;

    public Text textTitle;
    public Text textInfoNote;

    public GameObject panel2;
    public GameObject textPanel2;

    public GameObject[] notas;
    public GameObject[] notasPantalla;
    public Button[] buttonNotes;


    //objetos a destruir
    public GameObject plarTeacher;

    int opt;
    int optmenuPant;
    string buttonOptions;
    
    // Start is called before the first frame update
    void Start()
    {
        textInfoNote.GetComponent<Text>();
        textTitle.GetComponent<Text>();
        panelNotebook.SetActive(false);
        text_title.SetActive(false);
        text_info_note.SetActive(false);
        button_exit.SetActive(false);
        panel2.SetActive(false);
        textPanel2.SetActive(false);
        for (int i = 0; i < buttonNotes.LongLength; i++)
        {
            buttonNotes[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            optionNote();
        }
        if (Input.GetKeyDown("x"))
        {
            caseNextContinue(opt);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        tags = other.gameObject.tag;
        print(tags);
    }
    private void OnTriggerExit(Collider other)
    {
        
            
    }
    void optionNote()
    {
        switch (tags)
        {
            case "Logic":
                logicNote();
                tags = "";
                buttonOptions = "buttonLogic";
                validarButton(buttonOptions);
                break;
            case "teacherOne":
                mensajeWelcome();
                tags = "";
                break;
            case "Concept":
                concepText();
                tags = "";
                break;
            case "algorit":
                algorit();
                tags = "";
                break;
            case "codificacion":
                codificacion();
                tags = "";
                break;
            case "lenguProgramation":
                lenguProgramation();
                tags = "";
                break;
            case "pseudocodigo":
                pseudocodigo();
                tags = "";
                break;
            case "diaFlujo":
                diaFlujo();
                tags = "";
                break;
            default:
                break;
        }
    }
    public void exitNote()
    {
        panelNotebook.SetActive(false);
        text_title.SetActive(false);
        text_info_note.SetActive(false);
        button_exit.SetActive(false); 
        Time.timeScale = 1f;
    }
    public void logicNote()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "L�gica";
        textInfoNote.text = "Se conoce por l�gica computaci�n o l�gica matem�tica directamente aplicada en el contexto de las ciencias de computaci�n aquellos recursos que pueden se implementados en diferente nivel como lo puede ser: " +
          "\n\n- Circuitos computacionales " +
          "\n- Programaci�n l�gica " +
          "\n- An�lisis y optimizaci�n de recursos temporales y espaciales (mas conocidos en el campo de la ciencia computacional como algoritmos)"+
          "\n\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "Concept")
            {
                notas[i].SetActive(true);
            }
            if (notas[i].name == "Logic")
            {
                notas[i].SetActive(false);
            }
        }
        Time.timeScale = 0f;
        opt = 1;
        Destroy(plarTeacher);
    }
    public void concepText()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Conceptos";
        textInfoNote.text = "Para iniciar esta traves�a es importante tener claros algunos conceptos, los cuales aparecer�n en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificaci�n \n -Lenguaje de programaci�n \n -Seudoc�digo \n -Diagrama de flujo";
        button_exit.SetActive(true);

        Time.timeScale = 0f;
        opt = 0;
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "Logic")
            {
                notas[i].SetActive(false);
            }
            if (notas[i].name == "algorit" || notas[i].name == "codificacion" || notas[i].name == "lenguProgramation" || notas[i].name == "pseudocodigo" || notas[i].name == "diaFlujo")
            {
                notas[i].SetActive(true);

            }
        }
    }
    public void caseNextContinue(int opts)
    {
        switch (opts)
        {
            case 1:
                textInfoNote.text = "la l�gica computacional es una disciplina que estudia la aplicaci�n de la l�gica formal Para representaci�n computacional de par�metros, t�cnicas de deducci�n autom�tica o Conocimientos b�sicos asistidos por ordenador relacionados con la validez y la integridad de acuerdo con su complejidad. ";
                break;
            default:
                break;
        }
    }
    public void mensajeWelcome()
    {
        panelNotebook.SetActive(false);
        text_title.SetActive(false);
        text_info_note.SetActive(false);
        button_exit.SetActive(false);
        panel2.SetActive(true);
        textPanel2.SetActive(true);
        for (int i = 0; i < notas.LongLength; i++)
        {
           if(notas[i].name == "Logic")
            {
                notas[i].SetActive(true);
            }
        }
        optmenuPant = 1;
        StartCoroutine("expectTime");
        
    }
    public void algorit()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Algoritmo";
        textInfoNote.text = "Para iniciar esta traves�a es importante tener claros algunos conceptos, los cuales aparecer�n en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificaci�n \n -Lenguaje de programaci�n \n -Seudoc�digo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "Concept" || notas[i].name == "algorit")
            {
                notas[i].SetActive(false);
            }
        }
    }
    public void codificacion()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Codificaci�n";
        textInfoNote.text = "Para iniciar esta traves�a es importante tener claros algunos conceptos, los cuales aparecer�n en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificaci�n \n -Lenguaje de programaci�n \n -Seudoc�digo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "codificacion")
            {
                notas[i].SetActive(false);
            }
        }
    }
    public void lenguProgramation()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Lenguajes de programaci�n";
        textInfoNote.text = "Para iniciar esta traves�a es importante tener claros algunos conceptos, los cuales aparecer�n en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificaci�n \n -Lenguaje de programaci�n \n -Seudoc�digo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "lenguProgramation")
            {
                notas[i].SetActive(false);
            }
        }
    }
    public void pseudocodigo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Pseudoc�digo";
        textInfoNote.text = "Para iniciar esta traves�a es importante tener claros algunos conceptos, los cuales aparecer�n en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificaci�n \n -Lenguaje de programaci�n \n -Seudoc�digo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "pseudocodigo")
            {
                notas[i].SetActive(false);
            }
        }
    }
    public void diaFlujo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Diagrama de flujos";
        textInfoNote.text = "Para iniciar esta traves�a es importante tener claros algunos conceptos, los cuales aparecer�n en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificaci�n \n -Lenguaje de programaci�n \n -Seudoc�digo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == "diaFlujo")
            {
                notas[i].SetActive(false);
            }
        }
    }
    IEnumerator expectTime()
    {
        
        yield return new WaitForSeconds(5);
        switch (optmenuPant)
        {
            case 1:
                for (int i = 0; i < notasPantalla.LongLength; i++)
                {
                    if (notasPantalla[i].name == "miniMap")
                    {
                        notasPantalla[i].SetActive(true);
                    }        
                    yield return new WaitForSeconds(5);
                    notasPantalla[i].SetActive(false);
                }
                break;
            default:
                break;
        }
        
    }
    public void validarButton(string optiButton) 
    {
        for (int i = 0; i < buttonNotes.LongLength; i++)
        {
           if(buttonNotes[i].name == optiButton)
           {
                buttonNotes[i].enabled = true;   
           }
        }
    }
}
