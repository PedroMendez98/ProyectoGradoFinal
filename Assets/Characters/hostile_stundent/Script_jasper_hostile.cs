using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_jasper_hostile : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        if (llave == true)
        {
            teacherStatic();
        }
        if (llave == false)
        {
            teacherMove();
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
            //panel.SetActive(true);
            //textWelcome.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            llave = false;
            time = 0;
            timeRest = 5;
        }
    }
    void teacherStatic()
    {
        //distance = 0;
        teacher.angularSpeed = 120f;
        timeTrans += Time.deltaTime;
        time = Mathf.RoundToInt(timeTrans);

        if (time == timeRest)
        {
            nextPoint = Random.Range(0, lastPoint);
            teacherAnimator.SetBool("Walk", true);
            teacherAnimator.SetBool("Idle", false);
            teacherAnimator.SetBool("Speak", false);
            teacher.destination = jugador2.position;
            timeTrans = 0;
            time = 0;
        }
        distance = Mathf.RoundToInt(Vector3.Distance(transform.position, jugador2.position));
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
            teacher.destination = jugador2.position;
        }
    }
}
