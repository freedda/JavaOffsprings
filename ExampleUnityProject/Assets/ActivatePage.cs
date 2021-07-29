using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePage : MonoBehaviour
{
    public GameObject page;
    // Start is called before the first frame update
    void Awake()
    {
        page.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.enabled)
            page.SetActive(true);
    }
}
