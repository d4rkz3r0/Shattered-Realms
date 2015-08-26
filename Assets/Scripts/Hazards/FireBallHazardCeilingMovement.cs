using UnityEngine;
using System.Collections;

public class FireBallHazardCeilingMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround (Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		//transform.RotateAround (sphereObject.position, Vector3.up, 20 * Time.deltaTime);
		transform.Rotate(0, 0, -100 * Time.deltaTime);
	}
}
