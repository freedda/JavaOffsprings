using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class UIButtonLoadLevel : MonoBehaviourPunCallbacks
{
    public string SceneToLoad;

    public void loadLevel()
    {   
        // scene manager loads the scene
        SceneManager.LoadScene(SceneToLoad);

    }
   
    

}


