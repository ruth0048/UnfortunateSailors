using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPressure : MonoBehaviour {

    private Rigidbody myRB;
    public float maxHeight;//=1.25f
    public float pressure=10.0f;

    //lowest point variable?
    //random up and down?
    //match waves

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
        maxHeight = myRB.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (myRB.position.y < maxHeight)
        {
            Vector3 myVector = new Vector3(0.0f, pressure, 0.0f);
            myRB.AddForce(myVector, ForceMode.Force);
        }
        else
        { 
            Vector3 otherVec = new Vector3(myRB.position.x, maxHeight, myRB.position.z);
            myRB.MovePosition(otherVec);
        }
        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    pressure = 5.0f;
        //}

        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    pressure = 10.0f;
        //}
        ////maxHeight += Mathf.Sin(transform.position.x + Time.deltaTime) * (Mathf.Cos(45));
        ////maxHeight += Mathf.Cos(transform.position.z + Time.deltaTime) * Mathf.Cos(45);
    }
}
