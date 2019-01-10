using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using UnityEngine.UI;

public class SendMsgArduino : MonoBehaviour {
    [SerializeField]
    private int portNum;

    SerialPort stream;


	// Use this for initialization
	void Start () {
        //Initialise the serial port
        for(int i=0; i<10; i++)
        {
            portNum = i;
            stream = new SerialPort("COM" + portNum, 9600);

            if(!stream.IsOpen)
            {
                try
                {
                    Debug.Log("Trying to open serial port: " + "COM" + i);
                    stream.Open();
                    Debug.Log("Serial Port Open");

                    break;
                }
                catch (Exception ex)
                {
                    Debug.Log("Failed to open port. Error: " + ex);
                }
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
