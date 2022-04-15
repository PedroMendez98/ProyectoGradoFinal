using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
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
        canvasGroup = GetComponent<CanvasGroup>();
        itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
    }

    #region DragFunctions

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        objBeingDraged = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(itemDraggerParent);
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        objBeingDraged = null;

        canvasGroup.blocksRaycasts = true;
        if (transform.parent == itemDraggerParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    #endregion

    private void Update()
    {
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
