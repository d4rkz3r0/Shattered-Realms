///***********************************************************************
//Class: EnemyFlyingAI.cs
/*Notes:
 * The EnemyFlyingAI class is an AI Behavior that can be attached to any
 * flying enemy to give them the patrolling behavior.
 */
///***********************************************************************
///
using UnityEngine;
using System.Collections;

public class EnemyFlyingAI : MonoBehaviour
{
    ////Public Globals
    //Enemy
    public float moveSpeed;
    public float aggroRange;
    public float flightDistance;
    private float flightDistanceTimer;
    public bool vertical;

    //Player
    public LayerMask playerLayer;
    private bool switchDirection;
    private bool isPlayerInRange;
    private bool isPlayerFacingAwayFromMe;
    public bool stationaryBehavior;
    public bool patrollingBehavior;
    public bool aggroBehavior;

    
   
    //Private References
    private MasterController player;
    private Rigidbody2D rb2D;

    void Start()
    {
        //Auto Hook
        player = FindObjectOfType<MasterController>();
        rb2D = GetComponent<Rigidbody2D>();

        //Defaults
        //MoveSpeed - 1.5
        //AggroRange - 7.5
    }

    void FixedUpdate()
    {

    }
    void Update()
    {

        isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);


        if(flightDistanceTimer >= 0.0f)
        {
            flightDistanceTimer -= Time.deltaTime;
        }
        
        if (flightDistanceTimer <= 0.0f)
        {
            switchDirection = !switchDirection;
            flightDistanceTimer = flightDistance;
        }

        if (stationaryBehavior)
        {
            // Just Sprite Flip
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
        }

        if (patrollingBehavior)
        {
            if (!vertical)
            {
                if (switchDirection)
                {
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
                }
                else
                {
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
                }
            }
            else
            {

                if (switchDirection)
                {
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    rb2D.velocity = new Vector2(rb2D.velocity.x, moveSpeed);
                }
                else
                {
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    rb2D.velocity = new Vector2(rb2D.velocity.x, -moveSpeed);
                }
            }
        }


        if (aggroBehavior)
        {
            //Default Behavior
            if (isPlayerInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                }

            //Sprite Flipping
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            ////Every Enemy always knows if you are looking at them or not called every frame - possible slowdown in the future.
            //if ((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) ||
            //    (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0))
            //{
            //    isPlayerFacingAwayFromMe = true;
            //}
            //else
            //{
            //    isPlayerFacingAwayFromMe = false;
            //}

            ////Special Behavior
            //if (isPlayerInRange && isPlayerFacingAwayFromMe)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            //}
           
        }
    }

    //Enable to see a visual representation of the enemies aggro radius in the Scene View.
    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(transform.position, aggroRange);
    }
}
