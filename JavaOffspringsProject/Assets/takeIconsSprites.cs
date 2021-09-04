using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeIconsSprites : MonoBehaviour
{
    public static takeIconsSprites instance;
    public Sprite[] icons;
    
    private void Awake()
    {
        instance = this;
    }
}
