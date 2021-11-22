using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxtrigger : MonoBehaviour
{

    public bool cnt;
    // Start is called before the first frame update
    void Start()
    {
        cnt = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        cnt = true;
    }
}
