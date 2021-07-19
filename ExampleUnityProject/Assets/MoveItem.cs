using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    public string id;
    private string tempId;
    
    
    public Vector3 targetPos1;
    private Vector3 targetPos;
    private Vector3 prevPos;
    public float moveTime;
    float curMoveProportion = 0;
    
    // in Start, set up whichever is the first position to be going to
      
    public static MoveItem instance;
    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        targetPos = targetPos1;
        prevPos = transform.position;
    }
    // in Update, move the box around between the two points

    public void CompareId(string itemId)
    {
        tempId = itemId;
        Debug.Log("MPIKE STO COMP" + tempId);
        
        if (id.Equals(tempId))
        {
            curMoveProportion += (Time.deltaTime / moveTime);
            transform.position = Vector3.Lerp(prevPos, targetPos, curMoveProportion);
            
        }
        else
        {
            Debug.Log("U need other item");
        }
    }
    
    public bool isClose(GameObject player)
    {
        if (Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < 3)
        {
            Debug.Log("u r close, u can pick it");
        
            return true;
        }
        else
        {
            return false;
        }
    }
}
