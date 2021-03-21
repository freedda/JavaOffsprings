using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
   // distance between player and item in ordeto interact
   public float radius = 1f;
   public Transform interactionTransform;
   
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
   
}
