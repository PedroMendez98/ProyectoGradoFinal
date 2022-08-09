using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class script_teacher_one : MonoBehaviour
{
    public Transform[] wayPoints;
    public int time;
    public int timeRest;
    public Transform target;
    public Transform detect;
    private float timeTrans;
    private int nextPoint;
    private int lastPoint;
    private NavMeshAgent teacher;
    private Animator teacherAnimator;
    GUIStyle style;
    int distance;
    bool llave;
    public Transform jugador;
    public Transform jugador2;
    public Vector3 rota;
    public GameObject panel;
    public GameObject textWelcome;
    bool enter;
    public Font ScoreFont;
    public int llaveInt;

    /// <summary>
    /// The Awake function is called when the script instance is being loaded. Awake is used to
    /// initialize any variables or game state before the game starts. Awake is called only once during
    /// the lifetime of the script instance. Awake is called after all objects are initialized so you
    /// can safely speak to other objects or query them using for example GameObject.FindWithTag. Each
    /// GameObject's Awake is called in a random order between objects. Because of this, you should use
    /// Awake to set up references between scripts, and use Start to pass any information back and
    /// forth. Awake is always called before any Start functions. This allows you to order
    /// initialization of scripts. Awake can not act as a coroutine
    /// </summary>
    private void Awake()
    {
        teacher = GetComponent<NavMeshAgent>();
        teacherAnimator = GetComponent<Animator>();
        lastPoint = wayPoints.Length;
        style = new GUIStyle();
    }
    // Start is called before the first frame update
    void Start()
    {
        llaveInt = 1;
        llave = false;
        panel.SetActive(false);
        textWelcome.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (llaveInt == 0)
        {
            teacherStatic();
        }
        if (llaveInt == 1)
        {
            teacherMove();
        }
        if (llaveInt == 2)
        {
            teacherMove_2();
        }
    }

    /// <summary>
    /// If the player enters the trigger, the teacher will rotate to face the player, the key will be
    /// set to true, the enter variable will be set to true, and the teacherStatic function will be
    /// called
    /// </summary>
    /// <param name="Collider">The collider that is entered.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rota = jugador2.position;
            jugador.Rotate(rota);
            llave = true;
            enter = true;
            teacherStatic();
           
        }
    }
    /// <summary>
    /// If the player leaves the trigger area, the key is set to false, the time is set to 0, the
    /// timeRest is set to 5, the enter is set to false, the panel is set to false and the textWelcome
    /// is set to false
    /// </summary>
    /// <param name="Collider">The collider that is used to detect the player.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            llave = false;
            time = 0;
            timeRest = 5;
            enter = false;
            panel.SetActive(false);
            textWelcome.SetActive(false);
            
        }
    }
    /// <summary>
    /// If the teacher's destination is the player's position, then the teacher's angular speed is 0.
    /// </summary>
    void teacherStatic()
    {
        distance = 0;
        teacherAnimator.SetBool("Walk", false);
        teacherAnimator.SetBool("Idle", false);
        teacherAnimator.SetBool("Speak", true);
        teacher.destination = jugador.position;

        if(teacher.destination == jugador.position)
        {
            timeRest = 0;
            teacher.angularSpeed = 0f;
        }
        llaveInt = 2;
    }
    /// <summary>
    /// The teacher moves to a random point, then when it reaches that point, it moves to the player.
    /// </summary>
    void teacherMove()
    {
        teacher.angularSpeed = 120f;
        timeTrans += Time.deltaTime;
        time = Mathf.RoundToInt(timeTrans);

        if (time == timeRest)
        {
            nextPoint = Random.Range(0, lastPoint);
            teacherAnimator.SetBool("Walk", true);
            teacherAnimator.SetBool("Idle", false);
            teacherAnimator.SetBool("Speak", false);
            ///teacher.destination = wayPoints[nextPoint].position;
            teacher.SetDestination(wayPoints[nextPoint].position);
            timeTrans = 0;
            time = 0;
        }
        distance = Mathf.RoundToInt(Vector3.Distance(transform.position, wayPoints[nextPoint].position));
        if (distance == 0)
        {
            teacherAnimator.SetBool("Walk", false);
            teacherAnimator.SetBool("Idle", false);
            teacherAnimator.SetBool("Speak", true);
            teacher.destination = jugador.position;
        }
    }
    /// <summary>
    /// If the player is within a certain distance of the professor, the text "F" will appear on the
    /// screen. 
    /// 
    /// The first thing we do is create a new GUIStyle object called style. This is the style that we
    /// will use to display the text. We then set the font size to 25 and the font to the ScoreFont
    /// object we created earlier. 
    /// 
    /// Next, we check if the player is within a certain distance of the professor. If they are, we
    /// display the text "F" on the screen. 
    /// 
    /// The GUI.Label function is used to display text on the screen. The first parameter is the
    /// position of the text. The second parameter is the text itself. The third parameter is the style
    /// of the text. 
    /// 
    /// The position of the text is determined by the Rect function. The Rect function takes four
    /// parameters: the x position, the y position, the width
    /// </summary>
    void OnGUI()
    {
         style.fontSize = 25;
         style.font = ScoreFont;
         if (enter)
         {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Hablar con el Profe!", style);
         }
    }
    /// <summary>
    /// If the teacher is not walking, then make him speak.
    /// </summary>
    public void teacherMove_2()
    {
        teacherAnimator.SetBool("Walk", false);
        teacherAnimator.SetBool("Idle", false);
        teacherAnimator.SetBool("Speak", true);
    }
}

