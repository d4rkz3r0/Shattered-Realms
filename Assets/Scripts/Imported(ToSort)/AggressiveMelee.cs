using UnityEngine;
using System.Collections;

public class AggressiveMelee : MonoBehaviour
{


		
	public GameObject target;
	private Rigidbody2D rb2d;
	public Vector2 aiming;

	public float aggroRange;



	//Collision
	public Transform edgeCheckTransform;
	public Transform wallCheckTransform;
	public LayerMask wallCheckLayer;
	public float wallCheckRadius;
    public bool hasHitWall;
	public bool notAtEdge;
    public bool jumping;
	public float stunTime;
	public float stunTimer;
    private MasterController player;
	public int speed;



		// Use this for initialization
		void Start () 
        {
		stunTimer = 2;
		rb2d = GetComponent<Rigidbody2D> ();
        target = GameObject.Find("Player");
		//speed = 3;
		//aggroRange = 100;
		notAtEdge = true;
		jumping = false;


		}
		
		// Update is called once per frame
		void Update () 
        {
		//jumpTimer -= Time.deltaTime;
		stunTimer += Time.deltaTime;

		aiming = target.transform.position - transform.position;

        if (stunTimer > stunTime)
        {
            if (notAtEdge && !hasHitWall)
            {
                jumping = false;
            }

            if (hasHitWall && rb2d.velocity.y == 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -7.0f);

            }

            hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);

            notAtEdge = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);

            if ((hasHitWall || !notAtEdge) && !jumping)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 8.0f);
                jumping = true;
            }

            if (aiming.magnitude < aggroRange && stunTimer > stunTime)
            {
                if (target.transform.position.x < transform.position.x /*&& !jumping*/)
                {
                    rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                    //jumping = true;
                }
                else
                {

                    rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                }
            }

            else
            {

                if (gameObject.name == "dude")
                {
                    transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
                    rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

                }
                else
                {
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                }


            }
        }


        if (jumping)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x / 2.0f, rb2d.velocity.y);

        }
        }

}