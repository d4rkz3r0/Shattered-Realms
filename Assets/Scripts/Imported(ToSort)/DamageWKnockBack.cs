using UnityEngine;
using System.Collections;

public class DamageWKnockBack : MonoBehaviour {
	
	//Public Inspector Globals
	public int damageAmount;
	public int attackTimer;
	private float timer;
	private Rigidbody2D rbd2;
	
	//Private References
	
	void Start ()
	{
		timer = 1.0f;
		attackTimer = 1;
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
	}
	
	
	void OnTriggerStay2D(Collider2D other)
	{
        if (other.name == "Player" && timer > attackTimer)
		{
            if(other.GetComponent<MasterController>().isGoingSuper)
            {
                return;
            }

			timer = 0.0f;
			HealthManager.takeDamage(damageAmount);
			
			
			//KnockBack
			rbd2 = other.GetComponent<Rigidbody2D>();
			if(other.transform.position.x <transform.position.x)
			{
			rbd2.velocity = new Vector2(-10,10); 
			}
			else
            {
				rbd2.velocity = new Vector2(10,10); 
			}
		}
	}
}

