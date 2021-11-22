using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class port_cont : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OncollisionExit(Collision collision)
    {
        rb.isKinematic = false;

    }

    void OnCollisiononEnter(Collision collision)
    {
        rb.isKinematic = true;
    }

    void OnCollisionStay(Collision collision)
    {
        rb.isKinematic = true;
    }

}
