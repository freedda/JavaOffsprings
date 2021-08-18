using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private DBscriptMultiple dbMultipleManager;
    private DBscriptBlanks dbBlanksManager;
    private int blanksCorrect;
    private int blanksWrong;
    private int multipleCorrect;
    private int multipleWrong;

    public TextMeshProUGUI scoreText; 
    
    // Start is called before the first frame update
    void Start()
    {
        // instances from  db scripts
        dbBlanksManager = DBscriptBlanks.instance.GetComponent<DBscriptBlanks>();
        dbMultipleManager = DBscriptMultiple.instance.GetComponent<DBscriptMultiple>();
    }

    // Update is called once per frame
    void Update()
    {   
        // update current values
        multipleCorrect = dbMultipleManager.correctNum; 
        multipleWrong = dbMultipleManager.wrongNum;
        blanksCorrect = dbBlanksManager.correctNum;
        blanksWrong = dbBlanksManager.wrongNum;
    }
    
    public void getScore()
    {   
        // calculate current score
        double score = ((float)blanksCorrect + (float)multipleCorrect) / ((float)blanksCorrect + (float)blanksWrong + (float)multipleCorrect + (float)multipleWrong) * 100;
        
        if (Double.IsNaN(score))
        {   
            // when player hasn't answer any questions yet instead of "nan" the score is 0
            scoreText.text = "0%";
        }
        else
        {
            // format score in two decimals
            scoreText.text = score.ToString("F2") + "%" ; 
        }

    }
}
