using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCannonBallsLevel : MonoBehaviour
{
    public GameObject MenuManagerCanvas;
    public ObjectPool cannonBalls;
    public float RangeX;
    public float RangeZ;
    public float frequency;
    float frequencyTimer;
    float startFrequency;

    float difficultyTime;
    int difficulty;
    AudioManager myAudio;

    void Start()
    {
        startFrequency = frequency;
        difficulty = 1;
        //starting difficulty time
        difficultyTime = 6.0f;
        myAudio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManagerCanvas.GetComponent<GameMenuManager>().end == false )
        {
            CheckDifficulty();

            //update frequency
            frequency -= Time.deltaTime;

            //spawn based on frequency
            if (frequency < 0.0f)
            {
                float randXpos = Random.Range(this.transform.position.x - RangeX, this.transform.position.x + RangeX);
                float randZPos = Random.Range(this.transform.position.z - RangeZ, this.transform.position.z + RangeZ);

                GameObject bleh = cannonBalls.GetAvailableObject();
                bleh.transform.position = new Vector3(randXpos, this.transform.position.y, randZPos);
                bleh.GetComponent<Rigidbody>().velocity = Vector3.zero;

                frequency = frequencyTimer;
                myAudio.Play("Shoot");
            }
        }
    }

    public void Spawn()
    {
        float randXpos = Random.Range(this.transform.position.x - RangeX, this.transform.position.x + RangeX);
        float randZPos = Random.Range(this.transform.position.z - RangeZ, this.transform.position.z + RangeZ);

        cannonBalls.GetAvailableObject().transform.position = new Vector3(randXpos, this.transform.position.y, randZPos);
        myAudio.Play("Shoot");
    }

    void CheckDifficulty()
    {
        difficultyTime -= Time.deltaTime;
        //if time to increase difficulty
        switch (difficulty)
        {
            case 1:
                frequencyTimer = 3.0f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 10.0f;
                }
                break;
            case 2:
                frequencyTimer = 2.75f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 15.0f;
                }
                break;
            case 3:
                frequencyTimer = 3.0f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 10.0f;
                }
                break;
            case 4:
                frequencyTimer = 2.25f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 10.0f;
                }
                break;
            case 5:
                frequencyTimer = 2.75f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 10.0f;
                }
                break;
            case 6:
                frequencyTimer = 1.75f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 6.0f;
                }
                break;
            case 7:
                frequencyTimer = 2.0f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 6.0f;
                }
                break;
            case 8:
                frequencyTimer = 1.25f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 6.0f;
                }
                break;
            case 9:
                frequencyTimer = 1.0f;
                if (difficultyTime < 0.0f)
                {
                    difficulty++;
                    difficultyTime = 6.0f;
                }
                break;
            case 10:
                frequencyTimer = 0.75f;
                break;
        }
    }
}