using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class script_character_secundario: MonoBehaviour
{
    public Transform target;
    private NavMeshAgent brian;
    public Transform[] wayPoint;
    private int nextPoint;
    private int lastPoint;

    // Start is called before the first frame update
    void Start()
    {
        lastPoint = wayPoint.Length;
        brian = GetComponent<NavMeshAgent>();
        nextPoint = Random.Range(0, lastPoint);
        brian.destination = wayPoint[nextPoint].position;
        // transform.LookAt(new Vector3(target.position.x, transform.position.x, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
        //print("destination" + brian.destination);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WayPoint")
        {
            print("tagBrian: " + other.tag);
            nextPoint = Random.Range(0, lastPoint);
            brian.destination = wayPoint[nextPoint].position;
            //target = other.gameObject.GetComponent<WayPoint>().nextPoint;
            //brian.destination = wayPoint[nextPoint].position;
            //transform.LookAt(new Vector3(target.position.x, transform.position.x, target.position.z));
        }
    }
}
