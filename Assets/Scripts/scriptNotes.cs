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


    //objetos a destruir
    public GameObject plarTeacher;

    int opt;
    
    // Start is called before the first frame update
    void Start()
    {
        textInfoNote.GetComponent<Text>();
        textTitle.GetComponent<Text>();
        panelNotebook.SetActive(false);
        text_title.SetActive(false);
        text_info_note.SetActive(false);
        button_exit.SetActive(false);
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
    }
    private void OnTriggerExit(Collider other)
    {
        
            
    }
    void optionNote()
    {
        switch (tags)
        {
            case "Logic":
                opt = 1;
                logicNote();
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
        Time.timeScale = 0f;
        //Destroy(notebookLogic);
        Destroy(plarTeacher);
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
}
