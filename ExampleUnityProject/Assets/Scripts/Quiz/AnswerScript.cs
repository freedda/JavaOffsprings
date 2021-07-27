using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public DBscript dbManager;
    
    public GameObject multiplesPanel;

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
        
        //when sumbit the multiple anwer , close the panel.
        multiplesPanel.SetActive(false);
    }
    
}
