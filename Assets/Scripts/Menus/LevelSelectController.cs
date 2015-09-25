using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectController : MonoBehaviour 
{
    public AudioSource ButtonSelectSFX;
    public AudioSource SasukeSelectSFX;
    public AudioSource GizmoSelectSFX;
    public AudioSource RobotnikSelectSFX;
    public AudioSource MarioSelectSFX;
    public Button[] levelButtons;
    public Image[] levelStarArray;

    public Sprite completionStarImage;
    public Sprite bronzeStarImage;
    public Sprite silverStarImage;
    public Sprite goldStarImage;
    

	// Use this for initialization
	void Start ()
    {
        switch(GameOptionData.levelOneTimeTier)
        {
            case 0:
                {
                    levelStarArray[0].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[0].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[0].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[0].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelTwoTimeTier)
        {
            case 0:
                {
                    levelStarArray[1].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[1].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[1].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[1].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelThreeTimeTier)
        {
            case 0:
                {
                    levelStarArray[2].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[2].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[2].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[2].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelFourTimeTier)
        {
            case 0:
                {
                    levelStarArray[3].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[3].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[3].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[3].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelFiveTimeTier)
        {
            case 0:
                {
                    levelStarArray[4].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[4].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[4].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[4].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelSixTimeTier)
        {
            case 0:
                {
                    levelStarArray[5].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[5].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[5].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[5].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelSevenTimeTier)
        {
            case 0:
                {
                    levelStarArray[6].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[6].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[6].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[6].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelEightTimeTier)
        {
            case 0:
                {
                    levelStarArray[7].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[7].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[7].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[7].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelNineTimeTier)
        {
            case 0:
                {
                    levelStarArray[8].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[8].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[8].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[8].sprite = goldStarImage;
                    break;
                }
        }

        switch (GameOptionData.levelTenTimeTier)
        {
            case 0:
                {
                    levelStarArray[9].sprite = completionStarImage;
                    break;
                }
            case 1:
                {
                    levelStarArray[9].sprite = bronzeStarImage;
                    break;
                }
            case 2:
                {
                    levelStarArray[9].sprite = silverStarImage;
                    break;
                }
            case 3:
                {
                    levelStarArray[9].sprite = goldStarImage;
                    break;
                }
        }

       

	    if(GameOptionData.level1Completed)
        {
            levelButtons[1].interactable = true;
        }

        if(GameOptionData.level2Completed && GameOptionData.numberOfSpecialItemsCollected >= 1)
        {
            levelButtons[2].interactable = true;
        }
        if(GameOptionData.level3Completed)
        {
            levelButtons[3].interactable = true;
        }
        if (GameOptionData.level4Completed)
        {
            levelButtons[4].interactable = true;
        }
        if (GameOptionData.level5Completed && GameOptionData.numberOfSpecialItemsCollected >= 2)
        {
            levelButtons[5].interactable = true;
        }
        if (GameOptionData.level6Completed)
        {
            levelButtons[6].interactable = true;
        }
        if (GameOptionData.level7Completed)
        {
            levelButtons[7].interactable = true;
        }
        if (GameOptionData.level8Completed && GameOptionData.numberOfSpecialItemsCollected >= 3)
        {
            levelButtons[8].interactable = true;
        }
        if (GameOptionData.level9Completed && GameOptionData.numberOfSpecialItemsCollected >= 3)
        {
            levelButtons[9].gameObject.SetActive(true);
            levelButtons[9].interactable = true;
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.F1))
        {
            for(int i = 0; i < 10; i++)
            {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].interactable = true;
            }
        }
	}

    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        sceneChoice++;
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
    }

    public IEnumerator ChangeSceneSasuke(int sceneChoice, float waitTime)
    {
        sceneChoice++;
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenesSasuke(int sceneChoice)
    {
        SasukeSelectSFX.Play();
        StartCoroutine(ChangeSceneSasuke(sceneChoice, 4.47f));
    }

    public IEnumerator ChangeSceneGizmo(int sceneChoice, float waitTime)
    {
        sceneChoice++;
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenesGizmo(int sceneChoice)
    {
        
        GizmoSelectSFX.Play();
        StartCoroutine(ChangeSceneGizmo(sceneChoice, 2.9f));
    }

    public IEnumerator ChangeSceneRobotnik(int sceneChoice, float waitTime)
    {
        sceneChoice++;
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);
    }

    public void ChangeScenesRobotnik(int sceneChoice)
    {
        RobotnikSelectSFX.Play();
        StartCoroutine(ChangeSceneRobotnik(sceneChoice, 2.51f));
    }

    public void ChangeScenesMario(int sceneChoice)
    {
        MarioSelectSFX.Play();
        StartCoroutine(ChangeSceneMario(sceneChoice, 3.9f));
    }

    public IEnumerator ChangeSceneMario(int sceneChoice, float waitTime)
    {
        sceneChoice++;
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);
    }
}
