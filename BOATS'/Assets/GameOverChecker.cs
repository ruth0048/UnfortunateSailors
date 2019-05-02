using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour {

    //timer for touching long enough
    // Use this for initialization
   // private float gameTimer=0.0f;
    private float deathTimer = 0.0f;
    public float gracePeriod = 2.0f;
    private bool startCountDown = false;
    public GameObject canonSpawner;
    private bool canSpawn = true;
    public GameObject lose;
    private AudioManager myAudio;

    bool playOnce = false; 

    void Start () {
        myAudio = FindObjectOfType<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //gameTimer += Time.deltaTime;
        DeathCount();
        //Incrementer();
        //follow many if statements
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="boat")
        {
            startCountDown = true;          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "boat")
        {
            startCountDown = false;
            deathTimer = 0.0f;
        }
    }
    void DeathCount()
    {
        if (startCountDown)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > gracePeriod)
            {
                Debug.LogWarning("GameOver");
                myAudio.Stop("Music");
                if (!playOnce)
                {
                    myAudio.Play("Lose");
                    playOnce = true;
                }
                lose.GetComponent<GameMenuManager>().onLose();
            }
        }
    }

   // void Incrementer()
    //{
     //series of if statements
     //if(myTimer>132.0f && myTimer < 132.1f)
     //   {
     //       //do your stuff
     //       return;
     //   }
     //   if (myTimer > 125.0f && myTimer < 125.1f)
     //   {
     //       //do your stuff
     //       return;
     //   }
     //   if (myTimer > 99.0f && myTimer < 99.1f)
     //   {
     //       //do your stuff
     //       return;
     //   }
     //   if (myTimer > 85.0f && myTimer < 85.1f)
     //   {
     //       //do your stuff
     //       return;
     //   }
     //   if (myTimer > 80.0f && myTimer < 80.1f)
     //   {
     //       //do your stuff
     //       return;
     //   }
     //   if (myTimer > 70.0f && myTimer < 70.1f)
     //   {
     //       //do your stuff
     //       if(canSpawn)
     //       {
     //           canonSpawner.GetComponent<CannonBallsFall>().Spawn();
     //           canSpawn = false;
     //       }
     //       return;
     //   }
     //   if (myTimer > 55.0f && myTimer <55.1f)
     //   {
     //       //do your stuff
     //       return;
     //   }
     //   if (myTimer > 40.0f && myTimer < 40.1f)
     //   {
     //       //do your stuff
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeX = 1f;
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeZ = 1f;
     //       canonSpawner.GetComponent<CannonBallsFall>().frequency = 1.5f;
     //       return;
     //   }
     //   if (myTimer > 12.0f && myTimer < 12.1f)
     //   {
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeX = 2f;
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeZ = 2f;
     //       canonSpawner.GetComponent<CannonBallsFall>().frequency = 1.8f;
     //       canSpawn = true;
     //       return;
     //   }
     //   if (myTimer > 8.0f && myTimer < 8.1f)
     //   {
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeX = 1.5f;
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeZ = 1.5f;
     //       canonSpawner.GetComponent<CannonBallsFall>().frequency = 2.0f;
     //       if (canSpawn)
     //       { 
     //           canonSpawner.GetComponent<CannonBallsFall>().Spawn();
     //           canSpawn = false;
     //       }
     //       return;
     //   }

     //   if (myTimer > 6.0f && myTimer < 6.1f)
     //   {
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeX = 1.3f;
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeZ = 1.3f;
     //       canSpawn = true;
     //       return;
     //   }
     //   if (myTimer > 3.0f&& myTimer<3.1f)
     //   {
     //       //do your stuff
     //       //one timer?
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeX = 1.0f;
     //       canonSpawner.GetComponent<CannonBallsFall>().RangeZ = 1.0f;
     //       canonSpawner.GetComponent<CannonBallsFall>().frequency = 3.0f;

     //       if (canSpawn)
     //       {
     //           canonSpawner.GetComponent<CannonBallsFall>().Spawn();
     //           canSpawn = false;
     //       }
     //       return;
     //   }
        //can effect range as well
   // }
}
