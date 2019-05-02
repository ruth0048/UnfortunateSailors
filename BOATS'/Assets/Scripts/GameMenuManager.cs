using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour {

    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject retryButton;
    public GameObject menuButton;
    public bool end;
    private void Update()
    {
    }

    public void OnRetryPressed()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().name == "TwoPlayerScene")
        {
            SceneManager.LoadScene(2);
        }
    }

    public void OnMenuPress()
    {
        SceneManager.LoadScene(0);
    }

    //please do other functionality elsewhere, like turning off this song and starting new one. 
    public void onLose()
    {
        LoseScreen.SetActive(true);
        WinScreen.SetActive(false);

        retryButton.SetActive(true);
        menuButton.SetActive(true);
        end = true;
    }

    //same as above.
    public void onWin()
    {
        LoseScreen.SetActive(false);
        WinScreen.SetActive(true);

        retryButton.SetActive(true);
        menuButton.SetActive(true);
        end = true;
    }
}
