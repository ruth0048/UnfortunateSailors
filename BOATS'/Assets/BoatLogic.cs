using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLogic : MonoBehaviour {
    Vector3 startPosition;
    Vector3 Destination;
    public float gameLengthTravelSpeed;//inverse it so that big numbers mean takes longer to get there
    public GameObject Target;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        Destination = Target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, Destination, gameLengthTravelSpeed * Time.deltaTime);
	}
}
