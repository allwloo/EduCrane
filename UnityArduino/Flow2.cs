using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow2 : MonoBehaviour // Flow2는 장비 작동 검사 ( 작동하는지 확인 )
{

    TTS tts = new TTS();
    high_light h_l;

    public GameObject HighLighter;
    
    public GameObject Flow1;
    public GameObject Flow3;
    public GameObject Cabin;
    public GameObject trolly;
    public TextMesh text;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    public GameObject btn8;
    public GameObject ctr1;
    public GameObject ctr2;
    public GameObject tog1;
    public GameObject tog2;

    AudioSource audioSource;


    bool check = false;

    float timer;
    int waitingTime;

    bool trigger = true;
    bool flag1 = true;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    bool flag5 = false;

    float default_y;
    float default_z;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        h_l = HighLighter.GetComponent<high_light>();
        Flow1.SetActive(false);
        StartCoroutine(Corutine());
        default_z = Cabin.transform.localPosition.z;
        default_y = trolly.transform.localPosition.y;        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(flag1)
        {
            if(trigger)
            {
                tts.Init("이제 조종실의 기능들이 활성화 되었습니다.");
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
                
            }
            if(check)
            {
                tts.Init("활성화된 버튼을 눌러 트롤리 잠금장치를 해제하십시오.");
                h_l.ParticlePlay(btn8);
                audioSource.PlayOneShot(tts.CreateAudio());
                text.text = "트롤리 잠금장치를 \n 해제하십시오";
                check = false;
            }
            if(ScanBLE.is_trolly)
            {
                h_l.ParticleStop(btn8);
                trigger = true;
                flag1 = false;
                flag2 = true;
            }
        }

        if(flag2)
        {
            if(trigger)
            {
                h_l.ParticlePlay(ctr1);
                tts.Init("오른쪽 조이스틱를 상하로 움직여 트롤리를 올려보십시오.");
                audioSource.PlayOneShot(tts.CreateAudio());
                text.text = "트롤리를 작동하십시오.";
                trigger = false;
            }
            if(trolly.transform.localPosition.y > 13)
            {
                h_l.ParticleStop(ctr1);
                trigger = true;
                flag2 = false;
                flag3 = true;
            }
        }
        
        if(flag3)
        {
            if(trigger)
            {
                h_l.ParticlePlay(btn6);
                tts.Init("활성화된 버튼을 눌러 조종실 주행장치를 해제하십시오.");
                audioSource.PlayOneShot(tts.CreateAudio());
                text.text = "조종실 잠금장치를 \n 해제하십시오.";
                trigger = false;
            }
            if(ScanBLE.is_Cabin)
            {
                h_l.ParticleStop(btn6);
                trigger = true;
                flag3 = false;
                flag4 = true;
            }
        }

        if(flag4)
        {
            if(trigger)
            {
                h_l.ParticlePlay(ctr2);
                tts.Init("왼쪽 조이스틱를 앞뒤로 움직여 조종실을 앞으로 움직이십시오.");
                audioSource.PlayOneShot(tts.CreateAudio());
                text.text = "왼쪽 조이스틱을 앞뒤로 움직이세요.";
                trigger = false;
            }
            if(Cabin.transform.localPosition.z > 3)
            {
                h_l.ParticleStop(ctr2);
                trigger = true;
                flag4 = false;
                flag5 = true;
            }
        }
        
        if(flag5)
        {
            if(trigger)
            {
                tts.Init("트롤리와 조종실을 동시에 자유롭게 움직여 보세요.");
                text.text = "10초간 자유롭게 움직이세요";
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
                Invoke("F2_1", 10);
            }
        }


    }
    

    IEnumerator Corutine()
    {
        
        yield return new WaitForSeconds(5);
        check = true;

        /*
        
        while(ScanBLE.is_trolly == false)
        {
            Debug.Log("1");
        }
            yield return 0;
        tts.Init("오른쪽 조이스틱를 상하로 움직여 트롤리를 올리고 내려보십시오.");
        tts.CreateAudio();
        while(Cabin.transform.localPosition.x == -23.18) // transform이 변경되면!
        {
            Debug.Log("2");
        }
            yield return 0;
        tts.Init("활성화된 버튼을 눌러 조종실 주행장치를 해제하십시오.");
        tts.CreateAudio();
        while(ScanBLE.is_Cabin == true)
        {
            Debug.Log("3");
        }
            yield return 0;
        tts.Init("왼쪽 조이스틱를 상하로 움직여 조종실을 앞뒤로 움직이십시오.");
        tts.CreateAudio();
        while(Cabin.transform.localPosition.z == 30.29)
        {
            Debug.Log("4");
        }
            yield return 0;
        */

    }

    void F2_1()
    {
        Flow3.SetActive(true);
    }

}


