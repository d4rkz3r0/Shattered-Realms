using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour 
{
    static private MainMenuMusic instance;
    static public AudioSource mainMenuBGM;

    //Keep Audio Playing throughout Menu States
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        //GameOptionData.InitializeGame();
    }

    void OnLevelWasLoaded(int level)
    {
        //File Select Menu Reached, stop Intro Menu BGM
        if(level == 3)
        {
            Destroy(gameObject);
        }
    }

	void Start () 
    {
        mainMenuBGM = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
        mainMenuBGM.volume = GameOptionData.musicVolume;
	}

    
}
