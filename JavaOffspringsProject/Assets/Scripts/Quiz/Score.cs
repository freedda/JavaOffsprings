using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    #region Singleton
    public static Score instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    private DBscriptMultiple dbMultipleManager;
    private DBscriptBlanks dbBlanksManager;
    private int blanksCorrect;
    private int multipleCorrect;
    public double score = 0;
    public TextMeshProUGUI scoreText; 
    
    // Start is called before the first frame update
    void Start()
    {
        // Instances from db scripts
        dbBlanksManager = DBscriptBlanks.instance.GetComponent<DBscriptBlanks>();
        dbMultipleManager = DBscriptMultiple.instance.GetComponent<DBscriptMultiple>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        // Update current values
        multipleCorrect = dbMultipleManager.correctNum;
        blanksCorrect = dbBlanksManager.correctNum;
        // Calculate current score
        calculateScore();
    }
    
    public void calculateScore()
    {   
        // Calculate current score. The total number of questions is 31. Multiplying by 100 to get the percentage. 
        score = ((float) blanksCorrect + (float) multipleCorrect) / 31 * 100;
        
        if (Double.IsNaN(score))
        {   
            // When player hasn't answer any questions yet instead of "nan" the score is 0.
            scoreText.text = "0%";
        }
        else
        {
            // Format score in two decimals.
            scoreText.text = score.ToString("F2") + "%" ; 
        }

    }
    

}
