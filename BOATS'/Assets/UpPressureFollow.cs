using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPressureFollow : MonoBehaviour {

    // Use this for initialization
    public GameObject boat;

    Vector3 lastPosBoat;

    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {

            Vector3 moveVector = boat.transform.position - lastPosBoat;
            moveVector = new Vector3(moveVector.x, 0.0f, moveVector.z);
            this.transform.position += moveVector;
        
        lastPosBoat = boat.transform.position;
    }

}