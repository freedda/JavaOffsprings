
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlAudio : MonoBehaviour
{
        //Audio for two players
        public AudioSource m_MyAudioSource1;
        //Audio for single player
        public AudioSource m_MyAudioSource2;
        
        private GameObject player;
    
        private GameObject[] players;
    
        private bool m_Play;

        public TextMeshProUGUI textDisplay;
        
    
        void Start(){ 
            
            m_Play = true;
        }
    
        private void Update()
        {   
            // for single player
            player = GameObject.FindGameObjectWithTag("Player");
            // for two players
            players = GameObject.FindGameObjectsWithTag("Player");
             
            
            StartTheAudio();
        }
    
        public void StartTheAudio()
        { 
            
            if ((Mathf.Abs(Vector3.Distance(player.transform.position, this.transform.position)) < 1.5) && m_Play)
            {
    
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

                m_Play = false;
            }
    
        }
    
        //Create a coroutine for 2 players  
        IEnumerator Type1()
        {
          
                textDisplay.text = "You found me! Your ancestors would be very proud of you being here, but now it's your time to escape with your brother.";
                yield return new WaitForSeconds(7f);
                textDisplay.text = "In order to succeed and decode the message they left you, you need to be trained in the language they used: an object-oriented language called Java. ";
                yield return new WaitForSeconds(9f);
                textDisplay.text = "Your goal is to find 10 hidden pages in order to read your ancestors message.";
                yield return new WaitForSeconds(4f);
                textDisplay.text = "To achieve this you must work together with your brother sharing your knowledge, concentrating and most of all have fun!";
                yield return new WaitForSeconds(6.5f);
                textDisplay.text= "Make sure you have read the instructions in \"how to play\" section before you start. ";
                yield return new WaitForSeconds(5f);
                textDisplay.text = "Afterwards, one of you should take the first key and unlock the house in front of me.";
                yield return new WaitForSeconds(4f);
                textDisplay.text = "The map and the signs will help you not to get lost on your way. Enjoy your exploration!";
                yield return new WaitForSeconds(5f);
                textDisplay.text = "";
    
        }
    
       //Create a coroutine for  players  
        IEnumerator Type2()
        {
                textDisplay.text = "You found me! Your ancestors would be very proud of you being here, but now it's your time to escape.";
                yield return new WaitForSeconds(6f);
                textDisplay.text = "In order to succeed and decode the message they left you, you need to be trained in the language they used: an object-oriented language called Java. ";
                yield return new WaitForSeconds(9f);
                textDisplay.text = "Your goal is to find 10 hidden pages in order to read your ancestors message.";
                yield return new WaitForSeconds(4f);
                textDisplay.text = "To achieve this you must work concentrated and most of all have fun!";
                yield return new WaitForSeconds(5f);
                textDisplay.text= "Make sure you have read the instructions in \"how to play\" section before you start. ";
                yield return new WaitForSeconds(5f);
                textDisplay.text = "Afterwards, you should take the first key and unlock the house in front of me.";
                yield return new WaitForSeconds(3.5f);
                textDisplay.text = "The map and the signs will help you not to get lost on your way. Enjoy your exploration!";
                yield return new WaitForSeconds(5f);
                textDisplay.text = "";
        }
       
    
   
}
