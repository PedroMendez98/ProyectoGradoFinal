using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class dragControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public Image image;
    public bool pressed;
    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<Image>(); 
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
 
    }
}
