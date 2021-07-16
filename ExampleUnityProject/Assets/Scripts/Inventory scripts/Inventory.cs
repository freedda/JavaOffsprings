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
        /*if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }*/
        instance = this;
    }
    #endregion
    
    public List<string> items = new List<string>();
    public delegate void itemChanged();
    public itemChanged onItemChangedCallback;
    public int space = 12;

    //A counter for the existing keys in inventory
    public int CountKeys;

    private void Start()
    {
        CountKeys = 0;
    }

    public void AddItem (string newItemId)
    {
        items.Add(newItemId);
        //Every Key add 1 on itself.
        if (newItemId.Equals("02250c14-1e7b-4d55-a5e1-ce6758e5ac88"))
        {
            CountKeys += 1;
            //Debug.Log("MPIKA MESA STTO INVENTORY KAI  TO COUNT EINAI "+ CountKeys);
        }
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void RemoveItem(string newItemId)
    {
        items.Remove(newItemId);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    
    
}
