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

    public int cases;

    private void Start()
    {
        boxN = new string[comboxNum.LongLength];
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            item = DragHandler.objBeingDraged;
            item.transform.SetParent (transform);
            item.transform.position = transform.position;

            Debug.Log("objbox " + gameObject.name);
            switch (gameObject.name)
            {
                case "inicio":
                    valiItemActi("inicioI1", item);
                    break;
                case "entrada":
                    valiItemActi("valorI4", item);
                    break;
                case "desicion2":
                    if (DragHandler1.val == 1)
                    {
                        valiItemActi("valI3", item);
                    }
                    else if (DragHandler1.val == 2)
                    {
                        valiItemActi("valI2", item);
                    }
                    break;
                case "decision":
                    if (item.gameObject.name == "valI2")
                    {
                        valiItemActi("valI2", item);
                        DragHandler1.val = 1;
                    }
                    if (item.gameObject.name == "valI3")
                    {
                        valiItemActi("valI3", item);
                        DragHandler1.val = 2;
                    }
                    break;
                case "afirmativa2":
                    if (DragHandler1.val == 1)
                    {
                        valiItemActi("impreI6", item);
                    }
                    else if (DragHandler1.val == 2)
                    {
                        valiItemActi("impreI7", item);
                    }
                    break;
                case "afirmativa":
                    if (DragHandler1.val == 1)
                    {
                        valiItemActi("impreI7", item);
                    }
                    else if (DragHandler1.val == 2)
                    {
                        valiItemActi("impreI6", item);
                    }
                    break; 
                case "negativa":
                    valiItemActi("impreI8", item);
                    break;     
                case "fin":
                    valiItemActi("finI5", item);
                    break;
                default:
                    break;
            }

            if (
                gameObject.name == "SlotA1" ||
                gameObject.name == "SlotA2" ||
                gameObject.name == "SlotA3"
            )
            {
                if (item.gameObject.tag == "ItemA")
                {
                    gameObject.SetActive(false);
                }
            }
            if (
                gameObject.name == "SlotB1" ||
                gameObject.name == "SlotB2" ||
                gameObject.name == "SlotB3"
            )
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

    void valiItemActi(string itemActi, GameObject obj)
    {
        GameObject i = obj;
        if (i.gameObject.name == itemActi)
        {
            DragHandler1.cont = itemActi;
            gameObject.SetActive(false);
        }
    }
}
