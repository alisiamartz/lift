﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRange : MonoBehaviour {

    private bool inRange;

    // Use this for initialization
    void Start () {

        inRange = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(inRange == false)
        {
            GetComponent<LeverRotation>().grabbed = false;
        }
	}

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "grabPoint")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "grabPoint")
        {
            inRange = false;
        }
    }

    public void attemptGrab(GameObject hand){
        if (inRange)
        {
            GetComponent<LeverRotation>().grabbed = true;
            GetComponent<LeverRotation>().grabHand = hand;

            //Trigger Haptic pulse
            GameObject.FindGameObjectWithTag("ElevatorManager").GetComponent<grabHaptic>().triggerBurst(5, 2);
        }
    }

    public void attemptRelease()
    {
        GetComponent<LeverRotation>().grabbed = false;
    }
}
