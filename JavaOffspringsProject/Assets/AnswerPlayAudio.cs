using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPlayAudio : MonoBehaviour
{
    public AudioSource m_MyAudioSource;
    // Start is called before the first frame update
    private bool flag;
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && flag)
        {
            flag = false;
            m_MyAudioSource.Play();
        }

        if (!gameObject.activeSelf)
        {
            flag = true;
            Debug.Log("TTO GAME OBJECT EINAI " + gameObject + "katastasi " + gameObject.activeSelf);
        }

    }
}
