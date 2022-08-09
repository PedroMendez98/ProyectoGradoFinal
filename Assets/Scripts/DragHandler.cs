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

    /// <summary>
    /// The Start function is called when the game starts. It gets the canvas group component and the
    /// item dragger parent transform
    /// </summary>
    private void Start() 
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
    }

    /// <summary>
    /// When the user begins dragging the object, we set the objectBeingDragged to the current object,
    /// set the startPosition to the current position of the object, set the startParent to the current
    /// parent of the object, set the parent of the object to the itemDraggerParent, and set the
    /// canvasGroup.blocksRaycasts to false.
    /// </summary>
    /// <param name="PointerEventData">This is the data that is passed to the event.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        objBeingDraged = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(itemDraggerParent);
        canvasGroup.blocksRaycasts = false;
    }

   
    /// <summary>
    /// OnDrag is a function that is called when the user drags the object
    /// </summary>
    /// <param name="PointerEventData">This is the data that is passed to the event.</param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// If the object being dragged is not null, then set the object being dragged to null, set the
    /// canvas group to block raycasts, and if the object being dragged is a child of the item dragger
    /// parent, then set the object's position to the start position and set the object's parent to the
    /// start parent
    /// </summary>
    /// <param name="PointerEventData">This is the data that is passed to the event.</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        objBeingDraged = null;

        canvasGroup.blocksRaycasts = true;
        if (transform.parent == itemDraggerParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    private void Update()
    {
    }

    /// <summary>
    /// If the variable "cont" is true, then the variable "n" is increased by 1, the variable "vali" is
    /// set to " ", and the object "objetos" is set to active
    /// </summary>
    public void sumarN()
    {
        if (cont == true)
        {
            n = n + 1;
            DropSlot.vali = " ";
            objetos.SetActive(true);
        }
    }
}