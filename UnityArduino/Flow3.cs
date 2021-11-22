using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow3 : MonoBehaviour //  작업 위치로 이동
/*
    기울기 조정 -> 컨테이너 코너 피팅에 끼우기
    착상램프 점등 확인, 트위스트 콘 체결
    30cm 들어올리기 -> 끝까지 들어올리면서 모든 플리퍼 상승
    부두로 이동, 양화지점 30cm에서 일시 정지
    착륙 후 트위스터콘 해제
*/

{

    TTS tts = new TTS();

    public GameObject HighLighter;
    public GameObject trig_30m;

    public GameObject Flow0;
    public GameObject Flow2;
    public GameObject Flow4;
    public GameObject Cabin;
    public GameObject trolly;
    public GameObject cube;

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

    public GameObject up;
    public GameObject down;
    public GameObject go;
    public GameObject back;
    public GameObject stop;
    public GameObject end;
    
    public TextMesh text;

    public AudioClip bgm;//앞뒤

    AudioSource audioSource;
    boxtrigger box;
    high_light h_l;

    





    bool trigger = true;
    bool flag1 = true;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    bool flag5 = false;
    bool flag6 = false;
    bool flag7 = false;
    bool flag8 = false;


    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        Flow0.SetActive(false);
        ScanBLE.is_trolly = true;
        ScanBLE.is_Cabin = true;
        ScanBLE.is_start = true;
        ScanBLE.is_20ft = false;
        ScanBLE.is_fixed = false;
        ScanBLE.is_fliper = false;
        ScanBLE.is_exit = false;
        ScanBLE.is_move = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgm;
        audioSource.Play();
        if(!audioSource.isPlaying){
            audioSource.Play();
        }
        h_l = HighLighter.GetComponent<high_light>();
        box = trig_30m.GetComponent<boxtrigger>();
        Flow2.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource)
            audioSource = FindObjectOfType<AudioSource>();
        
        if(flag1)
        {
            if(trigger)
            {
                tts.Init("컨테이너를 항구에서 선박으로 옮기는 작업을 진행하겠습니다.");
                text.text = "컨테이너를 항구에서 선박으로 \n 옮기는 작업을 진행하겠습니다.";
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
                h_l.ParticlePlay(tog1);
                Invoke("F3_1", 6); // 스프레더의 넓이를 조절하세요.
                
            }
            if(ScanBLE.is_20ft)
            {
                h_l.ParticleStop(tog1);
                trigger = true;
                flag1 = false;
                flag2 = true;
            }
        }

        if(flag2)
        {
            if(trigger)
            {
                h_l.ParticlePlay(ctr2);
                tts.Init("조종실을 움직여서 작업 위치까지 이동하세요.");
                cube.SetActive(true);
                go.SetActive(true);
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
                text.text = "작업 위치까지 이동하세요.";
            }
            if(Cabin.transform.localPosition.z  > 13.5f)
            {
                h_l.ParticleStop(ctr2);
                cube.SetActive(false);
                go.SetActive(false);
                trigger = true;
                flag2 = false;
                flag3 = true;
            }
        }

        if(flag3)
        {
            if(trigger)
            {
                h_l.ParticlePlay(btn1);
                tts.Init("버튼을 눌러 플리퍼를 하강하세요.");
                
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
                text.text = "버튼을 눌러 플리퍼를 하강하세요.";
            }
            if(box.cnt)
                if(ScanBLE.is_fliper)
                {
                    
                    h_l.ParticleStop(btn1);
                    trigger = true;
                    flag3 = false;
                    flag4 = true;
                }
        }
        
        if(flag4)
        {
            if(trigger)
            {
                down.SetActive(true);
                tts.Init("트롤리를 천천히 내려 컨테이너와 스프레더를 결합하세요.");
                audioSource.PlayOneShot(tts.CreateAudio());
                text.text = "컨테이너와 결합하세요.";
                trigger = false;
            }
            if(ScanBLE.is_fixed) // container의 부모가 trolly가 되면 이거를 해준다.
            {
                down.SetActive(false);
                trigger = true;
                flag4 = false;
                flag5 = true;
            }
        }

        if(trolly.transform.localPosition.y > 7.6f)
            if(flag5)
            {
                if(trigger)
                    {
                        tts.Init("버튼을 눌러 플리퍼를 상승하세요.");
                        audioSource.PlayOneShot(tts.CreateAudio());
                        text.text = "버튼을 눌러 플리퍼를 상승하세요";
                        trigger = false;
                    }
                if(!ScanBLE.is_fliper)
                {
                    trigger = true;
                    flag5 = false;
                    flag6 = true;
                }
            }
        
        if(flag6)
        {
            if(trigger)
            {
                tts.Init("선박 위에 컨테이너를 결합시키고, 트위스트 콘을 해제하세요. ");
                text.text = "선박 위에 컨테이너를 적재하고,\n 트위스트 콘을 해제하세요. ";
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
                up.SetActive(true);
                
                
                
            }
            if(trolly.transform.localPosition.y > 12.14f)
                {
                    up.SetActive(false);
                    go.SetActive(true);
                    if(trolly.transform.localPosition.z > 37)
                    {
                        go.SetActive(false);
                        down.SetActive(true);
                        if(!ScanBLE.is_fixed)
                        {
                            down.SetActive(false);
                            trigger = true;
                            flag6 = false;
                            flag7 = true;
                        }
                        
                    }
                }
            
        }

        if(flag7)
        {
            if(trigger)
            {
                back.SetActive(true);
                tts.Init("배에서 항구로 컨테이너를 옮기세요.");
                text.text = "항구로 컨테이너를 옮기세요.";
                audioSource.PlayOneShot(tts.CreateAudio());
                trigger = false;
            }
            if(Cabin.transform.localPosition.z  < 20)
            {
                back.SetActive(false);
            }
        }
        
    }



    void F3_1()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        tts.Init("토글 스위치를 몸쪽으로 당겨 스프레더의 넓이를 조절하세요.");
        audioSource.PlayOneShot(tts.CreateAudio());
        text.text = "스프레더의 \n 넓이를 조절하세요";
    }

    void F3_2()
    {
        tts.Init("조종실을 움직여서 작업 위치까지 움직이세요.");
        tts.CreateAudio();
    }

}
