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
            Debug.Log(gameObject.name);
            Validation v = new Validation();
            if (gameObject.name == "SlotN1" || gameObject.name == "SlotN2" || gameObject.name == "SlotN3")
            {
                if (item.gameObject.tag == "ItemN")
                {
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

