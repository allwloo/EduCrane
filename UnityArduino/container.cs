using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container : MonoBehaviour
{

    //public FixedJoint FJ;



    public GameObject trolly;
    public GameObject traffic;
    public GameObject traffic_red;
    public GameObject Cabin;

    public GameObject con_crash;
    public GameObject tro_crash;

    public Rigidbody trolly_rb;
    Rigidbody rb;
    
    public AudioClip audioAlert;//경고음
    public AudioClip audioFit;//체결
    public AudioClip audioCrash;//충돌

    AudioSource audioSource;

    public GameObject ship;


    void Awake()
    {
        audioSource = Cabin.gameObject.GetComponent<AudioSource>();
    }

    void PlaySound(string action) {
        switch (action) {
            case "Alert"://경고
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

    IEnumerator worstReset()
    {
        yield return new WaitForSeconds(1f);
        if(transform.parent.name == "Trolly")
            Debug.Log("부모의 이름은?"+this.transform.parent.name);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("자식 개수는"+trolly.transform.childCount);

        
        float fixed_waring;
        float x = gameObject.transform.rotation.eulerAngles.x;
        float y = gameObject.transform.rotation.eulerAngles.y;
        float z = gameObject.transform.rotation.eulerAngles.z;
        Debug.Log(x+"y"+y+"z"+z);

        if((x > 300 && x < 359)) // || (y > 70 && y < 181) || (z > 70 && z < 181)
        {
            con_crash.SetActive(true);
            PlaySound("Alert");
            audioSource.Play();
            
        }

    
        //if(!ScanBLE.is_fliper)
        if(trolly.transform.childCount == 4)
            if(!ScanBLE.is_fixed)  // !is_fixed일때 컨테이너를 떼어내는 코드
            {
                this.transform.parent = null;
                ScanBLE.is_move = true;
                CreateRb();
                //traffic.SetActive(false);
            }
        /*
        if(this.transform.parent)
            if(this.transform.parent.name == "Trolly")
                traffic_red.SetActive(false);
        */


    }



    void OnCollisionEnter(Collision collision)
    {
        float diff = this.gameObject.transform.position.z - trolly.gameObject.transform.position.z;
        Debug.Log("diff : "+diff);
        if(collision.gameObject.name == "Trolly")
            if(trolly.transform.childCount == 3) // 아무것도 부착되어 있지 않는 트롤리 상태
            {   Debug.Log("트롤리랑 콜리젼 스테이");
                if(ScanBLE.is_20ft)
                    if(ScanBLE.is_fliper)
                        if(1.8f < diff && 2.3f > diff) // 올바른 충돌
                        {
                            Debug.Log("올바른 충돌 진동음 발생");
                            PlaySound("Fit");
                            audioSource.Play();
                            Destroy(GetComponent<Rigidbody>());
                            ScanBLE.is_move = false;
                            //traffic.SetActive(true);
                        }
                        else
                        {
                            Debug.Log("잘못된 충돌");
                            PlaySound("Fit");
                            audioSource.Play();
                            Destroy(GetComponent<Rigidbody>());
                            ScanBLE.is_move = true;
                            //traffic_red.SetActive(true); // 잘못된 충돌,
                            if(ScanBLE.is_fixed)
                                if(trolly.transform.localPosition.y > 12)
                                {
                                    tro_crash.SetActive(true);
                                    PlaySound("Alert");
                                    audioSource.Play();
                                }
                                    
                        }
            }
            else if(trolly.transform.childCount == 4) // 컨테이너가 부착되어 있는 트롤리 상태
            {   Debug.Log("컨테이너랑 컨테이너 스테이");
                if(ScanBLE.is_20ft)
                    if(!ScanBLE.is_fliper)
                        if(1.8f < diff && 2.3f > diff)
                        {
                            Debug.Log("컨테이너와 컨테이너 올바른 충돌");
                            audioSource.Play();
                            Destroy(GetComponent<Rigidbody>());
                            ScanBLE.is_move = false;
                        }
                        else
                        {
                            Debug.Log("잘못된 충돌");
                            PlaySound("Crash");
                            ScanBLE.is_move = true;
                        }

            }



    }

    void OnCollisionExit(Collision collision)
    {
        CreateRb();
    }

    void OnCollisionStay(Collision collision)
    {   
            if(trolly.transform.childCount == 3)
            {   
                if(ScanBLE.is_fixed)
                {
                    this.transform.parent = trolly.transform;
                    ScanBLE.is_move = true;
                    //traffic.SetActive(false);
                }
                else
                { 
                    this.transform.parent = null;
                    ScanBLE.is_move = true;
                    //traffic.SetActive(false);
                }
            }
            else if(trolly.transform.childCount == 4)
            {
                Debug.Log("이미 4개짜리라 아무것도 작동 안대므");
            }
    }

    void CreateRb(){
        Debug.Log("Rb를 만드는 중입니다.");
        if(!rb)
            rb = this.gameObject.AddComponent<Rigidbody>();
    }
}
