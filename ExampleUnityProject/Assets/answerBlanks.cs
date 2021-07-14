using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerBlanks : MonoBehaviour
{
    public bool isCorrect = false;
    public DBscriptBlanks dbManager;
    
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            dbManager.correct();
        }
        else
        {
            Debug.Log("Wrong answer");
            dbManager.correct();
        }
    }
    

}
