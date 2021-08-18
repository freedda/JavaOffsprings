using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private DBscript dbMultipleManager;
    private DBscriptBlanks dbBlanksManager;
    private int blanksCorrect;
    private int blanksWrong;
    private int multipleCorrect;
    private int multipleWrong;

    public TextMeshProUGUI scoreText; 
    
    // Start is called before the first frame update
    void Start()
    {
        dbBlanksManager = DBscriptBlanks.instance.GetComponent<DBscriptBlanks>();
        dbMultipleManager = DBscript.instance.GetComponent<DBscript>();
    }

    // Update is called once per frame
    void Update()
    {
        multipleCorrect = dbMultipleManager.correctNum; 
        multipleWrong = dbMultipleManager.wrongNum;
        blanksCorrect = dbBlanksManager.correctNum;
        blanksWrong = dbBlanksManager.wrongNum;
    }
    
    public void getScore()
    {
        Debug.Log("correct multiple: "+ multipleCorrect);
        Debug.Log("correct blanks: "+ blanksCorrect);
        Debug.Log("wrong multiple: "+ multipleWrong);
        Debug.Log("wrong blanks: "+ blanksWrong);
        double score = ((float)blanksCorrect + (float)multipleCorrect) / ((float)blanksCorrect + (float)blanksWrong + (float)multipleCorrect + (float)multipleWrong);
        Debug.Log("Score: " + score * 100 +  "%");
        scoreText.text = (score * 100 ) + "%" ; 

    }
}
