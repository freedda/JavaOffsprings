using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    
    private GameObject player;

    public float radius = 1.5f;

    private string playerTag = ("Player");
    private bool isPicked=true;
    public GameObject papyrusCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag (playerTag);
        if (!player)
        {
            isPicked = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {   if(Input.GetKeyDown("e") && (Vector3.Distance(player.transform.position, this.transform.position) < radius))
            {
                papyrusCanvas.SetActive(true);
                Destroy(gameObject);

            }
        }
    }
}
