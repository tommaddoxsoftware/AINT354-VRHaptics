﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    private string HitboxName;
    [SerializeField]
    private GameObject ArduinoController;
    private SendMsgArduino arduino;
    private UIOpenDoor doorScript;

    [SerializeField]
    private GameObject doorController;

    private int lCon, rCon, fCon = 0;
    private bool running = false;


    private void Start()
    {
        arduino = ArduinoController.GetComponent<SendMsgArduino>();
        doorScript = doorController.GetComponent<UIOpenDoor>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Wall")
        {
            string msg = "";
            if (HitboxName == "LeftCol")
            {
                msg = "LUPPERARMCOIN";

                //Reset consecutive rCoin value and increment lCoin
                rCon = 0;
                lCon++;
            }
            else if (HitboxName == "RightCol")
            {
                msg = "RUPPERARMCOIN";

                //Reset consecutive lCoin value and increment rCoin
                lCon = 0;
                rCon++;
            }
            else if (HitboxName == "FrontCol")
            {
                msg = "BOTHCOIN";
            }

            //Send message to arduinol
            arduino.SendArduinoMessage(msg);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if(!running)
            {
                switch (HitboxName)
                {
                    case "RightCol":
                        InvokeRepeating("IncrementRight", 1f, 1f);
                        running = true;
                        break;
                    case "LeftCol":
                        InvokeRepeating("IncrementLeft", 1f, 1f);
                        running = true;

                        break;
                    case "FrontCol":
                        InvokeRepeating("IncrementFront", 1f, 1f);
                        break;
                }
            }

        }
    }

    private void IncrementLeft()
    {
        lCon++;

        //If hit 5 consecutive calls, fire rumble
        if(lCon == 5)
        {
            arduino.SendArduinoMessage("LUPPERARMRUMBLE");
        }

        //If hit 10, fire both
        if (lCon == 10)
        {
            arduino.SendArduinoMessage("LUPPERARMBOTH");
        }
    }

    private void IncrementRight()
    {
        rCon++;

        //If hit 5 consecutive calls, fire rumble
        if (rCon == 5)
        {
            arduino.SendArduinoMessage("RUPPERARMRUMBLE");
        }

        //If hit 10, fire both
        if (rCon == 10)
        {
            arduino.SendArduinoMessage("RUPPERARMBOTH");
        }
    }

    private void IncrementFront()
    {
        fCon++;

        //If hit 5 consecutive calls, fire rumble
        if (fCon == 5)
        {
            arduino.SendArduinoMessage("BOTHRUMBLE");
        }

        //If hit 10, fire both
        if (fCon == 10)
        {
            arduino.SendArduinoMessage("BOTHBOTH");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            string msg = "STOP";
            lCon = rCon = fCon = 0;
            arduino.SendArduinoMessage(msg);
        }

        
        CancelInvoke();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StartArea")
        {
            UIOpenDoor doorScript = doorController.GetComponent<UIOpenDoor>();
            doorScript.ToggleDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StartArea")
        {

            doorScript.ToggleDoor();
        }
    }

}
