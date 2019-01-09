#include <Servo.h>
String motorLocations[3];
const byte ledPin = 13;
const byte pin = 2;
volatile byte state = LOW;

String content = "";
char character;

void setup()
{
  //Set up PWM pins
  pinMode(3, OUTPUT); //LEFT COIN 1
  pinMode(4, OUTPUT); //LEFT RUMBLE
  pinMode(5, OUTPUT); //LEFT COIN 2
  pinMode(6, OUTPUT); //RIGHT RUMBLE
  pinMode(7, OUTPUT); //RIGHT COINS

  
  //Begin serial input
  Serial.begin(9600); 
  delay(100);
}


void loop() {

  while(Serial.available()) {
    content = Serial.readString();
  }

  if(content.substring(0,9) == "LUPPERARM") { 
    String motorType =  content.substring(9, (content.length())); 
   
      //Turn Motors On
      if(motorType == "RUMBLE") {
        //Rumble motors
        digitalWrite(4, HIGH);
      }
      else if(motorType == "COIN") {
        //Coin cell motors
        digitalWrite(3, HIGH);
        digitalWrite(5, HIGH);
      }
      else {
        //Both motors
        digitalWrite(3, HIGH);
        digitalWrite(4, HIGH);
        digitalWrite(5, HIGH);
      }
      
      
  }
  else if(content.substring(0,9) == "RUPPERARM") {
    String motorType =  content.substring(9, (content.length())); 
   
      //Turn Motors On
      if(motorType == "RUMBLE") {
        //Rumble motors
        digitalWrite(6, HIGH);
      }
      else if(motorType == "COIN") {
        //Coin cell motors
        digitalWrite(7, HIGH);
      }
      else {
        //Both motors
        digitalWrite(6, HIGH);
        digitalWrite(7, HIGH);
      }
  }
  else {
    //Turn motors off
    digitalWrite(3, LOW);
    digitalWrite(4, LOW);
    digitalWrite(5, LOW);
    digitalWrite(6, LOW);
    digitalWrite(7, LOW);    
  }  

}
