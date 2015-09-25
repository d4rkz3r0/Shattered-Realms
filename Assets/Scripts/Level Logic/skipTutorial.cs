using UnityEngine;
using System.Collections;

public class skipTutorial : MonoBehaviour
{
    private PortalController warpPortal;
    private KeyPickup warpKey;
    private AudioSource warpSFX;
    private bool playedOnce;

	void Start ()
    {
        playedOnce = false;
        warpPortal = FindObjectOfType<PortalController>();
        warpKey = FindObjectOfType<KeyPickup>();
        warpSFX = GetComponent<AudioSource>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            warpKey.isPickedUp = true;
            if (!playedOnce)
            {
                warpSFX.Play();
                playedOnce = true;
            }
            other.transform.position = warpPortal.transform.position;
        }
        
    }
}
