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
        // Instance from DBscriptMultiple in order to get correct and wrong questions 
        dbMultipleManager = DBscriptMultiple.instance.GetComponent<DBscriptMultiple>();
    }

    private void Update()
    {   
        // Update current values
        dbMultipleManager.correctNum= dbMultipleManager.correctNum;
        dbMultipleManager.wrongNum = dbMultipleManager.wrongNum;
    }

    public void Answer()
    {
        if (isCorrect)
        {   
            // Activate "Correct Answer" panel
            correctAnswerPanel.SetActive(true);
            // Activate animation for correct answer
            animator.SetTrigger("Correct");
            // Increase correct answer value
            dbMultipleManager.correctNum += 1;
        }
        else
        {
            // Set the correct answer in the panel
            correctAnswerText.text = correctAnswer;
            // Activate "Wrong Answer" panel
            wrongAnswerPanel.SetActive(true);
            // Activate animation for wrong panel
            animator.SetTrigger("Wrong");
            // Increase wrong answer value
            dbMultipleManager.wrongNum+= 1;
            
        }
        // Call the correct method from DBscriptMultiple class
        dbMultipleManager.correct();
        
        // When the answer is submitted, close the panel.
        multiplesPanel.SetActive(false);
    }
 
    
}
