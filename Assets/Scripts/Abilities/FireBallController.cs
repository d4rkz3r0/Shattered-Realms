///***********************************************************************
//Class: FireBallController.cs
/*Notes:
 * The FireBallController class handles Itachi's FireBall ability.
 * abilitySpeed - x movement speed
 * enemyDeathParticle - the particle that plays when impacting an enemy.
 * standardImpactParticle - the particle that plays when this ability impacts
 * a non-enemy (Ex: Obstacle)
 * Start() - binds appropriate references, and sets the sprite's x localScale
 * depending on the players facing position.
 * Update() - abilitySpeed update per frame.
 * OnTrigger2D() - plays appropriate particle for collision and cleans up the
 * ability
 * 
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class FireBallController : MonoBehaviour
{
    //Public Globals
    public float abilitySpeed;
    public int abilityDamage;
    public GameObject enemyDeathParticle;
    public GameObject standardImpactParticle;


    //Private References
    private Rigidbody2D rb2D;
    private MasterController player;
    private BossHealthManager sasuke;



	void Start () 
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<MasterController>();

        switch(Application.loadedLevel)
        {
            case 5:
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
        

        if(player.transform.localScale.x < 0.0f)
        {
            abilitySpeed = -abilitySpeed;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if (player.transform.localScale.x > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        

	}
	
	void Update () 
    {
        rb2D.velocity = new Vector2(abilitySpeed, rb2D.velocity.y);

        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Fireball->Enemy
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().takeDamage(abilityDamage);
        }
        if(other.tag == "Boss")
        {
            if(sasuke != null)
            {
                sasuke.takeDamage(abilityDamage);
            }
            else
            {
                return;
            }
        }
   
        //Fireball->Anything Else
        Instantiate(standardImpactParticle, transform.position, transform.rotation);

        //Cleanup
        Destroy(gameObject);
    }
}
