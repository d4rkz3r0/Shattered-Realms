using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class XPGemManager : MonoBehaviour
{
    private GameObject[] levelXPGems;
    private int gemsRemaining;
    //private Text gemsRemainingText;
    //private bool areCollectedOnce;
    private float collectedTimer;
    public Sprite[] xpBarSheet;
    public Image currXPBarImage;
    //private bool lvlUpSFXHasPlayed;

    //XP Bar Vars
    private float xpBarRatio;
    private float finalXPBarRatio;
    public float formatFinalXPBarRatio;
    //private float currXPCollected;
    //private float totalLvLXP;
    public static int playerGemCount;
    public static bool allGemsCollected;
    private int xpBarSelection;

	// Use this for initialization
	void Start ()
    {
        //lvlUpSFXHasPlayed = false;
        //areCollectedOnce = false;
        allGemsCollected = false;
        levelXPGems = GameObject.FindGameObjectsWithTag("XP Gem");
        gemsRemaining = levelXPGems.Length;

        
        
        //gemsRemainingText = GetComponentInChildren<Text>();

        currXPBarImage = GetComponent<Image>();
        //currXPCollected = 0;
        playerGemCount = 0;
        finalXPBarRatio = 0.0f;
        //totalLvLXP = gemsRemaining * 50.0f;

        
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (collectedTimer >= 0.0f)
        //{
        //    collectedTimer -= Time.deltaTime;
        //}

        //if (collectedTimer <= 0.0f)
        //{
        //    areCollectedOnce = true;
        //}

        //if (gemsRemaining <= 0 && !areCollectedOnce)
        //{
        //    gemsRemaining = 0;
        //    MessageController.textSelection = 18;
        //    collectedTimer = 3.0f;
        //}

        //if (areCollectedOnce)
        //{
        //    //MessageController.textSelection = 17;
        //}

        xpBarRatio = (float)playerGemCount / (float)gemsRemaining;
        formatFinalXPBarRatio = xpBarRatio * 100.0f;
        finalXPBarRatio = xpBarRatio * 10.0f;
        

        xpBarSelection = Mathf.RoundToInt(finalXPBarRatio);

        //Debug.Log("Gems Collected: " + playerGemCount + " Gems in lvl: " + gemsRemaining + " CurrentXPBarImg:" + xpBarSelection);

        switch (xpBarSelection)
        {
            case 0:
                {
                    currXPBarImage.sprite = xpBarSheet[0];
                    break;
                }
            case 1:
                {
                    currXPBarImage.sprite = xpBarSheet[1];
                    break;
                }
            case 2:
                {
                    currXPBarImage.sprite = xpBarSheet[2];
                    break;
                }
            case 3:
                {
                    currXPBarImage.sprite = xpBarSheet[3];
                    break;
                }
            case 4:
                {
                    currXPBarImage.sprite = xpBarSheet[4];
                    break;
                }
            case 5:
                {
                    currXPBarImage.sprite = xpBarSheet[5];
                    break;
                }
            case 6:
                {
                    currXPBarImage.sprite = xpBarSheet[6];
                    break;
                }
            case 7:
                {
                    currXPBarImage.sprite = xpBarSheet[7];
                    break;
                }
            case 8:
                {
                    currXPBarImage.sprite = xpBarSheet[8];
                    break;
                }
            case 9:
                {
                    currXPBarImage.sprite = xpBarSheet[9];
                    break;
                }
            case 10:
                {
                    currXPBarImage.sprite = xpBarSheet[10];
                    allGemsCollected = true;
                    break;
                }
            default:
                {
                    //Empty Bar
                    currXPBarImage.sprite = xpBarSheet[0];
                    break;
                }
        }

        //gemsRemainingText.text = "x " + gemsRemaining.ToString();
        //Debug.Log(gemsRemaining * 50);

	}
}
