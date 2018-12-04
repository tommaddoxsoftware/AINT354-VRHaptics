#include <Servo.h>
String motorLocations[3];
const byte ledPin = 13;
const byte pin = 2;
volatile byte state = LOW;

void setup()
{
  //Set up PWM pins
  pinMode(1,OUTPUT);
  pinMode(2,OUTPUT);
  pinMode(3,OUTPUT);
  
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
    motorLocations[0] = "L";
    }
    else if(dataString.startsWith("R")) {
    motorLocations[0] = "R";
    }
    else {
    //Data is not what we're lookig for. 
    //return something to unity to throw an error or something
    }
    
    //Now that we've found which side we're firing motors too, find which part
    if(dataString.substring(1,6) == "UPPER") {
    motorLocations[1] = "UPPER";
    }
    else if(dataString.substring(1,6) == "LOWER") {
    motorLocations[1]= "LOWER";
    }
    
    
    //  switch(dataString.substring(7))
    //Test substring to see if we're getting the right data
    Serial.print(dataString.substring(7,9));         
  } 
}
