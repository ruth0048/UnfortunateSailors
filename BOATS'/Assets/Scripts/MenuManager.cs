using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject playButton;
    public GameObject playTwoButton;
    public GameObject exitButton;
    public GameObject creditsButton;
    public GameObject controlsButton;
    public GameObject backFromControlsButton;
    public GameObject backFromCreditsButton;

    public GameObject CreditsImage;
    public GameObject ConrtolsImage;
    public GameObject MenuImage;

	void Start ()
    {
        backFromControlsButton.SetActive(false);
        ConrtolsImage.SetActive(false);
        backFromCreditsButton.SetActive(false);
        CreditsImage.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayTwo()
    {
        //load 2 player scene.
        SceneManager.LoadScene(2);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnCreditsButton()
    {
        playButton.SetActive(false);
        playTwoButton.SetActive(false);
        exitButton.SetActive(false);
        creditsButton.SetActive(false);
        controlsButton.SetActive(false);

        backFromCreditsButton.SetActive(true);
        backFromControlsButton.SetActive(false);
        CreditsImage.SetActive(true);
        ConrtolsImage.SetActive(false);
        MenuImage.SetActive(false);
    }

    public void OnControlsButton()
    {
        playButton.SetActive(false);
        playTwoButton.SetActive(false);
        exitButton.SetActive(false);
        creditsButton.SetActive(false);
        controlsButton.SetActive(false);

        backFromCreditsButton.SetActive(false);
        backFromControlsButton.SetActive(true);
        CreditsImage.SetActive(false);
        ConrtolsImage.SetActive(true);
        MenuImage.SetActive(false);
    }

    public void OnBackFromCredits()
    {
        playButton.SetActive(true);
        playTwoButton.SetActive(true);
        exitButton.SetActive(true);
        creditsButton.SetActive(true);
        controlsButton.SetActive(true);

        backFromCreditsButton.SetActive(false);
        backFromControlsButton.SetActive(false);
        CreditsImage.SetActive(false);
        ConrtolsImage.SetActive(false);
        MenuImage.SetActive(true);

    }

    public void OnBackFromControls()
    {
        playButton.SetActive(true);
        playTwoButton.SetActive(true);
        exitButton.SetActive(true);
        creditsButton.SetActive(true);
        controlsButton.SetActive(true);

        backFromCreditsButton.SetActive(false);
        backFromControlsButton.SetActive(false);
        CreditsImage.SetActive(false);
        ConrtolsImage.SetActive(false);
        MenuImage.SetActive(true);
    }
}
