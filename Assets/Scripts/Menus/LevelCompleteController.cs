using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompleteController : MonoBehaviour
{
    public AudioSource ButtonSelectSFX;
    public GameObject GoalTimerImageHUD;
    public GameObject LevelYourTimeTextHUD;
    public GameObject LevelGoldTimeTextHUD;
    public GameObject LevelSilverTimeTextHUD;
    public GameObject LevelBronzeTimeTextHUD;


    public Sprite[] goalTimerSheet;
    private Image currGoalTimerImage;


    private int goalTimerSpriteIndex;
    private int goalTimerTier;
    private Text yourTimeText;
    private Text goldTierTimeText;
    private Text silverTierTimeText;
    private Text bronzeTierTimeText;
    public Text specialItemWarningText;

    //Special Items
    public Image level1SpecialItem;
    public Image level2SpecialItem;
    public Image level4SpecialItem;
    public Image level5SpecialItem;
    public Image level7SpecialItem;
    public Image level8SpecialItem;

    private AudioManager AM;


	void Start () 
    {
        goalTimerSpriteIndex = 0;
        goalTimerTier = 0;

        currGoalTimerImage = GoalTimerImageHUD.GetComponent<Image>();
        yourTimeText = LevelYourTimeTextHUD.GetComponent<Text>();
        goldTierTimeText = LevelGoldTimeTextHUD.GetComponent<Text>();
        silverTierTimeText = LevelSilverTimeTextHUD.GetComponent<Text>();
        bronzeTierTimeText = LevelBronzeTimeTextHUD.GetComponent<Text>();

        if(GameOptionData.level1SpecialItemCollected)
        {
            level1SpecialItem.gameObject.SetActive(true);
        }

        if (GameOptionData.level2SpecialItemCollected)
        {
            level2SpecialItem.gameObject.SetActive(true);
        }

        if (GameOptionData.level4SpecialItemCollected)
        {
            level4SpecialItem.gameObject.SetActive(true);
        }

        if (GameOptionData.level5SpecialItemCollected)
        {
            level5SpecialItem.gameObject.SetActive(true);
        }

        if (GameOptionData.level7SpecialItemCollected)
        {
            level7SpecialItem.gameObject.SetActive(true);
        }

        if (GameOptionData.level8SpecialItemCollected)
        {
            level8SpecialItem.gameObject.SetActive(true);
        }


	}
	
	void Update () 
    {
        switch(GameOptionData.prevLevel)
        {
            case 7:
                {
                    yourTimeText.text = GameOptionData.levelOneActualTime.ToString() + " seconds";
                    goldTierTimeText.text = GameOptionData.levelOneGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelOneSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelOneBronzeTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelOneTimeTier;
                    break;
                }
            case 8:
                {
                    yourTimeText.text = GameOptionData.levelTwoActualTime.ToString() + " seconds";
                    goldTierTimeText.text = GameOptionData.levelTwoGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelTwoSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelTwoBronzeTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelTwoTimeTier;
                    break;
                }
            case 9:
                {
                    yourTimeText.text = GameOptionData.levelThreeActualTime.ToString() + " seconds";
                    goldTierTimeText.text = GameOptionData.levelThreeGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelThreeSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelThreeBronzeTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelThreeTimeTier;
                    break;
                }
            case 10:
                {
                    goldTierTimeText.text = GameOptionData.levelFourGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelFourSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelFourBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelFourActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelFourTimeTier;
                    break;
                }
            case 11:
                {
                    goldTierTimeText.text = GameOptionData.levelFiveGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelFiveSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelFiveBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelFiveActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelFiveTimeTier;
                    break;
                }
            case 12:
                {
                    goldTierTimeText.text = GameOptionData.levelSixGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelSixSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelSixBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelSixActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelSixTimeTier;
                    break;
                }
            case 13:
                {
                    goldTierTimeText.text = GameOptionData.levelSevenGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelSevenSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelSevenBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelSevenActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelSevenTimeTier;
                    break;
                }
            case 14:
                {
                    goldTierTimeText.text = GameOptionData.levelEightGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelEightSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelEightBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelEightActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelEightTimeTier;
                    break;
                }
            case 15:
                {
                    goldTierTimeText.text = GameOptionData.levelNineGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelNineSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelNineBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelNineActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelNineTimeTier;
                    break;
                }
            case 16:
                {
                    goldTierTimeText.text = GameOptionData.levelTenGoldTime.ToString() + " seconds";
                    silverTierTimeText.text = GameOptionData.levelTenSilverTime.ToString() + " seconds";
                    bronzeTierTimeText.text = GameOptionData.levelTenBronzeTime.ToString() + " seconds";
                    yourTimeText.text = GameOptionData.levelTenActualTime.ToString() + " seconds";
                    goalTimerTier = GameOptionData.levelTenTimeTier;
                    break;
                }

            default:
                {
                    Debug.Log("Somethings busted, like yo face!");
                    break;
                }
        }

       


            currGoalTimerImage.sprite = goalTimerSheet[goalTimerTier];
        
	}

    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //If End of Game, return to Main Menu
        if(sceneChoice == 17)
        {
            sceneChoice = 0;
        }
        if(sceneChoice == 9 && GameOptionData.numberOfSpecialItemsCollected < 1)
        {
            specialItemWarningText.gameObject.SetActive(true);
            specialItemWarningText.text =
            "You need to find\n" +
            "at least 1 Special Item\n" +
            "to continue to Level 3.";
        }
        else if(sceneChoice == 12 && GameOptionData.numberOfSpecialItemsCollected < 2)
        {
            specialItemWarningText.gameObject.SetActive(true);
            specialItemWarningText.text =
            "You need to find\n" +
            "at least 2 Special Items\n" +
            "to continue to Level 6.";
        }
        else if (sceneChoice == 15 && GameOptionData.numberOfSpecialItemsCollected < 3)
        {
            specialItemWarningText.gameObject.SetActive(true);
            specialItemWarningText.text =
            "You need to find\n" +
            "at least 3 Special Items\n" +
            "to continue to Level 9.";
        }
        else
        {
            Application.LoadLevel(sceneChoice);
        }
    }

    public void ChangeScenes()
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(GameOptionData.nextLevel, 1.1f));
    }

    public void LevelSelect()
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(6, 1.1f));
    }
}
