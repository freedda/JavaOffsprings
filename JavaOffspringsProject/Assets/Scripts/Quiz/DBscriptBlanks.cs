using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;



public class DBscriptBlanks : MonoBehaviour
{   
    #region Singleton
    public static DBscriptBlanks instance;
    
    void Awake()
    {
        instance = this;
    }
    #endregion
    
    private string dbName = "URI=file:theoryBlanks.db";
    private string option;
    private int currentQ;
    private AnswerScript AnswerScriptManager;
    public TextMeshProUGUI QTxt;
    public TextMeshProUGUI BlanksTxt;
    public TextMeshProUGUI AnswerTxt;
    public TMP_InputField answerField;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    public TextMeshProUGUI correctAnswerText;
    public GameObject blanksPanel;

    public int correctNum = 0;
    public int wrongNum = 0 ;
    
    [SerializeField] private Animator animator;
    
    [System.Serializable]
    public class QuestionAndAnswers
    {
        public string Question;
        public string Blanks;
        public string correctAnswer;
    }
    
    public List<QuestionAndAnswers> QnA = new List<QuestionAndAnswers>();
    
    // Start is called before the first frame update
    void Start()
    {   
        // Create database
        //CreateDB();
        // Add a theory question with options and correct answer
        // AddTheory();
         
        // Display records to the console 
        DisplayTheory();
        
        // Reverse list
        QnA.Reverse();
        
        //Generate the first question 
        generateQuestion();
        
    }

    /*public void CreateDB()
    {
        // Create database connection
        using(var connection = new SqliteConnection(dbName))
        { 
            connection.Open();
            using (var command = connection.CreateCommand())
            {   
                // Create a table "theory" if it doesnt exist already  
                command.CommandText = "CREATE TABLE IF NOT EXISTS theoryBlanks (questionID INT PRIMARY KEY, question VARCHAR(50), blanks VARCHAR(50), correctAnswer VARCHAR(50));";
                command.ExecuteNonQuery();
            }
            // Close database connection
            connection.Close();
        }
    }*/
    
    /*public void AddTheory(int questionID, string question, string blanks, string correctAnswer)
    {   
        // Create database connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {   
                // Insert record to the database 
                command.CommandText = "INSERT INTO theoryBlanks (questionID,question, blanks, correctAnswer) VALUES ('" +questionID+ "', '" + question + 
                                      "' , '" + blanks + "', '" + correctAnswer + "' );";
                command.ExecuteNonQuery();
            }
            
            // Close database connection
            connection.Close();
        }
        
    }*/
    
      public void DisplayTheory()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // Select from the database
                command.CommandText = "SELECT * FROM theoryBlanks ORDER BY questionID;";
                
                // Iterate through the recordset and display
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        // Get question's ID. IDs start from 1, we want to count from 0 
                        currentQ = Convert.ToInt16(reader["questionID"])-1;

                        // Get question from the db
                        QnA[currentQ].Question = reader["question"].ToString();
                      
                        // Get code with blanks from the database
                        QnA[currentQ].Blanks = reader["blanks"].ToString();
                        
                        // Get correct code from the database
                        QnA[currentQ].correctAnswer = reader["correctAnswer"].ToString();
                        
                        // Display question's ID, question, code with blanks and correct answer
                        /*Debug.Log("Question ID: " +reader["questionID"] +"\n Question: " + reader["question"] + 
                          "\n " + reader["blanks"] + "\n" + reader["correctAnswer"]);*/
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
      
      void generateQuestion()
      {
          // Iterate through the list with the questions
          for (int i = 0; i < QnA.Count; i++)
          {
              currentQ = i;
              // Set the question
              QTxt.text = QnA[currentQ].Question;
              // Set the code with the blanks
              BlanksTxt.text = QnA[currentQ].Blanks;
          }
          
      }
        
      public void getAnswer()
      { 
          // Remove spaces from the correct answer
          string correctAnswer = Regex.Replace(QnA[currentQ].correctAnswer, @"\s+", "");
          // Remove spaces from player's answer
          string playersAnswer = Regex.Replace(AnswerTxt.text, @"\s+", "");
          // Remove extra character from player;s answer
          playersAnswer = playersAnswer.Remove(playersAnswer.Length - 1);
         
          if (playersAnswer.Equals(correctAnswer))
          {
              // Activate "Correct Answer" panel
              correctAnswerPanel.SetActive(true);
              // Activate animation for correct answer
              animator.SetTrigger("Correct");
              // Increase correct answer value
              correctNum += 1;
          }
          else
          {
              // Set the correct answer in the panel
              correctAnswerText.text = QnA[currentQ].correctAnswer;
              // Activate "Wrong Answer" panel
              wrongAnswerPanel.SetActive(true);
              // Activate animation for wrong panel
              animator.SetTrigger("Wrong");
              // Increase wrong answer value
              wrongNum += 1; 
          }
          correct();
          
          // When the answer is submitted, close the panel.
          blanksPanel.SetActive(false);

      }
      
      public void correct()
      {
          // Remove question from the list
          QnA.RemoveAt(currentQ);
          
          // Clear player's answer txt
          answerField.Select();
          answerField.text = "";
          
          // Generate next question
          generateQuestion();
          

      }

}
