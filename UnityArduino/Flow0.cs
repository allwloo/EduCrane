using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Flow0 : MonoBehaviour//튜토리얼 실전운행 선택
{
    bool tutorial = false;
    bool actual = false;

    public GameObject Flow1;
    public GameObject OVR1;
    public GameObject Cabin;
    public GameObject Video;
    VideoPlayer vid;

    
    
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    { 
        if(ScanBLE.is_fliper)
            OnClickTutorial();
        if(ScanBLE.is_Cabin)
            OnClickactual();

    }

    public void OnClickTutorial(){
        vid = Video.GetComponent<VideoPlayer>();
        vid.Play();
        OVR1.transform.parent = Cabin.transform;
        OVR1.transform.localPosition = new Vector3(0, 1, -0.5f);
        OVR1.transform.eulerAngles = new Vector3(0, 0, 0);
        
        Invoke("f1", 8);
        
    }

    public void OnClickactual(){
        vid = Video.GetComponent<VideoPlayer>();
        vid.Play();
        OVR1.transform.parent = Cabin.transform;
        OVR1.transform.localPosition = new Vector3(0, 1, -0.5f);
        OVR1.transform.eulerAngles = new Vector3(0, 0, 0);

        
        Invoke("f2", 8);
        
    } 

    public void f1(){
        tutorial = true;
        Flow1.SetActive(true);
        vid.Stop();

        
    }

    public void f2(){
        actual = true;
        Flow1.SetActive(true);
        vid.Stop();

        Debug.Log("실버튼클릭");

        
    }
}
