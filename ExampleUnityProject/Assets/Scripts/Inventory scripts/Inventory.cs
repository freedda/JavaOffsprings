using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion
    
    public List<Item> items = new List<Item>();
    public delegate void itemChanged();
    public itemChanged onItemChangedCallback;
    public int space = 12;

    //A counter for the existing keys in inventory
    public int CountKeys;

    private void Start()
    {
        CountKeys = 0;
    }

    public void AddItem (Item newItem)
    {
        items.Add(newItem);
        //Every Key add 1 on itself.
        if (newItem.name.Equals("Key"))
        {
            CountKeys += 1;
            Debug.Log("MPIKA MESA STTO INVENTORY KAI  TO COUNT EINAI "+ CountKeys);
        }
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void RemoveItem(Item newItem)
    {
        items.Remove(newItem);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    
    
}
