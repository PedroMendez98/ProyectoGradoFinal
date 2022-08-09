using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPool : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// If the object being dragged is not null, then set the parent of the object being dragged to the
    /// object that the script is attached to
    /// </summary>
    /// <param name="PointerEventData">This is the data that is passed to the event.</param>
    /// <returns>
    /// The object being dragged.
    /// </returns>
    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandler.objBeingDraged == null) return;
        DragHandler.objBeingDraged.transform.SetParent(transform);
        
    }
}
