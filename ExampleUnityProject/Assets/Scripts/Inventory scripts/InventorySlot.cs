using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    private Item item;

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

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
        // if player click an empty inventoryButton
        else
        {
            Debug.Log("Select an item");
        }
    }
    
}
