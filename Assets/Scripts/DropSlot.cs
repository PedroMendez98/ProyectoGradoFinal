using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject item1;

    public string[] boxN;

    public GameObject[] comboxNum;

    public GameObject[] comboxAlf;

    public GameObject[] comboxBool;

    public int cont;

    public int tam;

    public int contador;

    public static string vali;

    public GameObject objtos;

    public int cases;

    private void Start()
    {
        boxN = new string[comboxNum.LongLength];
        gameObject.SetActive(true);
        item = item1;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            item = DragHandler.objBeingDraged;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;

            /* A switch case that is used to validate the name of the gameObject and the name of the
            item that is being dragged. */
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
        }
    }

    private void Update()
    {
        /* This is checking if the item is not null and if the item's parent is not the transform of
        the object. If it is, it will set the item to null. */
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }

    /// <summary>
    /// This function is used to validate the item that is being dragged and dropped
    /// </summary>
    /// <param name="itemActi">The name of the item that is being dragged.</param>
    /// <param name="GameObject">The object that you want to be able to drag.</param>
    void valiItemActi(string itemActi, GameObject obj)
    {
        GameObject i = obj;
        if (i.gameObject.name == itemActi)
        {
            DragHandler1.cont = itemActi;
            gameObject.SetActive(false);
            ValidationFinal.cont += 1;
        }
    }
}
