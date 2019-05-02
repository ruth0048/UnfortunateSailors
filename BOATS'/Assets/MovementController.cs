using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed;
    private CharacterController myController;
    private Vector3 moveDir;
    public float mass;
    // Use this for initialization

    public GameObject grabPoint;

    [SerializeField]
    private GameObject canonBall;
    bool hasBall = false;

    void Start () {
        myController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0.0f, Input.GetAxis("Vertical") * moveSpeed);

       moveDir.y = moveDir.y + (Physics.gravity.y*mass);//* Time.deltaTime

        myController.Move(moveDir*Time.deltaTime);

        //if(moveDir !=Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(moveDir);
        //}
        //myController.Move(moveDir /8);
        RotatePlayer();

        if (Input.GetKeyDown("space") && canonBall != null)
        {
            if (hasBall == false)
            {
                moveSpeed = 1.0f;
                canonBall.transform.position = grabPoint.transform.position;
                canonBall.GetComponent<Rigidbody>().isKinematic = true;
                canonBall.transform.parent = grabPoint.transform;
                hasBall = true;
            }
            else
            {
                moveSpeed = 1.5f;
                canonBall.transform.parent = null;
                canonBall.GetComponent<Rigidbody>().isKinematic = false;
                canonBall.GetComponent<Rigidbody>().AddForce(new Vector3(this.transform.forward.x, this.transform.forward.y + 3.0f, this.transform.forward.z), ForceMode.Impulse);
                canonBall = null;
                hasBall = false;
            }
        }
    }
    void RotatePlayer()
    {
        float val = 0.1f;
        float nVal = -0.1f;
        //&& moveDir.y < val
        //&& myBody.velocity.y > nVal
        if (moveDir.x < val  && moveDir.z < val
            && moveDir.x > nVal  && moveDir.z > nVal)
        {
            return;
        }

        //will force the player to look forward if not moving. 
        //if(MovementIsHappening)
        moveDir.y = 0.0f;
        this.transform.forward = moveDir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball" && canonBall == null)
        {
            if (hasBall == false)
            {
                canonBall = other.gameObject;
                //added for more responsivness so you can hold the spacebar/press it down before it enters the trigger box
                if (Input.GetKey("space"))
                {
                    moveSpeed = 1.0f;
                    canonBall.transform.position = grabPoint.transform.position;
                    canonBall.GetComponent<Rigidbody>().isKinematic = true;
                    canonBall.transform.parent = grabPoint.transform;
                    hasBall = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ball")
        {
            if (hasBall == false)
            {
                canonBall = null;
            }
        }
    }
}
