using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    public bool isRotating;
	
	// Update is called once per frame
	void Update ()
    {
		if(isRotating)
        {
            this.transform.Rotate(new Vector3(0, 0, 1), 20.0f);
        }
	}
}
