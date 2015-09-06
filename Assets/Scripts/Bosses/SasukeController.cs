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
    public float phoenixFlowerJustuAnimTimer;
    public Transform phoenixFlowerJutsuTopSpawnPoint;
    public Transform phoenixFlowerJutsuMiddleSpawnPoint;
    public Transform phoenixFlowerJutsuBottomSpawnPoint;
    public GameObject phoenixFlowerJustuFireBall;
    public float phoenixFlowerJutsuCoolDown;
    public float phoenixFlowerJutsuTimer;
    private bool fireBallAudioHasPlayed;
    public float fireBallGlobalTimer;
    public float fireBallGlobalJutsuCoolDown;
    public bool isPlayerInFireBallRange;
    public float fireBallAggroRange;

    //Chidori
    public bool isChargingChidori;
    public float chidoriAnimTimer;
    public Transform chidoriEndPoint;
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
    public bool chidoriStrike;


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
        chidoriStrike = false;
        isChargingChidori = false;
        isCastingFireBallJustu = false;
        fireBallAudioHasPlayed = false;
        chidoriChargeAudiohasPlayed = false;
        chidoriCryAudiohasPlayed = false;
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        //Basic Init
        startMoving = false;
        canMove = true;
        

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
        isPlayerInChidoriRange = Physics2D.OverlapCircle(transform.position, chidoriAggroRange, playerLayer);
        
    }

	// Update is called once per frame
	void Update () 
    {


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

        if (!canCastPhoenixFlowerJustu && phoenixFlowerJutsuTimer >= 0.0f)
        {
            phoenixFlowerJutsuTimer -= Time.deltaTime;
        }
        if (phoenixFlowerJutsuTimer <= 0.0f)
        {
            canCastPhoenixFlowerJustu = true;
        }

        //Chidori CoolDown
        if (chidoriGlobalTimer > 0.0f)
        {
            chidoriGlobalTimer -= Time.deltaTime;
        }

        if (!canCastChidori && chidoriTimer >= 0.0f)
        {
            chidoriTimer -= Time.deltaTime;
        }
        if (chidoriTimer <= 0.0f)
        {
            canCastChidori = true;
        }

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
        if(phoenixFlowerJustuAnimTimer >= 0.0f && !isChargingChidori)
        {
            isCastingFireBallJustu = true;
            animator.SetBool("isCastingFireBall", true);
            phoenixFlowerJustuAnimTimer -= Time.deltaTime;
        }
        if (phoenixFlowerJustuAnimTimer <= 0.0f && !chatBoxHUDElement.isActiveAndEnabled)
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

        //Chidori Animation
        if (chidoriAnimTimer >= 0.0f && !isCastingFireBallJustu)
        {
            isChargingChidori = true;
            animator.SetBool("isChargingChidori", true);
            chidoriAnimTimer -= Time.deltaTime;
        }

        if (chidoriAnimTimer <= 0.0f)
        {
            isChargingChidori = false;
            animator.SetBool("isChargingChidori", false);
        }

        if (isPlayerInFireBallRange && fireBallGlobalTimer <= 0.0f)
        {
            if((Mathf.Round(player.transform.position.y) > Mathf.Round(transform.position.y)) || (Mathf.Round(player.transform.position.y) < Mathf.Round(transform.position.y)))
            {
                return;
            }
            else
            {
                if (!FindObjectOfType<BossHealthManager>().isBossDead)
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

        if (isPlayerInChidoriRange && chidoriGlobalTimer <= 0.0f && fireBallGlobalTimer >= 0.0f && !isCastingFireBallJustu)
        {
            if ((Mathf.Round(player.transform.position.y) > Mathf.Round(transform.position.y)) || (Mathf.Round(player.transform.position.y) < Mathf.Round(transform.position.y)))
            {
                return;
            }
            else
            {
                if (!FindObjectOfType<BossHealthManager>().isBossDead && !isCastingFireBallJustu)
                {
                    castChidori();
                    
                }
                else
                {
                    return;
                }
            }
        } 
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
        
        phoenixFlowerJustuAnimTimer = 2.1f;
        canCastPhoenixFlowerJustu = false;
        phoenixFlowerJutsuTimer = phoenixFlowerJutsuCoolDown;
    }

    public void spawnPhoneixFireJutsu()
    {
        phoenixBallSFX.Play();
        Instantiate(phoenixFlowerJustuFireBall, phoenixFlowerJutsuTopSpawnPoint.position, phoenixFlowerJutsuMiddleSpawnPoint.rotation);
        Instantiate(phoenixFlowerJustuFireBall, phoenixFlowerJutsuMiddleSpawnPoint.position, phoenixFlowerJutsuMiddleSpawnPoint.rotation);
        Instantiate(phoenixFlowerJustuFireBall, phoenixFlowerJutsuBottomSpawnPoint.position, phoenixFlowerJutsuBottomSpawnPoint.rotation);
    }

    public void castChidori()
    {
        if(canCastChidori)
        {
            animator.Play("sasuke_Chidori");
        }
    }
    public void chidoriStart()
    {
        chidoriAnimTimer = 2.0f;
        canMove = false;
        canCastChidori = false;
        if (!chidoriChargeAudiohasPlayed)
        {
            chargeChidoriSFX.Play();
            chidoriChargeAudiohasPlayed = true;
        }
    }

    public void chidoriMiddle()
    {
        if (!chidoriCryAudiohasPlayed)
        {
            chidoriCrySFX.Play();
            chidoriCryAudiohasPlayed = true;
        }
        //chidoriChargeTimer = chidoriChargeDuration;

        if (transform.localScale.x >= 0.0f)
        {
            rb2D.velocity = new Vector3(chidoriChargeSpeed, 0.0f);
        }
        else
        {
            rb2D.velocity = new Vector3(-chidoriChargeSpeed, 0.0f);
        }

    }

    public void chidoriEnd()
    {
        //Version 2 Chidori
        //rb2D.velocity = new Vector2(0.0f, 0.0f);
        canMove = true;
        chidoriChargeAudiohasPlayed = false;
        chidoriCryAudiohasPlayed = false;
        chidoriGlobalTimer = chidoriGlobalCoolDown;
        chidoriStrike = false;
    }

    
}
