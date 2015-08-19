﻿using UnityEngine;
using System.Collections;

public class QuakeController : MonoBehaviour {

	//Public Globals
	public int abilityDamage;
	public float duration;
	
	//Private References
	private MasterController player;
	private Rigidbody2D otherRB;
	private newAggresiveMelee meleeScrp;
	private EnemyPatrollingAI patrolAIScrp;
	private float timer;

	
	
	// Use this for initialization
	void Start ()
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer > duration) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name != "Player" && other.tag != "Collectibles" && other.tag != "LethalHazard" && other.tag != "Platform") 
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
			if (other.tag == "Destroyable")
			{
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
				otherRB.velocity = new Vector2 (-10, 2); 
			} 
			else
			{
				otherRB.velocity = new Vector2 (10, 2); 
			}
		}
		
	}
	
}