using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    private string HitboxName;
    [SerializeField]
    private GameObject ArduinoController;
    private SendMsgArduino arduino;
       
    private void Start()
    {
        arduino = ArduinoController.GetComponent<SendMsgArduino>();    
    }

    void OnCollisionEnter(Collision col)
    {
       
        if(col.gameObject.tag == "Wall")
        {
            string msg = "";
            if(HitboxName == "LeftArm")
            {
                msg = "LUpperArm";
            }
            else if(HitboxName == "RightArm")
            {
                msg = "RUpperArm";
            }

            //Send message to arduinol
            arduino.SendArduinoMessage(msg);

            Debug.Log("Hit Wall, should've sent to arduino");
        }
    }

}
