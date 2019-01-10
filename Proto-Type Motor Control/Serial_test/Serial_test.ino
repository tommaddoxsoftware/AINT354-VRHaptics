 #include <Servo.h>

 
 void setup()
 {
   Serial.begin(9600);  
 }
 
 void loop()
 {
  

  
  Serial.println(); 
     
   if(Serial.available() > 0)
       {
         String dataString = Serial.readString();
 
         if(dataString.startsWith("C"))
            {
                 dataString.replace('C', '0');
                 delay(30);
              
            }
 
      }
 
 
 }
