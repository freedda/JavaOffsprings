using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCanvasActiveUI : MonoBehaviour
{
    public GameObject CanvasActive;
    public GameObject CanvasNonActive;

    public void activateCanvas ()
    {   
        CanvasActive.SetActive(true);
        CanvasNonActive.SetActive(false);
    }
}
