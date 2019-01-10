using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOpenDoor : MonoBehaviour {
    [SerializeField]
    GameObject leftDoor;

    [SerializeField]
    GameObject rightDoor;

    private bool leftOpen = false;
    private bool rightOpen = false;

    private Animator ld_Animator;
    private Animator rd_Animator;

	// Use this for initialization
	void Start () {
        ld_Animator = leftDoor.GetComponent<Animator>();
        rd_Animator = rightDoor.GetComponent<Animator>();

        leftOpen = ld_Animator.GetBool("isOpen");
        rightOpen = rd_Animator.GetBool("isOpen");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleDoor()
    {
        if(leftOpen && rightOpen)
        {
            ld_Animator.SetBool("isOpen", false);
            rd_Animator.SetBool("isOpen", false);

            leftOpen = rightOpen = false;
        }
        else if(!leftOpen && !rightOpen)
        {
            ld_Animator.SetBool("isOpen", true);
            rd_Animator.SetBool("isOpen", true);

            leftOpen = rightOpen = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            //If tag is "finish", reload the scene
            Scene currLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currLevel.buildIndex);
        }
    }


}
