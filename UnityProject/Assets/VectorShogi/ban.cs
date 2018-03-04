using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ban : MonoBehaviour,IDropHandler,IEndDragHandler {
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        eventData.pointerDrag.transform.position = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
    }
}
