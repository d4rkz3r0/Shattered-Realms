using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyManager : MonoBehaviour 
{
    public Sprite[] keySlotSheet;
    private Image currKeySlotImage;
    private KeyPickup key;

	// Use this for initialization
	void Start () 
    {
        key = FindObjectOfType<KeyPickup>();
        currKeySlotImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(!key.isPickedUp)
        {
            currKeySlotImage.sprite = keySlotSheet[0];
        }
        else
        {
            currKeySlotImage.sprite = keySlotSheet[1];
        }
	}
}
