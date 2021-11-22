using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow5 : MonoBehaviour
{
    public GameObject gme_over1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScanBLE.is_exit)
            gme_over1.SetActive(true);
        
        if (!ScanBLE.is_exit)
            gme_over1.SetActive(false);
        
    }
}
