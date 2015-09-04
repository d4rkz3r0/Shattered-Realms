using UnityEngine;
using UnityEngine.UI;  
using System.Collections;

public class KeyPickup : MonoBehaviour
{
    public bool isPickedUp;
    public GameObject keySlotUIElement;
    private PortalController portal;
    private AudioSource keySFX;
    


	// Use this for initialization
	void Start () 
    {
        isPickedUp = false;
        portal = FindObjectOfType<PortalController>();
        keySFX = GetComponentInParent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        portal.keyCollected = isPickedUp;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Only allow the Player To pick up Key
        if (other.GetComponent<MasterController>() == null)
        {
            return;
        }

        //TutorialTextController.textSelection = 5;
        //keySlotUIElement
        isPickedUp = true;
        portal.keyCollected = true;
        keySFX.Play();
        Destroy(gameObject);

    }
}
