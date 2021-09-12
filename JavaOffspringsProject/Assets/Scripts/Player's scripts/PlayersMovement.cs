using UnityEngine;
using Photon.Pun;
using Photon.Voice;

public class PlayersMovement : MonoBehaviourPun, IPunObservable
{
    /*
     * Moving the player
     * with w-s up and down
     * and with a-d left and right 
     */
    [SerializeField] private string turnInput = ("Horizontal");
    [SerializeField] private string verticalInput = ("Vertical");

    //Player's Speed
    public float speed = 2f;
    
    Rigidbody rb;
    
    //Player's animation for walking
    Animator anim;
    public bool flagMove = true;

    PhotonView view;
    public static PlayersMovement instance;
    
    private Vector3 realPosition;
    private Quaternion realRotation;
    
   
    void Awake()
    {
        //Initialize the rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
        
        //Initialize the PhotonView
        view = GetComponent< PhotonView >();
        
        //Take the instance of this class
        instance = this; 
    }
    
    
    private void Start()
    {
    
        //Keep player's position and rotation 
        realPosition = Vector3.zero;
        realRotation = Quaternion.identity;
        
        
        if (!view.IsMine)
        {
            //Destroy Camera and Rigidbody of other players
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
        else
        {
            //Get the animator Component
            anim = GetComponent<Animator>();
        }


    }

    private void FixedUpdate()
    {
        if (!view.IsMine)
        {
            return;

        }
        //Get Vertical Axis
        float verticalMoveAxis = Input.GetAxis(verticalInput);
        
        //Get Horizontal Axis
        float horizontalMoveAxis = Input.GetAxis(turnInput);

        
        //Calculate player's velocity
        rb.velocity = new Vector3(horizontalMoveAxis * speed * Time.deltaTime, rb.velocity.y,
            verticalMoveAxis * speed * Time.deltaTime);

        //If the flag is false, the player is inside the Temple
        if (!flagMove){
            
            //Player's Immobilization
            anim.SetInteger("conditionL", 0); 
            anim.SetInteger("conditionR", 0); 
            anim.SetInteger("condition", 0);
            return;
        }
        
        
        if (rb.velocity.z >0.01 || rb.velocity.z < -0.01)
        {   
            //Walking straight 
            anim.SetInteger("condition", 1);
            transform.Translate(rb.velocity, Space.Self);

        }
        else

        {
            
            //Stop Walking
            anim.SetInteger("condition", 0);
            transform.Translate(rb.velocity, Space.Self);

        }

        if (rb.velocity.x > 0.01)
        {   
            //Walking Right
            anim.SetInteger("conditionR", 2);
            transform.Translate(rb.velocity, Space.Self);

        }
        else
        {
            //Stop Walking
            anim.SetInteger("conditionR", 0);
            transform.Translate(rb.velocity, Space.Self);

        }
        
        if (rb.velocity.x < -0.01)
        {   
            //Walking Left
            anim.SetInteger("conditionL", 3);
            transform.Translate(rb.velocity, Space.Self);

        }
        else
        {
            //Stop Walking
            anim.SetInteger("conditionL", 0);
            transform.Translate(rb.velocity, Space.Self);

        }

    }

    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
         //if the player is writing then send his position and rotation to other
         if (stream.IsWriting)
         {
             
             // This is OUR player. We need to send our actual position to the network.
             stream.SendNext(transform.position);
             stream.SendNext(transform.rotation);
         }
         //else receive his position and his rotation
         else
         {
             // This is someone else's player. We need to receive their position (as of a few
             // millisecond ago, and update our version of that player.
             realPosition = (Vector3) stream.ReceiveNext();
             realRotation = (Quaternion) stream.ReceiveNext();
             
 
         }
    }
    
}
