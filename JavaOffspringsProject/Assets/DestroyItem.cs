using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    public GameObject destroyedItem;

    private void OnMouseDown()
    {
        Instantiate(destroyedItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
