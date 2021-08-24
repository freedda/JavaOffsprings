using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AnswerScript : MonoBehaviour
{
    #region Singleton
    public static AnswerScript instance;
    
    void Awake()
    {
        instance = this;
    }
    #endregion
    
    public bool isCorrect = false;
    public string correctAnswer;
    
    public DBscriptMultiple dbMultipleManager;
    public GameObject multiplesPanel;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    public TextMeshProUGUI correctAnswerText;
    [SerializeField] private Animator animator;

    private void Start()
    {
        dbMultipleManager = DBscriptMultiple.instance.GetComponent<DBscriptMultiple>();
    }

    private void Update()
    {
        dbMultipleManager.correctNum= dbMultipleManager.correctNum;
        dbMultipleManager.wrongNum = dbMultipleManager.wrongNum;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            correctAnswerPanel.SetActive(true);
            animator.SetTrigger("Correct");
            dbMultipleManager.correct();
            dbMultipleManager.correctNum += 1;
        }
        else
        {
            Debug.Log("Wrong answer");
            correctAnswerText.text = correctAnswer;
            wrongAnswerPanel.SetActive(true);
            animator.SetTrigger("Wrong");
            dbMultipleManager.correct();
            dbMultipleManager.wrongNum+= 1;
            
        }
        
        //when submit the multiple answer , close the panel.
        multiplesPanel.SetActive(false);
    }
 
    
}
