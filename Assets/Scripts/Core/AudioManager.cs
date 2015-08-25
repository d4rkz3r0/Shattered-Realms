using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    //Level BGMs
    public AudioSource mainMenuMusic;
    public AudioSource preStoryMusic;
    public AudioSource tutorialLevelMusic;
    public AudioSource levelOneMusic;
    public AudioSource SasukeBossFight;
    public AudioSource GizmoBossFight;
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
        else if (Application.loadedLevel == 4)
        {
            //currAudio.Stop();
            currAudio = tutorialLevelMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 5)
        {
            //currAudio.Stop();
            currAudio = levelOneMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 6)
        {
            //currAudio.Stop();
            currAudio = preStoryMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 7)
        {
            //currAudio.Stop();
            currAudio = preStoryMusic;
            currAudio.Play();
        }
    }
    void Start()
    {

    }
    
    void Update()
    {

    }
    public static AudioManager GetInstance()
    {
        return instance;
    }
}
