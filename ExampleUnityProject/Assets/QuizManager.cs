using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class QuizManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQ;

    public TextMeshProUGUI QTxt;

    public void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQ);
        generateQuestion();
    }
    
    void generateQuestion()
    {
        for (int i = 0; i < QnA.Count; i++)
        {
            //currentQ = UnityEngine.Random.Range(0, QnA.Count);
            currentQ = i;
            QTxt.text = QnA[currentQ].Question;
            setAnswers();
        }
        
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQ].Answers[i];
            if (QnA[currentQ].correctAnswer == (i+1))
            {   
             //   Debug.Log("SWSTO");
                Debug.Log(options[i].GetComponent<AnswerScript>().isCorrect);
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
            
        }
    }


}
