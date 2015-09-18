using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreenController : MonoBehaviour
{
    public int levelToLoad;
    public Image backgroundImage;
    public Image progressBarImage;
    public Text percentageText;
    //public GameObject loadingAnimation;
    public Image TeamLogo;
    public Text ClassName;
    private int loadingProgress = 0;
    private float AnimTimer = 2.5f;
    bool loadOnce;


	void Start ()
    {
        loadOnce = false;
	}
	
	void Update ()
    {  
	    if(AnimTimer >= 0.0f && !loadOnce)
        {
            AnimTimer -= Time.deltaTime;
        }

        if(AnimTimer <= 0.0f && !loadOnce)
        {
            
            loadOnce = true;
            StartCoroutine("LogoTimer");
        }
	}

    private IEnumerator LogoTimer()
    {

        ClassName.gameObject.SetActive(false);
        TeamLogo.gameObject.SetActive(false);
        backgroundImage.gameObject.SetActive(true);
        progressBarImage.gameObject.SetActive(true);
        percentageText.gameObject.SetActive(true);
        

        
        progressBarImage.transform.localScale = new Vector3(loadingProgress,
                                                            progressBarImage.transform.localScale.y,
                                                            progressBarImage.transform.localScale.z);
        percentageText.text = "Loading..." + loadingProgress + "%";
        

        //Loads Level in background thread, without loss of input.
        AsyncOperation aSync = Application.LoadLevelAsync(levelToLoad);

        while (!aSync.isDone)
        {

            //Update While Frozen
            loadingProgress = (int)(aSync.progress * 100);

            //Use it
            percentageText.text = "Loading..." + loadingProgress + "%";
            progressBarImage.transform.localScale = new Vector3(aSync.progress,
                                                            progressBarImage.transform.localScale.y,
                                                            progressBarImage.transform.localScale.z);
            yield return null;
        }

        //while (!aSync.isDone)
        //{

        //    loadingAnimation.SetActive(true);
        //    yield return null;
        //}
        
    }
}
