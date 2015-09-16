	using UnityEngine;
	using System.Collections;
	
	public class ChargeController : MonoBehaviour
	{
		
		
		//Public Globals
		public int abilityDamage;
	public float stunTime;
	private float attTimer;
		
		//Private References
		private MasterController player;
		private Rigidbody2D otherRB;
		private EnemyMovement eMScrp;
		private EnemyAttack eAScrp;
		
	private BossHealthManager sasuke;
		// Use this for initialization
		void Start ()
		{
			if (Application.loadedLevel == 8) {
			sasuke = FindObjectOfType<BossHealthManager>();
		}
		}
		
		// Update is called once per frame
		void Update () 
		{
		attTimer -= Time.deltaTime;
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			//if (other.name != "Player" || other.tag != "Collectibles" || other.tag != "LethalHazard" || other.tag != "Platform") 
		if(other.GetComponent<Rigidbody2D> () || other.tag == "Obstacle")	
		{
				otherRB = other.GetComponent<Rigidbody2D> ();
			if (other.tag == "Boss" && attTimer <=0)
			{
				attTimer = 0.1f;
				sasuke.takeDamage (abilityDamage);
			}

				if (other.tag == "Enemy" && attTimer <=0)
				{
				attTimer = 0.1f;
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
