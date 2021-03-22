
using UnityEngine;

[RequireComponent(typeof(FocusWithClick))]
public class PlayersController : MonoBehaviour
{
    public LayerMask aMoveMask;
    private int range = 100;
    Camera myCamera;

    private FocusWithClick move;
    private bool CanPickUP = false;
    // item must change !!
    public Item item;
    private PickUpItem pickUpItem;
//    private Transform item;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
        move = GetComponent<FocusWithClick>();

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
                Debug.Log("Focused on item");
                CanPickUP = true;
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

        if (Input.GetKeyDown("e") && CanPickUP)
        {
            CanPickUP = false;
            Debug.Log("pick up " + item.name);
            Inventory.instance.AddItem(item);
           // pickUpItem.PickUp();
            // Inventory.instance.AddItem(item);
            // Destroy(gameObject);
        }
    }
}
