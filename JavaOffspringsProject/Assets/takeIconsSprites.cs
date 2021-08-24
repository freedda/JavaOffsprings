using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeIconsSprites : MonoBehaviour
{
    public static takeIconsSprites instance;
    public Sprite[] icons;
    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this;
    }
}
