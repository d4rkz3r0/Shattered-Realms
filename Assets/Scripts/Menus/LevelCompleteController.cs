using UnityEngine;
using System.Collections;

public class LevelCompleteController : MonoBehaviour
{
    public AudioSource ButtonSelectSFX;
    public AudioSource CarouselSelectSFX;


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
        yield return new WaitForSeconds(waitTime);
        GameOptionData.nextLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes()
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(GameOptionData.nextLevel, 1.1f));
    }
}
