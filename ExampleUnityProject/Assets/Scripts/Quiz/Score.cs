using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public AnswerScript dbMultipleManager;
    private DBscriptBlanks dbBlanksManager;
    public int blanksCorrect;
    public int blanksWrong;
    public int multipleCorrect;
    public int multipleWrong;
    
    // Start is called before the first frame update
    void Start()
    {
        dbBlanksManager = DBscriptBlanks.instance;
        dbMultipleManager = AnswerScript.instance; 
    }

    // Update is called once per frame
    void Update()
    {
        multipleCorrect = dbMultipleManager.GetComponent<AnswerScript>().correctNum;
        multipleWrong = dbMultipleManager.GetComponent<AnswerScript>().wrongNum;
        blanksCorrect = dbBlanksManager.GetComponent<DBscriptBlanks>().correctNum;
        blanksWrong = dbBlanksManager.GetComponent<DBscriptBlanks>().wrongNum;
    }
    
    public void getScore()
    {
        Debug.Log("correct multiple: "+ multipleCorrect);
        Debug.Log("correct blanks: "+ blanksCorrect);
        Debug.Log("wrong multiple: "+ multipleWrong);
        Debug.Log("wrong blanks: "+ blanksWrong);
        double score = ((float)blanksCorrect + (float)multipleCorrect) / ((float)blanksCorrect + (float)blanksWrong + (float)multipleCorrect + (float)multipleWrong);
        // Debug.Log("Score: " + String.Format("{0:0.00}", score));
        Debug.Log("Score: " + score * 100 +  "%"); 
      
    }
}
