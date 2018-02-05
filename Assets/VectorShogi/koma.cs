using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class koma : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector3 mouseDiff;
    private CanvasGroup myGroup;

    // Use this for initialization
    void Start()
    {
        myGroup = transform.parent.GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + mouseDiff;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        myGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseDiff = transform.position - Input.mousePosition;
        transform.SetAsLastSibling();

        myGroup.blocksRaycasts = false;
    }

}