using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour
{
    private bool isplayerInWarp;
    public int sceneToLoad;
    public bool canWarp;
    private bool playedOnce;
    private AudioSource winMusic;
    private float winAudioTimer;
    public float winDurationTime;

	void Start ()
    {
        //sceneToLoad = GameManager.currentLevel;
        playedOnce = false;
        winMusic = GetComponent<AudioSource>();
        winDurationTime = 3.0f;
        canWarp = false;
        isplayerInWarp = false;
	}
	
	void Update ()
    {
        //if(winAudioTimer >= 0.0f)
        //{
        //    winAudioTimer -= Time.deltaTime;
        //}

        //if(winAudioTimer <= 0.0f)
        //{
            
        //}

        if ((Input.GetAxis("Vertical") > 0.0f) && isplayerInWarp && canWarp)
        {
            //XPManager.AddToPlayerXP(XPManager.xpEarnedThisLevel);
            //MessageController.textSelection = 1;
            if(!playedOnce)
            {
                //if (AudioManager.currAudio.isPlaying)
                //{
                //    AudioManager.currAudio.Stop();
                //}
                
                winMusic.Play();
                playedOnce = true;
            }
            Invoke("LoadLevel", 3.4f);
            
            
        }
        else if ((Input.GetAxis("Vertical") > 0.0f) && isplayerInWarp && !canWarp)
        {
            MessageController.textSelection = 19;
            
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            isplayerInWarp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            isplayerInWarp = false;
        }
    }
    

    void LoadLevel()
    {
        int nextLevelToLoad = Application.loadedLevel;
        nextLevelToLoad++;

        float yourLevelTime = Time.time;
        int levelCompletedTimeSecs = (int)Mathf.Round(yourLevelTime);
        GameOptionData.actualLevelTime = levelCompletedTimeSecs;

        float goalLevelTime = FindObjectOfType<TimerManager>().timeToCompleteLevel;
        int levelGoalTimeSecs = (int)Mathf.Round(goalLevelTime);
        GameOptionData.levelGoalTime = levelGoalTimeSecs;

        float xpCollectedPercentage = FindObjectOfType<XPGemManager>().formatFinalXPBarRatio;
        GameOptionData.xpCollectedPercentage = xpCollectedPercentage;

        GameOptionData.nextLevel = nextLevelToLoad;
        if(nextLevelToLoad == 13)
        {
            sceneToLoad = 0;
        }
        Application.LoadLevel(sceneToLoad);
    }
}
