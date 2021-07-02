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
  
   // callback method to update things when equip and unequip items
   public delegate void EquipmentChanged (Equipment oldItem, Equipment newItem);
   public EquipmentChanged equipmentChanged;
   
   private Inventory inventory;
   
   void Start()
   {
      inventory = Inventory.instance;
      
      int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
      currentEquipment = new Equipment[numSlots];

   }

   //EDW TO ORISMA ISWS GINEI EPISIS STRING NEWITEM (THA FANEI)
   public void EquipPlayer(Equipment newItem)
   {
      // get the index of the slot our new item is supposed to be inserted into
      int slotIndex = (int)newItem.equipSlot;

      Equipment oldItem = null; 
      
      if (currentEquipment[slotIndex] != null)
      {  
         // take the old item and put it back to the inventory
         oldItem = currentEquipment[slotIndex];
         inventory.AddItem(oldItem.Id);
      }
      
      if (equipmentChanged != null) 
      {
         equipmentChanged.Invoke(newItem, oldItem);
      }
      
      // equip with the new item
      currentEquipment[slotIndex] = newItem;

   }

   public void UnequipPlayer(int slotIndex)
   {
      if (currentEquipment[slotIndex] != null)
      {
         Equipment oldItem = currentEquipment[slotIndex];
         inventory.AddItem(oldItem.Id);
         
         currentEquipment[slotIndex] = null;
         
         if (equipmentChanged != null) 
         {
            equipmentChanged.Invoke(null, oldItem);
         }
         
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
