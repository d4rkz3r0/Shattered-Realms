using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseUIOverlay;
    public AudioSource ButtonSelectSFX;
    public AudioSource ButtonEnterSFX;
    private bool transitionScene;

    //Private References
    public static bool isGamePaused;
    private LevelManager LM;

	void Start ()
    {
        LM = FindObjectOfType<LevelManager>();
        pauseUIOverlay.SetActive(false);
        isGamePaused = false;
        transitionScene = false;
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
            if(transitionScene)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
            
            
        }

        if(!isGamePaused)
        {
            pauseUIOverlay.SetActive(false);
            Time.timeScale = 1.0f;
        }
	}

    public void Resume()
    {
        ButtonSelectSFX.Play();
        isGamePaused = false;
    }

    public void Respawn()
    {
        ButtonSelectSFX.Play();
        isGamePaused = false;
        HealthManager.playerHP = 0;
    }


    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        //AudioManager.currAudio.Stop();
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        transitionScene = true;
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
    }
}
