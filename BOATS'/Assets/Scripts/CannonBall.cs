using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public CannonBallsFall ball;
    private AudioManager myAudio;
    public GameObject MenuManagerCanvas;

    private void Awake()
    {
        myAudio= FindObjectOfType<AudioManager>();
    }
    void Update ()
    {
		if(this.transform.position.y < -50)
        {
            gameObject.layer = 10;
            ball.cannonBalls.DeactivateObject(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (MenuManagerCanvas.GetComponent<GameMenuManager>().end == false)
        {
            if (collision.gameObject.tag == "water")
            {
                myAudio.Play("Splash");
                gameObject.layer = 0;
            }
            if(collision.gameObject.tag =="boat")
            {
                myAudio.Play("Hit");
            }
        }
    }
}
