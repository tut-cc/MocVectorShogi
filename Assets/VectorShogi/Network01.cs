using UnityEngine;
using System.Collections;

public class Network01 : MonoBehaviour
{
    private string roomName = "";

    public void SetRoomName(string roomName)
    {
        this.roomName = roomName;
    }
    public void JoinRoom()
    {
        roomName = roomName.Length == 0 ? "default" : roomName;
        // ルームに入室する
        PhotonNetwork.JoinRoom(roomName);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void Start()
    {
        // Photonに接続する(引数でゲームのバージョンを指定できる)
        PhotonNetwork.ConnectUsingSettings(null);        
    }
    void OnConnectedToMaster()
    {
        Debug.Log("接続しました。");

        PhotonNetwork.JoinLobby();
    }

    // ロビーに入ると呼ばれる
    void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました。");

    }

    // ルームに入室すると呼ばれる
    void OnJoinedRoom()
    {
        Debug.Log("ルームへ入室しました。");
    }

    // ルームの入室に失敗すると呼ばれる
    void OnPhotonJoinRoomFailed()
    {
        Debug.Log("ルームの入室に失敗しました。");

        // ルームがないと入室に失敗するため、その時は自分で作る
        // 引数でルーム名を指定できる
        PhotonNetwork.CreateRoom(roomName);
    }
}