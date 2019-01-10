
const byte ledPin = 13;
const byte Pin = 2;
volatile byte state = LOW;
void setup() {
pinMode(3, OUTPUT); // coincell 
pinMode(5, OUTPUT);// big rumble 
pinMode(7, OUTPUT);// small rumble

}

void loop() { 
//digitalWrite(3, HIGH);
//delay(10);
//digitalWrite(4 ,LOW);
//delay(10);

//digitalWrite(5, HIGH);
//delay(1000);
//digitalWrite(5 ,LOW);
//delay(1000);


//digitalWrite(6, HIGH);
//delay(10000);
//digitalWrite(6 ,LOW);
//delay(1000);

//digitalWrite(7, HIGH);

//digitalWrite(4 ,LOW);

//LEFT ARM 
digitalWrite(3, HIGH);
delay(100);
digitalWrite(3, LOW);
delay(500);

// RIGHT ARM
digitalWrite(5, HIGH);
digitalWrite(7, HIGH);
delay(1000);
digitalWrite(5, LOW);
digitalWrite(7, LOW);
delay(1000);

//BOTH ARMS
digitalWrite(3, HIGH);
digitalWrite(5, HIGH);
digitalWrite(7, HIGH);
delay(1000);
digitalWrite(3, LOW);
digitalWrite(5, LOW);
digitalWrite(7, LOW);
delay(500);

//LEFT BUZZ
digitalWrite(3, HIGH);
delay(10);
digitalWrite(3, LOW);
delay(15);
digitalWrite(3, HIGH);
delay(10);
digitalWrite(3, LOW);
delay(15);
digitalWrite(3, HIGH);
delay(10);
digitalWrite(3, LOW);
delay(100);






}


