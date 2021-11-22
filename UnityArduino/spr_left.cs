using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spr_left : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(ScanBLE.is_20ft)
            if(this.transform.localPosition.x < 0)
            { 
            //transform.localPosition = Vector3.SmoothDamp(target2, target , ref velocity, 0.3f);
            this.transform.Translate(new Vector3(0.01f,0,0));
            }
        
        if(!ScanBLE.is_20ft)
            if(this.transform.localPosition.x > -0.38)
            {
                //transform.localPosition = Vector3.SmoothDamp(target2, target , ref velocity, 0.3f);
                this.transform.Translate(new Vector3(-0.01f,0,0));
            }
    
        
    }
}
