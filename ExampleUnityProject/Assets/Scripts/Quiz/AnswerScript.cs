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
    
    public DBscript dbMultipleManager;
    public GameObject multiplesPanel;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    public TextMeshProUGUI correctAnswerText;
    [SerializeField] private Animator animator;

    private void Start()
    {
        dbMultipleManager = DBscript.instance.GetComponent<DBscript>();
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

    /*public void getScore()
    {
        Debug.Log("correct multiple: mesa stn getscore "+ correctNum);
       // Debug.Log("correct blanks: "+ blanksCorrect);
        Debug.Log("wrong multiple: mesa stn getscore "+ wrongNum);
        /*Debug.Log("wrong blanks: "+ blanksWrong);
        double score = ((float)blanksCorrect + (float)correctNum) / ((float)blanksCorrect + (float)blanksWrong + (float)correctNum + (float)wrongNum);
        Debug.Log("Score: " + score * 100 +  "%"); #1#
    }*/

   
    
}
