using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

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


    private void Update()
    {
        float verticalMoveAxis = Input.GetAxis(verticalInput);
        float horizontalMoveAxis = Input.GetAxis(turnInput);

        //Call the movement function
        Movement(verticalMoveAxis, horizontalMoveAxis);
    }

    private void Movement(float moveZ, float moveX)
    {
            
        Vector3 playerMovement = new Vector3(moveX, 0f, moveZ) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
    
}
