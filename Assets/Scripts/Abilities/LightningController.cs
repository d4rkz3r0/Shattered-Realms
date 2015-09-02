using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightningController : MonoBehaviour {

	public float abilitySpeed;
	public int abilityDamage;
	public float maxDistanceToTarget;
	private GameObject newLight;
	private MasterController player;
	private Rigidbody2D rb2D;
	public Vector3 distance;
	public bool isInitial;
	private LightningController lc;
	private EnemyMovement eM;
	public GameObject closest;
	public List<GameObject> enemies;
	public int i;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<MasterController>();

		if (isInitial) {
			if (player.transform.localScale.x < 0.0f) {
				rb2D.velocity = new Vector2 (-abilitySpeed, 0);
			} else {
				rb2D.velocity = new Vector2 (abilitySpeed, 0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		eM = other.GetComponent<EnemyMovement>(); i = 0;
		//Fireball->Enemy
		if (other.tag == "Enemy" && !eM.shocked) {
			other.GetComponent<EnemyHealthManager> ().takeDamage (abilityDamage);
			eM.shocked = true;
			eM.shockTimer = 5;
			enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
			eM = enemies[0].GetComponent<EnemyMovement>();
			closest = enemies[0];
			while(eM.shocked){
				i++;
				closest = enemies[i];
				eM = enemies[i].GetComponent<EnemyMovement>();
			}
		
			for (; i < enemies.Count; i++) {
				if(Vector3.Distance(enemies[i].transform.position, transform.position) < Vector3.Distance(closest.transform.position, transform.position)){
					eM = enemies[i].GetComponent<EnemyMovement>();
					if(enemies[i] != other && !eM.shocked){
						closest = enemies[i];
					}
					else{
						Debug.Log("Is The Same");
					}
				}
			}
			distance = closest.transform.position - transform.position;
			if(distance.magnitude < maxDistanceToTarget){
				newLight = Instantiate(gameObject);
				lc = newLight.GetComponent<LightningController>();
				lc.isInitial = false;
				rb2D = newLight.GetComponent<Rigidbody2D>();
				rb2D.velocity = distance.normalized * abilitySpeed;
			}
			Destroy(gameObject);
		}
	}
}
