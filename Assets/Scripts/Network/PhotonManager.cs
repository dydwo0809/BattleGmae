using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string version = "1.0f";
    private string userID = "tmpName";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userID;

        // �ʴ� 30ȸ ���;���
        Debug.Log(PhotonNetwork.SendRate);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���� ����");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� ����");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"���� �� ���� ���� {returnCode} : {message}");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;
        ro.IsVisible = true;

        PhotonNetwork.CreateRoom("My Room", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("�� ���� �Ϸ�");
        Debug.Log($"�� �̸� = {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"�� ���� ���� ���� = {PhotonNetwork.InRoom}");
        Debug.Log($"���� �÷��̾� �ο��� : {PhotonNetwork.CurrentRoom.PlayerCount}");

        Debug.Log("���� ���� ���� ����");
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
