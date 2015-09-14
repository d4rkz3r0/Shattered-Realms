using UnityEngine;
using System.Collections;

public class HPPotionPickup : MonoBehaviour
{
    public int HPToAdd;
    private AudioSource hpSFX;

	public GameObject spark;

	void Start () 
    {
        if(gameObject.name == "chestHPGem (clone)")
        {
            hpSFX = GetComponent<AudioSource>();
        }
        else
        {
            hpSFX = GetComponentInParent<AudioSource>();
        }
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        //Only allow the Player To pick up HP Potions
        if (other.GetComponent<MasterController>() == null)
        {
            return;
        }
        HealthManager.receiveHealing(HPToAdd);
        hpSFX.Play();

		Instantiate (spark).transform.position = transform.position;
        
		Destroy(gameObject);
    }
}
