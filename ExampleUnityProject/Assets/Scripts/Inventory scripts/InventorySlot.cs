using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    private string itemId;
    
    private PhotonView view;

    public GameObject theoryCanvas;
    public GameObject player;
    
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
        if (player == null)
        {
            // Debug.Log("DEN VRISKEI PAIKTI");
            return;
        }
    }

    public void AddItem(string newItemId)
    {
        itemId = newItemId;
        switch (newItemId)
        {   //Key ID
            case "02250c14-1e7b-4d55-a5e1-ce6758e5ac88":
                nameText.text = "Key";
                //Debug.Log("TO ICON EINAI "+ takeIconsSprites.instance.icons[0] + " OUUU  " + takeIconsSprites.instance.icons[0].name);
                icon.sprite = takeIconsSprites.instance.icons[0];
                break;
            case "c33c70d5-0665-4e90-aa76-6342bbe0cf50":
                nameText.text = "Hammer";
                icon.sprite = takeIconsSprites.instance.icons[1];
                break;
            case "9c2521b6-86a4-47a2-a5fd-0edf24a5c777":
                nameText.text = "Watering Can";
                icon.sprite = takeIconsSprites.instance.icons[2];
                break;
        }
        
        icon.enabled = true;
        nameText.gameObject.SetActive(true);
    }

    public void RemoveItem()
    {
        itemId = null;
        icon.enabled = false;
        nameText.text = null;
    }

    [PunRPC]
    public void ClickItem()
    {

        view.RPC("UseItem", RpcTarget.All, null);
        Debug.Log("Click apoooo " + view);
    }

    [PunRPC]
    public void UseItem()
    {
        if (itemId != null)
        {
            //if the item is a key, then activate the canvas (if the player click on inventory's button)
            if (itemId.Equals("02250c14-1e7b-4d55-a5e1-ce6758e5ac88"))
            {
                theoryCanvas.SetActive(true);
            }
            //Else use it like an equipment
            else
            {
                if (MoveItem.instance.isClose(player))
                {
                    MoveItem.instance.CompareId(itemId);

                    Item.instance.Use(itemId);
                }
                else
                {
                    Debug.Log("EISAI MAKRIAAAAAAA");
                }

            }
        }
        // if player click an empty inventoryButton
        else
        {
            Debug.Log("Select an item");
        }
    }
    
}
