using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow1 : MonoBehaviour // Flow1은 버튼 안내, 주행방지장치 해제
{

    
    TTS tts = new TTS();

    high_light h_l;

    public GameObject HighLighter;
    public GameObject Flow0;
    public GameObject Flow2;
    public TextMesh text;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    public GameObject btn8;
    public GameObject tog1;
    public GameObject tog2;
    public GameObject ctr1;
    public GameObject ctr2;

    public GameObject trolly_hl;
    public GameObject traffic_hl;

    void Awake()
    {
        Flow0.SetActive(false);
        ScanBLE.is_trolly = false;
        ScanBLE.is_Cabin = false;
        ScanBLE.is_start = false;
        ScanBLE.is_20ft = false;
        ScanBLE.is_fixed = false;
        ScanBLE.is_fliper = false;
        ScanBLE.is_exit = false;
        ScanBLE.is_move = true;
    }

    void Start()
    {
        h_l = HighLighter.GetComponent<high_light>();
        StartCoroutine(Corutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(ScanBLE.is_start == true)
            {
                Flow2.SetActive(true);
            }                
    }

    IEnumerator Corutine()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        yield return new WaitForSeconds(5);
        tts.Init("안녕하십니까 본 제품은 가상현실을 통해 컨테이너 크레인에 대해 안전하고 쉽게 교육하기 위한 스마트 항만 안전훈련 컨텐츠입니다. 정면의 메세지와 음성, 그리고 화살표를 통해 현재 컨텐츠를 안내합니다.");
        Debug.Log(tts.CreateAudio());
        audioSource.PlayOneShot(tts.CreateAudio());
        yield return new WaitForSeconds(20);
        tts.Init("화면 좌우측 컨트롤러와 버튼들을 확인하세요.");
        text.text = "화면 좌우측 컨트롤러와 \n 버튼들을 확인하세요.";
        h_l.ParticlePlay(btn1);
        h_l.ParticlePlay(btn2);
        h_l.ParticlePlay(btn3);
        h_l.ParticlePlay(btn4);
        h_l.ParticlePlay(btn5);
        h_l.ParticlePlay(btn6);
        h_l.ParticlePlay(btn7);
        h_l.ParticlePlay(btn8);
        h_l.ParticlePlay(tog1);
        h_l.ParticlePlay(tog2);
        h_l.ParticlePlay(ctr1);
        h_l.ParticlePlay(ctr2);
        audioSource.PlayOneShot(tts.CreateAudio());
        yield return new WaitForSeconds(10);
        h_l.ParticleStop(btn1);
        h_l.ParticleStop(btn2);
        h_l.ParticleStop(btn3);
        h_l.ParticleStop(btn4);
        h_l.ParticleStop(btn5);
        h_l.ParticleStop(btn6);
        h_l.ParticleStop(btn7);
        h_l.ParticleStop(btn8);
        h_l.ParticleStop(tog1);
        h_l.ParticleStop(tog2);
        h_l.ParticleStop(ctr1);
        h_l.ParticleStop(ctr2);
        tts.Init("현재 상태를 확인할 수 있는 \n 삼색등을 확인하세요.");
        text.text = "현재 상태를 확인할 수 있는 \n 삼색등을 확인하세요.";
        audioSource.PlayOneShot(tts.CreateAudio());
        h_l.ParticlePlay(traffic_hl);
        yield return new WaitForSeconds(10);
        tts.Init("컨테이너를 들어올리는 \n 트롤리를 확인하세요.");
        text.text = "컨테이너를 들어올리는 \n 트롤리를 확인하세요.";
        audioSource.PlayOneShot(tts.CreateAudio());
        h_l.ParticlePlay(trolly_hl);
        h_l.ParticleStop(traffic_hl);
        yield return new WaitForSeconds(10);
        h_l.ParticleStop(trolly_hl);
        tts.Init("이제 안전 훈련 컨텐츠가 시작됩니다. 강조된 버튼을 클릭해 장치를 켜십시오");
        text.text = "강조된 버튼을 클릭해 \n 장치를 켜십시오.";
        audioSource.PlayOneShot(tts.CreateAudio());
        h_l.ParticlePlay(btn7);
    }


}
