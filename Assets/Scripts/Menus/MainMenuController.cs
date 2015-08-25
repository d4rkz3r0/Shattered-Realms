using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class MainMenuController : MonoBehaviour
{

    public AudioSource ButtonSelectSFX;


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


    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
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

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
