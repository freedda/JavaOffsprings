using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ActivateItem : MonoBehaviour
{
    public GameObject hidedItem;


    public MoveItem moveItems;
    
    private bool notDone;

    private PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        notDone = true;
        hidedItem.SetActive(false);
        view = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        activated();
       
    }

    [PunRPC]
    public void activated()
    {
        view.RPC("RPC_activated", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPC_activated()
    {
        if(notDone){
            //Debug.Log("Stin Update to move in einai " + moveItems.itIsDestroyed);
            if (moveItems.itIsDestroyed)
            {
                notDone = false;
                Debug.Log("ok einai mesa stin update eprepe na einai tru");
                hidedItem.SetActive(true);
                Destroy(gameObject);
            }}
    }
}
