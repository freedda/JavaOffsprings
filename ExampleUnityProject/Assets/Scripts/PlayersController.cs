
using UnityEngine;

[RequireComponent(typeof(PlayersMovement))]
public class PlayersController : MonoBehaviour
{
    public LayerMask aMoveMask;
    private int range = 100;
    Camera myCamera;

    private PlayersMovement move;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
        move = GetComponent<PlayersMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        //If pressed left button down from mouse
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit castHit;

            if (Physics.Raycast(ray, out castHit, range, aMoveMask))
            {
                //Move our player to what we hit with a left click    
                move.movementTarget(castHit.point);
            }
        }
        
        //1 = right click mouse
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit castHit;

            if (Physics.Raycast(ray, out castHit, range))
            {
                // Focused on item if we hit an interactable item
            }
        }
    }
}
