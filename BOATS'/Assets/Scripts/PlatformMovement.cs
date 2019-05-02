using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public GameObject boat;

    Vector3 lastPosBoat;
    bool onBoat = false;

	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (onBoat)
        {
            Vector3 moveVector = boat.transform.position - lastPosBoat;
            this.transform.position += moveVector;
        }
        lastPosBoat = boat.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "boat")
        {
            onBoat = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "boat")
        {
            onBoat = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "boat")
    //    {
    //        onBoat = false;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "boat")
    //    {
    //        onBoat = true;
    //    }
    //}
}
