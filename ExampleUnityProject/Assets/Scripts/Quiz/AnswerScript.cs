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
    public int correctNum = 0;
    public int wrongNum = 0;
    public DBscript dbManager;
    private DBscriptBlanks dbBlanksManager;
    public int blanksCorrect;
    public int blanksWrong;
    public GameObject multiplesPanel;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    public TextMeshProUGUI correctAnswerText;
    [SerializeField] private Animator animator;

    private void Start()
    {
        dbBlanksManager = DBscriptBlanks.instance;
    }

    private void Update()
    {
        blanksCorrect = dbBlanksManager.GetComponent<DBscriptBlanks>().correctNum;
        blanksWrong = dbBlanksManager.GetComponent<DBscriptBlanks>().wrongNum;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            correctAnswerPanel.SetActive(true);
            animator.SetTrigger("Correct");
            dbManager.correct();
            correctNum += 1;
        }
        else
        {
            Debug.Log("Wrong answer");
            correctAnswerText.text = correctAnswer;
            wrongAnswerPanel.SetActive(true);
            animator.SetTrigger("Wrong");
            dbManager.correct();
            wrongNum += 1;
            
        }
        getScore();
       
        //when sumbit the multiple anwer , close the panel.
        multiplesPanel.SetActive(false);
    }

    public void getScore()
    {
        Debug.Log("correct multiple: "+ correctNum);
        Debug.Log("correct blanks: "+ blanksCorrect);
        Debug.Log("wrong multiple: "+ wrongNum);
        Debug.Log("wrong blanks: "+ blanksWrong);
        double score = ((float)blanksCorrect + (float)correctNum) / ((float)blanksCorrect + (float)blanksWrong + (float)correctNum + (float)wrongNum);
        Debug.Log("Score: " + score * 100 +  "%"); 
      
    }
    
}
