///***********************************************************************
//Class: SasukeController.cs
/*Notes:
 * AI Logic for Sasuke
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class SasukeController : MonoBehaviour
{
    public bool canMove;
    public bool startMoving;
    public bool hasPlayedOnce;

    //Blink
    public float blinkCoolDown;
    private float blinkTimer;
    public bool canCastPhoenixFlowerJustu;
    public bool canCastChidori;
    public bool canCastBlink;
    private float blinkAnimTimer;

    //FireBall
    public bool isCastingFireBallJustu;
    public float fireballJutsuAnimTimer;
    public Transform fireballJutsuTopSpawnPoint;
    public Transform fireballJutsuMiddleSpawnPoint;
    public Transform fireballJutsuBottomSpawnPoint;
    public GameObject fireballJustuFireBall;
    public float fireballJutsuCoolDown;
    public float fireballJutsuTimer;
    private bool fireBallAudioHasPlayed;
    public float fireBallGlobalTimer;
    public float fireBallGlobalJutsuCoolDown;
    public bool isPlayerInFireBallRange;
    public float fireBallAggroRange;
    private bool fireballOnce;

    //Chidori
    public bool isChargingChidori;
    public float chidoriAnimTimer;
    public Transform chidoriCheckPoint;
    public float chidoriCoolDown;
    public float chidoriTimer;
    private bool chidoriChargeAudiohasPlayed;
    private bool chidoriCryAudiohasPlayed;
    public float chidoriGlobalTimer;
    public float chidoriGlobalCoolDown;
    public bool isPlayerInChidoriRange;
    public float chidoriAggroRange;
    public float chidoriChargeSpeed;
    public float chidoriChargeTimer;
    public float chidoriChargeDuration = 7.0f;
    public float chidoriStrikeCD = 3.0f;
    public bool chidoriStrike;
    public bool chidoriHit;


    public float jumpHeight;
    public int numOfJumps;
    private int jumpsRemaining;

    public LayerMask playerLayer;
    public LayerMask groundCheckLayer;
    public Transform groundCheckTransform;
    public Transform upBlinkPoint;
    public Transform downBlinkPoint;
    private float groundCheckRadius = 0.1f;


    public Transform wallCheckTransform;


    private int boxColliderIndex;

    public AudioSource sasukeJumpSFX;
    public AudioSource sasukeExecuteSFX;
    public AudioSource sasukeBlinkSFX;
    public AudioSource sasukeMeleeSFX;
    public AudioSource sasukeFireballJutsuSFX;
    public AudioSource phoenixBallSFX;
    public AudioSource chargeChidoriSFX;
    public AudioSource chidoriCrySFX;
    public AudioSource sasukeVictorySFX;

    //Physics + Animation
    private bool isGrounded;
    private bool isBlinking;

    

    //Private References
    private Rigidbody2D rb2D;
    private Animator animator;
    private BossHealthManager sasukeHealth;
    private MasterController player;
    private Transform playerLocation;
    public ChatBoxController chatBoxHUDElement;

    
    
    


	// Use this for initialization
	void Start ()
    {
        hasPlayedOnce = false;
        chidoriHit = false;
        chidoriStrike = false;
        isChargingChidori = false;
        isCastingFireBallJustu = false;
        fireBallAudioHasPlayed = false;
        chidoriChargeAudiohasPlayed = false;
        chidoriCryAudiohasPlayed = false;
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        //Basic Init
        startMoving = false;
        canMove = false;
        fireballOnce = false;
        

        player = FindObjectOfType<MasterController>();
        playerLocation = player.transform;

        sasukeHealth = GetComponent<BossHealthManager>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Initialize Abilities
        canCastChidori = true;
        canCastPhoenixFlowerJustu = true;
        canCastBlink = true;
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
        isPlayerInFireBallRange = Physics2D.OverlapCircle(transform.position, fireBallAggroRange, playerLayer);
       //isPlayerInChidoriRange = Physics2D.OverlapCircle(transform.position, chidoriAggroRange, playerLayer);
        chidoriHit = Physics2D.OverlapCircle(chidoriCheckPoint.position, 0.2f, playerLayer);
    }

	// Update is called once per frame
	void Update () 
    {
        if(chidoriStrikeCD >= 0.0f && canCastChidori)
        {
            chidoriStrikeCD -= Time.deltaTime;
        }

        //float myX = Mathf.Abs(transform.position.x);
        //float hisX = Mathf.Abs(player.transform.position.x);

        if (playerLocation.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
        }


        if (canMove)
        {
            GetComponent<EnemyMovement>().enabled = true;
        }
        else if (!canMove)
        {
            GetComponent<EnemyMovement>().enabled = false;
        }

        //Version 2 Chidori
        ////Movement even with disabled Enemy MovementScript
        //if (chidoriChargeTimer >= 0.0f)
        //{
        //     if(myX < hisX)
        //     {
        //         Debug.Log("LOL");
        //         Vector3.MoveTowards(transform.position, player.transform.position, 10.0f * Time.deltaTime);
        //     }
        //}

        //if (chidoriChargeTimer <= 0.0f)
        //{
        //    rb2D.velocity = new Vector2(0.0f, 0.0f);
        //}


        //Blink CoolDown
        if (!canCastBlink && blinkTimer >= 0.0f)
        {
            blinkTimer -= Time.deltaTime;
        }
        if (blinkTimer <= 0.0f)
        {
            isBlinking = false;
            canCastBlink = true;
        }

        //FireBall CoolDown
        if (fireBallGlobalTimer > 0.0f)
        {
            fireBallGlobalTimer -= Time.deltaTime;
        }

        if (!canCastPhoenixFlowerJustu && fireballJutsuTimer >= 0.0f)
        {
            fireballJutsuTimer -= Time.deltaTime;
        }
        if (fireballJutsuTimer <= 0.0f)
        {
            canCastPhoenixFlowerJustu = true;
        }

        ////Chidori CoolDown
        //if (chidoriGlobalTimer > 0.0f)
        //{
        //    chidoriGlobalTimer -= Time.deltaTime;
        //}

        //if (!canCastChidori && chidoriTimer >= 0.0f)
        //{
        //    chidoriTimer -= Time.deltaTime;
        //}
        //if (chidoriTimer <= 0.0f)
        //{
        //    canCastChidori = true;
        //}

        //Blink Animation
        if (blinkAnimTimer >= 0.0f)
        {
            isBlinking = true;
            animator.SetBool("isBlinking", isBlinking);
            blinkAnimTimer -= Time.deltaTime;
        }
        if (blinkAnimTimer <= 0.0f)
        {
            isBlinking = false;
            animator.SetBool("isBlinking", isBlinking);
        }

        //FireBall Animation
        if(fireballJutsuAnimTimer >= 0.0f) //&& !isChargingChidori)
        {
            isCastingFireBallJustu = true;
            animator.SetBool("isCastingFireBall", true);
            fireballJutsuAnimTimer -= Time.deltaTime;
        }
        if (fireballJutsuAnimTimer <= 0.0f && !chatBoxHUDElement.isActiveAndEnabled)
        {
            isCastingFireBallJustu = false;
            animator.SetBool("isCastingFireBall", false);
            fireBallAudioHasPlayed = false;
            if (FindObjectOfType<BossHealthManager>() != null && !FindObjectOfType<BossHealthManager>().isBossDead && !isChargingChidori)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }

        ////Chidori Animation
        //if (chidoriAnimTimer >= 0.0f && !isCastingFireBallJustu)
        //{
        //    isChargingChidori = true;
        //    animator.SetBool("isChargingChidori", true);
        //    chidoriAnimTimer -= Time.deltaTime;
        //}

        //if (chidoriAnimTimer <= 0.0f)
        //{
        //    isChargingChidori = false;
        //    animator.SetBool("isChargingChidori", false);
        //}

        if (isPlayerInFireBallRange && fireBallGlobalTimer <= 0.0f)
        {
            if((Mathf.Round(player.transform.position.y) > Mathf.Round(transform.position.y)) || (Mathf.Round(player.transform.position.y) < Mathf.Round(transform.position.y)))
            {
                return;
            }
            else
            {
                if (FindObjectOfType<BossHealthManager>() != null && !FindObjectOfType<BossHealthManager>().isBossDead)
                {

                    castFireBall();
                    fireBallGlobalTimer = fireBallGlobalJutsuCoolDown;

                }
                else
                {
                    return;
                }
            }
        }

        //if (isPlayerInChidoriRange && chidoriGlobalTimer <= 0.0f && fireBallGlobalTimer >= 0.0f && !isCastingFireBallJustu)
        //{
        //    if ((Mathf.Round(player.transform.position.y) > Mathf.Round(transform.position.y)) || (Mathf.Round(player.transform.position.y) < Mathf.Round(transform.position.y)))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        if (!FindObjectOfType<BossHealthManager>().isBossDead && !isCastingFireBallJustu)
        //        {
        //            castChidori();
                    
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //} 
	}


    public void castDownwardBlink()
    {
        sasukeBlinkSFX.Play();
        blinkAnimTimer = 0.286f;
        rb2D.transform.position = new Vector3(downBlinkPoint.position.x,
                                              downBlinkPoint.position.y,
                                              rb2D.transform.position.z);
        canCastBlink = false;
        blinkTimer = blinkCoolDown;
    }

    public void castUpwardBlink()
    {
        sasukeBlinkSFX.Play();
        blinkAnimTimer = 0.286f;
        rb2D.transform.position = new Vector3(upBlinkPoint.position.x,
                                              upBlinkPoint.position.y,
                                              rb2D.transform.position.z);
        canCastBlink = false;
        blinkTimer = blinkCoolDown;
    }

    public void castFireBall()
    {
        canMove = false;
        if (!fireBallAudioHasPlayed)
        {
            sasukeFireballJutsuSFX.Play();
            fireBallAudioHasPlayed = true;
        }
        
        fireballJutsuAnimTimer = 2.1f;
        canCastPhoenixFlowerJustu = false;
        fireballJutsuTimer = fireballJutsuCoolDown;
    }

    public void spawnPhoneixFireJutsu()
    {
        phoenixBallSFX.Play();
        Instantiate(fireballJustuFireBall, fireballJutsuTopSpawnPoint.position, fireballJutsuMiddleSpawnPoint.rotation);
        Instantiate(fireballJustuFireBall, fireballJutsuMiddleSpawnPoint.position, fireballJutsuMiddleSpawnPoint.rotation);
        Instantiate(fireballJustuFireBall, fireballJutsuBottomSpawnPoint.position, fireballJutsuBottomSpawnPoint.rotation);
    }

    //public void castChidori()
    //{
    //    if (canCastChidori)
    //    {
    //        animator.Play("sasuke_Chidori");
    //    }
    //}

    //public void chidoriStart()
    //{
    //    chidoriAnimTimer = 2.0f;
    //    canMove = false;
    //    canCastChidori = false;
    //    if (!chidoriChargeAudiohasPlayed)
    //    {
    //        chargeChidoriSFX.Play();
    //        chidoriChargeAudiohasPlayed = true;
    //    }
    //}

    //public void chidoriMiddle()
    //{
    //    if (!chidoriCryAudiohasPlayed)
    //    {
    //        chidoriCrySFX.Play();
    //        chidoriCryAudiohasPlayed = true;
    //    }
    //    //chidoriChargeTimer = chidoriChargeDuration;

    //    if (transform.localScale.x >= 0.0f)
    //    {
    //        rb2D.velocity = new Vector3(chidoriChargeSpeed, 0.0f);
    //    }
    //    else
    //    {
    //        rb2D.velocity = new Vector3(-chidoriChargeSpeed, 0.0f);
    //    }

    //}

    //public void chidoriEnd()
    //{
    //    //Version 2 Chidori
    //    //rb2D.velocity = new Vector2(0.0f, 0.0f);
    //    canMove = true;
    //    chidoriChargeAudiohasPlayed = false;
    //    chidoriCryAudiohasPlayed = false;
    //    chidoriGlobalTimer = chidoriGlobalCoolDown;
    //    chidoriStrike = false;
    //}

    //public void chidoriStrikeCheck()
    //{
    //    if(chidoriHit && chidoriStrikeCD <= 0.0f)
    //    {
    //        HealthManager.takeDamage(5);
    //        chidoriStrikeCD = 3.0f;
    //        canCastChidori = false;
    //    }
    //}
}
