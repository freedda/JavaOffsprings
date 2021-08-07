using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

public class GetIntoTheTemple : MonoBehaviour
{
   private GameObject myPlayer;
   Vector3 warpPosition = Vector3.zero;
   private bool isTrigger = false;


   private void Update()
   {
      myPlayer = GameObject.FindGameObjectWithTag("Player");
      /*if (warpPosition != Vector3.zero)
      {
         myPlayer.transform.position = warpPosition;
         warpPosition = Vector3.zero;
      }*/
      if (isTrigger)
      {
         myPlayer.transform.position = new Vector3(178, 40, -151);
      }
   }

   void OnTriggerEnter(Collider other){

      if (other.gameObject.CompareTag("Player"))
      {
        isTrigger = true;
        PlayersMovement.instance.flagMove = false; 
      }
      

   }

}
