using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using  Photon.Pun;
using UnityEngine;


public class sceneManager : MonoBehaviourPunCallbacks
{
    
    public static sceneManager Instance;

    private void Awake()
    {
        //Check if a another scene already exists
        if (Instance)
        { 
            //destroy it
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += LoadRightScene;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= LoadRightScene;
    }

    void LoadRightScene(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.buildIndex == 1)
        {
            //access to the path class
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PrefabsPlayerManager"),
                new Vector3(81,30,-112), Quaternion.identity);
        }
    }


}
