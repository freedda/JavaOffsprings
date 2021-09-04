using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGameObjectActive : MonoBehaviour
{
    public GameObject house;
    
    // Start is called before the first frame update
    void Start()
    {
        house.SetActive(true);
    }
}
