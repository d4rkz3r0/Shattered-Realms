using UnityEngine;
using System.Collections;

public class RobProjectilePushController : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 0.1f) {
			timer = 0;
			if(GetComponent<SpriteRenderer>().color == Color.red)
			{
				GetComponent<SpriteRenderer>().color = Color.yellow;
			}
			else{
				GetComponent<SpriteRenderer>().color = Color.red;

			}
		}
	}

	void OnTriggerEnter2D(Collider2D otherObj){
		if (otherObj.tag == "Player") {
			HealthManager.takeDamage(3);
		  otherObj.GetComponent<MasterController>().stunned = true;
			otherObj.attachedRigidbody.velocity = new Vector2(35,0);
			Destroy(gameObject);
		}
	}
}
