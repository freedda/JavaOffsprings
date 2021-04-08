using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform GFXInvetory;
    private Inventory myInventory;
    private InventorySlot[] inventorySlots;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myInventory = Inventory.instance;
        myInventory.onItemChangedCallback += Update;

        inventorySlots = GFXInvetory.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log("update UI");
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < myInventory.items.Count)
            {
                inventorySlots[i].AddItem(myInventory.items[i]);      
            }
        }
    }
}
