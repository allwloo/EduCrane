using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colidersize : MonoBehaviour
{
    public BoxCollider b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScanBLE.is_20ft)
        {
            b.size = new Vector3(12.2860193f,3.01873446f,4.12371635f);
            b.center = new Vector3(2.26807833f,-11.0093775f,5.67534637f);
        }
        else
        {
            b.center = new Vector3(2.20016956f,-11.0093775f,5.67534637f);
            b.size = new Vector3(17.6871204f,3.01873446f,4.12371635f);
        }
        
    }
}
