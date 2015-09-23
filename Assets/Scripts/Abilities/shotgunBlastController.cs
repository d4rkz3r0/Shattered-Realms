using UnityEngine;
using System.Collections;

public class shotgunBlastController : MonoBehaviour
{

    //Public Globals
	public int abilityDamage;
	public float stunTime;

	//Private References
	private MasterController player;
    private BossHealthManager sasuke;
    private Animator anim;
	private Rigidbody2D otherRB;
	private EnemyMovement eMScrp;
	private EnemyAttack eAScrp;
    private float timer;
    private float timeBetweenAttacks;


	// Use this for initialization
	void Start ()
    {
		timeBetweenAttacks = 0;
		Debug.Log ("can attack");
        anim = GetComponent<Animator>();
		player = FindObjectOfType<MasterController>();
       

		if(player.transform.localScale.x < 0.0f)
		{
			transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
		}
		
		if (player.transform.localScale.x > 0.0f)
		{
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
        switch (Application.loadedLevel)
        {
            case 8:
                {
                    sasuke = FindObjectOfType<BossHealthManager>();
                    break;
                }
            default:
                {
                    sasuke = null;
                    break;
                }
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
		timeBetweenAttacks -= Time.deltaTime;
        anim.Play("cyborg_blast");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (timeBetweenAttacks <= 0) {
			timeBetweenAttacks = 0.2f;
			Debug.Log("time reseted");
			if (other.name != "Player" || other.tag != "Collectibles" || other.tag != "LethalHazard" || other.tag != "Platform") {
				if (other.GetComponent<Rigidbody2D> () == null) {
					return;
				} else {
					otherRB = other.GetComponent<Rigidbody2D> ();
				}
				if (other.tag == "Boss") {

					if (sasuke != null) {
						timer = 0;
						sasuke.takeDamage (1);
					} else {
						return;
					}
				}

				if (other.tag == "Destructable Platform") {
					other.GetComponent<PlatformHealthManager> ().takeDamage (abilityDamage);
				}
				if (other.tag == "MysteryBox") {
					other.GetComponent<MysteryBoxHealthManager> ().takeDamage (abilityDamage);
				}
				if (other.tag == "Enemy") {
					Debug.Log("damage deal");
					other.GetComponent<EnemyHealthManager> ().takeDamage (abilityDamage);
				}
				if (other.tag == "MiniBoss") {
					other.GetComponent<BossHealthManager> ().takeDamage (abilityDamage);
				}

				if (other.GetComponent<EnemyMovement> ()) {
					eMScrp = other.GetComponent<EnemyMovement> ();
					eMScrp.GetStun (stunTime);
				}
				if (other.GetComponent<EnemyAttack> ()) {
					eAScrp = other.GetComponent<EnemyAttack> ();
					eAScrp.GetStun (stunTime);
				}
				if (other.transform.position.x < player.transform.position.x) {
					otherRB.velocity = new Vector2 (-5, 2);
				} else {
					otherRB.velocity = new Vector2 (5, 2);
				}
			}
		}
        //Cleanup
        //Destroy(gameObject);
    }

}
