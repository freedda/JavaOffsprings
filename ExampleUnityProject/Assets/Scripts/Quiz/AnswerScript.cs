using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public DBscript dbManager;
    
    public GameObject multiplesPanel;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    [SerializeField] private Animator animator;
    
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            correctAnswerPanel.SetActive(true);
            animator.SetTrigger("Correct");
            dbManager.correct();
           
        }
        else
        {
            Debug.Log("Wrong answer");
            wrongAnswerPanel.SetActive(true);
            animator.SetTrigger("Wrong");
            dbManager.correct();
        }
        
        //when sumbit the multiple anwer , close the panel.
        multiplesPanel.SetActive(false);
    }
    
}
