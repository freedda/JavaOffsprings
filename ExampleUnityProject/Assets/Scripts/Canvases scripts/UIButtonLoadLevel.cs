using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonLoadLevel : MonoBehaviour
{
   public string LevelToLoad;
       
       public GameObject loadingBarScreen;
       public Slider slider;
       
       public void loadLevel()
       {
          
           StartCoroutine(AsynchronousLoad(LevelToLoad));
           //Load the level from LevelToLoad
           //SceneManager.LoadScene(LevelToLoad);
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       }
   
       //its a coroutine
       IEnumerator AsynchronousLoad (string scene)
       {
           
           AsyncOperation operation = SceneManager.LoadSceneAsync(LevelToLoad);
           loadingBarScreen.SetActive(true);
           while (!operation.isDone)
           {
               Debug.Log(operation.progress);
               float progress = Mathf.Clamp01(operation.progress / .9f);
              
   
               slider.value = progress;
               //return until the next frame
               yield return null;
           }
   
   
           
       }

}


