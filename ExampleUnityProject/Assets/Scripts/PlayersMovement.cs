using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class PlayersMovement : MonoBehaviour
{
    /*
     * Moving the player
     * with w-s up and down
     * and with a-d left and right
     */
    private string turnInput = ("Horizontal");
    private string verticalInput = ("Vertical");

    public float speed = 3f;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        float verticalMoveAxis = Input.GetAxis(verticalInput);
        float horizontalMoveAxis = Input.GetAxis(turnInput);
        
        //Call the movement function
        anim.SetInteger("condition", 0);
        // if (Input.GetKeyDown(KeyCode.W))
        //
        // {
          
            
            Movement(verticalMoveAxis, horizontalMoveAxis);
        //}
            //anim.SetInteger("condition", 0);
        

    }

    private void Movement(float moveZ, float moveX)
    {
            anim.SetInteger("condition", 1);
            Vector3 playerMovement = new Vector3(moveX, 0f, moveZ) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        
        
    }
    
}
