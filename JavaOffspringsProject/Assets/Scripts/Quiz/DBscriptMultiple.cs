using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEditor;
using TMPro;

public class DBscriptMultiple : MonoBehaviour
{   
    #region Singleton
    public static DBscriptMultiple instance;
    
    void Awake()
    {
        instance = this;
    }
    #endregion
    
    private string dbName = "URI=file:theoryMultiple.db";
    private string option;
    private int currentQ;
    public GameObject[] options;
    public TextMeshProUGUI QTxt;
   
    public int correctNum = 0;
    public int wrongNum = 0;
    
    
    [System.Serializable]
    public class QuestionAndAnswers
    {
        public string Question;
        public string[] Answers;
        public string correctAnswer;
        public int correctAnswerIndex;
    }
    
     public List<QuestionAndAnswers> QnA = new List<QuestionAndAnswers>();
    
    // Start is called before the first frame update
    void Start()
    {   
        
        // Create database
        CreateDB();
        // Add a theory question with options and correct answer
       // AddTheory(13, " " , " ", " " , " " , " ", 4);
        
        // Display records to the console 
        DisplayTheory();
        // Reverse list
        QnA.Reverse();
        
        //Generate the first question 
        generateQuestion();
    }
    
    
    public void CreateDB()
    {
        // Create database connection
        using(var connection = new SqliteConnection(dbName))
        { 
            connection.Open();
            using (var command = connection.CreateCommand())
            {   
                // Create a table "theory" if it doesnt exist already  
                command.CommandText = "CREATE TABLE IF NOT EXISTS theory (questionID INT PRIMARY KEY, question VARCHAR(50), option1 VARCHAR(30), option2 VARCHAR(30), option3 VARCHAR(30), option4 VARCHAR(30), correctAnswer INT );";
                command.ExecuteNonQuery();
            }
            // Close database connection
            connection.Close();
        }
    }

    public void AddTheory(int questionID, string question, string option1, string option2, string option3, string option4, int correctAnswer)
    {   
        // Create database connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {   
                // Insert record to the database 
                command.CommandText = "INSERT INTO theory (questionID,question, option1, option2, option3, option4, correctAnswer) VALUES ('" +questionID+ "', '" + question + 
                                      "' , '" + option1 + "' , '" + option2 + "' , '" +option3 + "' , '"  + option4 + "' , '" + correctAnswer + "');";
                command.ExecuteNonQuery();
            }
            
            // Close database connection
            connection.Close();
        }
        
    }

    public void DisplayTheory()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // Select from the database
                command.CommandText = "SELECT * FROM theory ORDER BY questionID;";
              //  command.CommandText = "DELETE FROM theory WHERE questionID =7";
                // Iterate through the recordset and display
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        // Get question's ID. IDs start from 1, we want to count from 0 
                        currentQ = Convert.ToInt16(reader["questionID"])-1;
                        Debug.Log("ID: " + currentQ);
                        
                        // Get question from the db
                        QnA[currentQ].Question = reader["question"].ToString();
                        Debug.Log(QnA[currentQ].Question);
                        
                        // Get correct answer index 
                        QnA[currentQ].correctAnswerIndex = Convert.ToInt32(reader["correctAnswer"]) - 1;
                        Debug.Log(QnA[currentQ].correctAnswerIndex);
                        
                        option = "option" + reader["correctAnswer"];
                        QnA[currentQ].correctAnswer = reader[option].ToString();
                        Debug.Log(QnA[currentQ].correctAnswer);
                        // Get answer's options
                        for (int i = 0; i < options.Length; i++)
                        {   
                            options[i].GetComponent<AnswerScript>().isCorrect = false;
                            // Using a string with an int in the end to store the options in the db
                            option = "option" + (i+1).ToString();
                            QnA[currentQ].Answers[i] = reader[option].ToString();
                            Debug.Log(QnA[currentQ].Answers[i]);
                        }
                       // Display question's ID, question, options and correct answer
                       // Debug.Log("Question ID: " +reader["questionID"] +"\n Question: " + reader["question"] + 
                         // "\n Option1: " + reader["option1"] + "\n Option2: " + reader["option2"] + "\n Option3: " + reader["option3"] + "\n Option4: " + reader["option4"] + "\n Correct Answer: " + reader["correctAnswer"]);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
    public void correct()
    {   
        // Remove question from the list
        QnA.RemoveAt(currentQ);
        // Generate next question
        generateQuestion();
    }
    
    void generateQuestion()
    {
        for (int i = 0; i < QnA.Count; i++)
        {
            currentQ = i;
            QTxt.text = QnA[currentQ].Question;
           // correctAnswerText.text = QnA[currentQ].correctAnswer;
            setAnswers();
        }
        //currentQ = UnityEngine.Random.Range(0, QnA.Count-1);
        QTxt.text = QnA[currentQ].Question;
        // correctAnswerText.text = QnA[currentQ].correctAnswer;
        setAnswers();
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponent<AnswerScript>().correctAnswer = QnA[currentQ].correctAnswer;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQ].Answers[i];
            if (QnA[currentQ].correctAnswerIndex == (i))
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
            }
        }
            
    }
    
}
