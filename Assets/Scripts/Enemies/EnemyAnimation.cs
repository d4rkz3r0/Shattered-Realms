using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
    private bool isGrounded;
    private bool isJumping;
    private bool isAttacking;
    private bool isDefeated;
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
    
    
	void Start () 
    {
        movement = GetComponent<EnemyMovement>();
        AI = GetComponent<EnemyAttack>();
        health = GetComponent<EnemyHealthManager>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = movement.speed;
        hp = health.enemyHP;
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


        //Defeat
        if(health.deathAnimation)
        {
            movement.enabled = false;
            AI.enabled = false;
            anim.SetBool("isDying", true);
            enemyDefeatedAnimTimer = enemyDefeatedAnimDuration;
        }
        
        //Attack
        if(AI.attackAnimation && enemyAttackAnimTimer <= 0.0f)
        {
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

        if(enemyDefeatedAnimTimer >= 0.0f && health.isDead)
        {
            enemyDefeatedAnimDuration -= Time.deltaTime;
        }

        if(enemyDefeatedAnimTimer <= 0.0f && health.isDead)
        {
            anim.SetBool("isDying", false);
            Destroy(gameObject);
        }
	}

    public void ThrowKunai()
    {
        Vector2 targetPoint = FindObjectOfType<MasterController>().transform.position - transform.position;
        GameObject kunai = Instantiate(AI.projectile);
        if(transform.localScale.x >= 0.0f)
        {
            kunai.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        }
        else
        {
            kunai.transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
        }
        Transform kunaiTransform = kunai.GetComponent<Transform>();
        kunaiTransform.position = transform.position;
        Rigidbody2D RB2D = kunai.GetComponent<Rigidbody2D>();
        RB2D.velocity = targetPoint.normalized * AI.projectileSpeed;
    }
}
