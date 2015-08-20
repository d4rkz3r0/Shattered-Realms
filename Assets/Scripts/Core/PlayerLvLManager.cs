using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLvLManager : MonoBehaviour 
{
    public bool resetPlayerToLevel1;

    public Sprite[] playerLevelSheet;
    private Image currLvLBarImage; 
    private int playerLevel;

	// Use this for initialization
	void Start ()
    {
        playerLevel = XPManager.playerLvL;
        currLvLBarImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (resetPlayerToLevel1)
        {
            XPManager.ResetPlayerToNoob();
        }
        else
        {
            playerLevel = XPManager.playerLvL;
            switch (playerLevel)
            {
                case 10:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[0];
                        break;
                    }
                case 9:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[1];
                        break;
                    }
                case 8:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[2];
                        break;
                    }
                case 7:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[3];
                        break;
                    }
                case 6:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[4];
                        break;
                    }
                case 5:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[5];
                        break;
                    }
                case 4:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[6];
                        break;
                    }
                case 3:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[7];
                        break;
                    }
                case 2:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[8];
                        break;
                    }
                case 1:
                    {
                        currLvLBarImage.sprite = playerLevelSheet[9];
                        break;
                    }
                default:
                    {
                        //Empty Bar
                        currLvLBarImage.sprite = playerLevelSheet[0];
                        break;
                    }
            }
        }
        
	}
}
