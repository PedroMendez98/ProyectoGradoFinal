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

    /// <summary>
    /// If the player collides with the object, the boolean variable llave is set to true and the
    /// teacherStatic() function is called
    /// </summary>
    /// <param name="Collider">The collider that is entered.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            llave = true;
            teacherStatic();
 
        }
    }
    /// <summary>
    /// If the player leaves the trigger area, the boolean variable llave is set to false
    /// </summary>
    /// <param name="Collider">The collider that is used to detect the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            llave = false;
        }
    }
    /// <summary>
    /// "If the teacher is not sitting, then set the teacher's idle animation to false."
    /// 
    /// The above function is called in the Update() function.
    /// </summary>
    void teacherStatic()
    {
            teacherAnimator.SetBool("idle", false);
            teacherAnimator.SetBool("sitting", false);
    }
    /// <summary>
    /// If the teacher is sitting, then set the teacher's animation to idle.
    /// </summary>
    void teacherMove()
    {

            teacherAnimator.SetBool("sitting", true);
            teacherAnimator.SetBool("idle", false);
    }


    void OnGUI()
    {
        style.fontSize = 25;
        style.font = ScoreFont;
        /* Displaying the message "F" Hablar on the screen. */
        if (llave)
        {
            StartCoroutine("expectTime");
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), msg , style);
        }
    }

    /// <summary>
    /// The function waits for 3 seconds and then sets the msg variable to an empty string
    /// </summary>
    IEnumerator expectTime()
    {
         yield return new WaitForSeconds(3f);
         msg = " ";
    }
}
