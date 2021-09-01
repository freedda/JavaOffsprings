using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  This class counts the unique keys
 *  which are collected from the players
 */
public class uniqueKeys : MonoBehaviour
{
    public static uniqueKeys instance;
    void Awake()
    {
        /*if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }*/
        instance = this;
    }
    
    private Inventory inventory;
    
    public int countKeys;
    
    void Start()
    {
        inventory = Inventory.instance;
        countKeys= 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Take the number of the unique keys which are in inventory
        countKeys = inventory.CountKeys;
      
    }
}
