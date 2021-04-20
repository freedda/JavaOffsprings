using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
   #region Singleton
   public static EquipmentManager instance;
   void Awake()
   {
      instance = this;
   }
   
   #endregion

   public Equipment[] currentEquipment;
   private Inventory inventory;
   
   void Start()
   {
      inventory = Inventory.instance;
      
      int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
      currentEquipment = new Equipment[numSlots];

   }

   public void EquipPlayer(Equipment newItem)
   {
      // get the index of the slot our new item is supposed to be inserted into
      int slotIndex = (int)newItem.equipSlot;

      Equipment oldItem = null; 
      
      if (currentEquipment[slotIndex] != null)
      {  
         // take the old item and put it back to the inventory
         oldItem = currentEquipment[slotIndex];
         inventory.AddItem(oldItem);
      }
      
      // equip with the new item
      currentEquipment[slotIndex] = newItem;

   }

   public void UnequipPlayer(int slotIndex)
   {
      if (currentEquipment[slotIndex] != null)
      {
         Equipment oldItem = currentEquipment[slotIndex];
         inventory.AddItem(oldItem);
         
         currentEquipment[slotIndex] = null;
      }
   }

   public void UnequipAll()
   {
      for (int i = 0; i < currentEquipment.Length; i++)
      {
         UnequipPlayer(i);
      }
   }

   // Unequip all when player press U key
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.U))
      {
         UnequipAll();
      }
   }
}
