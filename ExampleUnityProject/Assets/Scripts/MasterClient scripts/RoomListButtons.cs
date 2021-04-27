using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;

public class RoomListButtons : MonoBehaviour
{
    
    [SerializeField] private TMP_Text textName;
    public RoomInfo information;

    //Set up the name of the room
    public void SetUp(RoomInfo _info)
    {
        information = _info;
        textName.text = _info.Name;
    }

    public void OnClick()
    {
        Launch.Instance.JoinRoom(information);
    }
}
