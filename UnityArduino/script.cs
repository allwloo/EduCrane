using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public AudioClip audioCabin1;//앞뒤
    public AudioClip audioCabin2;//앞뒤
    public AudioClip audioCabin3;//앞뒤

    AudioSource audioSource;

    bool tmp = false;
    
    float cnt = 0;
    float a;


    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void PlaySound(string action) {
        switch (action) {
            case "Cabin1":
                audioSource.clip = audioCabin1;
                break;
            case "Cabin2":
                audioSource.clip = audioCabin2;
                break;
            case "Cabin3":
                audioSource.clip = audioCabin3;
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
        


        if(ScanBLE.is_start && ScanBLE.is_Cabin)
        {
            if(ScanBLE.y1<640) // 트롤리
            {
                tmp = true;
                PlaySound("Cabin2");
                //Debug.Log("script의 함수 실행은됨");
                a=-ScanBLE.y1+640;
                a/=640;
                Debug.Log("y1의a값입니다: "+a+"/ y1의 값:"+ScanBLE.y1);
                audioSource.volume=a;
                if(tmp&&cnt==0)
                {
                    audioSource.Play();
                    Debug.Log("앞소리난당y1"+a);
                    cnt=cnt+1;
                }

            }
            else if(ScanBLE.y1>900)
            {
                tmp = true;
                PlaySound("Cabin2");
                a=ScanBLE.y1-900;
                a/=100;
                Debug.Log("y1의a값입니다:   "+a+"/ y1의 값:"+ScanBLE.y1);
                audioSource.volume=a;
                
                audioSource.volume=a;
                if(tmp&&cnt==0)
                {
                    audioSource.Play();
                    Debug.Log("뒤소리난당y1"+a);
                    cnt=cnt+1;
                }
            }
            else
            {
                cnt = 0;
                audioSource.Stop();
            }
        }
    }

    IEnumerator Corutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log(cnt);
    }
}

