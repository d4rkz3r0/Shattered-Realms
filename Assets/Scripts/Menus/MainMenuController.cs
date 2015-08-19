using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{

    void Awake()
    {
        
    }

    void Start()
    {
        

    }

    void Update()
    {
        
    }

    //Legacy Code
    //public void NewGame()
    //{
    //    PlayerPrefs.SetInt("PlayerCurrentXP", playerCurrentXP);
    //    PlayerPrefs.SetInt("PlayerMaxHP", playerMaxHP);
    //    Application.LoadLevel(newGameLevel);
    //}


    public void ChangeScene(int sceneChoice)
    {
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);
    }

    public void ToggleMusic()
    {
        if (MainMenuMusic.mainMenuBGM != null)
        {
            if (MainMenuMusic.mainMenuBGM.isPlaying)
            {
                MainMenuMusic.mainMenuBGM.Stop();
            }
            else
            {
                MainMenuMusic.mainMenuBGM.Play();
            }
        }
        else
        {
            return;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
