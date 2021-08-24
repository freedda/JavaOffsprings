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
            case "b50247dc-8ec9-46c7-937c-5d1425810f52":
                nameText.text = "Hammer";
                icon.sprite = takeIconsSprites.instance.icons[1];
                objectTag = "Box";
                break;
            case "9c2521b6-86a4-47a2-a5fd-0edf24a5c777":
                nameText.text = "Watering Can";
                icon.sprite = takeIconsSprites.instance.icons[2];
                objectTag = "Flower";
                break;
            case "27ce03e1-1780-4f03-bfc1-65ff17fcbfea":
                nameText.text = "Axe";
                icon.sprite = takeIconsSprites.instance.icons[3];
                objectTag = "Basket";
                break;
            case "91dad548-723a-474b-a89e-ab4606f1492b":
                nameText.text = "Hoe";
                icon.sprite = takeIconsSprites.instance.icons[4];
                objectTag = "FlowerPot";
                break;
            case "e5bdaf11-a79b-4436-8422-2c063ac7cc42":
                nameText.text = "Nails";
                icon.sprite = takeIconsSprites.instance.icons[5];
                break;
            case "42a57c99-52c6-4ee0-bd84-1032112f959a":
                nameText.text = "Pickaxe";
                icon.sprite = takeIconsSprites.instance.icons[6];
                objectTag = "Pitcher";
                break;
            case "648ca90a-9168-4b30-ad30-fea8f5275ce4":
                nameText.text = "Saw";
                icon.sprite = takeIconsSprites.instance.icons[7];
                objectTag = "Wood";
                break;
            case "3d48b44b-3e22-4f1b-a274-36890d659094":
                nameText.text = "Shovel";
                icon.sprite = takeIconsSprites.instance.icons[8];
                objectTag = "Sack";
                break;
            case "578ab2af-36db-4f40-8d1c-662d854c8cf6":
                nameText.text = "Sickle";
                icon.sprite = takeIconsSprites.instance.icons[9];
                objectTag = "Barrel";
                break;  
            case "c0f922b8-1122-4e50-8839-93a08ec7c1a3":
                nameText.text = "Scissor";
                icon.sprite = takeIconsSprites.instance.icons[10];
                objectTag = "Grain";
                break;  
            case "60b4f560-252d-4e7b-9a3a-f59dc79fefd8":
                nameText.text = "Matches";
                icon.sprite = takeIconsSprites.instance.icons[11];
                objectTag = "Candles";
                break;  
            case "c4d08953-af47-4048-beb6-1cfce7abcc41":
                nameText.text = "Stone";
                icon.sprite = takeIconsSprites.instance.icons[12];
                objectTag = "Bottle";
                break;  
            case "e4904d6a-64e3-4500-be92-7f3a7d13bfc8":
                nameText.text = "Crowbar";
                icon.sprite = takeIconsSprites.instance.icons[13];
                objectTag = "WoodenBox";
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
