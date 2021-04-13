using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Inherited from PickUpItm Class
public class PickupKey : PickUpItem
{
 
    private bool isPicked=true;

    public GameObject myCanvas;
      
    // Start is called before the first frame update
    protected override void Start()
    {   
        //player component from parent class
        base.Start();
        
        //Make child changes
        if (!player)
        {
            isPicked = false;
            return;
        }

    }

    // Update is called once per frame
    protected override void Update()
    {
        ActiveCanvasWithE();
        tryToPick();
       
    }

    protected void tryToPick()
    {
        if (isPicked)
        {   if(Input.GetKeyDown("e") &&  isClose(player))
            {
                //Activate Theory 
                //myCanvas = Papyrus Canvas
                myCanvas.SetActive(true);
                Destroy(gameObject);
              

            }
        }
    }
}
