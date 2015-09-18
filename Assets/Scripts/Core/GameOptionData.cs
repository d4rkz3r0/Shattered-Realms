///***********************************************************************************************************************************************************************
//Class: GameOptionData.cs
/*Notes:
 * Game Data Option class can be accessed from anywhere.
 * Contains game settings variables.
 * Does not inherit from MonoBehavior and therefore cannot be attached to a GameObject.
 * 
 */
///***********************************************************************************************************************************************************************
using UnityEngine;
using System.Collections;

public static class GameOptionData
{
    public static int playerStartingHP;
    public static int playerStartingLVL;
    public static int levelsCompleted;

    public static int startingLevel;
    public static int prevLevel;
    public static int currentLevel;
    public static int nextLevel;

    public static int screenResolutionWidth;
    public static int screenResolutionHeight;

    public static float musicVolume;
    public static float sfxVolume;

    public static bool musicOn;
    public static bool isGamePaused;
    public static bool fullScreen;


    ////Level Complete Information
    //Arrays? Lists? Stacks?! Queues?! Hue hue hue!
    //XP
    public static int actualLevelTime;
    public static int levelGoalTime;

    //Level Times
    public static int levelOneActualTime;
    public static int levelTwoActualTime;
    public static int levelThreeActualTime;
    public static int levelFourActualTime;
    public static int levelFiveActualTime;
    public static int levelSixActualTime;
    public static int levelSevenActualTime;
    public static int levelEightActualTime;
    public static int levelNineActualTime;
    public static int levelTenActualTime;

    //Goal Times
    public static int levelOneBronzeTime;
    public static int levelOneSilverTime;
    public static int levelOneGoldTime;
    public static int levelTwoBronzeTime;
    public static int levelTwoSilverTime;
    public static int levelTwoGoldTime;
    public static int levelThreeBronzeTime;
    public static int levelThreeSilverTime;
    public static int levelThreeGoldTime;
    public static int levelFourBronzeTime;
    public static int levelFourSilverTime;
    public static int levelFourGoldTime;
    public static int levelFiveBronzeTime;
    public static int levelFiveSilverTime;
    public static int levelFiveGoldTime;
    public static int levelSixBronzeTime;
    public static int levelSixSilverTime;
    public static int levelSixGoldTime;
    public static int levelSevenBronzeTime;
    public static int levelSevenSilverTime;
    public static int levelSevenGoldTime;
    public static int levelEightBronzeTime;
    public static int levelEightSilverTime;
    public static int levelEightGoldTime;
    public static int levelNineBronzeTime;
    public static int levelNineSilverTime;
    public static int levelNineGoldTime;
    public static int levelTenBronzeTime;
    public static int levelTenSilverTime;
    public static int levelTenGoldTime;

    //Max Times
    public static int levelOneMaxTime;
    public static int levelTwoMaxTime;
    public static int levelThreeMaxTime;
    public static int levelFourMaxTime;
    public static int levelFiveMaxTime;
    public static int levelSixMaxTime;
    public static int levelSevenMaxTime;
    public static int levelEightMaxTime;
    public static int levelNineMaxTime;
    public static int levelTenMaxTime;

    //Goal Timer Tiers
    //0 - Completion Tier (No Stars)
    //1 - Bronze          (1 Stars)
    //2 - Silver          (2 Stars)
    //3 - Gold            (3 Stars)
    public static int levelOneTimeTier;
    public static int levelTwoTimeTier;
    public static int levelThreeTimeTier;
    public static int levelFourTimeTier;
    public static int levelFiveTimeTier;
    public static int levelSixTimeTier;
    public static int levelSevenTimeTier;
    public static int levelEightTimeTier;
    public static int levelNineTimeTier;
    public static int levelTenTimeTier;

    //Special Items
    public static int numberOfSpecialItemsCollected;
    public static bool level1SpecialItemCollected;
    public static bool level2SpecialItemCollected;
    public static bool level4SpecialItemCollected;
    public static bool level5SpecialItemCollected;
    public static bool level7SpecialItemCollected;
    public static bool level8SpecialItemCollected;




    public static void InitializeGame()
    {
        playerStartingHP = 10;
        playerStartingLVL = 1;

        musicOn = true;
        isGamePaused = false;
        fullScreen = false;
        musicVolume = 1.0f;
        sfxVolume = 1.0f;

        startingLevel = 0; //Splash Screen

        //Screen.SetResolution(screenResolutionWidth, screenResolutionHeight, fullScreen);


    }

    public static void ComputeAndSaveTimers(int levelTimeInSecs)
    {
        switch(Application.loadedLevel)
        {
            case 7:
                {
                    if(levelTimeInSecs >= levelOneMaxTime && levelTimeInSecs >= levelOneBronzeTime)
                    {
                        
                        levelOneTimeTier = 0;
                    }

                    else if(levelTimeInSecs <= levelOneBronzeTime && levelTimeInSecs >= levelOneSilverTime)
                    {
                        
                        levelOneTimeTier = 1;
                    }
                    else if(levelTimeInSecs <= levelOneSilverTime && levelTimeInSecs >= levelOneGoldTime)
                    {
                        
                        levelOneTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelOneGoldTime)
                    {
                        
                        levelOneTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelOneTimeTier = 0;
                    }
                    break;
                }
            case 8:
                {
                    if (levelTimeInSecs >= levelTwoMaxTime && levelTimeInSecs >= levelTwoBronzeTime)
                    {
                        
                        levelTwoTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelTwoBronzeTime && levelTimeInSecs >= levelTwoSilverTime)
                    {
                        
                        levelTwoTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelTwoSilverTime && levelTimeInSecs >= levelTwoGoldTime)
                    {
                        
                        levelTwoTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelTwoGoldTime)
                    {
                        
                        levelTwoTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelTwoTimeTier = 0;
                    }
                    break;
                }
            case 9:
                {
                    if (levelTimeInSecs >= levelThreeMaxTime && levelTimeInSecs >= levelThreeBronzeTime)
                    {
                        
                        levelThreeTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelThreeBronzeTime && levelTimeInSecs >= levelThreeSilverTime)
                    {
                        
                        levelThreeTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelThreeSilverTime && levelTimeInSecs >= levelThreeGoldTime)
                    {
                        
                        levelThreeTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelThreeGoldTime)
                    {
                        
                        levelThreeTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelThreeTimeTier = 0;
                    }
                    break;
                }
            case 10:
                {
                    if (levelTimeInSecs >= levelFourMaxTime && levelTimeInSecs >= levelFourBronzeTime)
                    {
                        
                        levelFourTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelFourBronzeTime && levelTimeInSecs >= levelFourSilverTime)
                    {
                        
                        levelFourTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelFourSilverTime && levelTimeInSecs >= levelFourGoldTime)
                    {
                        
                        levelFourTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelFourGoldTime)
                    {
                        
                        levelFourTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelFourTimeTier = 0;
                    }
                    break;
                }
            case 11:
                {
                    if (levelTimeInSecs >= levelFiveMaxTime && levelTimeInSecs >= levelFiveBronzeTime)
                    {
                        
                        levelFiveTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelFiveBronzeTime && levelTimeInSecs >= levelFiveSilverTime)
                    {
                        
                        levelFiveTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelFiveSilverTime && levelTimeInSecs >= levelFiveGoldTime)
                    {
                        
                        levelFiveTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelFiveGoldTime)
                    {
                        
                        levelFiveTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelFiveTimeTier = 0;
                    }
                    break;
                }
            case 12:
                {
                    if (levelTimeInSecs >= levelSixMaxTime && levelTimeInSecs >= levelSixBronzeTime)
                    {
                        
                        levelSixTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelSixBronzeTime && levelTimeInSecs >= levelSixSilverTime)
                    {
                        
                        levelSixTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelSixSilverTime && levelTimeInSecs >= levelSixGoldTime)
                    {
                        
                        levelSixTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelSixGoldTime)
                    {
                        
                        levelSixTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelSixTimeTier = 0;
                    }
                    break;
                }
            case 13:
                {
                    if (levelTimeInSecs >= levelSevenMaxTime && levelTimeInSecs >= levelSevenBronzeTime)
                    {
                        
                        levelSevenTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelSevenBronzeTime && levelTimeInSecs >= levelSevenSilverTime)
                    {
                        
                        levelSevenTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelSevenSilverTime && levelTimeInSecs >= levelSevenGoldTime)
                    {
                        
                        levelSevenTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelSevenGoldTime)
                    {
                        
                        levelSevenTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelSevenTimeTier = 0;
                    }
                    break;
                }
            case 14:
                {
                    if (levelTimeInSecs >= levelEightMaxTime && levelTimeInSecs >= levelEightBronzeTime)
                    {
                        
                        levelEightTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelEightBronzeTime && levelTimeInSecs >= levelEightSilverTime)
                    {
                        
                        levelEightTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelEightSilverTime && levelTimeInSecs >= levelEightGoldTime)
                    {
                        
                        levelEightTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelEightGoldTime)
                    {
                        
                        levelEightTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelEightTimeTier = 0;
                    }
                    break;
                }
            case 15:
                {
                    if (levelTimeInSecs >= levelNineMaxTime && levelTimeInSecs >= levelNineBronzeTime)
                    {
                        
                        levelNineTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelNineBronzeTime && levelTimeInSecs >= levelNineSilverTime)
                    {
                        
                        levelNineTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelNineSilverTime && levelTimeInSecs >= levelNineGoldTime)
                    {
                        
                        levelNineTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelNineGoldTime)
                    {
                        
                        levelNineTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelNineTimeTier = 0;
                    }
                    break;
                }
            case 16:
                {
                    if (levelTimeInSecs >= levelTenMaxTime && levelTimeInSecs >= levelTenBronzeTime)
                    {
                        
                        levelTenTimeTier = 0;
                    }

                    else if (levelTimeInSecs <= levelTenBronzeTime && levelTimeInSecs >= levelTenSilverTime)
                    {
                        
                        levelTenTimeTier = 1;
                    }
                    else if (levelTimeInSecs <= levelTenSilverTime && levelTimeInSecs >= levelTenGoldTime)
                    {
                        
                        levelTenTimeTier = 2;
                    }
                    else if (levelTimeInSecs <= levelTenGoldTime)
                    {
                        
                        levelTenTimeTier = 3;
                    }
                    else
                    {
                        Debug.Log("Time Not Specified");
                        levelTenTimeTier = 0;
                    }
                    break;
                }
            default:
                {
                    Debug.Log("Something is broken");
                    break;
                }
        }
    }
}
