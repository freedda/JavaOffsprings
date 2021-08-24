using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class UIButtonLoadLevel : MonoBehaviourPunCallbacks
{
    public string LevelToLoad;


    public GameObject loadingBarScreen;
    public Slider slider;
       
    public void loadLevel() {
          
        StartCoroutine(AsynchronousLoad(LevelToLoad));
         
    }
   
    //its a coroutine
    IEnumerator AsynchronousLoad (string scene)
    {
           
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelToLoad);
        
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


