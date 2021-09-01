using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        /*if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }*/
        instance = this;
    }
    #endregion
    
    //A list for items
    public List<string> items = new List<string>();
    
    //A list for keys
    public List<string> keys = new List<string>();
    public delegate void itemChanged();
    public itemChanged onItemChangedCallback;
    public int space = 12;

    //A counter for the existing keys in inventory
    public int CountKeys;
   
    private PhotonView view;

    private void Start()
    {   
        //Initialize the counter
        CountKeys = 0;
        
        //Initialize the Photon View
        view = GetComponent<PhotonView>();
    }

    public void AddItem (string newItemId)
    {
        
        //Every Key add 1 on itself. Every key has a unique id "02250c14-1e7b-4d55-a5e1-ce6758e5ac88"
        if (newItemId.Equals("02250c14-1e7b-4d55-a5e1-ce6758e5ac88"))
        {
            //Add the newItemId on keys list 
            keys.Add(newItemId);
            CountKeys += 1;
        }
        else
        {
            //Add the newItemId on items list 
            items.Add(newItemId);
        }
        
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    [PunRPC]
    public void RemoveItem(string newItemId)
    {
     
        var id = newItemId;
        //Call RPC_RemoveItem through PunRPC to inform all players
        view.RPC("RPC_RemoveItem", RpcTarget.AllBuffered, id);
    }

    [PunRPC]
    public void RPC_RemoveItem(string newItemId)
    {
        //Remove a item from items list
        items.Remove(newItemId);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    
    
    
}
