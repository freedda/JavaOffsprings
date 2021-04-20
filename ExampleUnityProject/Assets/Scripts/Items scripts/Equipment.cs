using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    // paradegima to sfuri mporei na prokalei 'damage' se antikeimeno pou thelei na spasei
    public int damage;

    public override void Use()
    {
        base.Use();
        // Equip the item
        EquipmentManager.instance.EquipPlayer(this);
        //Remove item from the inventory
        Debug.Log("Removing equipment from slot");
        RemoveFromInventory();
    }
    
}

public enum EquipmentSlot{ rightHand, leftHand}
