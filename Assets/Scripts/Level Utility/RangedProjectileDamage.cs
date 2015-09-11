using UnityEngine;
using System.Collections;

public class RangedProjectileDamage : MonoBehaviour
{

    //Public Inspector Globals
    public int damageAmount;
    //Default Values
    public float timeBetweenAttacks = 1.0f;
    private float timer = 1.0f;
    public LayerMask CollisionLayer;
    bool shouldDelete;
    private Rigidbody2D rb2D;
	private Vector2 preVel;

	void Start ()
    {
        shouldDelete = false;
        rb2D = GetComponent<Rigidbody2D>();
		if (rb2D.velocity.x <= 0) {
			transform.Rotate (0, 0, Vector2.Angle (Vector2.up, rb2D.velocity));
		} else {
			transform.Rotate (0, 0, Vector2.Angle (Vector2.up, Vector2.Reflect(rb2D.velocity,Vector2.up))+180);
		}
	}
	
    void FixedUpdate()
    {
        shouldDelete = Physics2D.OverlapCircle(transform.position, 0.3f, CollisionLayer);
    }

	void Update () 
    {



        if(shouldDelete)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        //Debug.Log(rb2D.velocity);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.name == "Player") && (timer > timeBetweenAttacks)) {
			timer = 0.0f;
			HealthManager.takeDamage (damageAmount);
			Destroy (gameObject);
		} 
    }
	void OnCollisionExit2D(Collision2D other)
	{
		if (Mathf.Abs(rb2D.velocity.x)*2 > Mathf.Abs(rb2D.velocity.y)){
			if(rb2D.velocity.x > 0){
				transform.Rotate (0, 0, Vector2.Angle (rb2D.velocity, Vector2.Reflect (rb2D.velocity, Vector2.right)));
			}else{
				transform.Rotate (0, 0, -Vector2.Angle (rb2D.velocity, Vector2.Reflect (rb2D.velocity, Vector2.right)));
			}
		} else {
			if(rb2D.velocity.y > 0){
				transform.Rotate (0, 0, -Vector2.Angle (rb2D.velocity, Vector2.Reflect (rb2D.velocity, Vector2.up)));
			}else{
				transform.Rotate (0, 0, Vector2.Angle (rb2D.velocity, Vector2.Reflect (rb2D.velocity, Vector2.up)));
			}
		
		}
	}

}
