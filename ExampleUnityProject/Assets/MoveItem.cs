using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    public string id;
    private string tempId;
    
    
    float curMoveProportion = 0;
    private GameObject player;

    
    // in Start, set up whichever is the first position to be going to
      
    public static MoveItem instance;
    
    private PhotonView view;

    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        view = GetComponent<PhotonView>();

        
    }
    // in Update, find the player

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
        if (player == null)
        {
            // Debug.Log("DEN VRISKEI PAIKTI");
            return;
        }
    }

    [PunRPC]
    public int CompareId(string itemId)
    {
        tempId = itemId;
        
        
        Debug.Log("MPIKE STO COMP" + tempId);
        if(!isClose(player)){
            Debug.Log("EIsai Makria jas");
            return 0;
        }
        if (!id.Equals(tempId) )
        {
            Debug.Log("U need other item to id einai " +id +"kai to tempId " + tempId);
            return 2;
            
        }

        MoveTheObject();
        return 1;
    }
    
    
    [PunRPC]
    public void MoveTheObject()
    {
        view.RPC("RPC_MoveTheObject", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_MoveTheObject()
    {

        curMoveProportion += (Time.fixedDeltaTime);
        transform.Translate(0, 0, 30*Time.fixedDeltaTime);

    }
    
    public bool isClose(GameObject player)
    {
        if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < 3)
        {
            Debug.Log("u r close, u can pick it");
        
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
}
