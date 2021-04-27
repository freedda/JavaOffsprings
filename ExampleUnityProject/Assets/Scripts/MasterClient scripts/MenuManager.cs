using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
This function is responsible 
to open and close the right menu of the 
list
*/
public class MenuManager : MonoBehaviour
{
   //Creae an instacne for Menu Manager
   public static MenuManager instance;

   //Keep a list of menus
   [SerializeField] private Menu[] menus;
   
   private void Awake()
   {
      instance = this;
   }
   
   //ISWS NA EINAI PERITTO 
   //Take the name of menu
   public void OpenMenu(string name)
   {
      for (int i = 0; i < menus.Length; i++)
      {
         //If the menu exist open it
         if (menus[i].menuName == name)
         {
            menus[i].OpenIt();
         }
         //if its already open, close it
         else if(menus[i].isItOpen)  
         {
            CloseMenu(menus[i]);
         }
      }
   }
   
   //Take menu 
   public void OpenMenu(Menu menu)
   {
      for (int i = 0; i < menus.Length; i++)
      {
         //is its open, close it
         if(menus[i].isItOpen)  
         {
            CloseMenu(menus[i]);
         }
      }
      //Open menu
      menu.OpenIt();
   }
    
   //A function which close Menu
   public void CloseMenu(Menu menu)
   {
      menu.CloseIt();
   }

}
