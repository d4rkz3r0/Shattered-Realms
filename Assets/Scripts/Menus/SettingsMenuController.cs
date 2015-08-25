using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    private AudioSource testSFX;

    public AudioSource ButtonSelectSFX;

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

    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
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

	public void ScreenToggle()
	{
		Screen.fullScreen = !Screen.fullScreen;
	}
}
