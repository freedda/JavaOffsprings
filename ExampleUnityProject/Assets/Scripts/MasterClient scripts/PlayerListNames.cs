using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;
public class PlayerListNames : MonoBehaviourPunCallbacks
{
    //This function puts player's names on lobby
    private Player player;
    [SerializeField] private TMP_Text playersName;

    //Set up player's name
    public void SetUp(Player _player)
    {
        player = _player;
        playersName.text = _player.NickName;
    }

    //If player exist destroy it
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (player == otherPlayer)
        {
            //player left the room
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
