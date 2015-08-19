using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseUIOverlay;

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

    public void Respawn()
    {
        //Fuck yourself
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
