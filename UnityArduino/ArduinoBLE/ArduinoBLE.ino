#include <ArduinoBLE.h>

BLEService DeviceInformation("180A");
BLEFloatCharacteristic X1("2A90", BLERead|BLENotify);
BLEFloatCharacteristic Y1("2A91", BLERead|BLENotify);
BLEFloatCharacteristic X2("2A92", BLERead|BLENotify);
BLEFloatCharacteristic Y2("2A93", BLERead|BLENotify);
BLEShortCharacteristic Button1("2A94", BLERead|BLENotify);
BLEShortCharacteristic Button2("2A95", BLERead|BLENotify);
BLEShortCharacteristic Button3("2A96", BLERead|BLENotify);
BLEShortCharacteristic Button4("2A97", BLERead|BLENotify);
BLEShortCharacteristic Button5("2A98", BLERead|BLENotify);
BLEShortCharacteristic Button6("2A99", BLERead|BLENotify);
BLEShortCharacteristic Button7("2A9A", BLERead|BLENotify);
BLEShortCharacteristic Button8("2A9B", BLERead|BLENotify);
BLEShortCharacteristic Toggle1("2A9C", BLERead|BLENotify);
BLEShortCharacteristic Toggle2("2A9D", BLERead|BLENotify);

int Pin0 = 0;
int Pin1 = 1;
int Pin2 = 2;
int Pin3 = 3;
int Pin4 = 4;
int Pin5 = 5;
int Pin6 = 6;
int Pin7 = 7;
int Pin8 = 8;
int Pin9 = 9;
int Pin10 = 10;
int Pin11 = 11;
int Pin12 = 12;
int Pin13 = 13;
int Pin18 = 18;
int Pin19 = 19;
int Pin20 = 20;

int btn0 = 0;
int btn1 = 0;
int btn2 = 0;
int btn3 = 0;
int btn4 = 0;
int btn5 = 0;
int btn6 = 0;
int btn7 = 0;
int btn8 = 0;
int btn9 = 0;
int btn10 = 0;
int btn11 = 0;
int btn12 = 0;
int btn13 = 0;
int btn18 = 0;
int btn19 = 0;
int btn20 = 0;

int val = 0;

int x1 = 0;

void setup() {
  Serial.begin(9600);
  pinMode(0, INPUT_PULLDOWN);
  pinMode(1, INPUT_PULLDOWN);
  pinMode(5, INPUT_PULLDOWN);
  pinMode(7, INPUT_PULLDOWN);
  pinMode(12, INPUT_PULLDOWN);
  pinMode(13, INPUT_PULLDOWN);
  pinMode(20, INPUT_PULLDOWN);
  pinMode(21, INPUT_PULLDOWN);
  
  if(!BLE.begin()){
    Serial.println("starting BLE failed!");
    while(1);
  }

  BLE.setLocalName("ArduinoNano33");
  BLE.setAdvertisedService(DeviceInformation);

  
  DeviceInformation.addCharacteristic(X1);
  DeviceInformation.addCharacteristic(Y1);
  DeviceInformation.addCharacteristic(X2);
  DeviceInformation.addCharacteristic(Y2);
  DeviceInformation.addCharacteristic(Button1);
  DeviceInformation.addCharacteristic(Button2);
  DeviceInformation.addCharacteristic(Button3);
  DeviceInformation.addCharacteristic(Button4);
  DeviceInformation.addCharacteristic(Button5);
  DeviceInformation.addCharacteristic(Button6);
  DeviceInformation.addCharacteristic(Button7);
  DeviceInformation.addCharacteristic(Button8);
  DeviceInformation.addCharacteristic(Toggle1);
  DeviceInformation.addCharacteristic(Toggle2);
  BLE.addService(DeviceInformation);
  X1.writeValue(0);
  Y1.writeValue(0);
  X2.writeValue(0);
  Y2.writeValue(0);
  Button1.writeValue(0);
  Button2.writeValue(0);
  Button3.writeValue(0);
  Button4.writeValue(0);
  Button5.writeValue(0);
  Button6.writeValue(0);
  Button7.writeValue(0);
  Button8.writeValue(0);
  Toggle1.writeValue(0);
  Toggle2.writeValue(0);

  BLE.advertise();
  Serial.println("BLE LED Peripheral");
  
}

void loop() {
  // put your main code here, to run repeatedly:
  BLEDevice central = BLE.central();

  if(central){
    Serial.print("Connected to central: ");
    Serial.println(central.address());

    while (central.connected()){

        btn0 = digitalRead(Pin0); // 토글(20ft)
        btn1 = digitalRead(Pin1); // 캐빈
        btn5 = digitalRead(Pin5); // 트롤리
        btn7 = digitalRead(Pin7); // 스타트
        btn12 = digitalRead(Pin12); // 플리퍼
        btn13 = digitalRead(Pin13); // 트위스트콘
        btn20 = digitalRead(Pin20); // 엑시트
        
        X1.writeValue(analogRead(Pin0));
        Y1.writeValue(analogRead(Pin1));
        /*
        if(analogRead(Pin2)>1000)
        {
           X2.writeValue(analogRead(Pin2));
           delay(1000);
        }
        */
        
        
        Y2.writeValue(analogRead(Pin3));
        
        if(btn5 == 1) //트롤리
        {
          Button1.writeValue(btn5);
          delay(1000);
        }
        
        if(btn1 == 1) // 캐빈
        {
          Button2.writeValue(btn1);
          delay(1000);
        }

        if(btn0 == 1) // 20ft (토글스위치)
        {
          Button3.writeValue(btn0); // toggle1으로 사용.
          delay(5000);
        }

        if(btn7 == 1) // start 버튼
        {
          Button4.writeValue(btn7); //
          delay(1000);
        }

        if(btn12 == 1) // 플리퍼
        {
          Button5.writeValue(btn12); // 
          delay(1000);
        }
        
        if(btn13 == 1) // 트위스트 콘
        {
          Button6.writeValue(btn13); //
          delay(1000);
        }

        if(btn20 == 1) // is_fixed
        {
          Button7.writeValue(btn20); //
          delay(1000);
        }
        
  
       
        
        Serial.print(central.address());
        Serial.println("Sending...");
        Serial.print("x1은: ");
        Serial.println(analogRead(Pin0));
        Serial.print("y1은: ");
        Serial.println(analogRead(Pin1));
        Serial.print("x2은: ");
        Serial.println(analogRead(Pin2));
        Serial.print("y2은: ");
        Serial.println(analogRead(Pin3));
    }
  }
  /*
  Serial.println(analogRead(Pin0));
  Serial.println(analogRead(Pin1));
  Serial.println(analogRead(Pin2));
  Serial.println(analogRead(Pin3));
  */

  /*
  Serial.print("Pin0 : ");
  val = digitalRead(Pin0));
  Serial.println(val);
  Serial.print("Pin1 : ");
  Serial.println(digitalRead(Pin1));
  Serial.print("Pin2 : ");
  Serial.println(digitalRead(Pin2));
  Serial.print("Pin3 : ");
  Serial.println(digitalRead(Pin3));
  Serial.print("Pin4 : ");
  Serial.println(digitalRead(Pin4));
  Serial.print("Pin5 : ");
  Serial.println(digitalRead(Pin5));
  Serial.print("Pin6 : ");
  Serial.println(digitalRead(Pin6));
  Serial.print("Pin7 : ");
  Serial.println(digitalRead(Pin7));
  Serial.print("Pin8 : ");
  Serial.println(digitalRead(Pin8));
  Serial.print("Pin9 : ");
  Serial.println(digitalRead(Pin9));
  Serial.print("Pin10 : ");
  Serial.println(digitalRead(Pin10));
  */
  Serial.print("Pin0 : ");
  btn0 = digitalRead(Pin0);
  Serial.println(btn0);
  Serial.print("Pin1 : ");
  btn1 = digitalRead(Pin1);
  Serial.println(btn1);
  Serial.print("Pin5 : ");
  btn5 = digitalRead(Pin5);
  Serial.println(btn5);
  Serial.print("Pin7 : ");
  btn7 = digitalRead(Pin7);
  Serial.println(btn7);
  Serial.print("Pin12 : ");
  btn12 = digitalRead(Pin12);
  Serial.println(btn12);
  Serial.print("Pin13 : ");
  btn13 = digitalRead(Pin13);
  Serial.println(btn13);
  Serial.print("Pin21 : ");
  btn19 = digitalRead(21);
  Serial.println(btn19);
  Serial.print("Pin20 : ");
  btn20 = digitalRead(Pin20);
  Serial.println(btn20);
  
}
