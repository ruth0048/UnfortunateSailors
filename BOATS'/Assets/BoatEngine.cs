using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatEngine : MonoBehaviour
{

    public bool listenForInput = false;
    public GameObject player1;
    public GameObject player2;
    private GameObject myOperator;
    // Use this for initialization
    public GameObject waterMover;
    public GameObject island;
    public GameObject propeller;
    void Start()
    {
        waterMover.GetComponent<ShipMovement>().enabled = false;
        island.GetComponent<ShipMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (listenForInput)
        {
            //if (Input.GetKey("space") && myOperator == null)
            //{
               /// myOperator = player1;
                //movement true
                waterMover.GetComponent<ShipMovement>().enabled = true;
                island.GetComponent<ShipMovement>().enabled = true;
            propeller.GetComponent<Rotater>().isRotating = true;
            //}

            //if (Input.GetKeyUp("space") && myOperator == player1)
            //{
            //    myOperator = null;
                //waterMover.GetComponent<ShipMovement>().enabled = false;
                //island.GetComponent<ShipMovement>().enabled = false;
           // }
            //repeat for second player
        }
        if (!listenForInput)
        {
            waterMover.GetComponent<ShipMovement>().enabled = false;
            island.GetComponent<ShipMovement>().enabled = false;
            propeller.GetComponent<Rotater>().isRotating = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            listenForInput = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            listenForInput = false;

            if (other.gameObject == myOperator)
            {
                myOperator = null;
                waterMover.GetComponent<ShipMovement>().enabled = false;
                island.GetComponent<ShipMovement>().enabled = false;
            }
        }
    }
}
