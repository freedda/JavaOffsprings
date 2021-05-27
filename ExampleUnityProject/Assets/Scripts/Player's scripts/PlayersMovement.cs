using UnityEngine;
using Photon.Pun;

public class PlayersMovement : MonoBehaviourPun
{
    /*
     * Moving the player
     * with w-s up and down
     * and with a-d left and right
     */
    [SerializeField] private string turnInput = ("Horizontal");
    [SerializeField] private string verticalInput = ("Vertical");

    public float speed = 2f;
    Rigidbody rb;

    Animator anim;


    private Vector3 direction;
    PhotonView view;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent< PhotonView >();
        
    }
    private void Start()
    {
        if (!view.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
        else
        {
            anim = GetComponent<Animator>();
        }


    }

    private void Update()
    {
        
        if (!view.IsMine)
        {
            return;
        }
        
        float verticalMoveAxis = Input.GetAxis(verticalInput);
        float horizontalMoveAxis = Input.GetAxis(turnInput);
        
        
        rb.velocity = new Vector3 (horizontalMoveAxis * speed * Time.deltaTime, rb.velocity.y, verticalMoveAxis * speed * Time.deltaTime);

        if (rb.velocity.z >0.01 || rb.velocity.z < -0.01)
        {   
            anim.SetInteger("condition", 1);
            transform.Translate(rb.velocity, Space.Self);

        }
        else

        {
            anim.SetInteger("condition", 0);
            transform.Translate(rb.velocity, Space.Self);

        }

        if (rb.velocity.x > 0.01)
        {   
            anim.SetInteger("conditionR", 2);
            transform.Translate(rb.velocity, Space.Self);

        }
        else
        {
            anim.SetInteger("conditionR", 0);
            transform.Translate(rb.velocity, Space.Self);

        }
        
        if (rb.velocity.x < -0.01)
        {   
            anim.SetInteger("conditionL", 3);
            transform.Translate(rb.velocity, Space.Self);

        }
        else
        {
            anim.SetInteger("conditionL", 0);
            transform.Translate(rb.velocity, Space.Self);

        }

    }

    
    
}
