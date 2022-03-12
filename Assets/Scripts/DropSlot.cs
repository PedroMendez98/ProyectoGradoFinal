using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public Collider2D col;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        
        if (!item)
        {
            item = DragHandler.objBeingDraged;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
            if (item.gameObject.tag == "item")
            {
                Debug.Log("Ingresa");


            }
            else
            {
                Debug.Log("No Ingresa");
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
