using UnityEngine;
using System.Collections;

public class QuakeController : MonoBehaviour {

	//Public Globals
	public int abilityDamage;
	public float duration;
	public float stunTime;


	//Private References
	private MasterController player;
    private BossHealthManager sasuke;
	private Rigidbody2D otherRB;
	private EnemyMovement eMScrp;
	private EnemyAttack eAScrp;
	private float timer;
	private float attTimer;

	
	
	// Use this for initialization
	void Start ()
	{
		timer = 0;
		attTimer = 0;
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
		timer += Time.deltaTime;
		attTimer -= Time.deltaTime;
		if (timer > duration) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{

	
		if (other.tag != "Player" && other.tag != "Collectibles" && other.tag != "LethalHazard" && other.tag != "Platform") 
		{
			otherRB = other.GetComponent<Rigidbody2D> ();
			Debug.Log ("not here");
			if (other.tag == "Destructable Platform")
			{
				Debug.Log ("here");
				other.GetComponent<PlatformHealthManager> ().takeDamage (abilityDamage);
			}
			if (other.tag == "Enemy" && attTimer <= 0)
			{
				timer = 0.1f;
				other.GetComponent<EnemyHealthManager> ().takeDamage (abilityDamage);
			}
			if (other.tag == "Boss" && attTimer <= 0)
            {
				timer = 0.1f;
                if (sasuke != null)
                {
                    sasuke.takeDamage(abilityDamage);
                }
                else
                {
                    return;
                }
            }
			if (other.tag == "MiniBoss")
			{
				other.GetComponent<BossHealthManager> ().takeDamage (abilityDamage);
			}
			if (other.tag == "Destroyable")
			{
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