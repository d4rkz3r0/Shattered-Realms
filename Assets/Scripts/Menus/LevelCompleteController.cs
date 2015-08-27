using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompleteController : MonoBehaviour
{
    public AudioSource ButtonSelectSFX;
    public GameObject GoalTimerImageHUD;
    public GameObject LevelYourTimeTextHUD;
    public GameObject LevelGoalTimeTextHUD;
    public GameObject XPCollectedTextHUD;


    

    private Text yourTimeText;
    private Text levelTimeText;
    private Text xpCollectedText;


	// Use this for initialization
	void Start () 
    {
        
        yourTimeText = LevelYourTimeTextHUD.GetComponent<Text>();
        levelTimeText = LevelGoalTimeTextHUD.GetComponent<Text>();
        xpCollectedText = XPCollectedTextHUD.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log(Application.loadedLevel);

        yourTimeText.text = GameOptionData.actualLevelTime.ToString() + " seconds";
        levelTimeText.text = GameOptionData.levelGoalTime.ToString() + " seconds";
        if(GameOptionData.xpCollectedPercentage.ToString() == float.NaN.ToString())
        {
            xpCollectedText.text = "0.0";
        }
        else
        {
            xpCollectedText.text = GameOptionData.xpCollectedPercentage.ToString("F1") + "%";
        }
       

        //if(GoalTimerImageHUD.GetComponent<Animator>().enabled == false)
        //{
        //    //Update image based on goal times set for completed level
            
        //}
	}

    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes()
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(GameOptionData.nextLevel, 1.1f));
    }
}
