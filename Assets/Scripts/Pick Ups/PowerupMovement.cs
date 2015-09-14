using UnityEngine;
using System.Collections;

public class PowerupMovement : MonoBehaviour {

	public GameObject Mario;
	private bool Mushroomrdy;
	private bool Flowerrdy;
	private Vector3 PwrUPPOS;
	private Vector3 PwrUPPOS2;
	public Vector3 tempvec;
	public Vector3 oppositeVec;
	public bool MushroomPwrActivate;
	public bool FlowerPwrActivate;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		Mushroomrdy = false;
		MushroomPwrActivate = false;
		Flowerrdy = false;
		FlowerPwrActivate = false;

		tempvec = new Vector3 (3, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
		PwrUPPOS = new Vector3 (0, 60, 0);
		oppositeVec = new Vector3(-tempvec.x, 0, 0);

        if(Mario == null)
        {
            return;
        }
        else
        {
            if (Mario.GetComponent<MarioMovementBehaviour>().MushroomActive == true && gameObject.name == "MarioLargePowerUp")
            {
                gameObject.transform.position += PwrUPPOS * Time.deltaTime;
                Mario.GetComponent<MarioMovementBehaviour>().MushroomActive = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = tempvec;
            }
            else if (Mario.GetComponent<MarioMovementBehaviour>().FlowerActive == true && gameObject.name == "Mario Flower Powerup")
            {
                gameObject.transform.position += PwrUPPOS * Time.deltaTime;
                Mario.GetComponent<MarioMovementBehaviour>().FlowerActive = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = tempvec;
            }
            else if (Mario.GetComponent<MarioMovementBehaviour>().TanookiActive == true && gameObject.name == "Mario Racoon Suit Powerup")
            {
                gameObject.transform.position += PwrUPPOS * Time.deltaTime;
                Mario.GetComponent<MarioMovementBehaviour>().TanookiActive = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = tempvec;
            }
            else if (Mario.GetComponent<MarioMovementBehaviour>().StarActive == true && gameObject.name == "MarioStarPowerup")
            {
                gameObject.transform.position += PwrUPPOS * Time.deltaTime;
                Mario.GetComponent<MarioMovementBehaviour>().StarActive = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = tempvec;
            }
        }
		

		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Wall") {

			tempvec = oppositeVec;
			gameObject.GetComponent<Rigidbody2D>().velocity = tempvec; 
		}

		if (other.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
}
