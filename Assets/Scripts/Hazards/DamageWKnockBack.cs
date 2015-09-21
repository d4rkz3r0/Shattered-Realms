using UnityEngine;
using System.Collections;

public class DamageWKnockBack : MonoBehaviour {
	
	//Public Inspector Globals
	public int damageAmount;
	public int attackTimer;
	private float timer;
	private Rigidbody2D rbd2;
	private Rigidbody2D kunairb2D;
	
	//Private References
	
	void Start ()
	{
        if(GetComponent<Rigidbody2D>() != null)
        {
            kunairb2D = GetComponent<Rigidbody2D>();
        }
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
            if ((other.GetComponent<MasterController>().currentCharacter == 3) &&
              ((other.GetComponent<MasterController>().isGoingSuper)    ||
              ((other.GetComponent<MasterController>().isBackFlipping))))

			    //|| ((!other.GetComponent<MasterController>().isGrounded))))
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

    void OnCollisionExit2D(Collision2D other)
    {
        if (gameObject.name == "kunai W_KnockBack(Clone)")
        {
            if (Mathf.Abs(kunairb2D.velocity.x) * 2 > Mathf.Abs(kunairb2D.velocity.y))
            {
                if (kunairb2D.velocity.x > 0)
                {
                    transform.Rotate(0, 0, Vector2.Angle(kunairb2D.velocity, Vector2.Reflect(kunairb2D.velocity, Vector2.right)));
                }
                else
                {
                    transform.Rotate(0, 0, -Vector2.Angle(kunairb2D.velocity, Vector2.Reflect(kunairb2D.velocity, Vector2.right)));
                }
            }
            else
            {
                if (kunairb2D.velocity.y > 0)
                {
                    transform.Rotate(0, 0, -Vector2.Angle(kunairb2D.velocity, Vector2.Reflect(kunairb2D.velocity, Vector2.up)));
                }
                else
                {
                    transform.Rotate(0, 0, Vector2.Angle(kunairb2D.velocity, Vector2.Reflect(kunairb2D.velocity, Vector2.up)));
                }

            }
        }
        
    }
}

