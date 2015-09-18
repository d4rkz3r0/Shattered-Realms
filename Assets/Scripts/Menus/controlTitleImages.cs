using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controlTitleImages : MonoBehaviour
{
    public int imageIndex = 0;
    public Image[] imageBank;
    private Image currImage;
    private ImageSwitcherController imgSwitch;


	// Use this for initialization
	void Start ()
    {
        currImage = GetComponent<Image>();
        currImage.sprite = imageBank[imageIndex].sprite;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currImage.sprite = imageBank[imageIndex].sprite;
        if (imageIndex <= 0)
        {
            imageIndex = 0;
        }
        if (imageIndex >= 2)
        {
            imageIndex = 2;
            currImage.sprite = imageBank[imageIndex].sprite;

        }
	}

    public void IncreaseIndex()
    {
        imageIndex++;
    }
    
    public void DecrementIndex()
    {
        imageIndex--;
    }

    public void ZeroOut()
    {
        imageIndex = 0;
    }
}
