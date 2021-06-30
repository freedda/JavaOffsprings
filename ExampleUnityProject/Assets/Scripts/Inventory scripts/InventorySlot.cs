using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    private Item item;

    public GameObject theoryCanvas;
    /*public void Start()
    {
        icon.enabled = false;
    }*/
    
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        nameText.text = item.name;
        icon.enabled = true;
        nameText.gameObject.SetActive(true);
    }

    public void RemoveItem()
    {
        item = null;
        icon.enabled = false;
        nameText.text = null;
    }

    public void UseItem()
    {
        if (item != null)
        {
            //if the item is a key, then activate the canvas (if the player click on inventory's button)
            if (item.name.Equals("Key"))
            {
                theoryCanvas.SetActive(true);
            }
            //Else use it like an equipment
            else
            {
                item.Use();
            }
        }
        // if player click an empty inventoryButton
        else
        {
            Debug.Log("Select an item");
        }
    }
    
}
