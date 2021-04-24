using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Random = UnityEngine.Random;

public class Launch : MonoBehaviourPunCallbacks
{   
    //create an instance for launch
    public static Launch Instance;

    private void Awake()
    {
        Instance=this;
    }


    [SerializeField] private TMP_InputField RoomNameField;
    [SerializeField] private TMP_Text roomNameText;
    [SerializeField] private TMP_Text errorText;
    void Start()
    {
        //connecting photon with a master service using setting (eu)    
        PhotonNetwork.ConnectUsingSettings();
    }
    
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected with master    ");
        //When actually connected to master server, join to lobby to find or create a room
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
 
    }
    
    
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
        //Joined to Looby and give a random name to the player
        PhotonNetwork.NickName = "Player " + Random.Range(0, 100).ToString("0000"); 
    }
    
    //Create the Room
    public void CreateRoom()
    {
        //If the user hasn't give a name, then return
        if(string.IsNullOrEmpty(RoomNameField.text)) return;
        
        //Read the name of room and Create a room
        PhotonNetwork.CreateRoom(RoomNameField.text);
     
    }
    
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("second menu");
    }
    
    //If created room failed then activate an error panel
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room creation failed " + message;
        MenuManager.instance.OpenMenu("error");
    }
    
    public override void OnJoinedRoom()
    {
        MenuManager.instance.OpenMenu("room lobby");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        

        /*
        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);

        }
        */
        
        //startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
}
