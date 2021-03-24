using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
   // distance between player and item in ordeto interact
   public float radius = 1.5f;
   public Transform interactionTransform;
   private GameObject player;
   private  string playerTag = ("Player");
   public Item item;
   public GameObject messagePanel;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag(playerTag);
   }
   

   void Update()
   {
      /*if (isClose(player))
      {
         messagePanel.SetActive(true);
      }
      else
      {
         messagePanel.SetActive(false);
      }*/
      
      if (Input.GetKeyDown("e") && isClose(player))
      {
         Debug.Log("pick up " + item.name);
         PickUp(item);
         Destroy(gameObject);
      }
      
   }

   void OnDrawGizmosSelected()
   {  
      // to prevent any errors
      if (interactionTransform == null)
      {
         interactionTransform = transform;
      }
      Gizmos.color = Color.magenta;
      Gizmos.DrawWireSphere(interactionTransform.position, radius);
   }
   
   public void PickUp(Item newItem)
   {
      Inventory.instance.AddItem(newItem);
   }
   
   private bool isClose(GameObject player)
   {
      if (Vector3.Distance(player.transform.position, this.transform.position) < radius)
      {
         Debug.Log("u r close, u can pick it");
         //Activate a "E" 
         //......
         //Its close in the radius
         return true;
      }
      else
      {
         return false;
      }
   }
}
