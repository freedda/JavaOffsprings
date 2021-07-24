using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Photon.Pun;
/*
 * This script is attatched to the items
 * If the player is near to the item then
 * they can pick up it.
 * If the item is a key, the Theory activated
 * if the item is somithing else it saved in inventory
 * if the item is a Page the counter increased by one
 */
public class PickUpItem : MonoBehaviourPun
{
   
   // distance between player and item in ordeto interact
   public float radius = 1f;
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
      TryToPick();
    
   }

   [PunRPC]
   protected void TryToPick()
   {
      if (Input.GetKeyDown("e") && isClose(player))
      {
         Debug.Log("pick up " + item.name);
         
         view.RPC("PickUp", RpcTarget.AllBuffered, item.Id);
         //PickUp(item);
         
         /*if (PhotonNetwork.IsMasterClient) {
             PhotonNetwork.Destroy(gameObject);
         }
         else
         {
            view.RPC("RPC_destroy",RpcTarget.MasterClient); 
            RPC_destroy();
            
         }*/
         
      }
   }
   
   [PunRPC]
   private void RPC_destroy()
   {
      Destroy(gameObject);
   }

   //PAEI GIA SVISIMO?
   /*protected void activeSpriteE()
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
     
   }*/
   protected void ActiveCanvasWithE()
   {
      GameObject g = GameObject.FindGameObjectsWithTag("Item").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, player.transform.position) > Vector3.Distance(o2.transform.position, player.transform.position) ? o2 : o1);
      if (!(Mathf.Abs(Vector3.Distance(player.transform.position, g.transform.position)) < radius) && messagePanel.activeSelf)
      {
         messagePanel.SetActive(false);
         Debug.Log("EINAI STO IF");
         
      }
      
      if((Mathf.Abs(Vector3.Distance(player.transform.position, g.transform.position)) < radius)){
         Debug.Log("PLAYER IS CLOSE + " + gameObject);
         cam = Camera.main;

         Ray ray = cam.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
         RaycastHit hit;

         if (ItemCollider.Raycast(ray, out hit, radius))
         {
            messagePanel.SetActive(true);
         }
         
         messagePanel.SetActive(true);
         Debug.Log("ENERGIOPOIHHHHHSE TON CANVVVVVA pou einai o  " + messagePanel + " einai einai " + messagePanel.activeSelf);
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
   
   [PunRPC]
   protected void PickUp(String newItemId)
   {
      RPC_destroy();
      //This is page's id
      if (newItemId.Equals("a3da4feb-3607-4a51-9a50-d19a9fc3f5fd"))
      {
         //to add page tha mporouse na mn dexete orisma kathw den to xrisimopoiei
         PageSlot.instance.AddPage(newItemId);
      }
      else
      {
         
         Inventory.instance.AddItem(newItemId);
         //this is key's id
         if (newItemId.Equals("02250c14-1e7b-4d55-a5e1-ce6758e5ac88"))
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
