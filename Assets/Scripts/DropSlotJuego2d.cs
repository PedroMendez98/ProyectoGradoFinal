using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlotJuego2d : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public string[] boxN;
    public GameObject[] comboxNum;
    public GameObject[] comboxAlf;
    public GameObject[] comboxBool;
    public int cont;
    public int tam;
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
            Validation v = new Validation();
            /* This is checking if the gameObject name is equal to SlotN1 or SlotN2 or SlotN3 and if
            the item gameObject tag is equal to ItemN then the gameObject is set to inactive. */
            if (gameObject.name == "SlotN1" || gameObject.name == "SlotN2" || gameObject.name == "SlotN3")
            {
                if (item.gameObject.tag == "ItemN")
                {
                    gameObject.SetActive(false);
                }
            }
            /* This is checking if the gameObject name is equal to SlotA1 or SlotA2 or SlotA3 and if
                        the item gameObject tag is equal to ItemA then the gameObject is set to
            inactive. */
            if (gameObject.name == "SlotA1" || gameObject.name == "SlotA2" || gameObject.name == "SlotA3")
            {
                if (item.gameObject.tag == "ItemA")
                {
                    gameObject.SetActive(false);
                }
            }
            /* This is checking if the gameObject name is equal to SlotB1 or SlotB2 or SlotB3 and if
                                    the item gameObject tag is equal to ItemB then the gameObject is
            set to
                        inactive. */
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
        /* This is checking if the item is not null and if the item transform parent is not equal to
        the transform then the item is set to null. */
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }

}