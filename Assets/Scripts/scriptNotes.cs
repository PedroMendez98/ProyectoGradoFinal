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
        textTitle.text = "Lógica";
        textInfoNote.text = "Se conoce por lógica computación o lógica matemática directamente aplicada en el contexto de las ciencias de computación aquellos recursos que pueden se implementados en diferente nivel como lo puede ser: " +
          "\n\n- Circuitos computacionales " +
          "\n- Programación lógica " +
          "\n- Análisis y optimización de recursos temporales y espaciales (mas conocidos en el campo de la ciencia computacional como algoritmos)"+
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
                textInfoNote.text = "la lógica computacional es una disciplina que estudia la aplicación de la lógica formal Para representación computacional de parámetros, técnicas de deducción automática o Conocimientos básicos asistidos por ordenador relacionados con la validez y la integridad de acuerdo con su complejidad. ";
                break;
            default:
                break;
        }
    }
}
