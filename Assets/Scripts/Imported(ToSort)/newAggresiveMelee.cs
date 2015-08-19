using UnityEngine;
using System.Collections;

public class newAggresiveMelee : MonoBehaviour {
	
	// Aggro
	private GameObject target;
	private Rigidbody2D rb2d;
	public int speed;
	public float aggroRange;
	public Vector2 distanceToTarget;
	
	
	//Jumping AI
	public Transform edgeCheckTransform;
	public Transform wallCheckTransform;
	public LayerMask wallCheckLayer;
	public LayerMask hazardCheckLayer;
	public float wallCheckRadius;
	public bool hasHitWall;
	public bool hasHitHazardWall;
	public bool thersGround;
	public float jumpPower;
	private bool jumping;
	
	//Stunned
	public float stunDuration;
	public float stunTimer;
	
	
	// Use this for initialization
	void Start () {
		
		jumping = false;
		target = GameObject.Find("Player");
		rb2d = GetComponent<Rigidbody2D> ();
		stunTimer = stunDuration +1;
	}
	
	// Update is called once per frame
	void Update () {
		
		hasHitWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
		thersGround = Physics2D.OverlapCircle(edgeCheckTransform.position, wallCheckRadius, wallCheckLayer);
		
		if (stunTimer < stunDuration) {
			stunTimer += Time.deltaTime;
		}
		distanceToTarget = transform.position - target.transform.position;
		
		
		if (stunTimer >= stunDuration) {
			if (aggroRange > distanceToTarget.magnitude) {
				if (target.transform.position.x > transform.position.x) {
					rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
					transform.localScale = new Vector3 (-1.0f, 1.0f, 0.0f);
				} else {
					rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
					transform.localScale = new Vector3 (1.0f, 1.0f, 0.0f);
				}
			}
			
			if ((hasHitWall || !thersGround) && !jumping) {
				jumping = true;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpPower);
			}
		}
		if (rb2d.velocity.y == 0.0f) {
			jumping = false;
		}
		
		
	}
}
