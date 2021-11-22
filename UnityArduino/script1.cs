using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour
{

    public AudioClip audioTrolly1;//위아래
    public AudioClip audioTrolly2;//위아래
    public AudioClip audioTrolly3;//위아래
    public AudioClip audioAlert;//경고음
    public AudioClip audioFit;//체결
    public AudioClip audioCrash;//충돌

    AudioSource audioSource;

    bool tmp2 = false;
    
    float cnt = 0;
    float a;

    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void PlaySound(string action) {
        switch (action) {
            case "Trolly1":
                audioSource.clip = audioTrolly1;
                break;
            case "Trolly2":
                audioSource.clip = audioTrolly2;
                break;
            case "Trolly3":
                audioSource.clip = audioTrolly3;
                break;
            case "Alert":
                audioSource.clip = audioAlert;
                break;
            case "Fit":
                audioSource.clip = audioFit;
                break;
            case "Crash":
                audioSource.clip = audioCrash;
                break;    
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Corutine());


        
//         if(y1<640) // 트롤리
//         {
//             tmp1 = true;
//             PlaySound("Cabin2");
//             Debug.Log("script의 함수 실행은됨");
//             //audioSource.volume=-y1+800;
//             if(tmp1&&cnt==0)
//             {
//                 audioSource.Play();
//                 Debug.Log("소리난당");
//                 cnt=cnt+1;
//             }
//         }else if(y1>900)
//         {
//             tmp1 = true;
//             PlaySound("Cabin2");
//             Debug.Log("script의 함수 실행은됨");

//             //audioSource.volume=y1-800;
//             if(tmp1&&cnt==0)
//             {
//                 audioSource.Play();
//                 Debug.Log("소리난당");
//                 cnt=cnt+1;
//             }
//         }else{
//             cnt = 0;
//             audioSource.Stop();
//         }
        if(ScanBLE.is_start&&ScanBLE.is_trolly)
        {
            if(ScanBLE.y2<640)
            {
                tmp2 = true;
                PlaySound("Trolly2");
                a=(-ScanBLE.y2)+640;
                a/=640;
                Debug.Log("y2의a값입니다: "+a+"/ y2의 값:"+ScanBLE.y2);
                audioSource.volume=a;
                if(tmp2&&cnt==0)
                {
                    audioSource.Play();
                    Debug.Log("위소리난당y2:"+a);
                    cnt=cnt+1;
                }
            }
            else if(ScanBLE.y2>900)
            {
                tmp2 = true;
                PlaySound("Trolly2");
                a=ScanBLE.y2-900;
                a/=100;
                Debug.Log("y2의a값입니다: "+a+ "/ y2의 값:"+ScanBLE.y2);
                audioSource.volume=a;
                if(tmp2&&cnt==0)
                {
                    audioSource.Play();
                    Debug.Log("아래소리난당y2"+a);
                    cnt=cnt+1;
                }
            }
            else{
                cnt = 0;
                audioSource.Stop();
            }
        }
    }

    IEnumerator Corutine()
    {
        yield return new WaitForSeconds(3f);
    }
}

