
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlAudio : MonoBehaviour
{
    private AudioSource m_MyAudioSource;

    private GameObject player;

    private bool m_Play;

    public TextMeshProUGUI textDisplay;
    

    void Start(){ 
        m_MyAudioSource = GetComponent<AudioSource>();
        m_Play = true;

    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        StartTheAudio();
    }

    public void StartTheAudio()
    { 
        
        if ((Mathf.Abs(Vector3.Distance(player.transform.position, this.transform.position)) < 1.5) && m_Play)
        {
            m_Play = false; 
            m_MyAudioSource.Play();
            StartCoroutine(Type());
        }

    }

    //Create a coroutine 
    IEnumerator Type()
    {
      
            textDisplay.text = "You found me! Your ancestors would be very proud of your being here, but now it's your time to escape with your brother.";
            yield return new WaitForSeconds(7f);
            textDisplay.text = "In order to succeed and decode the message they left you, you need to be trained in the language they used: an object-oriented language called Java. ";
            yield return new WaitForSeconds(9f);
            textDisplay.text = "Your goal is to find 10 hidden pages in order to read your ancestors message.";
            yield return new WaitForSeconds(4f);
            textDisplay.text = "To achieve this you must work together with your brother sharing your knowledge, concentrating and most of all have fun!";
            yield return new WaitForSeconds(6.5f);
            textDisplay.text= "Make sure you have read the instructions in < how to play > section before you start. ";
            yield return new WaitForSeconds(5f);
            textDisplay.text = "Afterwards, one of you should take the first key and unlock the house in front of me.";
            yield return new WaitForSeconds(4f);
            textDisplay.text = "The map and the signs will help you not to get lost on your way. Enjoy your exploration!";
            yield return new WaitForSeconds(5f);
            textDisplay.text = "";

    }

   
    
   
}
