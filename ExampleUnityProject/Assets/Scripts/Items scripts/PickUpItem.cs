using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Photon.Pun;

public class PickUpItem : MonoBehaviourPun
{
   
   // distance between player and item in ordeto interact
   public float radius = 1.5f;
   public Transform interactionTransform;
   
   [SerializeField] protected GameObject player;
   private  string playerTag = ("Player");
   
   public Item item;
   
   public GameObject myCanvas;
   
   //A message Panel for "E" canvas
   public GameObject messagePanel;
   private GameObject invetoryPanel;
   private CursorManager cursor;
   
   private Camera cam;
   private Collider ItemCollider;
   protected PhotonView view;
   
   protected virtual void Start()
   {
      view = GetComponent< PhotonView >();

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
      player = GameObject.FindGameObjectWithTag(playerTag);
      if (player == null)
      {
        // Debug.Log("DEN VRISKEI PAIKTI");
         return;
      }
      ActiveCanvasWithE();
     // activeSpriteE();
      tryToPick();
    
   }

   [PunRPC]
   protected void tryToPick()
   {
      if (Input.GetKeyDown("e") && isClose(player))
      {
         Debug.Log("pick up " + item.name);
         PickUp(item);
         if (PhotonNetwork.IsMasterClient) {
             PhotonNetwork.Destroy(gameObject);
         }
         else
         {
            view.RPC("RPC_destroy",RpcTarget.MasterClient); 
            RPC_destroy();
         
         }
         
      }
   }
   
   [PunRPC]
   void RPC_destroy()
   {
      Destroy(gameObject);
   }

   protected void activeSpriteE()
   {
      if (isClose(player))
      {
         Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
         RaycastHit hit;

         if (ItemCollider.Raycast(ray, out hit, radius))
         {
            cursor.SetCursorToE();
         }
      }
      else
      {
         cursor.SetCursorToDefault ();
      }
     
   }
   protected void ActiveCanvasWithE()
   {
      if (messagePanel.activeSelf == true && !isClose(player))
      {
         messagePanel.SetActive(false);
        // Debug.Log("MPIKE");
      }
     
      if (isClose(player) )
      {
         Debug.Log("PLAYER IS CLOSE");
         cam = Camera.main;

         Ray ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
         RaycastHit hit;

         if (ItemCollider.Raycast(ray, out hit, radius))
         {
            messagePanel.SetActive(true);
         }
      }
      else 
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
   
   protected void PickUp(Item newItem)
   {
      if (newItem.name.Contains("Page"))
      {
         PageSlot.instance.AddPage(newItem);
      }
      else
      {
         Inventory.instance.AddItem(newItem);
         if (newItem.name.Contains("Key"))
         {
            myCanvas.SetActive(true);
            Debug.Log("Pire key,  canvas. ");
         }
      }
   }
   
   protected bool isClose(GameObject player)
   {
      if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < radius)
      {
         Debug.Log("u r close, u can pick it");
        
         return true;
      }
      else
      {
         return false;
      }
   }
}
