///***********************************************************************
//Class: SasukeController.cs
/*Notes:
 * AI Logic for Sasuke
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class SasukeController : MonoBehaviour
{
    
    private enum MovementSelection { Idle, Patrolling, Chasing, Stunned, Damaged };
    private MovementSelection currBehavior;
    private MovementSelection startingBehavior;
    
    public bool canMove;
    public bool startMoving;

    public float idleSpeed;
    public float moveSpeed;
    public float chaseSpeed;
    public float aggroRange;
    public Transform[] patrolWaypoints;

    private float patrolTimer;
    private float chaseTimer;

    private int wayPointIndex;



    public float jumpHeight;
    public int numOfJumps;
    private int jumpsRemaining;

    public LayerMask playerLayer;
    public LayerMask groundCheckLayer;
    public Transform groundCheckTransform;
    private float groundCheckRadius = 0.1f;


    public Transform wallCheckTransform;

    private BoxCollider2D[] boxColliders;
    private int boxColliderIndex;
    private CircleCollider2D circleColliderCollision;

    public AudioSource sasukeJumpSFX;
    public AudioSource sasukeExecuteSFX;

    //Physics + Animation
    private bool isGrounded;
    private bool isBlinking;

    //Projectile Animation
    private Animation phoenixFlowerJustuAnimation;
    private float phoenixFlowerJustuAnimTimer;


    public Transform phoenixFlowerJutsuSpawnPoint;
    public GameObject phoenixFlowerJustuFireBall;
    public float phoenixFlowerJutsuCoolDown;
    private float phoenixFlowerJutsuTimer;
    private bool canCastPhoenixFlowerJustu;

    //Private References
    private Rigidbody2D rb2D;
    private Animator animator;
    private BossHealthManager sasukeHealth;
    private MasterController player;
    private Transform playerLocation;

    //Movement AI
    private bool isPlayerInAggroBubble;
    
    


	// Use this for initialization
	void Start ()
    {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        startingBehavior = MovementSelection.Idle;
        //Basic Init
        startMoving = false;
        canMove = true;
        

        player = FindObjectOfType<MasterController>();
        playerLocation = player.transform;

        boxColliders = GetComponents<BoxCollider2D>();
        circleColliderCollision = GetComponent<CircleCollider2D>();
        sasukeHealth = GetComponent<BossHealthManager>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Initialize Abilities
        canCastPhoenixFlowerJustu = true;


	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
        isPlayerInAggroBubble = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);
    }

	// Update is called once per frame
	void Update () 
    {
        if (playerLocation.position.x > transform.position.x)
        {
            //rb2D.velocity = new Vector2(chaseSpeed, rb2D.velocity.y);
            transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
        }
        else
        {
            //rb2D.velocity = new Vector2(-chaseSpeed, rb2D.velocity.y);
            transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
        }


            if (canMove)
            {
                GetComponent<EnemyMovement>().enabled = true;
            }
            else if(!canMove)
            {
                GetComponent<EnemyMovement>().enabled = false;
            }

        
	}

    void castPhoenixFlowerJustu()
    {

    }

    void Patrol()
    {

    }

    void Chase()
    {

    }

    
}
