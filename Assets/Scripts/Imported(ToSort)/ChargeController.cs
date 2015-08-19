	using UnityEngine;
	using System.Collections;
	
	public class ChargeController : MonoBehaviour
	{
		
		
		//Public Globals
		public int abilityDamage;
		
		//Private References
		private MasterController player;
		private Rigidbody2D otherRB;
		private newAggresiveMelee meleeScrp;
		private EnemyPatrollingAI patrolAIScrp;
		
		
		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.name != "Player" || other.tag != "Collectibles" || other.tag != "LethalHazard" || other.tag != "Platform") 
			{
				otherRB = other.GetComponent<Rigidbody2D> ();
				
				if (other.tag == "Enemy")
				{
					other.GetComponent<EnemyHealthManager> ().takeDamage (abilityDamage);
				}
				if (other.tag == "MiniBoss")
				{
					other.GetComponent<BossHealthManager> ().takeDamage (abilityDamage);
				}
				if (other.tag == "Obstacle")
				{
					//Debug.Log("IS GETTING CALLED");
					DestroyObject(other.gameObject);
				}
				if(other.GetComponent<newAggresiveMelee>())
				{
					meleeScrp = other.GetComponent<newAggresiveMelee>();
					meleeScrp.stunTimer = 0;
				}
				if( other.GetComponent<EnemyPatrollingAI>())
				{
					patrolAIScrp = other.GetComponent<EnemyPatrollingAI>();
					patrolAIScrp.stunTimer = 0;
				}
				if (other.transform.position.x < transform.position.x) 
				{
					otherRB.velocity = new Vector2 (-18, 2); 
				} 
				else
				{
					otherRB.velocity = new Vector2 (18, 2); 
				}
			}
			
		}
		
	}
