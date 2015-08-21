using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    private AudioSource testSFX;

    void Awake()
    {

    }

	void Start () 
    {
        testSFX = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        musicVolumeSlider.value = GameOptionData.musicVolume;
        sfxVolumeSlider.value = GameOptionData.sfxVolume;
	}

    public void AdjustMusicVolume(float newMusicVolume)
    {
        GameOptionData.musicVolume = newMusicVolume;
    }
    public void AdjustSFXVolume(float newSFXVolume)
    {
        GameOptionData.sfxVolume = newSFXVolume;
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

    public void TestSFX()
    {
        testSFX.volume = GameOptionData.sfxVolume;
        testSFX.Play();
    }

	public void ScreenMode()
	{
		GameOptionData.fullScreen = Screen.fullScreen;
		Screen.fullScreen = !Screen.fullScreen;
	}
}
