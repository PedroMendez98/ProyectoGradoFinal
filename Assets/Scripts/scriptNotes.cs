using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptNotes : MonoBehaviour
{
    string tags;
    public GameObject panelNotebook;

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
    int cont = 0;

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
        for (int i = 0; i < notas.LongLength; i++)
        {
            notas[i].SetActive(false);
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
                validarButton("buttonLogic");
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
                validarButton("buttonAlgorit");
                break;
            case "codificacion":
                codificacion();
                tags = "";
                validarButton("buttonCodificacion");
                break;
            case "lenguProgramation":
                lenguProgramation();
                tags = "";
                validarButton("buttonLenguProgramation");
                break;
            case "pseudocodigo":
                pseudocodigo();
                tags = "";
                validarButton("buttonPseudocodigo");
                break;
            case "diaFlujo":
                diaFlujo();
                tags = "";
                validarButton("buttonDiaFlujo");
                break;
            case "tipovariable":
                tipovariable();
                tags="";
                validarButton("buttonTipovariable");
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
        textTitle.text = "Lógica";
        textInfoNote.text = "Se conoce por lógica computación o lógica matemática directamente aplicada en el contexto de las ciencias de computación aquellos recursos que pueden se implementados en diferente nivel como lo puede ser: " +
          "\n\n- Circuitos computacionales " +
          "\n- Programación lógica " +
          "\n- Análisis y optimización de recursos temporales y espaciales (mas conocidos en el campo de la ciencia computacional como algoritmos)"+
          "\n\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        activarPistas("Concept");
        desactivarPistas("Logic");

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
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);

        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("Concept");
        activarPistas("algorit");
        activarPistas("codificacion");
        activarPistas("lenguProgramation");
        activarPistas("pseudocodigo");
        activarPistas("diaFlujo");
    }
    public void caseNextContinue(int opts)
    {
        switch (opts)
        {
            case 1:
                textInfoNote.text = "la lógica computacional es una disciplina que estudia la aplicación de la lógica formal Para representación computacional de parámetros, técnicas de deducción automática o Conocimientos básicos asistidos por ordenador relacionados con la validez y la integridad de acuerdo con su complejidad. ";
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
        optmenuPant = 1;
        activarPistas("Logic");
        StartCoroutine("expectTime");
        
    }
    public void algorit()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Algoritmo";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        cont = cont + 1;
        validarNotas(cont);
        desactivarPistas("algorit");
    }
    public void codificacion()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Codificación";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        cont = cont + 1;
        validarNotas(cont);
        opt = 0;
        desactivarPistas("codificacion");
    }
    public void lenguProgramation()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Lenguajes de programación";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        cont = cont + 1;
        validarNotas(cont);
        desactivarPistas("lenguProgramation");
    }
    public void pseudocodigo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Pseudocódigo";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("pseudocodigo");
        cont = cont + 1;
        validarNotas(cont);
    }
    public void diaFlujo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Diagrama de flujos";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("diaFlujo");
        cont = cont + 1;
        validarNotas(cont);
    }
    public void tipovariable()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Tipo Variable";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Seudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("tipovariable");
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
    public void activarPistas(string namePistaA)
    {
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == namePistaA)
            {
                notas[i].SetActive(true);
            }
        }
    }
    public void desactivarPistas(string namePistaD)
    {
        for (int i = 0; i < notas.LongLength; i++)
        {
            if (notas[i].name == namePistaD)
            {
                notas[i].SetActive(false);
            }
        }
    }
    public void validarNotas(int contador)
    {
        if (contador == 5)
        {
            activarPistas("tipovariable");
        }
    }
}
