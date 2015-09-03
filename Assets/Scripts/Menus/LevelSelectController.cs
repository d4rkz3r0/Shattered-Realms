using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectController : MonoBehaviour 
{
    public AudioSource ButtonSelectSFX;
    public AudioSource SasukeSelectSFX;
    public AudioSource GizmoSelectSFX;
    public AudioSource RobotnikSelectSFX;
    public Image[] levelStarArray;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
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

    //public IEnumerator ChangeSceneSasuke(int sceneChoice, float waitTime)
    //{
    //    sceneChoice++;
    //    yield return new WaitForSeconds(waitTime);
    //    GameOptionData.currentLevel = sceneChoice;
    //    Application.LoadLevel(sceneChoice);

    //}

    //public void ChangeScenesSasuke(int sceneChoice)
    //{
    //    SasukeSelectSFX.Play();
    //    StartCoroutine(ChangeSceneSasuke(sceneChoice, 1.1f));
    //}

    public IEnumerator ChangeSceneGizmo(int sceneChoice, float waitTime)
    {
        sceneChoice++;
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Debug.Log(sceneChoice);
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
        Debug.Log(sceneChoice);
        RobotnikSelectSFX.Play();
        StartCoroutine(ChangeSceneRobotnik(sceneChoice, 2.51f));
    }
}
