using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//bobobo bo bobobo

public class CreditsMenuController : MonoBehaviour
{

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

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
}
