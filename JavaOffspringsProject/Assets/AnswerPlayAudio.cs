using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPlayAudio : MonoBehaviour
{
    public AudioSource m_MyAudioSource;
    public GameObject other;
    private bool flag;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (other.activeSelf && flag)
        {
            flag = false;
            m_MyAudioSource.Play();
        }
      
        if (!other.activeSelf)
        {
            flag = true;
   
        }

    }
}
