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

    

	// Use this for initialization
	void Start ()
    {
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
