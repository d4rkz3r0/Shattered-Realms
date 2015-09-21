using UnityEngine;
using System.Collections;

public class RobotnikController : MonoBehaviour {

	private Vector3 respawnPos;
	private Rigidbody2D rb2d;
	public GameObject laser;
	public float robotnickSize;
	private MasterController player;
	public GameObject projectile;
	private float shotTimer;

	private float speed;
	private float speedIncrement;
	private Direction dir;
	private Direction laserDir;

	private float delayTimer;

	private RobotnickWPData newData;

	private AudioSource laugh;

	// Use this for initialization
	void Start () {
		respawnPos = transform.position;
		delayTimer = 0;
		rb2d = GetComponent<Rigidbody2D>();
		laserDir = Direction.Down;
		player = FindObjectOfType<MasterController> ();
		laugh = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		delayTimer += Time.deltaTime;
		if (delayTimer > 2) {
			shotTimer += Time.deltaTime;

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

			if (rb2d.velocity.x < 0) {
				transform.localScale = new Vector3 (robotnickSize, robotnickSize, 1);
			} else if (rb2d.velocity.x > 0) {
				transform.localScale = new Vector3 (-robotnickSize, robotnickSize, 1);
			}

			//Controlling Player
			if (shotTimer > 1 && ((player.transform.position.y > transform.position.y && player.transform.position.x < transform.position.x + 1) || player.transform.position.x < transform.position.x)) {
				//player.stunned = true;
				//player.GetComponent<Rigidbody2D>().velocity = new Vector2(15,0);
				laugh.Play();
				shotTimer = 0;
				GameObject daProj = Instantiate (projectile);
				daProj.transform.localScale = new Vector3 (5, 5, 1);
				daProj.transform.position = transform.position;
				Vector2 vel = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
				daProj.GetComponent<Rigidbody2D> ().velocity = vel.normalized * 100;
			}

			if (HealthManager.playerHP == 0) {
				laugh.Play();
				transform.position = respawnPos;
				delayTimer = 0;
				rb2d.velocity = Vector2.zero;
			}

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "RobotnickWaypoint") {
			newData = other.GetComponent<RobotnickWPData> ();
			if (newData.used == false) {
				newData.used = true;
				speed = newData.RobSpeed;
				speedIncrement = newData.RobSpeedIncrement;
				dir = newData.RobDirection;

				laser.SetActive (newData.RobLaserOn);

				switch (laserDir) {

				case Direction.Down:
					switch (newData.RobLaserDir) {
					case Direction.Down:
						break;
					case Direction.Right:
						laser.transform.RotateAround (transform.position, transform.forward, 90);
						break;
					case Direction.Up:
						laser.transform.RotateAround (transform.position, transform.forward, 180);
						break;
					case Direction.Left:
						laser.transform.RotateAround (transform.position, transform.forward, -90);
						break;
					}
					break;

				case Direction.Right:
					switch (newData.RobLaserDir) {
					case Direction.Right:
						break;
					case Direction.Up:
						laser.transform.RotateAround (transform.position, transform.forward, 90);
						break;
					case Direction.Left:
						laser.transform.RotateAround (transform.position, transform.forward, 180);
						break;
					case Direction.Down:
						laser.transform.RotateAround (transform.position, transform.forward, -90);
						break;
					}
					break;

				case Direction.Up:
					switch (newData.RobLaserDir) {
					case Direction.Up:
						break;
					case Direction.Left:
						laser.transform.RotateAround (transform.position, transform.forward, 90);
						break;
					case Direction.Down:
						laser.transform.RotateAround (transform.position, transform.forward, 180);
						break;
					case Direction.Right:
						laser.transform.RotateAround (transform.position, transform.forward, -90);
						break;
					}
					break;

				case Direction.Left:
					switch (newData.RobLaserDir) {
					case Direction.Left:
						break;
					case Direction.Down:
						laser.transform.RotateAround (transform.position, transform.forward, 90);
						break;
					case Direction.Right:
						laser.transform.RotateAround (transform.position, transform.forward, 180);
						break;
					case Direction.Up:
						laser.transform.RotateAround (transform.position, transform.forward, -90);
						break;
					}
					break;			
				}

				laserDir = newData.RobLaserDir;				
			}
		}
	}
}
