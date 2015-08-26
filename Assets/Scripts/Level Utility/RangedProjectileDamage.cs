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
    //private Rigidbody2D rb2D;

	void Start ()
    {
        shouldDelete = false;
        //rb2D = GetComponent<Rigidbody2D>();
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

	void OnCollisionEnter2D(Collider2D other){

	}
}
