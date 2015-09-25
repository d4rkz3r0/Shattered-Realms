using UnityEngine;
using System.Collections;

public class MarioMovementBehaviour : MonoBehaviour {

	private Vector3 startingPosition;
	public Transform waypoint1;
	public Transform waypoint2;
	private Vector3 currentWaypoint;
	public bool playertriggered;
	public bool waypointreached = false;
	public Transform Mysterybox;
	public Transform MarioMushroom;
	public bool MushroomActive;
	public bool MushroomPwrActivate;
	public bool FlowerActive;
	public bool FlowerPwrActivate;
	public bool PoweredUp;
	public bool TanookiPwrActivate;
	public bool TanookiActive;
	public bool StarPwrActivate;
	public bool StarActive;

	public int speed;
	private float actualSpeed;
	public float aggroRange;
	public LayerMask playerLayer;

	public GameObject player;


	public bool isPlayerInRange;
	public Transform sign;

	// Use this for initialization
	void Start () {
		PoweredUp = false;
		playertriggered = false;
		startingPosition = transform.position;
		currentWaypoint = waypoint1.position;
		actualSpeed = speed;
		MushroomActive = false;
		FlowerActive = false;
		TanookiActive = false;
	}
	
	// Update is called once per frame
	void Update () {

		isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

		if (isPlayerInRange == true) {


			if (gameObject.GetComponent<EnemyHealthManager>().enemyHP ==  gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP && PoweredUp == false ||
			    gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.75f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f)&& PoweredUp == false ||
			    gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f) && PoweredUp == false ||
			    gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > 0 && PoweredUp == false || 
			    gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP < 0 && PoweredUp == false)

			{

				transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, actualSpeed * Time.deltaTime);

				if (gameObject.GetComponent<MarioCombatBehaviour>().MysteryBoxDestroyed == false)
				{
					float blockPos = Mysterybox.transform.position.x;

					if (gameObject.transform.position.x < blockPos - 0.5f)
					{
						currentWaypoint = waypoint2.position;
					}

		
					if (gameObject.transform.localPosition.x <= blockPos + 0.5f && gameObject.transform.position.x >= blockPos - 0.5f && PoweredUp == false) //&& gameObject.GetComponent<MarioCombatBehaviour>().MysteryBoxDestroyed == false)
					{
						Vector3 jump = new Vector3(0.0f, 7.0f, 0.0f);
						gameObject.GetComponent<Rigidbody2D>().velocity = jump;
					}
				}
			}
			else if (PoweredUp == true)
			{
				currentWaypoint = waypoint1.position;
				transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, actualSpeed * Time.deltaTime);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "MysteryBox" && gameObject.GetComponent<EnemyHealthManager> ().enemyHP == gameObject.GetComponent<EnemyHealthManager> ().EnemyMaxHP) 
		{
			MushroomActive = true;
		} 
		else if (other.gameObject.tag == "PowerUp" && gameObject.GetComponent<EnemyHealthManager> ().enemyHP == gameObject.GetComponent<EnemyHealthManager> ().EnemyMaxHP) 
		{
			MushroomPwrActivate = true;
		}
		else if (other.gameObject.tag == "MysteryBox" && gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.75f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f))
		{
			FlowerActive = true;
		}
		else if (other.gameObject.tag == "PowerUp" && gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.75f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f))
		{
			FlowerPwrActivate = true;
		}
		else if (other.gameObject.tag == "MysteryBox" && gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f))
		{
			TanookiActive = true;
		}
		else if (other.gameObject.tag == "PowerUp" && gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.50f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f))
		{
			TanookiPwrActivate = true;
		}
		else if (other.gameObject.tag == "MysteryBox" && gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > 0)
		{
			StarActive = true;
		}
		else if (other.gameObject.tag == "PowerUp" && gameObject.GetComponent<EnemyHealthManager>().enemyHP <= (gameObject.GetComponent<EnemyHealthManager>().EnemyMaxHP  *.25f) && gameObject.GetComponent<EnemyHealthManager>().enemyHP > 0)
		{
			StarPwrActivate = true;
			sign.gameObject.SetActive (true);
		}	
}
}
