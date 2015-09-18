using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    private AudioSource testSFX;
    public AudioSource ButtonSelectSFX;
    public Image backgroundImage;
    public Image progressBarImage;
    public Text percentageText;
    private int loadingProgress = 0;
    //public GameObject loadingAnimation;

    void Awake()
    {

    }

	void Start () 
    {
        testSFX = GetComponent<AudioSource>();

        //loadingScreen = FindObjectOfType<LoadingScreenController>();
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

    public IEnumerator ChangeScene(int sceneChoice)
    {
        backgroundImage.gameObject.SetActive(true);
        progressBarImage.gameObject.SetActive(true);
        percentageText.gameObject.SetActive(true);

        progressBarImage.transform.localScale = new Vector3(loadingProgress,
                                                           progressBarImage.transform.localScale.y,
                                                           progressBarImage.transform.localScale.z);
        percentageText.text = "Loading..." + loadingProgress + "%";


        //Loads Level in background thread, without loss of input.
        AsyncOperation aSync = Application.LoadLevelAsync(sceneChoice);

        while (!aSync.isDone)
        {

            //Update While Frozen
            loadingProgress = (int)(aSync.progress * 100);

            //Use it
            percentageText.text = "Loading..." + loadingProgress + "%";
            progressBarImage.transform.localScale = new Vector3(aSync.progress,
                                                            progressBarImage.transform.localScale.y,
                                                            progressBarImage.transform.localScale.z);
            yield return null;
        } 
    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        GameOptionData.currentLevel = sceneChoice;
        StartCoroutine("ChangeScene", sceneChoice);
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
