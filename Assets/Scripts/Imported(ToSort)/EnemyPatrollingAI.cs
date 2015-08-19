///***********************************************************************
//Class: EnemyPatrollingAI.cs
/*Notes:
 * The EnemyPatrollingAI class is an AI Behavior that can be attached to any
 * enemy to give them the patrolling behavior.
 * moveSpeed - x movement speed.
 * moveRight - boolean which flips sprite and x velocity if an edge or obstacle is encountered.
 * hasHitWall and notAtEdge booleans are toggled if their transforms' position overlaps the 
 * respective layers that they are checking for, in our game non-lethal obstacles, walls and floors
 * are all considered the same.
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class EnemyPatrollingAI : MonoBehaviour
{
    ////Public Globals
    //Enemy
    public float moveSpeed;
    private bool moveRight;
   

    //Collision
    public Transform edgeCheckTransform;
    public Transform wallCheckTransform;
    public LayerMask wallCheckLayer;
    public float wallCheckRadius;
    private bool hasHitWall;
    private bool hasHitHazardWall;
    private bool notAtEdge;
	public float stunTime;
	public float stunTimer;

    ////Private References
    private Rigidbody2D rb2D;


	// Use this for initialization
	void Start () 
    {
        rb2D = GetComponent<Rigidbody2D>();

		stunTimer = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
		stunTimer += Time.deltaTime;
        hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
        notAtEdge = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);

        if ((hasHitWall) || !notAtEdge)
        {
            moveRight = !moveRight;
        }

	    if(moveRight)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
			if(stunTimer > stunTime)rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			if(stunTimer > stunTime)rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
        }
	}

    void FixedUpdate()
    {
        
    }
}
