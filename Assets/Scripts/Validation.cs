using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "item")
        {

            Debug.Log("ItemIngresa");

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "item")
        {

            Debug.Log("ItemSale");

        }
    }
}
