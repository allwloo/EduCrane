using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spr_right : MonoBehaviour
{
    /*
    Vector3 target = new Vector3(1.3f , -0.06140632f, -0.05310203f);
    Vector3 target2 = new Vector3(0.834f, -0.06140632f, -0.05310203f);
    private float startTime;
    private float journeyLength = 0.466f;
    private Vector3 velocity = Vector3.zero;

    float distCovered;
    float fracJourney;
    */



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //startTime = Time.time;
        //transform.localPosition = Vector3.SmoothDamp(target2, target , ref velocity, 0.01f);
        
        if(ScanBLE.is_20ft)
            if(transform.localPosition.x > 0)
            { 
            //transform.localPosition = Vector3.SmoothDamp(target2, target , ref velocity, 0.3f);
            transform.Translate(new Vector3(-0.01f,0,0));
            }
        
        if(!ScanBLE.is_20ft)
            if(transform.localPosition.x < 0.38)
            {
            if(!ScanBLE.is_20ft)
                //transform.localPosition = Vector3.SmoothDamp(target2, target , ref velocity, 0.3f);
                transform.Translate(new Vector3(0.01f,0,0));
            }
    
        

    }

    IEnumerator moving()
    {
        yield return 0;

    }



}
