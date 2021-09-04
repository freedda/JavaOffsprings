using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using TMPro;
using UnityEngine;

/*
 * This script controls the end of story
 */
public class GetIntoTheTemple : MonoBehaviour
{  
   // keep one player
   private GameObject myPlayer;
   // keep a list of players
   private GameObject[] players;
   
   //Check if the player is Trigger with an empty box
   private bool isTrigger = false;
   
   public GameObject finalImagePanel;
   public GameObject finalScorePanel;
   
   //Animator for the final Image Panel
   [SerializeField] private Animator animator;
   
   //Text Display is responsible for the final monologue
   public TextMeshProUGUI textDisplay;
   
   //Audio for two players
   public AudioSource m_MyAudioSource1;
   //Audio for one player
   public AudioSource m_MyAudioSource2;
   
   private bool m_Play;

   private PlayersMovement playerMove;

   private void Start()
   {
      m_Play = true;
   }

   private void Update()
   {
      
      // Find one player
      myPlayer = GameObject.FindGameObjectWithTag("Player");
      // Find two players
      players = GameObject.FindGameObjectsWithTag("Player");
      
    
      if (isTrigger && m_Play)
      {
         // Get into the if only once
         m_Play = false;
         
         // Transform player position
         myPlayer.transform.position = new Vector3(178, 41, -151);
         
         // Activate final image
         finalImagePanel.SetActive(true);
         
         // Start animation
         animator.SetTrigger("Activate");
         
         // If the game has 2 players play the audio 1 and start coroutine Type1
         if (players.Length.Equals(2))
         {
            m_MyAudioSource1.Play();
            StartCoroutine(Type1());
         }
         // If the game has 1 players play the audio 2 and start coroutine Type2
         else
         {
            m_MyAudioSource2.Play();
            StartCoroutine(Type2());
         }
      }
   }

   void OnTriggerEnter(Collider other){

      // If the empty objects collides with a player
      if (other.gameObject.CompareTag("Player"))
      {
         isTrigger = true;
        // Stop player's movement
        playerMove = other.gameObject.GetComponent<PlayersMovement>();
        playerMove.flagMove = false;      
        
      }
   }
   
   // Create a coroutine for 2 players
   IEnumerator Type1() {
          
         // Start final monologue
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
   
   // Create a coroutine for 1 players
   IEnumerator Type2() {
          
      // Start final monologue
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
