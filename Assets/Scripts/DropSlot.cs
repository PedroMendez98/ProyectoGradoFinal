using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item; 
    public string[] boxN;
    public GameObject[] comboxNum;
    public GameObject[] comboxAlf;
    public GameObject[] comboxBool;
    public int cont;
    public int tam;
    public string tag;
    public int contador;
    public static string vali;
    public GameObject objtos;


    private void Start()
    {
        boxN = new string[comboxNum.LongLength];
    }
    public void OnDrop(PointerEventData eventData)
    {

        if (!item)
        {
            item = DragHandler.objBeingDraged;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
           
            
            if (gameObject.name == "inicio")
            {  
                if (item.gameObject.name == "ItemA1")
                {
                    DragHandler1.cont = true;
                    gameObject.SetActive(false);
                    
                }
            }
            if (gameObject.name == "SlotA1" || gameObject.name == "SlotA2" || gameObject.name == "SlotA3")
            {
                if (item.gameObject.tag == "ItemA")
                {
                    gameObject.SetActive(false);
                }
            }
            if (gameObject.name == "SlotB1" || gameObject.name == "SlotB2" || gameObject.name == "SlotB3")
            {
                if (item.gameObject.tag == "ItemB")
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
        }
    }
    
}

