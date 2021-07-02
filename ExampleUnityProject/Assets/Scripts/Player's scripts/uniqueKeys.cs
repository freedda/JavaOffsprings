using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uniqueKeys : MonoBehaviour
{
    public static uniqueKeys instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    
    private Inventory inventory;


    public int countKeys;
    private int ListItemCount;
    private int count;


    void Start()
    {
        inventory = Inventory.instance;
        count = 0;
        countKeys= 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Take the number of the unique keys which are in inventory
        countKeys = inventory.CountKeys;
        //Debug.Log("TOSAAAAAAAAAA TA KLEIDIA "+ countKeys);
    }
}
