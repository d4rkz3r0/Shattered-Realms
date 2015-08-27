using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	//Behaviour Manager
	public enum AttackBehaviour {Melee, Range, Bomber, SideBomber, Stunned};
	private AttackBehaviour myBehaviour;
	public AttackBehaviour myDefaultBehaviour;

	//General
	public float timeBetweenAttacks;
	public float timeBetweenJutsuAttacks;
	public GameObject projectile;
	private float attackTimer;
	private float justuAttackTimer;

	//Melee
	public int damageAmount;
    public bool attackAnimation;
	private Rigidbody2D playerRigidBody;
	private AudioSource playerSound;
	private MasterController playerScript;

	//Projectile
	private GameObject temp;
	private Transform trf;
	private Rigidbody2D rb2d;
	public float projectileSpeed;

	//Range
	private GameObject player;
	private bool isPlayerInRange;
	public LayerMask playerLayer;
	public float aggroRange;
	private Vector2 aiming;

	//Side Bomber
	public bool shootingLeft;

	//Stunned
	private float stunTimer;

	// Use this for initialization
	void Start () {
        attackAnimation = false;
		myBehaviour = myDefaultBehaviour;
		playerSound = GameObject.Find("Player").GetComponent<AudioSource>();
		playerScript = GameObject.Find ("Player").GetComponent<MasterController> ();
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(attackTimer > 0)attackTimer -= Time.deltaTime;

        if(justuAttackTimer > 0)justuAttackTimer -= Time.deltaTime;
        

		switch (myBehaviour) {
		case AttackBehaviour.Melee:
                if (gameObject.name == "Sasuke")
                {
                    if(timeBetweenJutsuAttacks <= 0)
                    {
                        justuAttackTimer = timeBetweenJutsuAttacks;
                        gameObject.GetComponent<SasukeController>().canMove = false;
                        gameObject.GetComponent<Animator>().Play("sasuke_Fireball");
                    }
                }
			break;

		case AttackBehaviour.Range:
			isPlayerInRange = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

			if(attackTimer <= 0 && isPlayerInRange)
            {
                if (GetComponent<Animator>() != null)
                {
                    attackAnimation = true;
                    return;
                }
				aiming = player.transform.position - transform.position;
				attackTimer = timeBetweenAttacks;
				temp = Instantiate(projectile);
				trf = temp.GetComponent<Transform>();
				trf.position = transform.position;
				rb2d = temp.GetComponent<Rigidbody2D>();
				rb2d.velocity = aiming.normalized*projectileSpeed;
			}
			break;

		case AttackBehaviour.Bomber:
			if(attackTimer <= 0){
				attackTimer = timeBetweenAttacks;
				temp = Instantiate(projectile);
				trf = temp.GetComponent<Transform>();
				trf.position = transform.position;
				rb2d = temp.GetComponent<Rigidbody2D>();
				rb2d.velocity = new Vector2(0,-projectileSpeed);
			}
			break;

		case AttackBehaviour.SideBomber:
			if(attackTimer <= 0){
				attackTimer = timeBetweenAttacks;
				temp = Instantiate(projectile);
				trf = temp.GetComponent<Transform>();
				trf.position = transform.position;
				rb2d = temp.GetComponent<Rigidbody2D>();
				if(shootingLeft)
					rb2d.velocity = new Vector2(-projectileSpeed,0);
				else
					rb2d.velocity = new Vector2(projectileSpeed,0);
			}
			break;

		case AttackBehaviour.Stunned:

			stunTimer -= Time.deltaTime;
			if(stunTimer <=0 ){
				myBehaviour = myDefaultBehaviour;
			}
			break;
		}
	}

	void OnTriggerStay2D(Collider2D other)
    {
		if (myBehaviour == AttackBehaviour.Melee && other.name == "Player" && attackTimer <= 0)
		{
            if(GetComponent<Animator>() != null)
            {
                attackAnimation = true;
            }
            
			attackTimer = timeBetweenAttacks;
			HealthManager.takeDamage(damageAmount);

			//Knockback
			playerScript.stunned = true;
			playerRigidBody = other.GetComponent<Rigidbody2D>();
			if(other.transform.position.x <transform.position.x)
			{
				playerRigidBody.velocity = new Vector2(-10,10); 
			}
			else
			{
				playerRigidBody.velocity = new Vector2(10,10); 
			}
		}
	}

	public void GetStun(float stn){
//		rb2d.velocity = Vector2.zero;
		myBehaviour = AttackBehaviour.Stunned;
		stunTimer = stn;
	}
}
