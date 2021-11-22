using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow4 : MonoBehaviour 
/*
    기울기 조정 -> 컨테이너 코너 피팅에 끼우기
    착상램프 점등 확인, 트위스트 콘 체결
    30cm 들어올리기 -> 끝까지 들어올리면서 모든 플리퍼 상승
    부두로 이동, 양화지점 30cm에서 일시 정지
    착륙 후 트위스터콘 해제
*/
    
{
    TTS tts = new TTS();
    public GameObject ending;
    public GameObject Flow3;
    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        Flow3.SetActive(false);
        tts.Init("조종실을 움직여서 작업 위치까지 이동하세요.");
        audioSource.PlayOneShot(tts.CreateAudio());
        text.text = "축하합니다!";
        ending.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
