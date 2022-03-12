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
    public int llaveInt = 0;

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
        llave = false;
        panel.SetActive(false);
        textWelcome.SetActive(false);
        llaveInt = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rota = jugador2.position;
            jugador.Rotate(rota);
            llave = true;
            teacherStatic();
            enter = true;
            //panel.SetActive(true);
            //textWelcome.SetActive(true);
            llaveInt = 1;
        }
    }
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
        
    }
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
            teacher.destination = wayPoints[nextPoint].position;
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
    void OnGUI()
    {
         style.fontSize = 25;
         style.font = ScoreFont;
         if (enter)
         {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), "'F' Hablar con el Profe!", style);
         }
    }
    public void teacherMove_2()
    {

        teacherAnimator.SetBool("Walk", false);
        teacherAnimator.SetBool("Idle", false);
        teacherAnimator.SetBool("Speak", true);

    }
}

