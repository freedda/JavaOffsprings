using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonExitGame : MonoBehaviour
{
    public void Quit () 
    {
        // For testing.Show "QUIT" in console.
        //Debug.Log("QUIT");
        
        // Close the application.
        Application.Quit();
    }
}
