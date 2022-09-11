using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class scriptNotes : MonoBehaviour
{
    string tags;
    public GameObject panelNotebook;

    public GameObject text_title;
    public GameObject text_info_note;
    int sumaTotal;
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
    public GameObject imageGameOver;

    //objetos a destruir
    public GameObject plarTeacher;
    public GameObject obMiniMapTeacherPlar;
    public GameObject obMiniMapTeacherPlar2;
    public GameObject companionCharacter;
    public Collider objTeacher;
    public GameObject bookHomework;
    public GameObject imageHomework;

    public GameObject buttonStart;
    public GameObject buttonStartTwo;
    public GameObject prueba2d;

    public GameObject teacherGameOver;

    public Image iamgenEjempDiagramFlujo;

    public Image pistDiagFlujo;

    public bool enter;

    public string msg;

    public GUIStyle style;
    public Font ScoreFont;

    public Collider teacherOne;
    public Collider companionColl;

    script_Companion msgS = new script_Companion();
    public script_teacher_one hosti = new script_teacher_one();

    public Animator animatorTeacherTwo;
    public Collider colliderTeacherTwo;
    public Animator animatorTeacherThree;

    public int opt;
    int caseHom;
    int optmenuPant;
    string buttonOptions;
    public int optInterrogante = 0;
    int cont = 0;
    int option;

    public GameObject pruebaFinal2d;
    public GameObject miniMenu;
    public GameObject miniMap;

    public GameObject imagenFinalGameOver;

    public static int n;
    

    // Start is called before the first frame update
    void Start()
    {
        imageGameOver.SetActive(false);
        for (int i = 0; i < buttonNotes.LongLength; i++)
        {
            buttonNotes[i].enabled = false;
        }
        teacherGameOver.SetActive(false);
        imagenFinalGameOver.SetActive(false);
        miniMenu.SetActive(false);
        miniMap.SetActive(false);
        buttonStart.SetActive(false);
        buttonStartTwo.SetActive(false);
        prueba2d.SetActive(false);
        hosti.llaveInt = 1;
        style = new GUIStyle();
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
        bookHomework.SetActive(false);
        imageHomework.SetActive(false);
        pistDiagFlujo.enabled = false;
        iamgenEjempDiagramFlujo.enabled = false;
        opt = 0;
        enter = false;
        obMiniMapTeacherPlar2.SetActive(false);


        for (int i = 0; i < notas.LongLength; i++)
        {
            notas[i].SetActive(false);
        }
    }

    // Update is called once per frame
    /// <summary>
    /// The function is called every frame and it checks if the user has pressed a key. If the user has
    /// pressed a key, it calls another function
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            optionNote(tags);
        }
        if (Input.GetKeyDown("x"))
        {
            caseNextContinue(opt);
        }
        if (Input.GetKeyDown("e"))
        {
            optionNote(tags);
        }
        if (Input.GetKeyDown("r"))
        {
            switch (caseHom)
            {
                case 1:
                    caseNextContinue(15);
                    break;
                case 2:
                    imageHomework.SetActive(false);
                    optmenuPant = 3;
                    teacherOne.enabled = false;
                    animatorTeacherTwo.SetBool("idle", false);
                    animatorTeacherTwo.SetBool("talking", true);
                    buttonStart.SetActive(true);
                    StartCoroutine("expectTime");
                    panelNotebook.SetActive(true);
                    text_info_note.SetActive(true);
                    text_title.SetActive(true);
                    textTitle.text = "¡Felicidades!";
                    textInfoNote.text = "\n\n\nVamos a la siguiente prueba, \npulsa el botón";
                    textInfoNote.alignment = TextAnchor.UpperCenter;
                    Time.timeScale = 0f;
                    msg = "";
                    msgS.msg = " ";
                    break;
                case 3:
                    optmenuPant = 4;
                    enter = false;
                    animatorTeacherThree.SetBool("Idle", false);
                    animatorTeacherThree.SetBool("Talking", true);
                    buttonStartTwo.SetActive(true);
                    StartCoroutine("expectTime");
                    panelNotebook.SetActive(true);
                    button_exit.SetActive(true);
                    text_info_note.SetActive(true);
                    text_title.SetActive(true);
                    textTitle.text = "¡Felicidades!";
                    textInfoNote.text = "\nEsta es la última prueba, \nRevisa bien tus notas sobre los diagramas de flujo. \n\n Cuando estes listo regresa y \npulsa el botón";
                    textInfoNote.alignment = TextAnchor.UpperCenter;
                    textTitle.color = Color.green;
                    break;
                default:
                    break;
            }
        }
        personaje();
        ////--------borrar----------
        //for (int i = 0; i < buttonNotes.LongLength; i++)
        //{
        //    buttonNotes[i].enabled = true;
        //}
    }

    
    /// <summary>
    /// The function is called when the player collides with an object
    /// </summary>
    /// <param name="Collider">The collider that is entered.</param>
    private void OnTriggerEnter(Collider other)
    {
        tags = other.gameObject.tag;
        if (tags == "Tops")
        {
            option += 1;
            sumaTotal += 1;
        }
        if (tags == "teacherTwo")
        {
            msg = "'R' Entregar Tarea";
            enter = true;
            caseHom = 2;
            opt = 16;
            optInterrogante = 1;
            bookHomework.SetActive(false);
        }
        if (tags == "teacherThree")
        {
            msg = "'R' Hablar";
            enter = true;
            caseHom = 3;
        }
        if (tags == "book")
        {
            msg = "'R' Recoger Tarea";
            enter = true;
            colliderTeacherTwo.enabled = true;
        }
    }

    /// <summary>
    /// When the player exits the trigger, the opt variable is set to 0 and the exitNote() function is
    /// called
    /// </summary>
    /// <param name="Collider">The collider that is being used to detect the player.</param>
    private void OnTriggerExit(Collider other)
    {
        opt = 0;
        exitNote();
    }

    /// <summary>
    /// It's a switch statement that calls a function based on the value of the string tagG
    /// </summary>
    /// <param name="tagG">is the name of the button that was pressed</param>
    void optionNote(string tagG)
    {
        switch (tagG)
        {
            case "Logic":
                logicNote();
                tagG = "";
                validarButton("buttonLogic");
                break;
            case "teacherOne":
                mensajeWelcome();
                tagG = "";
                break;
            case "Concept":
                concepText();
                tagG = "";
                break;
            case "algorit":
                algorit();
                tagG = "";
                validarButton("buttonAlgorit");
                break;
            case "codificacion":
                codificacion();
                tagG = "";
                validarButton("buttonCodificacion");
                break;
            case "lenguProgramation":
                lenguProgramation();
                tagG = "";
                validarButton("buttonLenguProgramation");
                break;
            case "pseudocodigo":
                pseudocodigo();
                tagG = "";
                validarButton("buttonPseudocodigo");
                break;
            case "diaFlujo":
                diaFlujo();
                tagG = "";
                validarButton("buttonDiaFlujo");
                break;
            case "tipovariable":
                tipovariable();
                tagG = "";
                validarButton("buttonTipovariable");
                break;
            case "trouble":
                trouble();
                tagG = "";
                validarButton("buttonTrouble");
                break;
            case "optionInterrogante":
                if (optInterrogante == 1)
                {
                    caseNextContinue(opt);
                    tagG = "";
                }
                if (optInterrogante == 2)
                {
                    activarPruebas();
                    tagG = "";
                }
                if (optInterrogante == 3)
                {
                    activarExampleDiagrama();
                    tagG = "";
                }
                if (optInterrogante == 4)
                {
                    caseNextContinue(16);
                    tagG = "";
                }
                if (optInterrogante == 5)
                {
                    pistaPruebaFinal();
                    tagG = "";
                }
                break;
            case "companion":
                companion();
                tagG = "";
                break;
            case "pisDiagramFlujo":
                imgDiagrama();
                validarButton("butonPistaDiagramFlujo");
                tagG = "";
                break;
            case "ejemDiagramFlujo":
                imageExpleDiagrama();
                validarButton("butonEjemploDiagrama");
                tagG = "";
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// The function is called when the player clicks the exit button on the notebook
    /// </summary>
    public void exitNote()
    {
        panelNotebook.SetActive(false);
        text_title.SetActive(false);
        text_info_note.SetActive(false);
        button_exit.SetActive(false);
        Time.timeScale = 1f;
        pistDiagFlujo.enabled = false;
        iamgenEjempDiagramFlujo.enabled = false;
        buttonStartTwo.SetActive(false);
        buttonStart.SetActive(false);
        enter = false;
    }


    public void logicNote()
    {
        /* A code that is used to display a text in a game. */
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Lógica";
        textInfoNote.text = "Se conoce por lógica, computación o lógica matemática directamente aplicada en el contexto de las ciencias informáticas, aquellos recursos que pueden ser implementados en diferentes niveles como lo son: " +
          "\n\n- Circuitos computacionales " +
          "\n- Programación lógica " +
          "\n- Análisis y optimización de recursos temporales y espaciales (más conocidos en el campo de la ciencia computacional como algoritmos)" +
          "\n\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        activarPistas("Concept");
        desactivarPistas("Logic");
        Time.timeScale = 0f;
        opt = 1;
        plarTeacher.transform.position = new Vector3(350.43f, 165.418f, 259.57f);
        plarTeacher.transform.eulerAngles = new Vector3(0f, -281.874f, 0f);
        plarTeacher.SetActive(false);
        Destroy(obMiniMapTeacherPlar);
    }

    /// <summary>
    /// It's a function that activates a panel, a text, a title, and a button, and then it deactivates
    /// some other things.
    /// </summary>
    public void concepText()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Conceptos";
        textInfoNote.text = "Para iniciar esta travesía es importante tener claros algunos conceptos, los cuales aparecerán en el mapa para que puedas analizarlos."
                               + "\n\nLos conceptos son: \n -Algoritmos \n -Codificación \n -Lenguaje de programación \n -Pseudocódigo \n -Diagrama de flujo";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("Concept");
        /* Activating the hints for the following words*/
        activarPistas("algorit");
        activarPistas("codificacion");
        activarPistas("lenguProgramation");
        activarPistas("pseudocodigo");
        activarPistas("diaFlujo");
    }

    /// <summary>
    /// It sets the active state of some UI elements to false and others to true
    /// </summary>
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

    /// <summary>
    /// It's a function that activates a panel, a text, a title, and a button
    /// </summary>
    public void algorit()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Algoritmo";
        textInfoNote.text = "Un algoritmo informático es un conjunto definido, ordenado y acotado de instrucciones para resolver un problema, realizar un cálculo o realizar una tarea. Es decir; un algoritmo es un proceso paso a paso para llegar a un fin. Partiendo de un estado de información inicial, sigue una secuencia de pasos ordenados para resolver una situación."
                            + "\n\nLos algoritmos se componen de tres partes: " +
                                "\n\t* Input(Entrada) informació�n que se suministra al algoritmo." +
                                "\n\t* Proceso(Paso asignados a partir de la entrada)." +
                                "\n\t* Output(Salida) resultado de la transformación de los datos."
                           + "\nLos cuales son importantes para realizar los pasos y resolver los problemas.  ";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        cont = cont + 1;
        validarNotas(cont);
        desactivarPistas("algorit");
    }

    /// <summary>
    /// This function is used to display a panel with information about the topic "codification"
    /// </summary>
    public void codificacion()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Codificación";
        textInfoNote.text = "En informática, la codificación también es la operación de enviar datos de un lugar a otro, procesarlos y obtener resultados de ellos. Todas las operaciones de la computadora están encriptadas en código binario o en una combinación más o menos compleja de 1 y 0, que siguen apareciendo. \n\nA su vez, ciertas operaciones de la computadora requieren un segundo nivel de encriptación. Son aquellas que requieren aspectos de seguridad y confidencialidad, y por lo tanto, implican la creación de mensajes encriptados que solo pueden ser leídos por cierto tipo de computadoras o por el usuario que los creó, al igual que las contraseñas y los datos personales en las transacciones en línea.";
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
        textInfoNote.text = "Es un lenguaje completo que, a través de una serie de instrucciones, permite a los programadores escribir un conjunto de instrucciones, acciones secuenciales, datos y algoritmos para crear programas que manipulan la física y la lógica de una máquina." +
                            "\n\nGracias a este lenguaje, el programador y la maquina se comunican entre si, lo que permite determinar con precisión aspectos como:" +
                              "\n\t-Que datos debe explotar un determinado software." +
                              "\n\t-Cómo deben almacenarse o transmitirse estos datos." +
                              "\n\t-Acciones tomadas por el software en base a los casos de cambio." +
                              "\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 2;
        cont = cont + 1;
        validarNotas(cont);
        desactivarPistas("lenguProgramation");
    }
    
    /// <summary>
    /// This function is used to show a panel with information about pseudocode
    /// </summary>
    public void pseudocodigo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Pseudocódigo";
        textInfoNote.text = "El pseudocódigo, es una forma de expresar los diferentes pasos que realizará un programa, más similar a un lenguaje de programación. Su principal función es representar la solución de un problema o algoritmo paso a paso de la forma más detallada posible, utilizando un lenguaje cercano a la programación. \n\nEl pseudocódigo no se puede ejecutar en una computadora porque entonces ya no será un pseudocódigo, como sugiere el nombre, es un código de error (pseudo = falso), que es un código escrito para el entendimiento humano, no para la máquina."
                            + "\n\n                                        Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 4;
        desactivarPistas("pseudocodigo");
        cont = cont + 1;
        validarNotas(cont);
    }

    /// <summary>
    /// This function is used to display a text in a panel
    /// </summary>
    public void diaFlujo()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Diagrama de flujos";
        textInfoNote.text = "Un diagrama de flujo se conoce como una representación gráfica de todos los pasos involucrados en un proceso. Por lo tanto, es un diagrama esquemático de la secuencia de operaciones que componen el sistema. Un diagrama de flujo es en pocas palabras, todas las acciones que se relacionan entre sí para conducir a un resultado específico. \n\nEs importante resaltar que un diagrama de flujo es una representación gráfica o visual de un algoritmo que utiliza varios símbolos, formas y líneas para representar el proceso de un programa." +
                             "\n                                           Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 3;
        desactivarPistas("diaFlujo");
        cont = cont + 1;
        validarNotas(cont);
    }

    /// <summary>
    /// This function is used to display a panel with information about the variable type
    /// </summary>
    public void tipovariable()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Tipo Variable";
        textInfoNote.text = "Es un espacio en la memoria de la computadora que permite el almacenamiento temporal de datos durante la ejecución de un proceso, cuyo contenido puede cambiarse durante la ejecución del programa. \n\nLa información puede ser un carácter, una cadena, un número, una matriz y, en general, cualquier otro tipo de dato. Para identificar una variable en la memoria de la computadora, es necesario darle un nombre para que podamos identificarla en el algoritmo."
                            + "\n                                           Pulsa 'X' para continuar....";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 5;
        desactivarPistas("tipovariable");
        activarPistas("trouble");
    }

    /// <summary>
    /// This function is used to display a panel with information about the problem
    /// </summary>
    public void trouble()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Problemas";
        textInfoNote.text = "En el cual se comprende con claridad, cuál es el problema, que debes lograr y planificar una posible solución."
                             + "\n\nLa programación lineal es un método por el cual se optimiza una función objetivo, por maximización o minimización, en el que las variables se elevan a potencias de 1. Ello, teniendo en cuenta las diversas restricciones introducidas." +
                                " Recuerda que este tipo de ecuación es una igualdad matemática que puede tener una o más incógnitas. Entonces tiene la siguiente forma básica, donde (a, b) son constantes, mientras que (x, y) son variables.";
        button_exit.SetActive(true);
        Time.timeScale = 0f;
        opt = 0;
        desactivarPistas("trouble");
        pistaInterrogante.SetActive(true);
        optInterrogante = 2;
    }

    /// <summary>
    /// It's a function that activates a panel, a text, and a title, and it also changes the text of the
    /// title and the text of the panel
    /// </summary>
    void activarPruebas()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textInfoNote.alignment = TextAnchor.UpperCenter;
        opt = 12;
        textTitle.text = "¡FELICIDADES!";
        textInfoNote.text = "¡Felicidades! has llegado al momento de las pruebas!" +
                            "\n\n¡Validemos que tanto aprendiste!" +
                             "\n\n\nPulsa | X | para empezar….";
        Time.timeScale = 0f;
        companionCharacter.SetActive(true);
        plarTeacher.SetActive(true);
        obMiniMapTeacherPlar2.SetActive(true);
        hosti.llaveInt = 2;
        objTeacher.enabled = false;
        optInterrogante = 2;
        caseHom = 0;
    }

    /// <summary>
    /// If the player collides with the companion, the panelNotebook is activated, the text_info_note is
    /// activated, the text_title is activated, the textTitle.text is set to "¡Hola!", the
    /// textInfoNote.text is set to "Soy tu compañero \n\nQueria pedirte el favor que busques al docente
    /// y entregues nuestra tarea para que asi nos pueda calificar.", the Time.timeScale is set to 0f,
    /// the bookHomework is activated, the button_exit is activated, the caseHom is set to 1, and the
    /// companionColl is disabled.
    /// </summary>
    void companion()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "¡Hola!";
        textInfoNote.text = "Soy tu compañero \n\nQueria pedirte el favor que busques al docente y entregues nuestra tarea para que asi nos pueda calificar.";
        Time.timeScale = 0f;
        bookHomework.SetActive(true);
        button_exit.SetActive(true);
        caseHom = 1;
        companionColl.enabled = false;
    }
    
    /// <summary>
    /// The function is called when the player collides with an object, the function checks if the
    /// player has collided with an object with the tag "Tops" and if so, it checks the value of the
    /// variable "option" and depending on the value of "option" it calls the function "calculateLife"
    /// with a string parameter.
    /// 
    /// The function "calculateLife" is as follows:
    /// </summary>
    void personaje()
    {
        ui_manager m = new ui_manager();
        if (sumaTotal == 3)
        {
            imageGameOver.SetActive(true);
            miniMap.SetActive(false);
            optmenuPant = 6;
            StartCoroutine("expectTime");

        }
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
/// <summary>
/// It's a function that takes an integer as a parameter and depending on the value of the integer, it
/// will display a different text in a text box
/// </summary>
/// <param name="opts">This is the parameter that is passed to the function.</param>
    public void caseNextContinue(int opts)
    {
        switch (opts)
        {
            case 1:
                textInfoNote.text = "la lógica computacional, es una disciplina que estudia la aplicación de la lógica formal para representación computacional de parámetros, técnicas de deducción automática o conocimientos básicos asistidos por ordenador relacionados con la validez y la integridad de acuerdo con su complejidad. ";
                break;
            case 2:
                textInfoNote.text = "Para explicar mejor, un lenguaje de programación es un sistema de comunicación estructurado, compuesto por conjuntos de símbolos, palabras clave, reglas semánticas y sintaxis, que permite el entendimiento entre programadores y máquinas." +
                                    "\n\nEstos son algunos ejemplos de lenguajes de programación que podrás encontrar:" +
                                    "\n\t*JavaScript \n\t*Java \n\t*C# \n\t*PHP \n\t*C / C++";
                break;
            case 3:
                textInfoNote.text = "Usando algoritmos, las personas pueden entender fácilmente un programa. El objetivo principal de los diagramas de flujo, es analizar diferentes procesos.\n\n Los procesos se pueden representar mediante cajas y flujos de diferentes tamaños y colores. En un diagrama, podemos resaltar fácilmente un elemento y la relación entre cada parte.";
                break;
            case 4:
                textInfoNote.text = "El pseudocódigo es un método para visualizar una solución detallada de un algoritmo. El término utiliza campos como la informática, las especializaciones en informática y el análisis numérico. Por lo tanto, el pseudocódigo es una forma relativamente simple de representar los diferentes pasos que debe seguir un programa para lograr sus objetivos.";
                break;
            case 5:
                textInfoNote.text = "Estos son los tipos de variables que puedes utilizar: \n\n* Variables numéricas: Variables que almacenan valores numéricos(positivos o negativos), es decir, almacenan números del 0 al 9, signos(+y -) y puntos decimales. \n\n*Variables booleanas: Son variables que pueden contener solo dos valores (verdadero o falso) que muestran el resultado de una comparación entre otros datos. \n\n*Variables Alfanuméricas: incluye caracteres alfabéticos numéricos (letras, números y caracteres especiales).";
                break;
            case 12:
                panelNotebook.SetActive(true);
                text_info_note.SetActive(true);
                text_title.SetActive(true);
                Time.timeScale = 1f;
                textInfoNote.alignment = TextAnchor.UpperLeft;
                textTitle.text = "Prueba de algoritmo";
                hosti.llaveInt = 2;
                textInfoNote.text = "Un compañero te está esperando para entregarte la tarea y la presentes ante el docente, la cual contiene el problema a resolver."
                                    + "\n\nEstos son los pasos para la solución de este problema:"
                                    + "\t\n\n1.) Buscar la tarea en el mapa"
                                    + "\t\t\n2.) Recoger la tarea"
                                    + "\t\t\n3.) Buscar al docente en el mapa para entregar la tarea"
                                    + "\t\t\n4.) Llegar hasta donde él"
                                    + "\t\t\n5.) Dejar tarea con el docente.";
                optInterrogante = 1;
                opt = 12;
                companionColl.enabled = true;
                break;
            case 15:
                bookHomework.SetActive(false);
                imageHomework.SetActive(true);
                enter = false;
                break;
            case 16:
                panelNotebook.SetActive(true);
                text_info_note.SetActive(true);
                text_title.SetActive(true);
                textInfoNote.alignment = TextAnchor.UpperCenter;
                textTitle.text = "Prueba de Diagrama de flujo";
                textInfoNote.text = "\n\n\n\nVeamos cómo se compone un diagrama de flujo, dirígete al restaurante para mostrarte como.";
                activarPistas("pisDiagramFlujo");
                break;
            default:
                opt = 0;
                break;
        }
    }

    /// <summary>
    /// It's a function that waits for a certain amount of time before executing the next line of code
    /// </summary>
    IEnumerator expectTime()
    {
        switch (optmenuPant)
        {
            case 1:
                yield return new WaitForSeconds(3);
                for (int i = 0; i < notasPantalla.LongLength; i++)
                {
                    if (notasPantalla[i].name == "miniMap")
                    {
                        notasPantalla[i].SetActive(true);
                    }
                    yield return new WaitForSeconds(5);
                    Destroy(notasPantalla[i]);
                }
                break;
            case 2:
                yield return new WaitForSeconds(.5f);
                msgS.msg = " ";
                break;
            case 3:
                yield return new WaitForSeconds(5f);
                msgS.msg = " ";
                animatorTeacherTwo.SetBool("idle", true);
                animatorTeacherTwo.SetBool("talking", false);
                caseHom = 0;
                colliderTeacherTwo.enabled = false;
                break;
            case 4:
                yield return new WaitForSeconds(5f);
                msgS.msg = " ";
                animatorTeacherThree.SetBool("Idle", true);
                animatorTeacherThree.SetBool("Talking", false);    
                caseHom = 0;
                //colliderTeacherTwo.enabled = false;
                break;
            case 5:
                yield return new WaitForSeconds(5);
                //SceneManager.LoadScene("SampleScene");
                SceneManager.LoadScene("Juego2D 1");
                break;
            case 6:
                yield return new WaitForSeconds(5);
                //SceneManager.LoadScene("SampleScene");
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }

/// <summary>
/// It's a function that enables a button that has the same name as the string that is passed to it
/// </summary>
/// <param name="optiButton">The name of the button that will be enabled.</param>
    public void validarButton(string optiButton)
    {
        for (int i = 0; i < buttonNotes.LongLength; i++)
        {
            if (buttonNotes[i].name == optiButton)
            {
                buttonNotes[i].enabled = true;
            }
        }
    }

    /// <summary>
    /// It takes a string as a parameter and then loops through an array of GameObjects and activates
    /// the one that matches the string
    /// </summary>
    /// <param name="namePistaA">The name of the track that will be activated.</param>
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
    
   /// <summary>
   /// It takes a string as a parameter and then loops through an array of GameObjects and if the name
   /// of the GameObject is equal to the string passed in as a parameter, it sets the GameObject to
   /// inactive
   /// </summary>
   /// <param name="namePistaD">The name of the track that will be disabled.</param>
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

/// <summary>
/// It checks if the user has clicked on the correct notes 5 times, and if so, it activates the
/// "tipovariable" hint
/// </summary>
/// <param name="contador">is the number of times the user has clicked on the button</param>
    public void validarNotas(int contador)
    {
        if (contador == 5)
        {
            activarPistas("tipovariable");
        }
    }

/* Checking if the life is equal to the string life. If it is, it will set the life to false. */
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
    /// <summary>
    /// If the player is in the trigger, then display the message
    /// </summary>
    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;
        if (enter == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), msg, style);
        }
    }

/// <summary>
/// It sets the active state of the prueba2d object to true, sets the enter variable to false, sets the
/// time scale to 0, sets the active state of the panelNotebook object to false, sets the active state
/// of the text_info_note object to false, sets the active state of the text_title object to false, sets
/// the active state of the buttonStart object to false, sets the optInterrogante variable to 4, and
/// sets the enabled state of the colliderTeacherTwo object to false
/// </summary>
    public void button_active()
    {
        prueba2d.SetActive(true);
        enter = false;
        Time.timeScale = 0f;
        panelNotebook.SetActive(false);
        text_info_note.SetActive(false);
        text_title.SetActive(false);
        buttonStart.SetActive(false);
        optInterrogante = 4;
        colliderTeacherTwo.enabled = false;
    }

/// <summary>
/// It loads the scene "Juego2D 1" and disables the following objects: panelNotebook, text_info_note,
/// text_title, buttonStart, miniMap, miniMenu, button_exit, buttonStartTwo.
/// </summary>
    public void button_active_final()
    {
        SceneManager.LoadScene("Juego2D 1");
        //pruebaFinal2d.SetActive(true);
        Time.timeScale = 0f;
        panelNotebook.SetActive(false);
        text_info_note.SetActive(false);
        text_title.SetActive(false);
        buttonStart.SetActive(false);
        miniMap.SetActive(false);
        miniMenu.SetActive(false);
        button_exit.SetActive(false);
        buttonStartTwo.SetActive(false);
    }

    /// <summary>
    /// This function is called when the user clicks on the image of the diagram of the flowchart
    /// </summary>
    public void imgDiagrama()
    {
        pistDiagFlujo.enabled = true;
        button_exit.SetActive(true);
        desactivarPistas("pisDiagramFlujo");
        optInterrogante = 3;
        opt = 0;
        tags = "";
    }

    /// <summary>
    /// This function is used to activate the image of the example diagram of flow, the text of the
    /// title, the text of the information, the button to exit and the panel of the notebook
    /// </summary>
    public void activarExampleDiagrama()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        button_exit.SetActive(true);
        textTitle.text = "Ejemplo";
        textInfoNote.alignment = TextAnchor.UpperCenter;
        textInfoNote.text = "¡En el salón de secretaria encontraras un ejemplo de un diagrama de flujo, repásalo bien se aproxima la prueba!."; 
        iamgenEjempDiagramFlujo.enabled = true;
        Time.timeScale = 0f;
        opt = 0;
        activarPistas("ejemDiagramFlujo");
    }

    /// <summary>
    /// This function is used to display the image of the diagram of the flow of the game
    /// </summary>
    public void imageExpleDiagrama()
    {
        iamgenEjempDiagramFlujo.enabled = true;
        button_exit.SetActive(true);
        desactivarPistas("ejemDiagramFlujo");
        optInterrogante = 5;
        opt = 0;
        Time.timeScale = 0f;
        teacherGameOver.SetActive(true);
        imagenFinalGameOver.SetActive(true);
        tags = "";
    }
    /// <summary>
    /// It's a function that activates a panel, a text, a title, and a button.
    /// </summary>
    public void pistaPruebaFinal()
    {
        panelNotebook.SetActive(true);
        text_info_note.SetActive(true);
        text_title.SetActive(true);
        textTitle.text = "Prueba Final";
        textInfoNote.alignment = TextAnchor.UpperCenter;
        textInfoNote.text = "¡En el Aula Multiple te espera el docente con la pista para la prueba final \n\n -CORRE-!.";
        button_exit.SetActive(true);
        opt = 0;
    }
}

