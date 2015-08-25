using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitcherController : MonoBehaviour
{

    private int imageIndex = 0;
    public Image[] imageBank;
    private Image currImage;

    public AudioSource ButtonSelectSFX;
    

	// Use this for initialization
	void Start () 
    {
        
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
        if(imageIndex >= 22)
        {
            imageIndex = 22;
            currImage.sprite = imageBank[imageIndex].sprite;
            
        }
	}


    public void IncreaseScene()
    {
        GetComponent<AudioSource>().Play();
        if (imageIndex >= 22)
        {
            imageIndex = 22;
            ChangeScenes(5);
        }
        else
        {
            imageIndex++;
            PreStoryText.textIndex++;
            currImage.sprite = imageBank[imageIndex].sprite;
        } 
    }

    public void DecreaseScene()
    {
        GetComponent<AudioSource>().Play();
        if (imageIndex <= 0)
        {
            imageIndex = 0;
            return;
        }
        else
        {
            imageIndex--;
            PreStoryText.textIndex--;
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
        imageIndex = 22;
        currImage.sprite = imageBank[imageIndex].sprite;
        PreStoryText.textIndex = 22;
    }
}
