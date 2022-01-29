using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detected2D : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("impreso");
        if (collision.CompareTag("Esfera"))
        {
            Debug.Log("impreso");
        }
    }
}
