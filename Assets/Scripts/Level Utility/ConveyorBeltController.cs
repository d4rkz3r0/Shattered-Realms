using UnityEngine;
using System.Collections;

public class ConveyorBeltController : MonoBehaviour {

	public bool goingRight;
	public float beltSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other){
		if ((other.tag == "Player" && other.name != "Ground Checker" )|| other.tag == "Enemy") {
			if (goingRight) {
				//if (other.transform.position.y > transform.position.y)
				other.transform.position += transform.right * beltSpeed * Time.deltaTime;
				//else
				//	other.transform.position += force * -Time.deltaTime;
			} else {
				//if (other.transform.position.y <= transform.position.y)
				//	other.transform.position += force * Time.deltaTime;
				//else
				other.transform.position -= transform.right * beltSpeed * Time.deltaTime;
			}	
		}
	}
}
