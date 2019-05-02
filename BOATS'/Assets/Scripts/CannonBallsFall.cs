using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallsFall : MonoBehaviour {

    public ObjectPool cannonBalls;
    public float RangeX;
    public float RangeZ;
    public float frequency;
    float startFrequency;

	void Start ()
    {
        startFrequency = frequency;
	}
	
	// Update is called once per frame
	void Update ()
    {
        frequency -= Time.deltaTime;

        if (frequency < 0.0f)
            {
            float randXpos = Random.Range(this.transform.position.x -RangeX, this.transform.position.x + RangeX);
                float randZPos = Random.Range(this.transform.position.z - RangeZ, this.transform.position.z +  RangeZ);

                cannonBalls.GetAvailableObject().transform.position = new Vector3(randXpos, this.transform.position.y, randZPos);
                frequency = startFrequency;
            }
	}

    public void Spawn()
    {
        float randXpos = Random.Range(this.transform.position.x - RangeX, this.transform.position.x + RangeX);
        float randZPos = Random.Range(this.transform.position.z - RangeZ, this.transform.position.z + RangeZ);

        cannonBalls.GetAvailableObject().transform.position = new Vector3(randXpos, this.transform.position.y, randZPos);
    }
}
