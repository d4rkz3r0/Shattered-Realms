using UnityEngine;
using System.Collections;

public class RobotnikController : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	public GameObject laser;

	private float speed;
	private float speedIncrement;
	private Direction dir;
	private Direction laserDir;

	private RobotnickWPData newData;
	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		laserDir = Direction.Down;
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

			switch(laserDir){

			case Direction.Down:
				switch(newData.RobLaserDir){
				case Direction.Down:
					break;
				case Direction.Right:
					laser.transform.RotateAround(transform.position,transform.forward,90);
					break;
				case Direction.Up:
					laser.transform.RotateAround(transform.position,transform.forward,180);
					break;
				case Direction.Left:
					laser.transform.RotateAround(transform.position,transform.forward,-90);
					break;
				}
				break;

			case Direction.Right:
				switch(newData.RobLaserDir){
				case Direction.Right:
					break;
				case Direction.Up:
					laser.transform.RotateAround(transform.position,transform.forward,90);
					break;
				case Direction.Left:
					laser.transform.RotateAround(transform.position,transform.forward,180);
					break;
				case Direction.Down:
					laser.transform.RotateAround(transform.position,transform.forward,-90);
					break;
				}
				break;

			case Direction.Up:
				switch(newData.RobLaserDir){
				case Direction.Up:
					break;
				case Direction.Left:
					laser.transform.RotateAround(transform.position,transform.forward,90);
					break;
				case Direction.Down:
					laser.transform.RotateAround(transform.position,transform.forward,180);
					break;
				case Direction.Right:
					laser.transform.RotateAround(transform.position,transform.forward,-90);
					break;
				}
				break;

			case Direction.Left:
				switch(newData.RobLaserDir){
				case Direction.Left:
					break;
				case Direction.Down:
					laser.transform.RotateAround(transform.position,transform.forward,90);
					break;
				case Direction.Right:
					laser.transform.RotateAround(transform.position,transform.forward,180);
					break;
				case Direction.Up:
					laser.transform.RotateAround(transform.position,transform.forward,-90);
					break;
				}
				break;			
			}

			laserDir = newData.RobLaserDir;				
		}
	}
}
