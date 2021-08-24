using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{   
    
    public float windIntensity = 0.8f;
   
    public Vector3 direction = new Vector3 (0, 0, 1);
    private float seed;

    private Vector3 initialEulerAngles;

    void Start () {
        seed = Random.Range (0.5f, 1.5f);	
        initialEulerAngles = transform.eulerAngles;
    }


    void Update () {
        float rotateFactor = Mathf.Sin (Time.time * seed ) * windIntensity;	

       // Vector3 rot = new Vector3 (rotateFactor, initialEulerAngles.y, rotateFactor);
       Vector3 rot = new Vector3 (rotateFactor, initialEulerAngles.y, rotateFactor);
        transform.eulerAngles = rot;



			
    }
    
}
