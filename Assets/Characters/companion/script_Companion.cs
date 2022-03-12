using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class script_Companion : MonoBehaviour
{
    public Transform target;
    public Transform detect;
    private int nextPoint;
    private NavMeshAgent teacher;
    private Animator teacherAnimator;
    GUIStyle style;
    int distance;
    bool llave;
    public Font ScoreFont;
    public string msg;

    public Vector3 rota;

    private void Awake()
    {
        teacher = GetComponent<NavMeshAgent>();
        teacherAnimator = GetComponent<Animator>();
        style = new GUIStyle();
    }
    // Start is called before the first frame update
    void Start()
    {
        msg = "'F' Hablar";
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
           
            llave = true;
            teacherStatic();
 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            llave = false;
        }
    }
    void teacherStatic()
    {
            teacherAnimator.SetBool("idle", false);
            teacherAnimator.SetBool("sitting", false);
    }
    void teacherMove()
    {

            teacherAnimator.SetBool("sitting", true);
            teacherAnimator.SetBool("idle", false);        
    }
    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;
        if (llave)
        {
            StartCoroutine("expectTime");
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), msg , style);
        }
    }
    IEnumerator expectTime()
    {

         yield return new WaitForSeconds(3f);
         msg = " ";


    }
}
