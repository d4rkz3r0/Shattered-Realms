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
    public static int playerStartingXP;
    public static int playerStartingLVL;
    public static int levelsCompleted;

    public static int startingLevel;
    public static int currentLevel;
    public static int nextLevel;

    public static int screenResolutionWidth;
    public static int screenResolutionHeight;

    public static float musicVolume;
    public static float sfxVolume;

    public static bool musicOn;
    public static bool isGamePaused;
    public static bool fullScreen;


    public static float xpCollectedPercentage;

    public static int actualLevelTime;
    public static int levelGoalTime;

    public static void InitializeGame()
    {
        playerStartingHP = 10;
        playerStartingXP = 0;
        playerStartingLVL = 1;

        musicOn = true;
        isGamePaused = false;
        fullScreen = false;
        musicVolume = 1.0f;
        sfxVolume = 1.0f;

        startingLevel = 0; //Main Menu

        //Screen.SetResolution(screenResolutionWidth, screenResolutionHeight, fullScreen);


    }
}
