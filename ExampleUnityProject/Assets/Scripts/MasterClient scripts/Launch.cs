using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Random = UnityEngine.Random;
using System.Collections.Generic;

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

    //Controll find room lobby
    [SerializeField] private Transform RoomListButtons;
    [SerializeField] private GameObject RoomNameListPrefab;
    
    //Controll players list name
    [SerializeField] private Transform PlayersList;
    [SerializeField] private GameObject PlayerListNamesPrefab;

    [SerializeField] private GameObject startGameButton;
    
    void Start()    
    {
        //connecting photon with a master service using setting (eu)    
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
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
    
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
      
    }

    
    public void LoadGameScene(){
        PhotonNetwork.LoadLevel(1);
    }
    //If created room failed then activate an error panel
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room creation failed " + message;
        MenuManager.instance.OpenMenu("error");
    }
    
    
    public override void OnJoinedRoom()
    {
        
        if (2 == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }
        MenuManager.instance.OpenMenu("room lobby");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        

        foreach (Transform player in PlayersList)
        {
            Destroy(player.gameObject);
        }
        
        //Loop list for set up the players
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(PlayerListNamesPrefab, PlayersList).GetComponent<PlayerListNames>().SetUp(players[i]);

        }
        
        
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    
    public override void OnLeftRoom()
    {
        MenuManager.instance.OpenMenu("main menu");
    }

    
    //When the master client switched then set active the current master client
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    
    
    
    //Put New players name in lobby
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListNamesPrefab, PlayersList).GetComponent<PlayerListNames>().SetUp(newPlayer);

    }
    
    
    //RoomInfo is a function from Photon

    public override void OnRoomListUpdate(List<RoomInfo> listOfRooms)
    {
        foreach (Transform room in RoomListButtons)
        {
            //Clear the List
            Destroy(room.gameObject);
        }
        
        //Loop room List
        for (int i = 0; i < listOfRooms.Count; i++)
        {
            if(listOfRooms[i].RemovedFromList) continue;
            Instantiate(RoomNameListPrefab, RoomListButtons).GetComponent<RoomListButtons>().SetUp(listOfRooms[i]);
        }
    }
    
    
}
