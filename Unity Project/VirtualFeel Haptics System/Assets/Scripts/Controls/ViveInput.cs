using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour {
    [SteamVR_DefaultAction("touchpadmove")]
    public SteamVR_Action_Vector2 touchpadAction;

    [SerializeField]
    private Transform steamRig;

	void Update () {

        Vector2 touchpadValue = touchpadAction.GetAxis(SteamVR_Input_Sources.Any);
        if(touchpadValue != Vector2.zero)
        {
            if(steamRig != null)
            {
                steamRig.position += (transform.right * touchpadValue.x + transform.forward * touchpadValue.y) * Time.deltaTime;
                steamRig.position = new Vector3(steamRig.position.x, 0, steamRig.position.z);
            }

        }

	}
}
