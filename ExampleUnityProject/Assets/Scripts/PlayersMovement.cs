using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    // private string turnInput = ("Horizontal");
    // private string verticalInput = ("Vertical");

    public float speed = 3f;
    Animator anim;


    private Vector3 direction;
    private void Start()
    {
        anim = GetComponent<Animator>();


    }

    private void Update()
    {
        // float verticalMoveAxis = Input.GetAxis(verticalInput);
        // float horizontalMoveAxis = Input.GetAxis(turnInput);
        
        
            //Call the movement function
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetInteger("condition", 1);
                direction = transform.TransformDirection(new Vector3(0, 0, -1) * speed);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("condition", 0);
                direction = transform.TransformDirection(new Vector3(0, 0, 0) * speed);
            }


            if (Input.GetKeyDown(KeyCode.W))
            { 
                anim.SetInteger("condition", 1);
               direction = transform.TransformDirection(new Vector3(0, 0, 1) * speed);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
               direction = transform.TransformDirection(new Vector3(0, 0, 0) * speed);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetInteger("conditionL", 3);
                direction = transform.TransformDirection(new Vector3(-1, 0, 0) * speed);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("conditionL", 0);
               direction = transform.TransformDirection(new Vector3(0, 0, 0) * speed);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetInteger("conditionR", 2);
                direction = (new Vector3(1, 0, 0) * speed);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetInteger("conditionR", 0);
                direction = transform.TransformDirection(new Vector3(0, 0, 0) * speed);
            }

        
            
        //call movement function
        Movement(direction);
        

    }

    private void Movement(Vector3 direction)
    {
        
        transform.Translate(direction * Time.deltaTime, Space.Self);
        
        
    }
    
}
