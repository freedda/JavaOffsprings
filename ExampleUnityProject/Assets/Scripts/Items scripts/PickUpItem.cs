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
   
   protected GameObject player;
   private  string playerTag = ("Player");
   
   public Item item;
   
   //A message Panel for "E" canvas
   public GameObject messagePanel;
   private GameObject invetoryPanel;

  


   protected virtual void Start()
   {
      player = GameObject.FindGameObjectWithTag(playerTag);
      
    
   }
   

   protected  virtual void Update()
   {
      ActiveCanvasWithE();
      if (Input.GetKeyDown("e") && isClose(player))
      {
         Debug.Log("pick up " + item.name);
         
         PickUp(item);
         Destroy(gameObject);
        
        
  
      }
 
   }

   protected void ActiveCanvasWithE()
   {
      if (isClose(player))
      {
         messagePanel.SetActive(true);
      }
      else if(messagePanel.activeSelf==true)
      {
         messagePanel.SetActive(false);
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
   
   protected bool isClose(GameObject player)
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
