using UnityEngine;
using System.Collections;

public class shotgunBlastController : MonoBehaviour
{

    //Public Globals
	public int abilityDamage;

	//Private References
	private MasterController player;
    private Animator anim;
	private Rigidbody2D otherRB;
	private newAggresiveMelee meleeScrp;
	private EnemyPatrollingAI patrolAIScrp;
    private float timer;
    public float timeBetweenAttacks;


	// Use this for initialization
	void Start ()
    {
        timer = timeBetweenAttacks;
        anim = GetComponent<Animator>();
		player = FindObjectOfType<MasterController>();
        timer += Time.deltaTime;

		if(player.transform.localScale.x < 0.0f)
		{
			transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
		}
		
		if (player.transform.localScale.x > 0.0f)
		{
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}

	}
	
	// Update is called once per frame
	void Update () 
    {
        anim.Play("cyborg_blast");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Player" || other.tag != "Collectibles" || other.tag != "LethalHazard" || other.tag != "Platform")
        {
            otherRB = other.GetComponent<Rigidbody2D>();
            //Fireball->Enemy
            if (other.tag == "Enemy" && timer > timeBetweenAttacks)
            {
                timer = 0;
                other.GetComponent<EnemyHealthManager>().takeDamage(abilityDamage);
            }
            if (other.tag == "MiniBoss")
            {
                other.GetComponent<BossHealthManager>().takeDamage(abilityDamage);
            }

            if (other.GetComponent<newAggresiveMelee>())
            {
                meleeScrp = other.GetComponent<newAggresiveMelee>();
                meleeScrp.stunTimer = 0;
            }
            if (other.GetComponent<EnemyPatrollingAI>())
            {
                patrolAIScrp = other.GetComponent<EnemyPatrollingAI>();
                patrolAIScrp.stunTimer = 0;
            }
            if (other.transform.position.x < transform.position.x)
            {
                otherRB.velocity = new Vector2(-5, 2);
            }
            else
            {
                otherRB.velocity = new Vector2(5, 2);
            }
        }
        //Cleanup
        //Destroy(gameObject);
    }

}
