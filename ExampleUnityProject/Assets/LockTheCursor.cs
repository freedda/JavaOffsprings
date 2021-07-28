using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTheCursor : MonoBehaviour
{
    private bool isLocked;

    void Start(){
        
        isLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isLocked = false;
        }
        
        if (!isLocked) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void LockCursor()
    {
        //Press this button to lock the Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLocked = true;
        
        
    }
}
