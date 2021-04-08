using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

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
   private CursorManager cursor;
   
   private Camera cam;
   private Collider ItemCollider;
   
   protected virtual void Start()
   {
      player = GameObject.FindGameObjectWithTag(playerTag);
      ItemCollider = GetComponent<BoxCollider> ();
      cam = Camera.main;
      
      
      cursor = CursorManager.instance;

      if (cursor != null) {
         cursor.SetCursorToDefault ();
      }
   }
   
   protected  virtual void Update()
   {
      ActiveCanvasWithE();
     // activeSpriteE();
      tryToPick();
    
   }

   protected void tryToPick()
   {
      if (Input.GetKeyDown("e") && isClose(player))
      {
         Debug.Log("pick up " + item.name);
         PickUp(item);
         Destroy(gameObject);
      }
   }

   protected void activeSpriteE()
   {
      if (isClose(player)){ 
         Ray ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (ItemCollider.Raycast (ray, out hit, radius)) {
           
               cursor.SetCursorToE(); 
           					
         } 
      else {
            cursor.SetCursorToDefault ();
         }
     }
   }
   protected void ActiveCanvasWithE()
   {
      if (messagePanel.activeSelf == true && !isClose(this.player))
      {
         messagePanel.SetActive(false);
        // Debug.Log("MPIKE");
      }
      /*Debug.Log("to E pane einai genika ston kwdika: " +  messagePanel.activeSelf);
      Debug.Log("to E pane einai sto hierarchy: " +  messagePanel.activeInHierarchy);*/
      if (isClose(this.player) )
      {
         Ray ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
         RaycastHit hit;

         if (ItemCollider.Raycast(ray, out hit, radius))
         {
            messagePanel.SetActive(true);
            Debug.Log("to E pane einai genika ston kwdika  11 : " + messagePanel.activeSelf);
            Debug.Log("to E pane einai sto hierarchy  11 : " + messagePanel.activeInHierarchy);
         }
      }
      else 
      {
         messagePanel.SetActive(false);
         Debug.Log("to E pane einai genika ston kwdika  22 : " +  messagePanel.activeSelf);
         Debug.Log("to E pane einai sto hierarchy  22 : " +  messagePanel.activeInHierarchy);
         Debug.Log(isClose(player));
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
   
   protected void PickUp(Item newItem)
   {
      Inventory.instance.AddItem(newItem);
   }
   
   protected bool isClose(GameObject player)
   {
      if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < radius)
      {
         Debug.Log("u r close, u can pick it");
         //Activate a "E" 
         //......
         //Its close in the radius
       //  Debug.Log("einai mKONTA o player stin thesi " + player.transform.position + "kai to antikeimeno " + this.transform.position);
         
         return true;
      }
      else
      {
         return false;
      }
   }
}
