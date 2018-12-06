using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    private string HitboxName;
    [SerializeField]

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Wall")
        {

        }
    }

}
