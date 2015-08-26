using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    //Level BGMs
    public AudioSource mainMenuMusic;
    public AudioSource fileSelectMusic;
    public AudioSource preStoryMusic;
    public AudioSource tutorialLevelMusic;
    public AudioSource levelOneMusic;
    public AudioSource SasukeBossFight;
    public AudioSource GizmoBossFight;
    public AudioSource RobotnikBossFight;
    public AudioSource MarioBossFight;

    
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
            currAudio = tutorialLevelMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 6)
        {
            currAudio = levelOneMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 7)
        {
            currAudio = SasukeBossFight;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 8)
        {
            currAudio = GizmoBossFight;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 9)
        {
            currAudio = RobotnikBossFight;
            currAudio.Play();
        }
       else if (Application.loadedLevel == 10)
        {
            currAudio = MarioBossFight;
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
