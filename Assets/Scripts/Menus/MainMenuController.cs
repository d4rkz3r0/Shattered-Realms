using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class MainMenuController : MonoBehaviour
{

    public AudioSource ButtonSelectSFX;
    //public GameObject loadingAnimation;
    public Image backgroundImage;
    public Image progressBarImage;
    public Text percentageText;
    private int loadingProgress = 0;

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

        //AsyncOperation aSync = Application.LoadLevelAsync(sceneChoice);
        //while (!aSync.isDone)
        //{
        //    loadingAnimation.SetActive(true);
        //    yield return null;
        //}
        //yield return null;



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
        GameOptionData.currentLevel = sceneChoice;
        StartCoroutine("ChangeScene", sceneChoice);


        //loadingAnimation.SetActive(true);
        //ButtonSelectSFX.Play();
        //GameOptionData.currentLevel = sceneChoice;
        //StartCoroutine("ChangeScene", sceneChoice);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
