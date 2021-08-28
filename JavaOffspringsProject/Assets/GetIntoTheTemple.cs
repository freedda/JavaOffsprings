using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using TMPro;
using UnityEngine;

public class GetIntoTheTemple : MonoBehaviour
{  
   // for single player
   private GameObject myPlayer;
   // for two players
   private GameObject[] players;
   
   Vector3 warpPosition = Vector3.zero;
   private bool isTrigger = false;
   public GameObject finalImagePanel;
   public GameObject finalScorePanel;
   [SerializeField] private Animator animator;
   
   public TextMeshProUGUI textDisplay;
   public AudioSource m_MyAudioSource1;
   public AudioSource m_MyAudioSource2;
   private bool m_Play;

   private void Start()
   {
      m_Play = true;
   }

   private void Update()
   {
      // for single player
      myPlayer = GameObject.FindGameObjectWithTag("Player");
      // for two players
      players = GameObject.FindGameObjectsWithTag("Player");
      
    
      if (isTrigger && m_Play)
      {
         m_Play = false;
         myPlayer.transform.position = new Vector3(178, 41, -151);
         finalImagePanel.SetActive(true);
         animator.SetTrigger("Activate");
         if (players.Length.Equals(2))
         {
            m_MyAudioSource1.Play();
            StartCoroutine(Type1());
         }
         else
         {
            m_MyAudioSource2.Play();
            StartCoroutine(Type2());
         }
      }
   }

   void OnTriggerEnter(Collider other){

      if (other.gameObject.CompareTag("Player"))
      {
        isTrigger = true;
        PlayersMovement.instance.flagMove = false; 
      }
   }
   
   //Create a coroutine for 2 players
   IEnumerator Type1() {
          
         textDisplay.text = "You did it! You have succeeded in completing all your quests and have reached your final destination, the Temple!";
         yield return new WaitForSeconds(7f);
         textDisplay.text = " The manuscripts you have collected divulge the family secret and are parts of a document revealings your origin.";
         yield return new WaitForSeconds(7f);
         textDisplay.text = "What your parents didn't have the time to tell you before they passed away, is that you are the King's offsprings.";
         yield return new WaitForSeconds(6f);
         textDisplay.text = " Now you are successors, of the Kingdom of Java!!";
         yield return new WaitForSeconds(3f);
         textDisplay.text = "";
         setFinalCanvases();
   }
   
   IEnumerator Type2() {
          
      textDisplay.text = "You did it! You have succeeded in completing all your quests and have reached your final destination, the Temple!";
      yield return new WaitForSeconds(7f);
      textDisplay.text = " The manuscripts you have collected divulge the family secret and are parts of a document revealings your origin.";
      yield return new WaitForSeconds(7f);
      textDisplay.text = "What your parents didn't have the time to tell you before they passed away, is that you are the King's offspring.";
      yield return new WaitForSeconds(6f);
      textDisplay.text = " Now you are successor, of the Kingdom of Java!!";
      yield return new WaitForSeconds(3f);
      textDisplay.text = "";
      setFinalCanvases();
   }

   void setFinalCanvases()
   {
      finalImagePanel.SetActive(false);
      finalScorePanel.SetActive(true);
   }

}
