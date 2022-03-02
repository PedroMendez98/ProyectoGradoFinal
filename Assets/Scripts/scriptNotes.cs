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
    public GameObject pistaInterrogante;

    public GameObject[] notas;
    public GameObject[] notasPantalla;
    public Button[] buttonNotes;
    public GameObject[] life;

    //objetos a destruir
    public GameObject plarTeacher;
    public GameObject companionCharacter;
    public Collider objTeacher;


    script_teacher_one hosti = new script_teacher_one();

    int opt;
    int optmenuPant;
    string buttonOptions;
    int cont = 0;
    int option;

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
        pistaInterrogante.SetActive(false);
        companionCharacter.SetActive(false);
       
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
        if (Input.GetKeyDown("e"))
        {
            if (tags == "actiPruebas")
            {
                optionNote();
            }
           
        }
        personaje();

        //--------borrar----------
        for (int i = 0; i < buttonNotes.LongLength; i++)
        {
            buttonNotes[i].enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        tags = other.gameObject.tag;
        print(tags);
        if (tags=="Tops")
        {
            option += 1;
        }
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
            case "trouble":
                trouble();
                tags = "";
                validarButton("buttonTrouble");
                break;
            case "actiPruebas":
                activarPruebas();
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
        activarPistas("Concept");
        desactivarPistas("Logic");

        Time.timeScale = 0f;
        opt = 1;
        plarTeacher.transform.position = new Vector3(350.43f, 165.418f, 259.57f);
        plarTeacher.SetActive(false);
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
        desactivarPistas("Concept");
        activarPistas("algorit");
        activarPistas("codificacion");
        activarPistas("lenguProgramation");
        activarPistas("pseudocodigo");
        activarPistas("diaFlujo");
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
        textInfoNote.text = "Un algoritmo inform�tico es un conjunto definido, ordenado y acotado de instrucciones para resolver un problema, realizar un c�lculo o realizar una tarea. Es decir, un algoritmo es un proceso paso a paso para llegar a un fin. Partiendo de un estado e informaci�n inicial, sigue una secuencia de pasos ordenados para resolver una situaci�n."
                            + "\n\nLos algoritmos se componen de tres partes importantes para realizar los pasos y resolver los problemas, sus componentes son:"+
                                "\n\t* Input(Entrada) informaci�n que se suministra al algoritmo."+ 
                                "\n\t* Proceso(Paso asignados a partir de la entrada)."+
                                "\n\t* Output(Salida) resultado de la transformaci�n de los datos.";
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
        textTitle.text = "Codificaci�n";
        textInfoNote.text = "En inform�tica, la codificaci�n tambi�n es la operaci�n de enviar datos de un lugar a otro, procesarlos y obtener resultados de ellos. Todas las operaciones de la computadora est�n encriptadas en c�digo binario o en una combinaci�n m�s o menos compleja de 1 y 0 que siguen apareciendo. \n\nA su vez, ciertas operaciones de la computadora requieren un segundo nivel de encriptaci�n. Son aquellas que requieren aspectos de seguridad y confidencialidad, y por lo tanto implican la creaci�n de mensajes encriptados que solo pueden ser le�dos por cierto tipo de computadoras o por el usuario que los cre�, al igual que las contrase�as y los datos personales en las transacciones en l�nea.";
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
        textTitle.text = "Lenguajes de programaci�n";
        textInfoNote.text = "Es un lenguaje completo que, a trav�s de una serie de instrucciones, permite a los programadores escribir un conjunto de instrucciones, acciones secuenciales, datos y algoritmos para crear programas que manipulan la f�sica y la l�gica de una m�quina."+
                            "\n\nGracias a este lenguaje, el programador y la m�quina se comunican entre s�, lo que permite determinar con precisi�n aspectos como:"+
                              "\n\t-Qu� datos debe explotar un determinado software."+
                              "\n\t-C�mo deben almacenarse o transmitirse estos datos." +
                              "\n\t-Acciones tomadas por el software en base a los casos de cambio."+
                              "\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 2;
        cont = cont + 1;
        validarNotas(cont);
        desactivarPistas("lenguProgramation");
    }
    public void pseudocodigo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Pseudoc�digo";
        textInfoNote.text = "El pseudoc�digo es una forma de expresar los diferentes pasos que realizar� un programa, m�s similar a un lenguaje de programaci�n. Su principal funci�n es representar la soluci�n de un problema o algoritmo paso a paso de la forma m�s detallada posible, utilizando un lenguaje cercano a la programaci�n. \n\nEl pseudoc�digo no se puede ejecutar en una computadora porque entonces ya no ser� un pseudoc�digo, como sugiere el nombre, es un c�digo de error (pseudo = falso), que es un c�digo escrito para el entendimiento humano, no para la m�quina."
                            +"\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 4;
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
        textInfoNote.text = "Un diagrama de flujo se conoce como una representaci�n gr�fica de todos los pasos involucrados en un proceso. Por lo tanto, es un diagrama esquem�tico de la secuencia de operaciones que componen el sistema. Un diagrama de flujo es en pocas palabras todas las acciones que se relacionan entre s� para conducir a un resultado espec�fico. \n\nEs importante resaltar que un diagrama de flujo es una representaci�n gr�fica o visual de un algoritmo que utiliza varios s�mbolos, formas y l�neas para representar el proceso de un programa."+
                             "\n                                           Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 3;
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
        textInfoNote.text = "Es un espacio en la memoria de la computadora que permite el almacenamiento temporal de datos durante la ejecuci�n de un proceso, cuyo contenido puede cambiarse durante la ejecuci�n del programa. \n\nLa informaci�n puede ser un car�cter, una cadena, un n�mero, una matriz y, en general, cualquier otro tipo de dato. Para identificar una variable en la memoria de la computadora, es necesario darle un nombre para que podamos identificarla en el algoritmo."
                            +"\n                                           Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 5;
        desactivarPistas("tipovariable");
        activarPistas("trouble");
    }
    public void trouble()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Problemas";
        textInfoNote.text = "En el cual se comprende con claridad, cu�l es el problema, que debes lograr y perfilar una posible soluci�n."
                             + "\n\nLa programaci�n lineal es un m�todo por el cual se optimiza una funci�n objetivo, por maximizaci�n o minimizaci�n, en el que las variables se elevan a potencias de 1. Ello, teniendo en cuenta las diversas restricciones introducidas." +
                                " Recuerda que este tipo de ecuaci�n es una igualdad matem�tica que puede tener una o m�s inc�gnitas. Entonces tiene la siguiente forma b�sica, donde a y b son constantes, mientras que x e y son variables.";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("trouble");
        pistaInterrogante.SetActive(true);
        
    }
    void activarPruebas()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textInfoNote.alignment = TextAnchor.UpperCenter;
        opt = 12;
        textTitle.text = "�FELICIDADES!";
        textInfoNote.text = "�Felicidades has llegado al momento de las pruebas!" +
                            "\n\n�Validemos que tanto aprendiste empecemos!" +
                             "\n\n\nPulsa | X | para empezar�.";
        Time.timeScale = 0f;
        companionCharacter.SetActive(true);
        plarTeacher.SetActive(true);
        hosti.llaveInt = 2;
        objTeacher.enabled = false;

    }
    void personaje()
    {
        if (tags == "Tops")
        {
            switch (option)
            {
                case 1:
                    calculateLife("Notebook_3");
                    break;
                case 2:
                    calculateLife("Notebook_2");
                    break;
                case 3:
                    calculateLife("Notebook_1");
                    break;
                default:
                    break;
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
            case 2:
                textInfoNote.text = "Para explicar mejor, un lenguaje de programaci�n es un sistema de comunicaci�n estructurado, compuesto por conjuntos de s�mbolos, palabras clave, reglas sem�nticas y sintaxis que permite el entendimiento entre programadores y m�quinas." +
                                    "\n\nEstos son algunos ejemplos de lenguajes de programaci�n que podr�s encontrar:" +
                                    "\n\t*JavaScript \n\t*Java \n\t*C# \n\t*PHP \n\t*C / C++";
                break;
            case 3:
                textInfoNote.text = "Usando algoritmos, las personas pueden entender f�cilmente un programa. El objetivo principal de los diagramas de flujo es analizar diferentes procesos.\n\n Los procesos se pueden representar mediante cajas y flujos de diferentes tama�os y colores. En un diagrama, podemos resaltar f�cilmente un elemento y la relaci�n entre cada parte.";
                break;
            case 4:
                textInfoNote.text = "El pseudoc�digo es un m�todo para visualizar una soluci�n detallada de un algoritmo. El t�rmino se utiliza campos como la inform�tica, las especializaciones en inform�tica y el an�lisis num�rico. Por lo tanto, el pseudoc�digo es una forma relativamente simple de representar los diferentes pasos que debe seguir un programa para lograr sus objetivos.";
                break;
            case 5:
                textInfoNote.text = "Estos son los tipos de variables que puedes utilizar: \n\n* Variables num�ricas: Variables que almacenan valores num�ricos(positivos o negativos), es decir, almacenan n�meros del 0 al 9, signos(+y -) y puntos decimales. \n\n*Variables booleanas: Son variables que pueden contener solo dos valores (verdadero o falso) que muestran el resultado de una comparaci�n entre otros datos. \n\n*Variables Alfanum�ricas: incluye caracteres alfab�ticos num�ricos (letras, n�meros y caracteres especiales).";
                break;
            case 12:
                panelNotebook.SetActive(false);
                text_info_note.SetActive(false);
                text_title.SetActive(false);
                Time.timeScale = 1f;
                pistaInterrogante.SetActive(false);
                break;
            default:
                break;
        }
    }
    IEnumerator expectTime()
    {
        
        yield return new WaitForSeconds(3);
        switch (optmenuPant)
        {
            case 1:
                for (int i = 0; i < notasPantalla.LongLength; i++)
                {
                    if (notasPantalla[i].name == "miniMap")
                    {
                        notasPantalla[i].SetActive(true);
                    }        
                    yield return new WaitForSeconds(3);
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
    public void calculateLife(string strlife)
    {
        for (int i = 0; i < life.LongLength; i++)
        {
            if (life[i].name == strlife)
            {
                life[i].SetActive(false);
            }
        }
    }
}
