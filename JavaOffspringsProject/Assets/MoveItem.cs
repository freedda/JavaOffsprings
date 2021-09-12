using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    
    //Create a static class
    public static MoveItem instance;

    public string id;
    private string tempId;
    
    //Find the player
    private GameObject player;
    
    private PhotonView view;
 
    public GameObject destroyedItem;
    
    //Check if the item has been destroyed 
    public bool itIsDestroyed;
    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        view = GetComponent<PhotonView>();
        itIsDestroyed = false;

    }
    // in Update, find the player

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
      
        if (player == null)
        {
            return;
        }
    }

    [PunRPC]
    public int CompareId(string itemId)
    {
        tempId = itemId;
        
        //Check if the player is near
        if(!isClose(player)){
            return 0;
        }
        
        //Check if you have the right item
        if (!id.Equals(tempId) )
        {
            return 2;
            
        }

        if (gameObject.tag == "Barrel" || gameObject.tag == "Flower")
        {
            MoveTheObject();
        }
        else
        {
            destroyItem();
        }
        return 1;
    }
    
    /*
     * id the gameobject is a barrel or flower
     * move it and discover the hide euquipment
     * Target.ALL
     */
    [PunRPC]
    public void MoveTheObject()
    {
        view.RPC("RPC_MoveTheObject", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPC_MoveTheObject()
    {

        itIsDestroyed = true;
        transform.Translate(0, 0, 30*Time.fixedDeltaTime);

    }

    /*
     * If the object isnt a box, destroyed it to
     * find the hide object
     */
    [PunRPC]
    public void destroyItem()
    {
        view.RPC("RPC_destroyItem" , RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPC_destroyItem()
    {
        itIsDestroyed = true;

        Instantiate(destroyedItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
    public bool isClose(GameObject player)
    {
        if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < 2)
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
