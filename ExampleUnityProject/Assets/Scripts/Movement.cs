using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private string turnInput = ("Horizontal");
    private string moveInput = ("Vertical");

    public float speed = 3f;
    public float rotation = 360; 
    
    
    
    #region Monobehaviour API
  
    private void Update()
    {
        float moveAxis = Input.GetAxis(moveInput);
        float turnAxis = Input.GetAxis(turnInput);

        ApplyInput(moveAxis, turnAxis);
    }

    private void ApplyInput(float move, float turn)
    {
       // PlayerMove(move);
        //PlayerTurn(turn);

        //Diaforetika vazw se sxolia tin playermove kai turn kai ektelw ta parakatw
        //Kai apo to look with the mouse vgale to sxolio stin grammi 26
        Vector3 playerMovement = new Vector3(turn, 0f, move) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void PlayerTurn(float input)
    {
        
        transform.Rotate(0, input * rotation * Time.deltaTime, 0);
        
    }
  
    private void PlayerMove(float input)
    {
        
        transform.Translate(Vector3.forward * input * speed * Time.deltaTime);
    }


    #endregion
}
