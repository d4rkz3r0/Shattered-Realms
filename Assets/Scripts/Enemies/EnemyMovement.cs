using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//Behaviour Managment
	public enum MovementBehaviour {GroundAggro, GroundPatrolling, FlyingAggro, FlyingPatrolling, Stunned};
	private MovementBehaviour myBehaviour;
	public MovementBehaviour myDefaultBehaviour;

	//General Movement
	public int speed;
	private float actualSpeed;
	private Rigidbody2D rb2d;
	public bool slowed;
	public float slowFactor;

	//Aggresive Behaviour Variables
	private GameObject target;
	public float aggroRange;
	private bool isPlayerInRange;
	public LayerMask playerLayer;

	//Exclusively Ground Aggresive
	public Transform edgeCheckTransform;
	public Transform wallCheckTransform;
	public LayerMask wallCheckLayer;
	public LayerMask hazardCheckLayer;
	public float wallCheckRadius;
	private bool hasHitWall;
	private bool hasHitHazardWall;
	private bool thersGround;
	public float jumpPower;
	private bool jumping;

	// Flying Patrolling
	private Vector3 startingPosition;
	public Transform waypoint1;
	public Transform waypoint2;
	public Transform waypoint3;
	private Vector3 currentWaypoint;
	private GameObject HPBar;
	//Ground Patrolling
	private bool moveRight;

	//Stunned
	private float stunTimer;

	// Use this for initialization
	void Start () {
		HPBar = GameObject.Find("EnemyHealthBar");
		startingPosition = transform.position;
		currentWaypoint = waypoint1.position;

		actualSpeed = speed;
		myBehaviour = myDefaultBehaviour;
		target = GameObject.Find("Player");
		rb2d = GetComponent<Rigidbody2D>();
		jumping = false;
	}
	
	// Update is called once per frame
	void Update () {



		if (slowed)
			actualSpeed = speed / slowFactor;
		else
			actualSpeed = speed;

		isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

		switch (myBehaviour) {
		case MovementBehaviour.GroundAggro:

			hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
			thersGround = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);

			if(isPlayerInRange){
				if (target.transform.position.x > transform.position.x) {
					rb2d.velocity = new Vector2 (actualSpeed, rb2d.velocity.y);
					transform.localScale = new Vector3 (-1.0f, 1.0f, 0.0f);
					//rb2d.gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector3 (25, 1, 1);
					//gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector3 (25, 1, 1);
					  //rb2d.gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector2 (-actualSpeed, rb2d.velocity.y);
					//gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector3 (25, 1, 1);
				} else {
				    rb2d.velocity = new Vector2 (-actualSpeed, rb2d.velocity.y);
					transform.localScale = new Vector3 (1.0f, 1.0f, 0.0f);
					//gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector3 (25, 1, 1);
					  //rb2d.gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector3 (25, 1, 1);
					//gameObject.GetComponentsInChildren<SpriteRenderer> () [2].transform.localScale = new Vector3 (25, 1, 1);
				}
			}

			if ((hasHitWall || !thersGround) && !jumping) {
				jumping = true;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpPower);
			}

			if (rb2d.velocity.y == 0.0f) {
				jumping = false;
			}

			break;

		case MovementBehaviour.GroundPatrolling:

			hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
			thersGround = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);

			if (hasHitWall || !thersGround)
			{
				moveRight = !moveRight;
			}
			if(moveRight)
			{
				transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
				rb2d.velocity = new Vector2(actualSpeed, rb2d.velocity.y);
				HPBar.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
			else
			{
				transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				rb2d.velocity = new Vector2(-actualSpeed, rb2d.velocity.y);
				HPBar.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
			break;

		case MovementBehaviour.FlyingAggro:

			if(isPlayerInRange){
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, actualSpeed * Time.deltaTime);
			}
			break;

		case MovementBehaviour.FlyingPatrolling:

			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, actualSpeed * Time.deltaTime);

			if(transform.position == currentWaypoint)
			{
				//Debug.Log("Reached waypoint");
				if(transform.position - startingPosition == waypoint1.localPosition){
				//	Debug.Log("Reached waypoint 1");
					currentWaypoint = waypoint2.position + startingPosition - transform.position; 
				}
				else if(transform.position - startingPosition == waypoint2.localPosition){
				//	Debug.Log("Reached waypoint 2");
					currentWaypoint = waypoint3.position + startingPosition - transform.position;  
				}
				else if(transform.position - startingPosition == waypoint3.localPosition){
				//	Debug.Log("Reached waypoint 3");
					currentWaypoint = startingPosition; 
				}
				else if(transform.position == startingPosition){
				//	Debug.Log("Reached starting point");
					currentWaypoint = waypoint1.position; 
				}
			}

			break;

		case MovementBehaviour.Stunned:

			stunTimer -= Time.deltaTime;
			if(stunTimer <=0 ){
				myBehaviour = myDefaultBehaviour;
			}
			break;
		}
	}

	public void GetStun(float stn){
		//rb2d.velocity = Vector2.zero;
		myBehaviour = MovementBehaviour.Stunned;
		stunTimer = stn;
	}
}

