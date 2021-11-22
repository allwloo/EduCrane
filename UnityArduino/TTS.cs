using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System;
using UnityEngine;
using UnityEngine.Audio;
//12

public class TTS
{

    public GameObject MainUI;
    private string apiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyBqAYAvx2EMGRu3x8ShYgSjTIAf6kMJlkg";
    SetTextToSpeech tts = new SetTextToSpeech();

    public TTS()
    {
        apiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyBqAYAvx2EMGRu3x8ShYgSjTIAf6kMJlkg";
        tts = new SetTextToSpeech();
    }
    void Awake()
    {
        apiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyBqAYAvx2EMGRu3x8ShYgSjTIAf6kMJlkg";
        tts = new SetTextToSpeech();
    }


    //
    public void Init(string text)
    {

        SetInput si = new SetInput();
        si.text = text;
        tts.input = si;

        SetVoice sv = new SetVoice();
        sv.languageCode = "ko-KR";
        sv.name = "ko-KR-Standard-B";
        sv.ssmlGender = "FEMALE";
        tts.voice = sv;

        SetAudioConfig sa = new SetAudioConfig();
        sa.audioEncoding = "LINEAR16";
        sa.speakingRate = 0.8f;
        sa.pitch = 0;
        sa.volumeGainDb = 5;
        tts.audioConfig = sa;

        
    }

    public AudioClip CreateAudio()
    {
        //string 값 불러오기
        var str = TextToSpeechPost(tts);
        GetContent info = JsonUtility.FromJson<GetContent>(str);

        var bytes = Convert.FromBase64String(info.audioContent);
        var f = ConvertByteToFloat(bytes);
        AudioClip audioClip = AudioClip.Create("audioContent", f.Length, 1, 44100, false);
        audioClip.SetData(f, 0);

        return audioClip;

    }

    private static float[] ConvertByteToFloat(byte[] array)
    {
        float[] floatArr = new float[array.Length/2];

        for (int i = 0; i < floatArr.Length; i++)
        {
            floatArr[i] = BitConverter.ToInt16(array, i * 2 )/32768.0f;
        }

        return floatArr;
    }

    public string TextToSpeechPost(object data)
    {
        //JsonUtility를 사용해서 string을 요청 보내기 위해 byte[]로 변환
        string str = JsonUtility.ToJson(data);
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);

        //요청을 보낼 주소, 세팅
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = bytes.Length;

        //Stream 형식으로 데이터를 보냄
        try
        {
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes,0,bytes.Length);
                stream.Flush();
                stream.Close();
            }

            //응답 데이터를 StreamReader로 받음
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //stream데이터를 읽음
            StreamReader reader = new StreamReader(response.GetResponseStream());
            //stream -> string 변환
            string json = reader.ReadToEnd();

            return json;
        }
        catch (WebException e)
        {
            Debug.Log(e);
            return null;
        }
    }

    [System.Serializable]
    public class SetTextToSpeech
    {
        public SetInput input;
        public SetVoice voice;
        public SetAudioConfig audioConfig;
    }
    [System.Serializable]
    public class SetInput
    {
        public string text;
        //public string ssml;
    }
    [System.Serializable]
    public class SetVoice
    {
        public string languageCode;
        public string name;
        public string ssmlGender;
    }
    [System.Serializable]
    public class SetAudioConfig
    {
        public string audioEncoding;
        public float speakingRate;
        public int pitch;
        public int volumeGainDb;
        //public int sampleRateHertz;
    }
    [System.Serializable]
    public class GetContent
    {
        public string audioContent;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
   
    }
} 