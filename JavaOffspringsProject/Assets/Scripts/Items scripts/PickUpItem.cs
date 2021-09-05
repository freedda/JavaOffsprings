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
   
   public string item;
   
   public GameObject myCanvas;
   
   //A message Panel for "E" canvas
   public GameObject messagePanel;
   //Take inventory 
   private GameObject inventoryPanel;
   
   private CursorManager cursor;
   private PhotonView view;

   //Its responsible for the theory tasks
   public GameObject theoryPanel;
   
   private bool flag;
   private AudioSource m_MyAudioSource;
  
   private void Awake()
   {
      m_MyAudioSource = GetComponent<AudioSource>();
  
   }
  
   //Initialize variables
   private void Start()
   {
      view = GetComponent< PhotonView >();
   
      player = GameObject.FindGameObjectWithTag(playerTag);
      

      cursor = CursorManager.instance;
  
      if (cursor != null) {
         cursor.SetCursorToDefault ();
      }
  
      flag = true;
  
   }
  
   private void Update()
   {
      //Find the player
      player = GameObject.FindGameObjectWithTag(playerTag);
      
      //Play the audio clip once in the beginning 
      if (m_MyAudioSource != null && flag)
      {
         m_MyAudioSource.Play();
         flag = false;
      }
      
      //call the method active canvas with E
      ActiveCanvasWithE();
      //Call a method to pick up an item
      TryToPick();
   
   }


   [PunRPC] 
   private void TryToPick()
   {
      if (Input.GetKeyDown("e") && isClose(player))
      {
         
         view.RPC("PickUp", RpcTarget.AllBuffered, item);

      }
   }
   
   [PunRPC]
   private void RPC_destroy()
   {
      Destroy(gameObject);
   }

   
   private void ActiveCanvasWithE()
   {
      //Find the gameobject with the Tag "item", which is closer to the player
      GameObject g = GameObject.FindGameObjectsWithTag("Item").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, player.transform.position) > Vector3.Distance(o2.transform.position, player.transform.position) ? o2 : o1);
      
      //If the player isn't near and the panel is active, make it Deactivate 
      if ((Mathf.Abs(Vector3.Distance(player.transform.position, g.transform.position)) > radius) && messagePanel.activeSelf)
      {
         messagePanel.SetActive(false);
      }
      
      //if the player is near, activate the press E panel
      if((Mathf.Abs(Vector3.Distance(player.transform.position, g.transform.position)) < radius)){
         
         messagePanel.SetActive(true);
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
   private void PickUp(String newItemId)
   {
      //  Call destroy with PunRPC
      RPC_destroy();
      //This is page's id
      if (newItemId.Equals("a3da4feb-3607-4a51-9a50-d19a9fc3f5fd"))
      {
         PageSlot.instance.AddPage(newItemId);
      }
      else
      {
         if (messagePanel.activeSelf)
         {
            messagePanel.SetActive(false);
         }
         
         //add the item to the list
         Inventory.instance.AddItem(newItemId);
         //this is key's id
         if (newItemId.Equals("02250c14-1e7b-4d55-a5e1-ce6758e5ac88"))
         {
            //Open lesson Canvas
            myCanvas.SetActive(true);
         }
         else
         {
            //if it isn't key, then open the theory task
            theoryPanel.SetActive(true);
         }
      }
   }
   
   private bool isClose(GameObject player)
   {
      if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < radius)
      {
         //Debug.Log("u r close, u can pick it")
         return true;
      }
      else
      {
         return false;
      }
   }
   
}
