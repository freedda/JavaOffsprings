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
    
    public void AddItem (Item newItem)
    {
        items.Add(newItem);
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
