using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour
{
    public bool keyCollected;
    private bool isplayerInWarp;
    private bool playedOnce;
    private AudioSource warpSFX;
    private float winAudioTimer;
    private float warpSFXDuration;

	void Start ()
    {
        //sceneToLoad = GameManager.currentLevel;
        playedOnce = false;
        isplayerInWarp = false;
        keyCollected = false;
        warpSFX = GetComponent<AudioSource>();
        warpSFXDuration = 1.3f;
	}
	
	void Update ()
    {
        if ((Input.GetAxis("Vertical") > 0.0f) && isplayerInWarp && keyCollected)
        {
            if(!playedOnce)
            {
                warpSFX.Play();
                playedOnce = true;
            }
            Invoke("LoadLevel", warpSFXDuration);
        }
        else if ((Input.GetAxis("Vertical") > 0.0f) && isplayerInWarp && !keyCollected)
        {
            //Tell the player to get they Key!
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

        //Always Load the Level Complete Screen
        Application.LoadLevel(16);
    }
}
