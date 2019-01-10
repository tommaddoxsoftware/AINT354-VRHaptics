#include <Servo.h>
const byte ledPin = 13;
const byte Pin = 2;
volatile byte state = LOW;
/*
void setup() {
pinMode(3, OUTPUT); // coincell 
pinMode(5, OUTPUT);// big rumble 
pinMode(6, OUTPUT);
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
/*digitalWrite(3, HIGH);
delay(100);
digitalWrite(3, LOW);
delay(500);*/
/*
// RIGHT ARM
digitalWrite(5, HIGH);
digitalWrite(7, HIGH);
delay(1000);
digitalWrite(5, LOW);
digitalWrite(7, LOW);
delay(1000);



}*/


void setup()
{
  //Set up PWM pins
  pinMode(3,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(7,OUTPUT);
  
  //Begin serial input
  Serial.begin(9600);  
  }

void loop()
{  
  Serial.println(); 
  
  if(Serial.available() > 0)  {
    //Read the data we receive from unity, uppercase it to avoid errors
    String dataString = Serial.readString();
    dataString.toUpperCase();
    
    if(dataString.startsWith("L")) {


    digitalWrite(3, HIGH);
    delay(10);
    digitalWrite(3, LOW);
    delay(10);

    }
    else if(dataString.startsWith("R")) {

    // RIGHT ARM
    digitalWrite(5, HIGH);
    digitalWrite(7, HIGH);
    delay(10);
    digitalWrite(5, LOW);
    digitalWrite(7, LOW);
    delay(10);
    }
    else {
    //Data is not what we're lookig for. 
    //return something to unity to throw an error or something
    }
        
  } 
}
