using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEditor;

public class DBscript : MonoBehaviour
{
    private string dbName = "URI=file:theory.db";
    
    // Start is called before the first frame update
    void Start()
    {   
        // Create database
        CreateDB();
        // Add a theory question with options and correct answer
      //  AddTheory(1, "Which one of these commands is correct for printing text on screen?" , "System.out.println", "system.out.println" , "System.Out.Println" , "System.out.printLn", 1);
    
        // Display records to the console 
        DisplayTheory();
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
                
                // Iterate through the recordset and display
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        
                        Debug.Log("Question ID: " +reader["questionID"] +"\n Question: " + reader["question"] + 
                                  "\n Option1: " + reader["option1"] + "\n Option2: " + reader["option2"] + "\n Option3: " + reader["option3"] + "\n Option4: " + reader["option4"] + "\n Correct Answer: " + reader["correctAnswer"]);
                    }
                    reader.Close();
                }
            }
            
            connection.Close();
        }
    }
}
