using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    
    //
    public string id;
    private string tempId;
    
    
    float curMoveProportion = 0;
    private GameObject player;

    
    // in Start, set up whichever is the first position to be going to
      
    public static MoveItem instance;
    
    private PhotonView view;
 
    public GameObject destroyedItem;

    public GameObject OtherToolPanel;

    public bool itIsDestroyed;
    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        view = GetComponent<PhotonView>();
        itIsDestroyed = false;


    }
    // in Update, find the player

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
      
        if (player == null)
        {
            // Debug.Log("DEN VRISKEI PAIKTI");
            return;
        }
    }

    [PunRPC]
    public int CompareId(string itemId)
    {
        tempId = itemId;

        Debug.Log("MPIKE STO COMP" + tempId);
        if(!isClose(player)){
            Debug.Log("EIsai Makria jas");
            StartCoroutine(OtherTool());
            return 0;
        }

       
        if (!id.Equals(tempId) )
        {
            Debug.Log("U need other item to id einai " + id + "kai to tempId " + tempId);
            StartCoroutine(OtherTool());
            return 2;
            
        }
        

        if (gameObject.tag == "Barrel" || gameObject.tag == "Flower")
        {
            MoveTheObject();
        }
        else
        {
            destroyItem();
        }
        return 1;
    }
    
    /*
     * id the gameobject is a box
     * move it and discover the hide euquipment
     * Target.ALL
     */
    [PunRPC]
    public void MoveTheObject()
    {
        view.RPC("RPC_MoveTheObject", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPC_MoveTheObject()
    {

        itIsDestroyed = true;

        curMoveProportion += (Time.fixedDeltaTime);
        transform.Translate(0, 0, 30*Time.fixedDeltaTime);

    }

    /*
     * If the object isnt a box, destroyed it to
     * find the hide object
     */
    
    [PunRPC]
    public void destroyItem()
    {
        view.RPC("RPC_destroyItem" , RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPC_destroyItem()
    {
        itIsDestroyed = true;

        Instantiate(destroyedItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
    public bool isClose(GameObject player)
    {
        if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < 2.5)
        {
            Debug.Log("u r close, u can pick it");
        
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator OtherTool()
    {
        OtherToolPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        OtherToolPanel.SetActive(false);
    }
}
