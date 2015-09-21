using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	
	public Transform door;
	public bool DoorisActive;
    private bool once;
	// Use this for initialization
	void Start () 
    {
        once = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
        {
            if (!once)
            {
                if (AudioManager.GetInstance() != null)
                {
                    AudioManager.playMarioBossMusic();
                }
                once = true;
            }
			door.gameObject.SetActive (true);
		}
	}

}
