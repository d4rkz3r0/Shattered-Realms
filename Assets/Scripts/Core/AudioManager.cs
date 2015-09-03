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
        if (Application.loadedLevel == 0)
        {
            if(currAudio != null)
            {
                currAudio.Stop();
            }

            
            
        }

        else if (Application.loadedLevel == 3)
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
            currAudio.Stop();
            currAudio = tutorialLevelMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 6)
        {
            currAudio.Stop();
            currAudio = levelOneMusic;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 7)
        {
            currAudio.Stop();
            currAudio = SasukeBossFight;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 8)
        {
            currAudio.Stop();
            currAudio = GizmoBossFight;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 9)
        {
            currAudio.Stop();
            currAudio = RobotnikBossFight;
            currAudio.Play();
        }
       else if (Application.loadedLevel == 10)
        {
            currAudio.Stop();
            currAudio = MarioBossFight;
            currAudio.Play();
        }
        else if (Application.loadedLevel == 11)
        {
            currAudio.Stop();
            currAudio = MarioBossFight;
            currAudio.Play();
        }
    }

    void Start()
    {

    }
    
    void Update()
    {
        Debug.Log(Application.loadedLevel);
    }
    public static AudioManager GetInstance()
    {
        return instance;
    }
}
