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
    private TimerManager timerManager;

	void Start ()
    {
        playedOnce = false;
        isplayerInWarp = false;
        keyCollected = false;
        warpSFX = GetComponent<AudioSource>();
        timerManager = FindObjectOfType<TimerManager>();
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
        //Game State Data
        int nextLevelToLoad = Application.loadedLevel;
        nextLevelToLoad++;

        GameOptionData.prevLevel = Application.loadedLevel;
        GameOptionData.nextLevel = nextLevelToLoad;
        

        //Level and Goal Timer Data
        float yourLevelTime = Time.time;
        int levelCompletedTimeSecs = (int)Mathf.Round(yourLevelTime);

        //Save Level Time
        switch(Application.loadedLevel)
        {
            case 6:
                {
                    GameOptionData.levelOneActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 7:
                {
                    GameOptionData.levelTwoActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 8:
                {
                    GameOptionData.levelThreeActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 9:
                {
                    GameOptionData.levelFourActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 10:
                {
                    GameOptionData.levelFiveActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 11:
                {
                    GameOptionData.levelSixActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 12:
                {
                    GameOptionData.levelSevenActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 13:
                {
                    GameOptionData.levelEightActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 14:
                {
                    GameOptionData.levelNineActualTime = levelCompletedTimeSecs;
                    break;
                }
            case 15:
                {
                    GameOptionData.levelTenActualTime = levelCompletedTimeSecs;
                    break;
                }
            default:
                {
                    Debug.Log("Level loaded is not a gameplay level...");
                    break;
                }
        }

        float maxLevelTime = timerManager.maxTimeToCompleteLevel;
        int maxLevelTimeSecs = (int)Mathf.Round(maxLevelTime);

        //Save Max Level Time
        switch (Application.loadedLevel)
        {
            case 6:
                {
                    GameOptionData.levelOneMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 7:
                {
                    GameOptionData.levelTwoMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 8:
                {
                    GameOptionData.levelThreeMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 9:
                {
                    GameOptionData.levelFourMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 10:
                {
                    GameOptionData.levelFiveMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 11:
                {
                    GameOptionData.levelSixMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 12:
                {
                    GameOptionData.levelSevenMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 13:
                {
                    GameOptionData.levelEightMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 14:
                {
                    GameOptionData.levelNineMaxTime = maxLevelTimeSecs;
                    break;
                }
            case 15:
                {
                    GameOptionData.levelTenMaxTime = maxLevelTimeSecs;
                    break;
                }
            default:
                {
                    Debug.Log("Level loaded is not a gameplay level...");
                    break;
                }
        }

        float levelBronzeTime = timerManager.bronzeTimeToCompleteLevel;
        int levelBronzeTimeSecs = (int)Mathf.Round(levelBronzeTime);
        float levelSilverTime = timerManager.silverTimeToCompleteLevel;
        int levelSilverTimeSecs = (int)Mathf.Round(levelSilverTime);
        float levelGoldTime = timerManager.goldTimeToCompleteLevel;
        int levelGoldTimeSecs = (int)Mathf.Round(levelGoldTime);
 


        //Save Goal Times
        switch (Application.loadedLevel)
        {
            case 6:
                {
                    GameOptionData.levelOneBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelOneSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelOneGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 7:
                {
                    GameOptionData.levelTwoBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelTwoSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelTwoGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 8:
                {
                    GameOptionData.levelThreeBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelThreeSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelThreeGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 9:
                {
                    GameOptionData.levelFourBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelFourSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelFourGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 10:
                {
                    GameOptionData.levelFiveBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelFiveSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelFiveGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 11:
                {
                    GameOptionData.levelSixBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelSixSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelSixGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 12:
                {
                    GameOptionData.levelSevenBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelSevenSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelSevenGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 13:
                {
                    GameOptionData.levelEightBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelEightSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelEightGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 14:
                {
                    GameOptionData.levelNineBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelNineSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelNineGoldTime = levelGoldTimeSecs;
                    break;
                }
            case 15:
                {
                    GameOptionData.levelTenBronzeTime = levelBronzeTimeSecs;
                    GameOptionData.levelTenSilverTime = levelSilverTimeSecs;
                    GameOptionData.levelTenGoldTime = levelGoldTimeSecs;
                    break;
                }
            default:
                {
                    Debug.Log("Level loaded is not a gameplay level...");
                    break;
                }
        }



        GameOptionData.ComputeAndSaveTimers(levelCompletedTimeSecs);



        ////XP Info
        //float xpCollectedPercentage = FindObjectOfType<XPGemManager>().formatFinalXPBarRatio;
        //GameOptionData.xpCollectedPercentage = xpCollectedPercentage;

        //Always Load the Level Complete Screen
        Application.LoadLevel(16);
    }
}
