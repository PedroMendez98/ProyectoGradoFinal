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
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WayPoint")
        {
            nextPoint = Random.Range(0, lastPoint);
            brian.destination = wayPoint[nextPoint].position;
        }
    }
}
