using UnityEngine;
using System.Collections;

public class AcidController : MonoBehaviour
{
    public float audioTimer;
	
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(audioTimer >= 0.0f)
        {
            audioTimer -= Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Itachi")
        {
            audioTimer = 1.0f;
        }

        if (other.name == "platformMed" && audioTimer <= 0.0f)
        {
            Destroy(gameObject);
        }

		if (other.tag == "Destructable Platform" && audioTimer <= 0.0f)
		{
			other.GetComponent<PlatformHealthManager> ().takeDamage (1);
			Destroy(gameObject);
		}
    }
}
