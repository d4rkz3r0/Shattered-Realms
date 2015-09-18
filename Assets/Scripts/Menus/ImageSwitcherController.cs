using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitcherController : MonoBehaviour
{

    public int imageIndex = 0;
    public Image[] imageBank;
    private Image currImage;


    private controlTitleImages crtlTitle;
    public AudioSource ButtonSelectSFX;
    

	// Use this for initialization
	void Start () 
    {
        crtlTitle = FindObjectOfType<controlTitleImages>();
        currImage = GetComponent<Image>();
        currImage.sprite = imageBank[imageIndex].sprite;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(imageIndex <= 0)
        {
            imageIndex = 0;
        }
        if(imageIndex >= 2)
        {
            imageIndex = 2;
            currImage.sprite = imageBank[imageIndex].sprite;
            
        }
	}


    public void IncreaseScene()
    {
        GetComponent<AudioSource>().Play();
        if (imageIndex >= 2)
        {
            imageIndex = 2;
            crtlTitle.imageIndex = 2;
            ChangeScenes(6);
        }
        else
        {
            crtlTitle.IncreaseIndex();
            imageIndex++;
            currImage.sprite = imageBank[imageIndex].sprite;
        } 
    }

    public void DecreaseScene()
    {
        GetComponent<AudioSource>().Play();
        if (imageIndex <= 0)
        {
            crtlTitle.ZeroOut();
            imageIndex = 0;
            return;
        }
        else
        {
            crtlTitle.DecrementIndex();
            imageIndex--;
            currImage.sprite = imageBank[imageIndex].sprite;
        }
        
    }

    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.currAudio.Stop();
        }
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
    }

    public void SkipIntro()
    {
        imageIndex = 2;
        crtlTitle.imageIndex = 2;
        currImage.sprite = imageBank[imageIndex].sprite;
    }
}
