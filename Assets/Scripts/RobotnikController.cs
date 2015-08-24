using UnityEngine;
using System.Collections;

public class RobotnikController : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	public GameObject laser;

	private float speed;
	private float speedIncrement;
	private Direction dir;

	private RobotnickWPData newData;
	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		speed += speedIncrement * Time.deltaTime;
		switch (dir) {
		case Direction.Right:
			rb2d.velocity = transform.right;
			break;
		case Direction.Up:
			rb2d.velocity = transform.up;
			break;
		case Direction.Left:
			rb2d.velocity = -transform.right;
			break;
		case Direction.Down:
			rb2d.velocity = -transform.up;
			break;
		}
		rb2d.velocity *= speed;

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "RobotnickWaypoint") {
			newData = other.GetComponent<RobotnickWPData>();
			speed = newData.RobSpeed;
			speedIncrement = newData.RobSpeedIncrement;
			dir = newData.RobDirection;

			laser.SetActive(newData.RobLaserOn);

					
		}
	}
}
