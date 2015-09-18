using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//Behaviour Managment
    public enum MovementBehaviour { GroundAggro, GroundPatrolling, FixedDistanceGroundPatrolling, GroundSmart, GroundAgile, FlyingAggro, FlyingPatrolling, Stunned, SpawnAggro };
	private MovementBehaviour myBehaviour;
	public MovementBehaviour myDefaultBehaviour;

	//General Movement
	public int speed;
	private float actualSpeed;
	private Rigidbody2D rb2d;
	public bool slowed;
	public float slowFactor;

	//lightning
	public bool shocked;
	public float shockTimer;

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
	public bool hasHitWall;
	private bool hasHitHazardWall;
    public bool thersGround;
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

    //Fixed Distance Ground Patrolling
    public float distance;
    private float distanceTimer;

	//Ground Smart
	private bool isPlayerTooClose;
	public float defensiveRange;
	private float smartTimer;

	//Ground Agile
	private GameObject playerProjectile;
	private Vector2 toPlayerProj;

	//Stunned
	private float stunTimer;

    //Spawn Aggro
    public bool spawnAggroOnce;

    //Ground Aggro Movement Fix
    private SasukeController sasuke;
    private MasterController player;

	private float defJumpPower;

	// Use this for initialization
	void Start ()
    {
		startingPosition = transform.position;
		currentWaypoint = waypoint1.position;
		
		actualSpeed = speed;
		myBehaviour = myDefaultBehaviour;
		target = GameObject.Find("Player");
        player = FindObjectOfType<MasterController>();
        sasuke = FindObjectOfType<SasukeController>();
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 0;
		defJumpPower = jumpPower;
		jumpPower = 0;
		jumping = false;
		shocked = false;
		smartTimer = 0;

		if (gameObject.GetComponent<CircleCollider2D> ()) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		}
        //Spawn Aggro
        spawnAggroOnce = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
		float xPos;
		if (target.transform.position.x > transform.position.x) {
			if (startingPosition.x > transform.position.x) {
				xPos = transform.position.x;
			} else {
				xPos = startingPosition.x;
			}
		} else {
			if (startingPosition.x < transform.position.x) {
				xPos = transform.position.x;
			} else {
				xPos = startingPosition.x;
			}
		}

		if(rb2d.gravityScale == 0){
		if (myDefaultBehaviour == MovementBehaviour.GroundAgile || myDefaultBehaviour == MovementBehaviour.FixedDistanceGroundPatrolling || myDefaultBehaviour == MovementBehaviour.GroundAggro || myDefaultBehaviour == MovementBehaviour.GroundPatrolling || myDefaultBehaviour == MovementBehaviour.GroundSmart || myDefaultBehaviour == MovementBehaviour.SpawnAggro) {
			if(Mathf.Abs(target.transform.position.x - xPos)< 10){
					rb2d.gravityScale = 1;
					gameObject.GetComponent<CircleCollider2D> ().enabled = true;
					jumpPower = defJumpPower;
				}
			}
		}

		if (shocked) {
			shockTimer -= Time.deltaTime;
		}
		if (shockTimer <= 0) {
			shocked = false;
		}

		if (slowed)
			actualSpeed = speed / slowFactor;
		else
			actualSpeed = speed;

		isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

		if(isPlayerInRange && myBehaviour != MovementBehaviour.GroundPatrolling  && myBehaviour != MovementBehaviour.FlyingPatrolling)
        {
            if (gameObject.name == "Sasuke")
            {
                //Do Nothing
            }
            else
            {
                if (target.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
					//Debug.Log("CHANGE 1");
                }
                else
                {
                    transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
					//Debug.Log("CHANGE 2");
                }
            }
		}

		switch (myBehaviour) 
        {
		case MovementBehaviour.GroundAggro:

			hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
			thersGround = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);

			if(isPlayerInRange)
            {
                if(Mathf.Round(target.transform.position.x) == Mathf.Round(transform.position.x))
                {
                    if(gameObject.name == "Sasuke")
                    {
                        if (sasuke.canCastBlink && Mathf.Round(target.transform.position.y) > Mathf.Round(transform.position.y) && player.isGrounded)
                        {
                            sasuke.castUpwardBlink();
                        }
                        else if (sasuke.canCastBlink && Mathf.Round(target.transform.position.y) < Mathf.Round(transform.position.y) && player.isGrounded)
                        {
                            sasuke.castDownwardBlink();
                        }
                        else
                        {
                            rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y);
                        }
                    }

                    else
                    {
                        rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y);
                    }
                    
                }

                else if ((Mathf.Round(target.transform.position.x * 100.0f) / 100.0f) > (Mathf.Round(transform.position.x) * 100.0f) / 100.0f)
                {
					rb2d.velocity = new Vector2 (actualSpeed, rb2d.velocity.y);
				}
                else 
                {
					rb2d.velocity = new Vector2 (-actualSpeed, rb2d.velocity.y);
				}
			}
            

                if(gameObject.name == "Heavy Aggro Sound Ninja")
                {
                    if(hasHitWall)
                    {
                        rb2d.velocity = new Vector2(0.0f, 0.0f);
                    }
                    return;
                }
                else
                {
                    if ((hasHitWall || !thersGround) && !jumping)
                    {
                        jumping = true;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
                    }

                    if (rb2d.velocity.y == 0.0f)
                    {
                        jumping = false;
                    }
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


        case MovementBehaviour.FixedDistanceGroundPatrolling:

            if (distanceTimer >= 0.0f)
            {
                distanceTimer -= Time.deltaTime;
            }

            if (distanceTimer <= 0.0f)
            {
                moveRight = !moveRight;
                distanceTimer = distance;
            }

            if (moveRight)
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
			if(isPlayerTooClose && smartTimer <= 0)
            {
				smartTimer = 1;
				if (target.transform.position.x > transform.position.x) 
                {
                    if(gameObject.name == "Jumping Sound Ninja")
                    {
                        rb2d.gravityScale = 1.5f;
                        rb2d.velocity = new Vector2(-actualSpeed * 0.3f, jumpPower);
                        
                    }
                    else
                    {
                        rb2d.velocity = new Vector2(-actualSpeed, jumpPower);

                    }
					
				}
				else
                {
                    if (gameObject.name == "Jumping Sound Ninja")
                    {
                        rb2d.gravityScale = 1.5f;
                        rb2d.velocity = new Vector2(actualSpeed * 0.3f, jumpPower);
                    }
                    else if(gameObject.name == "FLJumping Sound Ninja")
                    {
                        rb2d.gravityScale = 1.5f;
                        rb2d.velocity = new Vector2(0.0f, jumpPower);
                    }
                    else
                    {
                        rb2d.velocity = new Vector2(actualSpeed, jumpPower);
                    }
                }
					
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
			Debug.Log(transform.position);
			Debug.Log(currentWaypoint);
			if(ComparePositions(currentWaypoint,transform.position))
			{
				//Debug.Log("Reached waypoint");
				if(ComparePositions(waypoint1.position,transform.position)){
					Debug.Log("Reached waypoint 1");
					currentWaypoint = waypoint2.position; 
				}
				else if(ComparePositions(waypoint2.position,transform.position)){
					Debug.Log("Reached waypoint 2");
					currentWaypoint = waypoint3.position;  
				}
				else if(ComparePositions(waypoint3.position,transform.position)){
					Debug.Log("Reached waypoint 3");
					currentWaypoint = startingPosition; 
				}
				else if(ComparePositions(startingPosition,transform.position)){
					Debug.Log("Reached starting point");
					currentWaypoint = waypoint1.position; 
				}
			}

			//if (transform.position.x < currentWaypoint.x)
			//{
			//	transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
			//}
			//else
			//{
			//	transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
			//}

			break;

		case MovementBehaviour.Stunned:

			stunTimer -= Time.deltaTime;
			if(stunTimer <=0 ){
				myBehaviour = myDefaultBehaviour;
				rb2d.velocity = Vector2.zero;
			}
			break;

            case MovementBehaviour.SpawnAggro:

            isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

                if(isPlayerInRange && !GetComponent<EnemyHealthManager>().isDead)
                {
                    GetComponent<Animator>().SetBool("isSpawning", true);
                    GetComponent<Animator>().SetBool("isDespawning", false);
                }
                else if (!isPlayerInRange && !GetComponent<EnemyHealthManager>().isDead)
                {
                    if (!spawnAggroOnce)
                    {
                        GetComponent<Animator>().SetBool("isDespawning", true);
                        spawnAggroOnce = true;
                    }
                    GetComponent<Animator>().SetBool("isIdling", false);
                    GetComponent<Animator>().SetBool("isSpawning", false);
                }
            break;
		}
	}

	public void GetStun(float stn){
		//rb2d.velocity = Vector2.zero;
		myBehaviour = MovementBehaviour.Stunned;
		stunTimer = stn;
	}

	bool ComparePositions(Vector3 pos1, Vector3 pos2){
		if (pos1.x < pos2.x + 0.01f && pos1.x > pos2.x - 0.01f && pos1.y < pos2.y + 0.01f && pos1.y > pos2.y - 0.01f) {
			return true;
		} else {
			return false;
		}
	}

}

