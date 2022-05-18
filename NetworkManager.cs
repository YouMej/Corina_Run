using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public static NetworkManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master Done");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        //CreateRoom("Game");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected To Master Done");
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Game",ro,TypedLobby.Default);
        
    }

    

    public override void OnJoinedRoom()
    {
        Debug.Log("Join Room Done");
        LoadScene(1);
    }

    public void LoadScene (int SceneIndex)
    {
        PhotonNetwork.LoadLevel(SceneIndex);
    }
}
