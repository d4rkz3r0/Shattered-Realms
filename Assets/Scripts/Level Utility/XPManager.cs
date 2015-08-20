///***********************************************************************
//Class: XPManager.cs
/*Notes:
 * The XPManager class handles the players XP and provides functions for
 * adding XP and resetting it.
 * 
 */
///***********************************************************************
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class XPManager : MonoBehaviour
{
    public Slider xpSlider;
    public static int playerXP;
    public static int playerLvL;
    public static int xpEarnedThisLevel;


    void Start()
    {
        xpEarnedThisLevel = 0;
        playerXP = PlayerPrefs.GetInt("PlayerCurrentXP");
        initialUpdatePlayerLevel(playerXP);
    }

    void Update()
    {
        //xpSlider.value = Mathf.MoveTowards(xpSlider.value, 1000.0f, 2.0f);

        //Prevent Over and under flow
        if (xpEarnedThisLevel < 0)
        {
            xpEarnedThisLevel = 0;
        }
        if (playerXP < 0)
        {
            playerXP = 0;
        }

        updatePlayerLevel();


    }


    

    public static void AddToPlayerXP(int xpToAdd)
    {
        playerXP += xpToAdd;
        PlayerPrefs.SetInt("PlayerCurrentXP", playerXP);
    }

    public static void ResetPlayerXP()
    {
        PlayerPrefs.SetInt("PlayerCurrentXP", 0);
    }

    public static void ResetPlayerToNoob()
    {
        PlayerPrefs.SetInt("PlayerCurrentXP", 1000);
    }

    public static void AddToEarnedXPThisLevel(int xpToAdd)
    {
        xpEarnedThisLevel += xpToAdd;
    }

    public void ResetEarnedXPThisLevel()
    {
        xpEarnedThisLevel = 0;
    }

    public void initialUpdatePlayerLevel(int playerXP)
    {
        if (playerXP == 10000 || (playerXP > 10000 || playerXP > 9000))
		{
			playerLvL = 10;
		}
		else if (playerXP == 9000 || (playerXP < 9000 && playerXP > 8000))
		{
			playerLvL = 9;
		}
		else if (playerXP == 8000 || (playerXP < 8000 && playerXP > 7000))
		{
            playerLvL = 8;
        }
		else if (playerXP == 7000 || (playerXP < 7000 && playerXP > 6000))
		{
			playerLvL = 7;
		}
		else if (playerXP == 6000 || (playerXP < 6000 && playerXP > 5000))
		{
			playerLvL = 6;
		}
		else if (playerXP == 5000 || (playerXP < 5000 && playerXP > 4000))
		{
			playerLvL = 5;
		}
		else if (playerXP == 4000 || (playerXP < 4000 && playerXP > 3000))
		{
			playerLvL = 4;
		}
		else if (playerXP == 3000 || (playerXP < 3000 && playerXP > 2000))
		{
			playerLvL = 3;
		}
		else if (playerXP == 2000 || (playerXP < 2000 && playerXP > 1000))
		{
			playerLvL = 2;
		}
		else if (playerXP == 1000 || (playerXP < 1000 && playerXP > 0))
		{
            playerLvL = 1;
		}
		else if (playerXP == 0 || playerXP < 0)
		{
			Debug.Log("Player level beyond bounds or intial XP was not set.");
		}
    }

    public void updatePlayerLevel()
    {
        if (playerXP == 10000 || (playerXP > 10000 || playerXP > 9000))
        {
            playerLvL = 10;
        }
        else if (playerXP == 9000 || (playerXP < 9000 && playerXP > 8000))
        {
            playerLvL = 9;
        }
        else if (playerXP == 8000 || (playerXP < 8000 && playerXP > 7000))
        {
            playerLvL = 8;
        }
        else if (playerXP == 7000 || (playerXP < 7000 && playerXP > 6000))
        {
            playerLvL = 7;
        }
        else if (playerXP == 6000 || (playerXP < 6000 && playerXP > 5000))
        {
            playerLvL = 6;
        }
        else if (playerXP == 5000 || (playerXP < 5000 && playerXP > 4000))
        {
            playerLvL = 5;
        }
        else if (playerXP == 4000 || (playerXP < 4000 && playerXP > 3000))
        {
            playerLvL = 4;
        }
        else if (playerXP == 3000 || (playerXP < 3000 && playerXP > 2000))
        {
            playerLvL = 3;
        }
        else if (playerXP == 2000 || (playerXP < 2000 && playerXP > 1000))
        {
            playerLvL = 2;
        }
        else if (playerXP == 1000 || (playerXP < 1000 && playerXP > 0))
        {
            playerLvL = 1;
        }
        else if (playerXP == 0 || playerXP < 0)
        {
            Debug.Log("Player level beyond bounds or intial XP was not set.");
        }
    }
}
