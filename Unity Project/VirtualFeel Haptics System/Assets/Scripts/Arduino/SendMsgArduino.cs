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
        //Initialise the serial port
        stream = new SerialPort(portName, 9600);

        try
        {
            stream.Open();
            Debug.Log("Serial Port Open");
        }
        catch(Exception ex)
        {
            Debug.Log("Failed to open port. Error: " + ex);
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
