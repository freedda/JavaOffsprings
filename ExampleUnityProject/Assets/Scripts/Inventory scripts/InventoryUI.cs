using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform GFXInvetory;
    private Inventory myInventory;
    private InventorySlot[] inventorySlots;
    private PhotonView view;
   
       
       // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        myInventory = Inventory.instance; 
        myInventory.onItemChangedCallback += Update; 
        inventorySlots = GFXInvetory.GetComponentsInChildren<InventorySlot>();
    }
   
    // Update is called once per frame
    void Update() 
    { 
        RPC_Update();
    }
   
    [PunRPC] 
    void RPC_Update() 
    { 
        view.RPC("RPC_Inventory_Update", RpcTarget.All);
    }
   
    [PunRPC] 
    void RPC_Inventory_Update() 
    { 
        //Debug.Log("update UI"); 
        for (int i = 0; i < inventorySlots.Length-11; i++) 
        { 
            if (i < myInventory.items.Count) 
            { 
                inventorySlots[i].AddItem(myInventory.items[i]);      
            }
            else 
            { 
                inventorySlots[i].RemoveItem();
            }
        }   
        for (int i = 0; i < 11; i++)
        {
            // Debug.Log("MPIKE STO KEYS");
            if (i < myInventory.keys.Count)
            {
                inventorySlots[i+13].AddItem(myInventory.keys[i]);
             }
                
        }
    }
}
