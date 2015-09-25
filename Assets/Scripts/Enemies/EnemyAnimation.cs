using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
    private bool isIdling;
    private bool isGrounded;
    private bool isJumping;
    private bool isAttacking;
    public bool isDefeated;

    private int moveSpeed;
    private int hp;
    private float groundCheckRadius = 0.1f;
    public LayerMask groundCheckLayer;
    public Transform groundCheckTransform;

    private EnemyMovement movement;
    private EnemyAttack AI;
    private EnemyHealthManager health;
    private Rigidbody2D rb2D;
    private Animator anim;

    //Anim Timers
    private float enemyDefeatedAnimTimer;
    public float enemyDefeatedAnimDuration;

    private float enemyAttackAnimTimer;
    public float enemyAttackAnimTimerDuration;

    private SasukeController sasuke;
    
    
	void Start () 
    {
        movement = GetComponent<EnemyMovement>();
        AI = GetComponent<EnemyAttack>();
        if(gameObject.name == "Sasuke")
        {
            sasuke = FindObjectOfType<SasukeController>();
        }

        else
        {
            health = GetComponent<EnemyHealthManager>();
            hp = health.enemyHP;
        }
       
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = movement.speed;
        
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
    }
	
	void Update ()
    {
        //Movement
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("isGrounded", isGrounded);


        if(gameObject.name == "Jumping Sound Ninja")
        {

        }

        if(gameObject.name == "Sasuke")
        {
            //Do Nothing
        }

        else
        {
            //Defeat
            if (health.deathAnimation)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<BoxCollider2D>().enabled = false;
                movement.enabled = false;
                AI.enabled = false;
                anim.SetBool("isDying", true);
                enemyDefeatedAnimTimer = enemyDefeatedAnimDuration;
            }
        }
        
        
        
        //Attack
        if(AI.attackAnimation && enemyAttackAnimTimer <= 0.0f)
        {
            if(gameObject.name == "Sasuke")
            {
                if(FindObjectOfType<BossHealthManager>().isBossDead)
                {
                    return;
                }
                else
                {
                    sasuke.sasukeMeleeSFX.Play();
                    HealthManager.takeDamage(1);
                    if (FindObjectOfType<MasterController>().transform.position.x < transform.position.x)
                    {
                        FindObjectOfType<MasterController>().GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 10);
                    }
                    else
                    {
                        FindObjectOfType<MasterController>().GetComponent<Rigidbody2D>().velocity = new Vector2(10, 10);
                    }
                }
                
            }

            anim.SetBool("isAttacking", true);
            enemyAttackAnimTimer = enemyAttackAnimTimerDuration;
        }

        if (enemyAttackAnimTimer >= 0.0f)
        {
            enemyAttackAnimTimer -= Time.deltaTime;
        }

        if (enemyAttackAnimTimer <= 0.0f && AI.attackAnimation)
        {
            anim.SetBool("isAttacking", false);
            AI.attackAnimation = false;
        }

        if(gameObject.name == "Sasuke")
        {
            //Do Nothing
        }
        else
        {
            if (enemyDefeatedAnimTimer >= 0.0f && health.isDead)
            {
                enemyDefeatedAnimDuration -= Time.deltaTime;
            }

            if (enemyDefeatedAnimTimer <= 0.0f && health.isDead)
            {
                anim.SetBool("isDying", false);
                gameObject.SetActive(false);
            }
        }
	}

    public void ThrowKunai()
    {
        if(!FindObjectOfType<HealthManager>().isPlayerDead)
        {
            Vector2 targetPoint = FindObjectOfType<MasterController>().transform.position - transform.position;
            GameObject kunai = Instantiate(AI.projectile);
            if (transform.localScale.x >= 0.0f)
            {
                kunai.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else
            {
                kunai.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            Transform kunaiTransform = kunai.GetComponent<Transform>();
            kunaiTransform.position = transform.position;
            Rigidbody2D RB2D = kunai.GetComponent<Rigidbody2D>();
            RB2D.velocity = targetPoint.normalized * AI.projectileSpeed;
        }
        else if(!AI.attackAnimation)
        {
            anim.SetBool("isAttacking", false);
            return;
        }
    }

    public void TriggerKunai()
    {
        AI.attackAnimation = true;
    }

    public void TriggerIdle()
    {
        anim.SetBool("isIdling", true);
    }
    public void TriggerWaiting()
    {
        anim.SetBool("isWaiting", true);
        anim.SetBool("isDespawning", false);
        //movement.spawnAggroOnce = true;
    }
}
