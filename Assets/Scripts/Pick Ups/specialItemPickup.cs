using UnityEngine;
using System.Collections;

public class specialItemPickup : MonoBehaviour
{
    public bool isSpecialItemPickedUp;
    private AudioSource[] specialItemSFXs;
    private AudioSource currentItemSFX;

	void Start ()
    {
        isSpecialItemPickedUp = false;
        specialItemSFXs = GetComponentsInParent<AudioSource>();

        if(gameObject.name == "Ninja Scroll")
        {
            currentItemSFX = specialItemSFXs[0];
        }
        else if(gameObject.name == "Titan Communicator")
        {
            currentItemSFX = specialItemSFXs[1];
        }
        else if (gameObject.name == "Golden Ring")
        {
            currentItemSFX = specialItemSFXs[2];
        }
        else
        {
            //Default Itachi SFX
            currentItemSFX = specialItemSFXs[0];
        }
	}
	
	void Update () 
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Only allow the Player To pick up special item
        if (other.GetComponent<MasterController>() == null)
        {
            return;
        }


        switch(Application.loadedLevel)
        {
            case 6:
                {
                    GameOptionData.level1SpecialItemCollected = true;
                    GameOptionData.numberOfSpecialItemsCollected++;
                    break;
                }
            case 7:
                {
                    GameOptionData.level2SpecialItemCollected = true;
                    GameOptionData.numberOfSpecialItemsCollected++;
                    break;
                }
            case 9:
                {
                    GameOptionData.level4SpecialItemCollected = true;
                    GameOptionData.numberOfSpecialItemsCollected++;
                    break;
                }
            case 10:
                {
                    GameOptionData.level5SpecialItemCollected = true;
                    GameOptionData.numberOfSpecialItemsCollected++;
                    break;
                }
            case 12:
                {
                    GameOptionData.level7SpecialItemCollected = true;
                    GameOptionData.numberOfSpecialItemsCollected++;
                    break;
                }
            case 13:
                {
                    GameOptionData.level8SpecialItemCollected = true;
                    GameOptionData.numberOfSpecialItemsCollected++;
                    break;
                }
        }
        currentItemSFX.Play();
        Destroy(gameObject);

    }


}
