using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rotate4 : MonoBehaviour
{ // 0 0 0 -> -180 0 90

    bool trigger = true;
    bool edge;


    //Vector3 target3 = new Vector3(0, 0, 0.5f);

    

    

    // Start is called before the first frame update
    void Start()
    {
         
        
    }

    // Update is called once per frame
    void Update()
    { 

    
        float a = transform.rotation.eulerAngles.x;
        //Debug.Log("x값은"+a);
        
        if(edge != ScanBLE.is_fliper)
            trigger = true;
        
        //transform.rotation = Quaternion.Slerp(zero, one, Time.deltaTime);
        if(!ScanBLE.is_fliper)
        {
            edge = false;
            if(trigger)
                transform.Rotate(Vector3.left*1.5f);
            if(a > 269 && a < 271)
                trigger = false;
        }
        if(ScanBLE.is_fliper)
        {   
            edge = true;
            if(trigger)
                transform.Rotate(Vector3.right*1.5f);
            if(a > 85 && a < 86)
                trigger = false;
        }
        
        /*
        float a = transform.rotation.eulerAngles.x;

        if(edge != ScanBLE.is_fliper)
            trigger = true;

        if(ScanBLE.is_fliper)
        { 
            edge = true;
            if(trigger)
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + 180f * Vector3.down, Time.deltaTime*0.3f);
            if(a == 90)
                trigger = false;
        }

        if(!ScanBLE.is_fliper)
        { 
            edge = false;
            if(trigger)
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + 180f * Vector3.up, Time.deltaTime*0.3f);
            if(a == 270)
                trigger = false;
        }
        */

        



        /*

        
        float a = transform.rotation.eulerAngles.x;
        Debug.Log(a);

        if(edge != ScanBLE.is_fliper)
            trigger = true;


        if(ScanBLE.is_fliper)
        {
            if(trigger)
                transform.Rotate(Vector3.down, 0.46f, Space.Self);
            if(89 < a && a < 90)
                trigger = false;
        }

        if(!ScanBLE.is_fliper)
        {
            if(trigger)
                transform.Rotate(Vector3.up, 0.46f, Space.Self);
            if(268 < a && a < 294)
            {
                trigger = false;
                Debug.Log("제발제발제발제발제발제발");
            }
            Debug.Log(a);
        }
        */
        
    }

    void RotatePathblock()
    {
    }
}


// -90 0 -45 -> -270 45 -90 // -180 45 -45