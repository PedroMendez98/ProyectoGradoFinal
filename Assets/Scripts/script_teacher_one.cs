using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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


    private void Awake()
    {
        teacher = GetComponent<NavMeshAgent>();
        teacherAnimator = GetComponent<Animator>();
        lastPoint = wayPoints.Length;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move_teacher();
        playerDetected();
    }          
    
    //Mover Teacher
    void move_teacher()
    {
        timeTrans += Time.deltaTime;
        time = Mathf.RoundToInt(timeTrans);

        if (time == timeRest)
        {
            nextPoint = Random.Range(0, lastPoint);
            teacher.destination = wayPoints[nextPoint].position;
            timeTrans = 0;
            time = 0;
            teacherAnimator.SetBool("Walk", true);
        }
        int distance = Mathf.RoundToInt(Vector3.Distance(transform.position, wayPoints[nextPoint].position));

        if (distance == 0)
        {
            teacherAnimator.SetBool("Walk", false);
        }
    }
    void playerDetected()
    {
        detect.LookAt(target);
        Vector3 fwd = detect.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(detect.position, fwd,out hit, 5f) && hit.collider.CompareTag("Player"))
        {
            teacher.isStopped = true;
            transform.LookAt(target);
            teacherAnimator.SetBool("Walk", false);
            teacherAnimator.SetBool("Idle", true);
        }
        else
        {
            teacher.isStopped = false;
            teacherAnimator.SetBool("Idle", false);
        }
    }
}
