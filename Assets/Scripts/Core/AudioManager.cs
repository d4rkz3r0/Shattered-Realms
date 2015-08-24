using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    //Level BGMs
    public AudioSource mainMenuMusic;
    public AudioSource preStoryMusic;
    public AudioSource tutorialLevelMusic;
    public AudioSource levelOneMusic;
    public AudioSource levelTwoMusic;
    public AudioSource SasukeBossFight;
    public AudioSource RobotnikBossFight;

    
    //Instance
    public static AudioSource currAudio;
    public static AudioManager instance = null;
    public static AudioManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        currAudio = GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

   void OnLevelWasLoaded(int level)
    {

        if (Application.loadedLevel == 3)
        {
            //currAudio.Stop();
            currAudio = preStoryMusic;
            currAudio.Play();
        }

        
        //if (Application.loadedLevelName == "TutorialLevel")
        //{
        //    currAudio.Stop();
        //    currAudio = tutorialLevelMusic;
        //    currAudio.Play();
        //}
        //if (Application.loadedLevelName == "Level1")
        //{
        //    currAudio.Stop();
        //    currAudio = level1Music;
        //    currAudio.Play();
        //}
        //if (Application.loadedLevelName == "TutorialLevelHard")
        //{
        //    currAudio.Stop();
        //    currAudio = tutorialLevelMusic;
        //    currAudio.Play();
        //}
        //if (Application.loadedLevelName == "Level1Hard")
        //{
        //    currAudio.Stop();
        //    currAudio = level1Music;
        //    currAudio.Play();
        //}
    }
    void Start()
    {
        if (Application.loadedLevelName == "IntroMenu")
        {
            //currAudio.Stop();
            //currAudio = mainMenuMusic;
            //currAudio.Play();
        }
    }
    
    void Update()
    {
        //if(Application.loadedLevelName == "IntroMenu")
        //{
        //    currAudio = mainMenuMusic;
        //    currAudio.Play();
        //}
    }
    public static AudioManager GetInstance()
    {
        return instance;
    }
}
