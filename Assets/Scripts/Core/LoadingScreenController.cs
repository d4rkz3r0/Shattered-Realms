using UnityEngine;
using System.Collections;

public class LoadingScreenController : MonoBehaviour 
{
    public int levelToLoad;
    public GameObject backgroundImage;
    public GameObject progressBarImage;
    public GameObject percentageText;
    private int loadingProgress = 0;

	void Start ()
    {
       
	}
	
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(DisplayLoadingScreen(levelToLoad));
        }
	}

    public IEnumerator DisplayLoadingScreen(int levelToLoad)
    {
        Debug.Log("Here");
        backgroundImage.SetActive(true);
        progressBarImage.SetActive(true);
        percentageText.SetActive(true);

        progressBarImage.transform.localScale = new Vector3(loadingProgress,
                                                            progressBarImage.transform.localScale.y,
                                                            progressBarImage.transform.localScale.z);

        percentageText.GetComponent<GUIText>().text = "Loading..." + loadingProgress + "%";

        //Loads Level in background thread, without loss of input.
        AsyncOperation aSync = Application.LoadLevelAsync(levelToLoad);

        while(!aSync.isDone)
        {
            //Update While Frozen
            loadingProgress = (int)(aSync.progress * 100);

            //Use it
            percentageText.GetComponent<GUIText>().text = "Loading..." + loadingProgress + "%";
            progressBarImage.transform.localScale = new Vector3(aSync.progress,
                                                            progressBarImage.transform.localScale.y,
                                                            progressBarImage.transform.localScale.z);

            yield return null;
        }
    }
}
