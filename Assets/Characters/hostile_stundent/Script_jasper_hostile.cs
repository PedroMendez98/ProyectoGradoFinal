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

    /// <summary>
    /// If the player collides with the object, the player will rotate to the position of the object and
    /// the teacher will be static
    /// </summary>
    /// <param name="Collider">The collider that is entered.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rota = jugador2.position;
            jugador.Rotate(rota);
            llave = true;
            teacherStatic();
        }
    }
    /// <summary>
    /// If the player leaves the trigger, the key is set to false, the time is set to 0, and the
    /// timeRest is set to 5
    /// </summary>
    /// <param name="Collider">The collider that is used to detect the player.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            llave = false;
            time = 0;
            timeRest = 5;
        }
    }
    /// <summary>
    /// "If the time is equal to the timeRest, then the nextPoint is equal to a random number between 0
    /// and lastPoint, then the teacherAnimator is set to true, then the teacherAnimator is set to
    /// false, then the teacherAnimator is set to false, then the teacher destination is equal to the
    /// jugador2 position, then the timeTrans is equal to 0, then the time is equal to 0."
    /// </code>
    /// </summary>
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
    /// <summary>
    /// "If the time is equal to the timeRest, then the nextPoint is equal to a random number between 0
    /// and lastPoint, then the teacherAnimator is set to true, then the teacherAnimator is set to
    /// false, then the teacherAnimator is set to false, then the teacher's destination is equal to the
    /// wayPoints[nextPoint].position, then the timeTrans is equal to 0, then the time is equal to 0."
    /// </code>
    /// </summary>
    public void teacherMove()
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
