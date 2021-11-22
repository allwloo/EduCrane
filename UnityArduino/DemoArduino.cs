using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;


public class DemoArduino : MonoBehaviour
{
    // Start is called before the first frame update
    byte[] data = new byte[4];
    public enum PortNumber
   {
       COM1, COM2, COM3, COM4,
       COM5, COM6, COM7, COM8,
       COM9, COM10, COM11, COM12,
       COM13, COM14, COM15, COM16
   }

    private SerialPort serial;
    private PortNumber portNumber = PortNumber.COM4; //포트 넘버
    private string baudRate = "115200"; // 통신 속도

    public GameObject Xaxis;
    public GameObject Yaxis;




    void Start()
    {
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate)
                                    , Parity.None, 8, StopBits.One);
        serial.Open();
        serial.ReadTimeout = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (serial.IsOpen)
        {
            try
            {
                serial.Read(data, 0, 1);
                serial.Read(data, 1, 1);
                serial.Read(data, 2, 1);
                serial.Read(data, 3, 1);
                print("X1값은 : "+ data[0]);
                print("Y1값은 : "+ data[1]);
                print("X2값은 : "+ data[2]);
                print("Y2값은 : "+ data[3]);
            }
            catch(System.TimeoutException e)
            {
                Debug.Log(e);
                throw;
            }
            GameObject.Find("ArduinoState").GetComponent<Text>().text = "연결됨";
        }
        else if (!serial.IsOpen)
        {
            GameObject.Find("ArduinoState").GetComponent<Text>().text = "연결안됨";
            serial.Open();
        }
    }

    void OnApplicationQuit() // 프로그램 종료 시 포트 닫기
    {
        serial.Close();
    }
}