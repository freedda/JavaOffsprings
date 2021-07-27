using System;
using System.Linq;
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

    private string objectTag;

    private GameObject findTheObject;
    private MoveItem moveItemsObject;
    
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
                objectTag = "Box";
                break;
            case "9c2521b6-86a4-47a2-a5fd-0edf24a5c777":
                nameText.text = "Watering Can";
                icon.sprite = takeIconsSprites.instance.icons[2];
                break;
            case "27ce03e1-1780-4f03-bfc1-65ff17fcbfea":
                nameText.text = "Axe";
                icon.sprite = takeIconsSprites.instance.icons[3];
                objectTag = "Basket";
                break;
            case "0c217d02-9e3d-4633-8171-826d75d922c0":
                nameText.text = "Hoe";
                icon.sprite = takeIconsSprites.instance.icons[4];
                break;
            case "e5bdaf11-a79b-4436-8422-2c063ac7cc42":
                nameText.text = "Nails";
                icon.sprite = takeIconsSprites.instance.icons[5];
                break;
            case "42a57c99-52c6-4ee0-bd84-1032112f959a":
                nameText.text = "Pickaxe";
                icon.sprite = takeIconsSprites.instance.icons[6];
                break;
            case "648ca90a-9168-4b30-ad30-fea8f5275ce4":
                nameText.text = "Saw";
                icon.sprite = takeIconsSprites.instance.icons[7];
                break;
            case "3d48b44b-3e22-4f1b-a274-36890d659094":
                nameText.text = "Shovel";
                icon.sprite = takeIconsSprites.instance.icons[8];
                break;
            case "6337484d-d404-4a26-b38c-6f36fd9437ea":
                nameText.text = "Sickle";
                icon.sprite = takeIconsSprites.instance.icons[9];
                break;  
        }
        
        icon.enabled = true;
        nameText.gameObject.SetActive(true);
    }

    [PunRPC]
    public void RemoveItem()
    {
        itemId = null;
        icon.enabled = false;
        nameText.text = null;
    }

    [PunRPC]
    public void ClickItem()
    {

        view.RPC("UseItem", RpcTarget.AllBuffered);
        Debug.Log("Click apoooo " + view);
    }

    [PunRPC]
    public void UseItem()
    {
        if (itemId != null)
        {

            findTheObject = GetNearestTarget();
                moveItemsObject = (MoveItem) findTheObject.GetComponent(typeof(MoveItem));

                if (moveItemsObject.CompareId(itemId) == 1)
                {
                    Item.instance.Use(itemId);
                    Inventory.instance.RemoveItem(itemId);
                    //Debug.Log("OK EINAI edw");
                } 


            
        }
        // if player click an empty inventoryButton
        else
        {
            Debug.Log("Select an item");
        }
    }

   
    
    private GameObject GetNearestTarget()
    {
       //Find the closest object between the player and the object to use the equipment
        return GameObject.FindGameObjectsWithTag(objectTag).Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, player.transform.position) > Vector3.Distance(o2.transform.position, player.transform.position) ? o2 : o1);
    }

    public void useKeyNotRpc()
    {
        if (itemId != null)
        {

            //if the item is a key, then activate the canvas (if the player click on inventory's button)
            if (itemId.Equals("02250c14-1e7b-4d55-a5e1-ce6758e5ac88"))
            {
                theoryCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Select an item");
            }
        }
    }
}
