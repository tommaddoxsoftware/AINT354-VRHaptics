using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class SendMsgArduino : MonoBehaviour {
    [SerializeField]
    private string portName;

    SerialPort stream;

	// Use this for initialization
	void Start () {
        for(int i = 3; i<4; i++)
        {
            int portNum = i;
            //Initialise the serial port
            stream = new SerialPort("COM"+portNum, 9600);

            try
            {
                stream.Open();
                Debug.Log("Serial Port Open. Running on COM"+portNum);
                
            }
            catch (Exception ex)
            {
                Debug.Log("Tried to open COM" + i + " . Failed to open, trying next");
              
            }
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SendArduinoMessage(string message)
    {
        //Send message to arduino
        stream.Write(message);
        Debug.Log("Message was sent. Message was: " + message);
    }
}
