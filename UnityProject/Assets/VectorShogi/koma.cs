using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class koma : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector3 mouseDiff;
    private CanvasGroup myGroup;
    private PhotonView photonView;
    private bool isDraging = false;
    private static Transform root = null;
    private static readonly Quaternion Reverce = Quaternion.Euler(0, 0, 180);
    public static Sprite initSprite = null;

    // Use this for initialization
    void Start()
    {
        if (root == null) { root = GameObject.Find("komaRoot").transform; }
        transform.parent = root;

        if (initSprite != null) { gameObject.GetComponent<Image>().sprite = initSprite; }

        myGroup = transform.parent.GetComponent<CanvasGroup>();
        photonView = transform.GetComponent<PhotonView>();
    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Reverce") && isDraging)
        {
            transform.rotation = transform.rotation * koma.Reverce;
        }
        if (Input.GetButtonDown("Destroy") && isDraging)
        {
            myGroup.blocksRaycasts = true;
            PhotonNetwork.Destroy(this.photonView);
        }

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
        isDraging = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var pos = Input.mousePosition;
        mouseDiff = transform.position - Camera.main.ScreenToWorldPoint(pos);
        transform.SetAsLastSibling();
        photonView.RequestOwnership();
        myGroup.blocksRaycasts = false;
        isDraging = true;
    }    
}