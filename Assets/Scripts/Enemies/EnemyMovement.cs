using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//Behaviour Managment
	public enum MovementBehaviour {GroundAggro, GroundPatrolling, GroundSmart, GroundAgile, FlyingAggro, FlyingPatrolling, Stunned};
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

	//Ground Patrolling
	private bool moveRight;

	//Ground Smart
	private bool isPlayerTooClose;
	public float defensiveRange;
	private float smartTimer;

	//Ground Agile
	private GameObject playerProjectile;
	private Vector2 toPlayerProj;

	//Stunned
	private float stunTimer;

	// Use this for initialization
	void Start ()
    {
		startingPosition = transform.position;
		currentWaypoint = waypoint1.position;

		actualSpeed = speed;
		myBehaviour = myDefaultBehaviour;
		target = GameObject.Find("Player");
		rb2d = GetComponent<Rigidbody2D>();
		jumping = false;
		smartTimer = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (slowed)
			actualSpeed = speed / slowFactor;
		else
			actualSpeed = speed;

		isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

		if(isPlayerInRange && myBehaviour != MovementBehaviour.GroundPatrolling  && myBehaviour != MovementBehaviour.FlyingPatrolling){
			if (target.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (-1.0f, 1.0f, 0.0f);
			} else {
				transform.localScale = new Vector3 (1.0f, 1.0f, 0.0f);
			}
		}

		switch (myBehaviour) {
		case MovementBehaviour.GroundAggro:

			hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
			thersGround = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);

			if(isPlayerInRange){
				if (target.transform.position.x > transform.position.x) {
					rb2d.velocity = new Vector2 (actualSpeed, rb2d.velocity.y);
				} else {
					rb2d.velocity = new Vector2 (-actualSpeed, rb2d.velocity.y);
				}
			}

			if ((hasHitWall || !thersGround) && !jumping) {
				jumping = true;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpPower);
			}

			if (rb2d.velocity.y == 0.0f) 
            {
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
			}
			else
			{
				transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				rb2d.velocity = new Vector2(-actualSpeed, rb2d.velocity.y);
			}
			break;

		case MovementBehaviour.GroundSmart:

			isPlayerTooClose = Physics2D.OverlapCircle(transform.position, defensiveRange, playerLayer);
			smartTimer -= Time.deltaTime;
			if(isPlayerTooClose && smartTimer <= 0){
				smartTimer = 1;
				if (target.transform.position.x > transform.position.x) {
					rb2d.velocity = new Vector2(-actualSpeed, jumpPower);
				}
				else
					rb2d.velocity = new Vector2(actualSpeed, jumpPower);
			}
			break;

		case MovementBehaviour.GroundAgile:
			smartTimer -= Time.deltaTime;
			if(playerProjectile = GameObject.FindGameObjectWithTag("PlayerAbility")){
			if(playerProjectile.transform.position.y < transform.position.y + 1 && playerProjectile.transform.position.y > transform.position.y - 1){
				toPlayerProj = playerProjectile.transform.position - transform.position;
				if(toPlayerProj.magnitude < defensiveRange  && smartTimer <= 0){
					smartTimer = 2.08f;
						rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower*2);
				}
			}
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

