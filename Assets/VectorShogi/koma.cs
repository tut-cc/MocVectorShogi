using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class koma : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector3 mouseDiff;
    private CanvasGroup myGroup;
    private PhotonView photonView;

    // Use this for initialization
    void Start()
    {
        myGroup = transform.parent.GetComponent<CanvasGroup>();
        photonView = transform.GetComponent<PhotonView>();
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
        photonView.RequestOwnership();
        myGroup.blocksRaycasts = false;
    }    
}