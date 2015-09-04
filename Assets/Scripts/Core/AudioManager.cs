using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    //Level BGMs
    public AudioSource mainMenuMusic;
    public AudioSource fileSelectMusic;
    public AudioSource preStoryMusic;
    public AudioSource levelSelectMusic;
    public AudioSource level1Music;
    public AudioSource level2Music;
    public AudioSource level3Music;
    public AudioSource level4Music;
    public AudioSource level5Music;
    public AudioSource level6Music;
    public AudioSource level7Music;
    public AudioSource level8Music;
    public AudioSource level9Music;
    public AudioSource level10Music;

    
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
            currAudio = fileSelectMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 4)
        {
            currAudio.Stop();
            currAudio = preStoryMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 5)
        {
            currAudio.Stop();
            currAudio = levelSelectMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 6)
        {
            currAudio.Stop();
            currAudio = level1Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 7)
        {
            currAudio.Stop();
            currAudio = level2Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 8)
        {
            currAudio.Stop();
            currAudio = level3Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 9)
        {
            currAudio.Stop();
            currAudio = level4Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 10)
        {
            currAudio.Stop();
            currAudio = level5Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 11)
        {
            currAudio.Stop();
            currAudio = level6Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 12)
        {
            currAudio.Stop();
            currAudio = level7Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 13)
        {
            currAudio.Stop();
            currAudio = level8Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 14)
        {
            currAudio.Stop();
            currAudio = level9Music;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 15)
        {
            currAudio.Stop();
            currAudio = level10Music;
            currAudio.Play();
        }
    }

    void Start()
    {
        //currAudio = mainMenuMusic;
    }
    
    void Update()
    {
        //Debug.Log(Application.loadedLevel);
    }
    public static AudioManager GetInstance()
    {
        return instance;
    }
}
