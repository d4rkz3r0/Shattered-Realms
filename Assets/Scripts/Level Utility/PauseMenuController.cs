using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseUIOverlay;
    public AudioSource ButtonSelectSFX;

    //Private References
    public static bool isGamePaused;

	void Start ()
    {
        pauseUIOverlay.SetActive(false);
        isGamePaused = false;
	}
	
	void Update () 
    {
        //Gamepad Support
	    if(Input.GetButtonDown("Pause"))
        {
            isGamePaused = !isGamePaused;
        }

        if(isGamePaused)
        {
            pauseUIOverlay.SetActive(true);
            //Freeze Delta Time's scalar value
            Time.timeScale = 0.0f;
            
        }

        if(!isGamePaused)
        {
            pauseUIOverlay.SetActive(false);
            Time.timeScale = 1.0f;
        }
	}

    public void Resume()
    {
        isGamePaused = false;
    }


    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        AudioManager.currAudio.Stop();
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
    }
}
