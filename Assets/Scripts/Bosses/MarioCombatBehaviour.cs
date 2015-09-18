using UnityEngine;
using System.Collections;

public class MarioCombatBehaviour : MonoBehaviour {

	GameObject MushRoomPwrUp;
	GameObject player;
	GameObject mysteryBox;
	public float attackTimer;
	public Sprite marioSmall;
	public Sprite marioFlower;
	public Sprite marioTanooki;
	public GameObject projectile;
	public float projectileSpeed;
	private Vector2 aiming;
	private GameObject temp;
	private Transform trf;
	private Rigidbody2D rb2d;
	public bool MysteryBoxDestroyed;
	

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		mysteryBox = GameObject.Find ("Mystery Box");
		MysteryBoxDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.GetComponent<MarioMovementBehaviour>().MushroomPwrActivate == true) {
			gameObject.GetComponent<EnemyHealthManager>().enabled = false;
			transform.localScale = new Vector3(1.45f, 1.45f, 0);
			gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = true;
		}

		if (gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.75f))
		{
			if (gameObject.GetComponent<MarioMovementBehaviour>().MushroomPwrActivate == true){
				gameObject.GetComponent<EnemyHealthManager>().enemyHP = (int)(gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.75f);
				gameObject.GetComponent<MarioMovementBehaviour>().MushroomPwrActivate = false;
			transform.localScale = new Vector3(1f, 1f, 0f);
			gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = false;
			}

			if (gameObject.GetComponent<MarioMovementBehaviour>().FlowerPwrActivate == true){
				transform.localScale = new Vector3(1.45f, 1.45f, 0);
				gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = true;
				gameObject.GetComponent<SpriteRenderer>().sprite = marioFlower;

				if (attackTimer <= 0) {

					if (gameObject.GetComponent<MarioMovementBehaviour>().isPlayerInRange == true)
					{
					aiming = player.transform.position - transform.position;
					temp = Instantiate(projectile);
					trf = temp.GetComponent<Transform>();
					trf.position = transform.position;
					rb2d = temp.GetComponent<Rigidbody2D>();
					rb2d.velocity = aiming.normalized*projectileSpeed;
					attackTimer = .75f;
					}
				}
				
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				}
			}
		}

		if (gameObject.GetComponent<EnemyHealthManager> ().enemyHP <= (gameObject.GetComponent<EnemyHealthManager> ().EnemyMaxHP * .50f)) {
			if (gameObject.GetComponent<MarioMovementBehaviour>().FlowerPwrActivate == true){
				gameObject.GetComponent<EnemyHealthManager>().enemyHP = (int)(gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f);
				gameObject.GetComponent<MarioMovementBehaviour>().FlowerPwrActivate = false;
				transform.localScale = new Vector3(1f, 1f, 0f);
				gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = false;
				gameObject.GetComponent<SpriteRenderer>().sprite = marioSmall;
			}
			if (gameObject.GetComponent<MarioMovementBehaviour>().TanookiPwrActivate == true){
				transform.localScale = new Vector3(1f, 1f, 0);
				gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = true;
				gameObject.GetComponent<SpriteRenderer>().sprite = marioTanooki;
			}
		}

		if (gameObject.GetComponent<EnemyHealthManager> ().enemyHP <= (gameObject.GetComponent<EnemyHealthManager> ().EnemyMaxHP * .25f)) {

			if (gameObject.GetComponent<MarioMovementBehaviour> ().TanookiPwrActivate == true) {
				gameObject.GetComponent<EnemyHealthManager>().enemyHP = (int)(gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f);
				gameObject.GetComponent<MarioMovementBehaviour> ().TanookiPwrActivate = false;
				transform.localScale = new Vector3 (1f, 1f, 0f);
				gameObject.GetComponent<MarioMovementBehaviour> ().PoweredUp = false;
				gameObject.GetComponent<SpriteRenderer> ().sprite = marioSmall;
			}
			if (gameObject.GetComponent<MarioMovementBehaviour>().StarPwrActivate == true){
				transform.localScale = new Vector3(1f, 1f, 0);
				gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = true;

			}
		}
		if (MysteryBoxDestroyed == true)
		{
			if (gameObject.GetComponent<EnemyHealthManager>().enemyHP < 0)
				gameObject.GetComponent<EnemyHealthManager>().enemyHP = 1;
			gameObject.GetComponent<EnemyHealthManager>().enabled = true;
			gameObject.GetComponent<MarioMovementBehaviour>().StarPwrActivate = false;
			gameObject.GetComponent<MarioMovementBehaviour>().PoweredUp = false;
			
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {

			if (attackTimer <= 0) {
				HealthManager.takeDamage (2);
				attackTimer = .25f;
			}
			
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			}
		}
	
	}
}
