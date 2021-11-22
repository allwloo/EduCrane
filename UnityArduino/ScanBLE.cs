
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;
using System;
using UnityEngine.UI;

public class ScanBLE : MonoBehaviour
{

    // Vector3(2.20000005,-24.0599995,38.5400009)
    // Vector3(6.91275072,6,11.5)
    // Use this for initialization
    BluetoothHelper bluetoothHelper;

    public static float y1 = 800;
    public static float y2 = 800;
    public static bool is_trolly = false;
    public static bool is_Cabin = false;
    public static bool is_start = false;
    public static bool is_20ft = false;
    public static bool is_fixed = false;
    public static bool is_fliper = false;
    public static bool is_exit = false;
    public static bool is_move = true;


    public bool my_trolly;
    public bool my_Cabin;
    public bool my_start;
    public bool my_20ft;
    public bool my_fixed;
    public bool my_fliper;
    public bool my_exit;

    public bool trigger = false;

    public GameObject jff;
    public GameObject Cabin;
    public GameObject trolly;
    public Rigidbody trolly_rb;

    public TextMesh text;
    public GameObject sphere;
    public GameObject gme_over1;

    string received_message;

    void Start()
    {

        OVRPlugin.systemDisplayFrequency = 90.0f;

        try
        {

            BluetoothHelper.BLE = true;  //use Bluetooth Low Energy Technology
            bluetoothHelper = BluetoothHelper.GetInstance("ArduinoNano33");

            bluetoothHelper.OnConnected += OnConnected;
            bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
            bluetoothHelper.OnDataReceived += OnMessageReceived; //read the data
            bluetoothHelper.OnScanEnded += OnScanEnded;

            //bluetoothHelper.setTerminatorBasedStream("\n");

            bluetoothHelper.OnCharacteristicChanged += (helper, value, characteristic) =>
           {
               
               if(characteristic.getName() == "00002a90-0000-1000-8000-00805f9b34fb")
               {
                   //x1
                   float x1 = BitConverter.ToSingle(value, 0);
                   //Debug.Log(x1+"x1 들어옴");

                   /*

                   if(x1 < 640)
                            {
                                x1 -= 640; // 40~640정도
                                x1 /= 50000; // 0.08~1.28
                                
                                jff.transform.Translate(0, -x1, 0);
                                
                            }
                    else if(x1 > 900)
                            {
                                x1 -= 900; // 1~124가 최대
                                x1 /= 10000; // 0.01~1.24
                                jff.transform.Translate(0,-x1,0);
                            }
                    else
                            { 
                                jff.transform.Translate(0, 0, 0);
                            }
                    */


               }

               if(characteristic.getName() == "00002a91-0000-1000-8000-00805f9b34fb")
               {
                   y1 = BitConverter.ToSingle(value, 0);
                   float y1_1 = y1;
                   float yf = BitConverter.ToSingle(value, 0);
                   /*

                   if(yf < 640)
                            {
                                yf -= 640; // 40~640정도
                                yf /= 50000; // 0.08~1.28
                                
                                jff.transform.Translate(0, 0, -yf);
                                
                            }
                    else if(yf > 900)
                            {
                                yf -= 900; // 1~124가 최대
                                yf /= 10000; // 0.01~1.24
                                jff.transform.Translate(0,0,-yf);
                            }
                    else
                            { 
                                jff.transform.Translate(0, 0, 0);
                            }

                    */
                    if(is_move)
                        if( is_Cabin == true && is_start == true )
                        {
                                if(y1_1 < 640)
                                {
                                    y1_1 -= 640; // 40~640정도
                                    y1_1 /= 50000; // 0.08~1.28
                                    if(Cabin.transform.localPosition.z < 48)
                                    {
                                        Cabin.transform.Translate(0, 0, -y1_1);
                                        trolly.transform.Translate(0, 0, -y1_1);
                                    }
                                }
                                else if(y1_1 > 900)
                                {
                                    y1_1 -= 900; // 1~124가 최대
                                    y1_1 /= 10000; // 0.01~1.24
                                    if(Cabin.transform.localPosition.z > 1.46)
                                    {
                                        Cabin.transform.Translate(0, 0, -y1_1);
                                        trolly.transform.Translate(0, 0, -y1_1);
                                    }
                                }
                                else
                                { 
                                    Cabin.transform.Translate(0, 0, 0);
                                }
                        }
                   

               }

               if(characteristic.getName() == "00002a92-0000-1000-8000-00805f9b34fb")
               {
                   float x2 = BitConverter.ToSingle(value, 0);
                   /*
                   if(x2 < 640)
                            {
                                x2 -= 640; // 40~640정도
                                x2 /= 50000; // 0.08~1.28
                                
                                jff.transform.Translate(-x2, 0, 0);
                                
                            }
                    else if(x2 > 900)
                            {
                                x2 -= 900; // 1~124가 최대
                                x2 /= 10000; // 0.01~1.24
                                jff.transform.Translate(-x2,0,0);
                            }
                    else
                            { 
                                jff.transform.Translate(0, 0, 0);
                            }
                    */

               }



               if(characteristic.getName() == "00002a93-0000-1000-8000-00805f9b34fb")
               {
                   y2 = BitConverter.ToSingle(value, 0);
                   float y2_1 = y2;
                   if(is_move)
                        if( is_trolly == true && is_start == true ){
                                if(y2_1 < 640)
                                {
                                    y2_1 -= 640; // 40~640정도
                                    y2_1 /= 400; // 400
                                    if(trolly.transform.localPosition.y < 16.5f)
                                        trolly_rb.velocity = new Vector3(0, -y2_1, 0);
                                }
                                else if(y2_1 > 900)
                                {
                                    y2_1 -= 900; // 1~124가 최대
                                    y2_1 /= 80; // 0.01~1.24
                                    if(trolly.transform.localPosition.y > 5.5f)
                                        trolly_rb.velocity = new Vector3(0, -y2_1, 0);
                                    
                                }
                                else
                                    trolly_rb.velocity = new Vector3(0, 0, 0);
                            }
               }

    

               if(characteristic.getName() == "00002a94-0000-1000-8000-00805f9b34fb")
               {
                   short btn0 = BitConverter.ToInt16(value, 0);
                   if(btn0 == 1)
                   {
                        Debug.Log(is_trolly+"트롤리 버튼 클릭");
                        if(is_trolly == false)
                            is_trolly = true;
                        else
                            is_trolly = false;
                   }
                    

               }

               if(characteristic.getName() == "00002a95-0000-1000-8000-00805f9b34fb")
               {
                   short btn1 = BitConverter.ToInt16(value, 0);
                   if(btn1 == 1)
                   {
                        Debug.Log(is_Cabin+"조종실 버튼 클릭");
                        if(is_Cabin == false)
                            is_Cabin = true;
                        else
                            is_Cabin = false;
                   }

               }

               if(characteristic.getName() == "00002a96-0000-1000-8000-00805f9b34fb")
               {
                   short btn2 = BitConverter.ToInt16(value, 0);
                   if(btn2 == 1)
                   {
                        Debug.Log(is_20ft+"20ft 버튼 클릭");
                        if(is_20ft == false)
                            is_20ft = true;
                        else
                            is_20ft = false;
                   }

                    

               }

               if(characteristic.getName() == "00002a97-0000-1000-8000-00805f9b34fb")
               {
                   
                   short btn3 = BitConverter.ToInt16(value, 0);
                   if(btn3 == 1)
                   {
                        Debug.Log(is_start+"시작 버튼 클릭");
                        if(is_start == false)
                            is_start = true;
                        else
                            is_start = false;
                   }

               }

               if(characteristic.getName() == "00002a98-0000-1000-8000-00805f9b34fb")
               {
                   short btn4 = BitConverter.ToInt16(value, 0);
                   if(btn4 == 1)
                   {
                        Debug.Log(is_fliper+"플리퍼");
                        if(is_fliper == false)
                            is_fliper = true;
                        else
                            is_fliper = false;
                   }

               }

               if(characteristic.getName() == "00002a99-0000-1000-8000-00805f9b34fb")
               {
                   //btn6
                   short btn5 = BitConverter.ToInt16(value, 0);
                   if(btn5 == 1)
                   {
                        Debug.Log(is_fixed+"트위스트콘");
                        if(is_fixed == false)
                            is_fixed = true;
                        else
                            is_fixed = false;
                   }
                   Debug.Log("btn13 트위스트콘 버튼 들어옴");

               }

               if(characteristic.getName() == "00002a9a-0000-1000-8000-00805f9b34fb")
               {
                   short btn6 = BitConverter.ToInt16(value, 0);
                   if(btn6 == 1)
                   {
                        Debug.Log(is_exit+"is_exit");
                        if(is_exit == false)
                            is_exit = true;
                        else
                            is_exit = false;
                   }
                   
                   

               }

               if(characteristic.getName() == "00002a9b-0000-1000-8000-00805f9b34fb")
               {
                   

               }

               if(characteristic.getName() == "00002a9c-0000-1000-8000-00805f9b34fb") // 토글1
               {
                  

               }

               if(characteristic.getName() == "00002a9d-0000-1000-8000-00805f9b34fb") // 토글2
               {
            

               }


               
               
               //text.text = System.Text.Encoding.ASCII.GetString(value);

               /*

               Debug.Log(characteristic.getName());
               Debug.Log(System.Text.Encoding.ASCII.GetString(value));
               Debug.Log(value);

               */
           };


            BluetoothHelperService service = new BluetoothHelperService("180A");
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A90"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A91"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A92"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A93"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A94"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A95"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A96"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A97"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A98"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A99"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A9A"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A9B"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A9C"));
            service.addCharacteristic(new BluetoothHelperCharacteristic("2A9D"));
            
            bluetoothHelper.Subscribe(service);


            bluetoothHelper.ScanNearbyDevices();


            //text.text = "start scan";

        }
        catch (BluetoothHelper.BlueToothNotEnabledException ex)
        {
            sphere.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log(ex.ToString());
            //text.text = ex.Message;
        }
    }



    IEnumerator blinkSphere()
    {
        sphere.GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(0.5f);
        sphere.GetComponent<Renderer>().material.color = Color.green;
    }

    //Asynchronous method to receive messages
    void OnMessageReceived(BluetoothHelper helper)
    {
        //StartCoroutine(blinkSphere());
        received_message = helper.Read();
        //text.text = received_message;
        Debug.Log(System.DateTime.Now.Second);
        Debug.Log(received_message);
    }

    void OnScanEnded(BluetoothHelper helper, LinkedList<BluetoothDevice> nearbyDevices)
    {
        Debug.Log("1 ended");

        if (nearbyDevices.Count == 0)
        {
            helper.ScanNearbyDevices();
            return;
        }


        foreach (BluetoothDevice device in nearbyDevices)
        {
            if (device.DeviceName == "ArduinoNano33")
                Debug.Log("FOUND!!");
        }

        //text.text = "ArduinoNano33";

        // bluetoothHelper.setDeviceAddress("00:21:13:02:16:B1");
        bluetoothHelper.setDeviceName("ArduinoNano33");
        bluetoothHelper.Connect();
        bluetoothHelper.isDevicePaired();

    }

    void OnScanEnded2(BluetoothHelper helper, LinkedList<BluetoothDevice> nearbyDevices)
    {
        Debug.Log("2 ended " + nearbyDevices.Count);
        if (nearbyDevices.Count == 0)
        {
            helper.ScanNearbyDevices();
            return;
        }


        foreach (BluetoothDevice device in nearbyDevices)
        {
            Debug.Log(device.DeviceName);
            if (device.DeviceName == "HUAWEI Y7 Prime 2018")
                Debug.Log("FOUND!!");
        }


        helper.setDeviceName("HUAWEI Y7 Prime 2018");
        helper.Connect();
    }

    void Update()
    {   

        /*

        is_trolly = my_trolly;
        is_20ft = my_20ft;
        is_Cabin = my_Cabin;
        is_exit = my_exit;
        is_fixed = my_fixed;
        is_start = my_start;
        is_fliper = my_fliper;

        */
        
        //Debug.Log(bluetoothHelper.IsBluetoothEnabled());
        if (!bluetoothHelper.IsBluetoothEnabled())
        {
            bluetoothHelper.EnableBluetooth(true);
        }

    }

    void OnConnected(BluetoothHelper helper)
    {
        sphere.GetComponent<Renderer>().material.color = Color.green;
        try
        {
            helper.StartListening();
            if(helper.getId() == bluetoothHelper.getId()) //1st instance connected, connect the second
                bluetoothHelper.ScanNearbyDevices();
            
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }
    void OnConnectionFailed(BluetoothHelper helper)
    {
        sphere.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("Connection Failed");
    }

    //Call this function to emulate message receiving from bluetooth while debugging on your PC.
    void OnGUI()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.DrawGUI();
        else
            return;

        if (bluetoothHelper.isConnected())
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height - 2 * Screen.height / 10, Screen.width / 5, Screen.height / 10), "Disconnect"))
            {
                bluetoothHelper.Disconnect();
                sphere.GetComponent<Renderer>().material.color = Color.blue;
            }

        if (bluetoothHelper.isConnected())
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 10, Screen.width / 5, Screen.height / 10), "Send text"))
            {
                //bluetoothHelper.SendData(new byte[] { 0, 1, 2, 3, 4 });
                bluetoothHelper.SendData("Hi From unity");
            }
    }

    void OnDestroy()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.Disconnect();
        //if (bluetoothHelper2 != null)
        //  bluetoothHelper2.Disconnect();
    }

    void F1()
    {
        gme_over1.SetActive(true);
    }
    
        

    

}

