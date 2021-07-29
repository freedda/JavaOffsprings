using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePage : MonoBehaviour
{
    public GameObject page;

    private bool flag;
    // Start is called before the first frame update
    void Awake()
    {
        flag = true;
        page.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enabled && flag)
        {
            page.SetActive(true);
            flag = false;
        }

        
    }
}
