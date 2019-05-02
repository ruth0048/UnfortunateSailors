using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour {
    public GameObject win;
    private AudioManager myAudio;
    bool playOnce = false;
    //private bool win = false;
    private void Awake()
    {
        myAudio = FindObjectOfType<AudioManager>();
    }

    //private void Update()
    //{
    //    if(win)
    //    {
    //        fade();
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="boat")
        {
            myAudio.Stop("Music");
            if (!playOnce)
            {
                myAudio.Play("Win");
                playOnce = true;
            }
            win.gameObject.GetComponent<GameMenuManager>().onWin();
            Debug.LogWarning("WIN");
        }
    }
}
