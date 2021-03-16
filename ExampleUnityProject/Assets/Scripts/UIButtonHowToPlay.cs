using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonHowToPlay : MonoBehaviour
{
    public GameObject CanvasActive;
    public GameObject CanvasNonActive;

    public void HowToPlay ()
    {   
        Debug.Log("How to play");
        CanvasActive.SetActive(true);
        CanvasNonActive.SetActive(false);
    }
}
