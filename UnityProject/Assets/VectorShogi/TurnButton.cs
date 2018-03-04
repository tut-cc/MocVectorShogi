using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnButton : MonoBehaviour {
    public Image img;
    public Sprite tSprite;
    public Sprite fSprite;
    public PhotonView photonView;
    private bool turn = false;

    public void ChangeTurn()
    {
        photonView.RequestOwnership();
        turn = !turn;
    }

    public void Update()
    {
        img.sprite = turn ? tSprite : fSprite;
    }

    void OnPhotonSerializeView(PhotonStream i_stream, PhotonMessageInfo i_info)
    {
        if (i_stream.isWriting)
        {
            //データの送信
            i_stream.SendNext(turn);
        }
        else
        {
            //データの受信
            bool t = (bool)i_stream.ReceiveNext();
            turn = t;
        }
    }
}
