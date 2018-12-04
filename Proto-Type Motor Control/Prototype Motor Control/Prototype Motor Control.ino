const byte ledPin = 13;
const byte Pin = 2;
volatile byte state = LOW;
void setup() {
pinMode(1, 7);
pinMode(2, 6);
pinMode(3, 5);

}

void loop() {
digitalWrite(1, HIGH);
delay(1000);
digitalWrite(1 ,LOW);
delay(1000);


digitalWrite(2, HIGH);
delay(1000);
digitalWrite(2 ,LOW);
delay(1000);


  
digitalWrite(3, HIGH);
delay(1000);
digitalWrite(3 ,LOW);
delay(1000);




}

