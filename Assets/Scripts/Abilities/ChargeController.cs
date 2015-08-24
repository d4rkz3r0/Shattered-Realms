	using UnityEngine;
	using System.Collections;
	
	public class ChargeController : MonoBehaviour
	{
		
		
		//Public Globals
		public int abilityDamage;
	public float stunTime;
		
		//Private References
		private MasterController player;
		private Rigidbody2D otherRB;
		private EnemyMovement eMScrp;
		private EnemyAttack eAScrp;
		
		
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
			//if (other.name != "Player" || other.tag != "Collectibles" || other.tag != "LethalHazard" || other.tag != "Platform") 
		if(other.GetComponent<Rigidbody2D> () || other.tag == "Obstacle")	
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
				if(other.GetComponent<EnemyMovement>())
				{
					eMScrp = other.GetComponent<EnemyMovement>();
					eMScrp.GetStun(stunTime);
				}
				if( other.GetComponent<EnemyAttack>())
				{
					eAScrp = other.GetComponent<EnemyAttack>();
					eAScrp.GetStun(stunTime);
				}
			if(other.tag != "Obstacle"){
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
		
	}
