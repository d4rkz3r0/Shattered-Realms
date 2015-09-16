using UnityEngine;
using System.Collections;

public class HPGemPickup : MonoBehaviour
{
    public int HPToRestore = 1;
    public GameObject spark;
    private AudioSource hpGemSFX;
	
	void Start () 
    {
        if(gameObject.name == "chestHPGem (clone)")
        {
            hpGemSFX = GetComponent<AudioSource>();
        }
        else
        {
            hpGemSFX = GetComponentInParent<AudioSource>();
        }
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        //Only allow the Player To pick up HP Potions
        if (other.GetComponent<MasterController>() == null)
        {
            return;
        }
        HealthManager.receiveHealing(HPToRestore);
        hpGemSFX.Play();

		Instantiate (spark).transform.position = transform.position;

        gameObject.SetActive(false);
    }
}
