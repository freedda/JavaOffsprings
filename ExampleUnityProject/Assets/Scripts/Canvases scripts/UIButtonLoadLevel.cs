using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonLoadLevel : MonoBehaviour
{
    public string LevelToLoad;

    public void loadLevel()
    {
        //Load the level from LevelToLoad
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}


