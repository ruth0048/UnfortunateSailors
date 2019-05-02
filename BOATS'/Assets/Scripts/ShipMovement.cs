using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float MoveSpeed;
    public float Acceleration;
    public float RotationSpeed;
    public Vector3 Size;
    public bool GoesIdle;
    public bool Idle;
    public float IdleTimer;
    public float IdleTime;
    public float StuckTimer;
    public bool CurvedTurns;
    //seems to work best at 0.5f
    public float DistanceWhenArrived = 0.1f;
    public float DistanceBetweenAngles = 0.5f;

    //set up Destination points dynamically in a game scene for the specific ai to walk to
    public Transform[] DestinationPoints;
    public Vector3 CurrentDestination;
    public int currentDestinationIndex;
    public Vector3 StartPosition;

    public bool Patrol;
    public bool UseRotation;

    void Start ()
    {
        //the start position of the object is the first of it's destinations
        StartPosition = this.transform.position;
        currentDestinationIndex = 0;
        DestinationPoints[currentDestinationIndex].position = this.StartPosition;
        CurrentDestination = DestinationPoints[currentDestinationIndex].position;


        IdleTimer = IdleTime;
        StuckTimer = IdleTimer + 1.0f;

    }

    // Update is called once per frame
    void Update ()
    {
        HandleAi();
    }

    public void HandleAi()
    {
        if (!this.Idle)
        {
            if (UseRotation)
            {
                //have ai turn to its destination, and have it move towards it
                TurnToDestination(this.transform.position, CurrentDestination);

                if (Vector3.Distance(transform.forward, (CurrentDestination - transform.position).normalized) < DistanceBetweenAngles || this.CurvedTurns)
                {
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }
            }
            else
            {
                Vector3 moveVector = (CurrentDestination - transform.position).normalized * MoveSpeed * Time.deltaTime;
                transform.position += moveVector;
            }

        }

        if (this.Idle)
        {
            IdleTimer -= Time.deltaTime;
            if (IdleTimer < 0.0f)
            {
                this.Idle = false;
                IdleTimer = IdleTime;
            }
        }

        if (Patrol)
        {
            //if it has arrived
            if (Vector3.Distance(transform.position, CurrentDestination) < this.DistanceWhenArrived)
            {
                //go to the next destination in the array
                currentDestinationIndex++;
                //Sometimes the next destination is the start of the array
                if (DestinationPoints.Length - 1 < currentDestinationIndex)
                {
                    currentDestinationIndex = 0;
                }

                CurrentDestination = DestinationPoints[currentDestinationIndex].position;
            }
        }
        if (!Patrol)
        {
            //if it has arrived
            if (Vector3.Distance(transform.position, CurrentDestination) < this.DistanceWhenArrived)
            {
                //still go to next index
                if (DestinationPoints.Length - 1 > currentDestinationIndex)
                {
                    currentDestinationIndex++;
                    CurrentDestination = DestinationPoints[currentDestinationIndex].position;
                }
                else
                {
                    //but if it has arrived to its last index, make it forever idle
                    this.Idle = true;
                }
            }
        }
    }

    public void TurnToDestination(Vector3 currentPosition, Vector3 destinationPoistion)
    {
        //have Ai rotate towards its desired destination
        Vector3 destDir = (destinationPoistion - currentPosition).normalized;
        Vector3 rot = Vector3.RotateTowards(transform.forward, destDir, Time.deltaTime, 1.0f);
        transform.rotation = Quaternion.LookRotation(rot);
    }
}
