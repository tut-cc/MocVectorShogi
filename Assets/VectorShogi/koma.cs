using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class koma : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector3 mouseDiff;
    private CanvasGroup myGroup;
    private PhotonView photonView;
    private static Transform root = null;

    void Awake()
    {
        if(root == null) { root = transform.parent; }
        transform.parent = root;
    }

    // Use this for initialization
    void Start()
    {
        myGroup = transform.parent.GetComponent<CanvasGroup>();
        photonView = transform.GetComponent<PhotonView>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pos = Input.mousePosition;
        pos.z = 300.0f;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        myGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var pos = Input.mousePosition;
        mouseDiff = transform.position - Camera.main.ScreenToWorldPoint(pos);
        transform.SetAsLastSibling();
        photonView.RequestOwnership();
        myGroup.blocksRaycasts = false;
    }    
}