using UnityEngine;
using System.Collections;

public class WallClimbingCheck : MonoBehaviour {

	public bool touchingWall;
	public bool wallToTheRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherObj){
		if (otherObj.tag == "Wall") {
			touchingWall = true;
			if(otherObj.transform.position.x > GetComponentInParent<Transform>().position.x){
				wallToTheRight = true;
			}
			else{
				wallToTheRight = false;
			}
		}
	}
	void OnTriggerExit2D(Collider2D otherObj){
		if (otherObj.tag == "Wall") {
			touchingWall = false;
		}
	}
}
