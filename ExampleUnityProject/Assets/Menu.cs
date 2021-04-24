using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    
    public string menuName;
    public bool isItOpen;

    public void OpenIt()
    {
        isItOpen = true;
        gameObject.SetActive(true);
    }
    
    public void CloseIt()
    {
        isItOpen = false;
        gameObject.SetActive(false);
    }
}
