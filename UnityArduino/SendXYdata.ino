int aPin = 0;
int aPin2 = 1;
byte XYaxis[2];
byte val;
byte val2;

void setup() {
  Serial.begin(115200);
}

void loop() {
  val = analogRead(aPin)/4;
  val2 = analogRead(aPin2)/4;
  XYaxis[0] = val;
  XYaxis[1] = val2;
  Serial.write(XYaxis, 2);
  delay(100);
}
