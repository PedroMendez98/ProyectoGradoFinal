using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler1 : MonoBehaviour
{
    public static GameObject objBeingDraged;

    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private Transform itemDraggerParent;
    public int n = 0;
    public static bool cont;
    public GameObject objetos;

    private void Start() 
    {

    }

    private void Update()
    {
        Debug.Log("cuenta: " + cont);
        sumarN();
    }
    public void sumarN()
    {
        if (cont == true)
        {
            n = n + 1;
            Debug.Log("N" + n);
            DropSlot.vali = " ";
            objetos.SetActive(true);
        }
        
    }
}
