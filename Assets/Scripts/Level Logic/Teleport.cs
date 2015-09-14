using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    KeyPickup key;
    PortalController portal;

	// Use this for initialization
	void Start ()
    {
        key = FindObjectOfType<KeyPickup>();
        portal = FindObjectOfType<PortalController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            key.isPickedUp = true;
            other.transform.position = portal.transform.position;
        }
    }
}
