using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitcherController : MonoBehaviour
{

    private int imageIndex = 0;
    public Image[] imageBank;
    private Image currImage;

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
	}

    public void IncreaseScene()
    {
        imageIndex++;
        PreStoryText.textIndex++;
        currImage.sprite = imageBank[imageIndex].sprite;
    }

    public void DecreaseScene()
    {
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

    public void ChangeScene(int sceneChoice)
    {
        if(AudioManager.GetInstance() != null)
        {
            AudioManager.currAudio.Stop();
        }
        
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);
    }
}
