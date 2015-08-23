///***********************************************************************
//Class: MasterController.cs
/*Notes:
 * The MasterController class all player basic ability and character specific abilities.
 */
///***********************************************************************
using UnityEngine;
using System.Collections;


    


public class MasterController : MonoBehaviour
{
    //Movement Abilities
    public bool stunned;
    public float jumpHeight;
    public int numOfJumps;
    private int jumpsRemaining;
    public float moveSpeed;
    public float wallClimbSpeed;
    private float defaultGravityScale;
    private float stunTimer;
    
    //private float defaultDrag;
    

    //Collision Detection
    public Transform groundCheckTransform;
    public Transform wallCheckTransform;
    public Transform playerCenterPoint;
    public LayerMask groundCheckLayer;
    public LayerMask wallCheckLayer;
    public float groundCheckRadius;
    public float wallCheckRadius;
    public LayerMask blinkDetectionLayer;
    public bool isTouchingWall;
    public bool isOnWall;
    private BoxCollider2D[] boxColliders;
    private CircleCollider2D circleCollider;



    //SFX

    public AudioSource itachiHurtSFX;
    public AudioSource cyborgHurtSFX;
    public AudioSource sonicHurtSFX;

    public AudioSource playerJump;
    public AudioSource playerLvLUP;
    public AudioSource backFlipSFX;
    public AudioSource chaosSFX;
    public AudioSource spinDashSFX;
    
    //Player and Character Animation Abilities
    private Animation blastProjectileAnimation;
    private float blastAnimTimer = 0.45f; //Must Match ability cooldown!
    public bool isGrounded;
    public bool isBlinking;

    //LvL Up Animation
    private Animation levelUpAnimation;
    private float levelUpAnimTimer;
    private bool releaseControl;
    

    //Character Switching
    //1 - Itachi
    //2 - Cyborg
    //3 - Sonic
    public int startingCharacter = 1;
    public int currentCharacter;
    private bool playedOnce;
    //private int charBeforelvlUp;
   

    ////Character Abilities
    //Itachi - The Mage
    //FireBall
    public Transform fireBallPoint;
    public GameObject fireBall;
    public float fireBallCoolDown;
    private float fireBallTimer;
    private bool canCastFireBall;
    //private bool aboutToCastFireball;

    //Dark Storm
    public Transform darkStormPoint;
    public GameObject darkStorm;
    public float darkStormCoolDown;
    private float darkStormTimer;
    private bool canCastDarkStorm;

    //Magic Guard

    //Blink
    public Transform blinkPoint;
    public Transform upBlinkPoint;
	public Transform downBlinkPoint;
    public GameObject blinkParticle;
    public AudioSource blinkSFX;
    public float blinkCoolDown;
    private float blinkTimer;
    private bool canCastBlink;
    private float blinkAnimTimer;
   
    
	//CB - The Cyborg
	//Blast
    public Transform blastPoint;
	public GameObject blast;
	public float blastCooldown;
	private float blastTimer;
	private bool canCastBlast;

   //Charge
	public float chargeCoolDown;
	private float chargeTimer;
	private bool isCharging;
	private bool canCastCharge;
	public GameObject charge;
	public float chargingDuration;
	public float chargeRunningSpeed;
	private GameObject actualCharge;
	public float chargeSize;

	//Quake
	public float quakeCoolDown;
	private float quakeTimer;
	private bool isQuaking;
	private bool canCastQuake;
	public GameObject theQuake;
	private GameObject actualQuake;
	public float quakeSize;


    //Sonic
	//Knocking Back Enemies
	private EnemyMovement eMScrp;
	private EnemyAttack eAScrp;
	public float shortStun;

    //Q - Back Flip
    public float backFlipCoolDown;
    public int backFlipDamage;
    private float backFlipTimer;
    private bool canCastBackFlip;
    private float backFlipAnimTimer; //Must Match ability cooldown!
    private bool isBackFlipping;
    
    //W - Chaos Emeralds
    public float chaosEmeraldCoolDown;
    private float chaosEmeraldTimer;
    private bool canCastChaosEmeralds;
    private float chaosEmeraldsAnimTimer; //Must Match ability cooldown!
    public bool isGoingSuper;

    //R - Spin Dash
    public float spinDashSpeed;
    public float spinDashCoolDown;
    public int spinDashDamage;
    private float spinDashTimer;
    private bool canCastSpinDash;
    private float spinDashAnimTimer;
    public bool isSpinDashing;
    public bool disableInput;
    
    
	//Neat Hacks
    public Sprite sasukePain;
    public Sprite sasukeDead;
    public bool canExecuteSasuke;
    public bool isExecutingSasuke;
    public bool once;
    public bool sasukeBossFightOver;
    public float executeSasukeTimer;
    private float executeSasukeAnimTimer;
    public AudioSource executeSasukeSFX;

    

    ////Private References
    private Rigidbody2D rb2D;
    private Animator anim;
    private HealthManager healthManager;
    private SasukeController sasuke;
    private PortalController warpPortal;
    private KeyPickup warpKey;
    private BossHealthManager sasukeHP;



    void Start()
    {
        
        releaseControl = false;
        disableInput = false;
        canExecuteSasuke = false;
        isExecutingSasuke = false;
        once = false;
        //aboutToCastFireball = false;
        levelUpAnimTimer = 0.0f;
        playedOnce = false;
        stunned = false;
        //Auto Hook to GameObjects Components
        boxColliders = GetComponents<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentCharacter = startingCharacter;
        healthManager = FindObjectOfType<HealthManager>();
        defaultGravityScale = rb2D.gravityScale;
        warpPortal = FindObjectOfType<PortalController>();
        warpKey = FindObjectOfType<KeyPickup>();
        //defaultDrag = rb2D.drag;

        if(Application.loadedLevel == 5)
        {
            executeSasukeTimer = 2.0f;
            sasukeBossFightOver = false;
            sasuke = FindObjectOfType<SasukeController>();
            sasukeHP = FindObjectOfType<BossHealthManager>();
        }

        switch(currentCharacter)
        {
            case 1:
                {
                    boxColliders[0].offset = new Vector2(0.0f, 0.05f);
                    circleCollider.offset = new Vector2(0.0f, -0.83f);
                    anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    
                    break;
                }
            case 2:
                {
			boxColliders[0].offset = new Vector2(0.0f, 0.05f);
                    circleCollider.offset = new Vector2(0.0f, -0.83f);
                    anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    break;
                }
            case 3:
                {
			boxColliders[0].offset = new Vector2(0.0f, 0.05f);
                    circleCollider.offset = new Vector2(0.0f, -0.56f);
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.26992f, transform.position.z);
                    anim.runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                    break;
                }
            default:
                {
                    Debug.Log("Invalid starting character supplied, check Inspector Value");
                    break;
                }
        }

        //Initialize Abilities
        canCastFireBall = true;
        canCastDarkStorm = true;
        canCastBlink = true;
        canCastBlast = true;
        canCastCharge = true;
        canCastQuake = true;
        canCastBackFlip = true;
        canCastChaosEmeralds = true;
        canCastSpinDash = true;


        //Local Player Ability Animation
        isBlinking = false;
        isBackFlipping = false;
        isGoingSuper = false;
        isSpinDashing = false;
    }

    void FixedUpdate()
    {
        //Player Collision
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
    }

    void Update()
    {

        if (stunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                stunTimer = 0.5f;
                stunned = false;
            }
        }

        else if (!healthManager.isPlayerDead && !PauseMenuController.isGamePaused && !disableInput)
        {
            //Left Right Movement
            float hAxis = Input.GetAxis("Horizontal");
            //float yAxis = Input.GetAxis("Vertical");

            if (hAxis != 0.0f)
            {
                if (disableInput)
                {
                    return;
                    //Do Nothing
                }
                else
                {
                    rb2D.velocity = new Vector2(moveSpeed * hAxis, rb2D.velocity.y);
                }

            }



            if (XPGemManager.allGemsCollected && playedOnce == false)
            {
                playerLvLUP.Play();
                //charBeforelvlUp = currentCharacter;
                levelUpAnimTimer = 3.0f;
                anim.runtimeAnimatorController = Resources.Load("Animations/Player") as RuntimeAnimatorController;
                anim.Play("player_LvLUP");
                playedOnce = true;
                releaseControl = false;
            }

            if (levelUpAnimTimer > 0.0f)
            {
                levelUpAnimTimer -= Time.deltaTime;
            }
            if (levelUpAnimTimer < 0.0f && playedOnce && releaseControl == false)
            {
                if (currentCharacter == 1)
                {
                    currentCharacter = 2;
                    anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;


                }
                else if (currentCharacter == 2)
                {
                    currentCharacter = 1;
                    anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                }
                releaseControl = true;
            }


            //Flip Sprites Vertically
            if (hAxis > 0.0f && !isOnWall)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else if (hAxis < 0.0f && !isOnWall)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }

            //Jumping
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jumpsRemaining = numOfJumps - 1;
                playerJump.Play();
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
            }
            else if (Input.GetButtonDown("Jump"))
            {
                if (jumpsRemaining > 0)
                {
                    playerJump.Play();
                    rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
                    jumpsRemaining--;
                }
            }

            //Rotate Characters
            //Forward
            if (Input.GetButtonDown("CharSwitchForward"))
            {
                switch (currentCharacter)
                {
                    case 1:
                        {
                            currentCharacter = 2;
					boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
                            circleCollider.offset = new Vector2(0.0f, -0.83f);

                            anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                            break;
                        }
                    case 2:
                        {
                            currentCharacter = 3;
					boxColliders[0].offset = new Vector2(0.0f, 0.05f);
                            transform.position = new Vector3(transform.position.x, transform.position.y - 0.26992f, transform.position.z);
                            circleCollider.offset = new Vector2(0.0f, -0.56f);
                            anim.runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                            break;
                        }
                    case 3:
                        {
                            currentCharacter = 1;
					boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
                            circleCollider.offset = new Vector2(0.0f, -0.83f);
                            //circleCollider.radius = 0.2f;
                            transform.position = new Vector3(transform.position.x, transform.position.y + 0.26992f, transform.position.z);

                            anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                            break;
                        }
                    default:
                        {
                            Debug.Log("Character not assigned");
                            break;
                        }
                }
            }
            //Backwards
            if (Input.GetButtonDown("CharSwitchBackward"))
            {
                switch (currentCharacter)
                {
                    case 1:
                        {
                            currentCharacter = 3;
					boxColliders[0].offset = new Vector2(0.0f, 0.05f);
                            circleCollider.offset = new Vector2(0.0f, -0.56f);
                            transform.position = new Vector3(transform.position.x, transform.position.y - 0.26992f, transform.position.z);
                            anim.runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                            break;
                        }
                    case 2:
                        {
                            currentCharacter = 1;
					boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
                            circleCollider.offset = new Vector2(0.0f, -0.83f);

                            anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                            break;
                        }
                    case 3:
                        {
                            currentCharacter = 2;
					boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
                            circleCollider.offset = new Vector2(0.0f, -0.83f);
                            transform.position = new Vector3(transform.position.x, transform.position.y + 0.26992f, transform.position.z);
                            anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                            break;
                        }
                    /*
                     * 
                     * 
                     * 
                     * 
                     * 
                     * 
                     * 
                     * 
                     * */
                    default:
                        {
                            Debug.Log("Character not assigned");
                            break;
                        }
                }
            }

            ////Character Ability Input
            ////Itachi
            ////Q - FireBall Ability with CoolDown
            if (Input.GetButtonDown("Fire1") && (currentCharacter == 1))
            {
                if (canCastFireBall)
                {
                    Instantiate(fireBall, fireBallPoint.position, fireBallPoint.rotation);
                    canCastFireBall = false;
                    fireBallTimer = fireBallCoolDown;
                }
            }

            ////W - Dark Storm Ability with CoolDown
            if ((Input.GetButtonDown("Fire2")) && (currentCharacter == 1))
            {
                if (canCastDarkStorm)
                {
                    Instantiate(darkStorm, darkStormPoint.position, darkStormPoint.rotation);
                    canCastDarkStorm = false;
                    darkStormTimer = darkStormCoolDown;
                }
            }

            ////E - Magic Guard Ability with CoolDown


            ////R - Blink Ability with CoolDown
            //Downward
            if ((Input.GetAxis("Fire4") != 0 || Input.GetKeyDown(KeyCode.R)) && (Input.GetAxis("Vertical") < 0) && (currentCharacter == 1))
            {
                if (canCastBlink)
                {
                    if (!Physics2D.Linecast(playerCenterPoint.position, downBlinkPoint.position, blinkDetectionLayer))
                    {
                        StartCoroutine("makeBlinkParticle");
                        blinkSFX.Play();
                        blinkAnimTimer = 0.3f;
                        rb2D.transform.position = new Vector3(downBlinkPoint.transform.position.x,
                                                              downBlinkPoint.transform.position.y,
                                                              rb2D.transform.position.z);
                        canCastBlink = false;
                        blinkTimer = blinkCoolDown;

                    }
                    else
                    {
                        Debug.Log("Cannot blink through the ground, just platforms!");
                    }
                }
            }


            //Upward
            else if ((Input.GetAxis("Fire4") != 0 || Input.GetKeyDown(KeyCode.R)) && (Input.GetAxis("Vertical") > 0) && (currentCharacter == 1))
            {
                if (canCastBlink)
                {
                    if (!Physics2D.Linecast(playerCenterPoint.position, upBlinkPoint.position, blinkDetectionLayer))
                    {
                        StartCoroutine("makeBlinkParticle");
                        blinkSFX.Play();
                        blinkAnimTimer = 0.3f;

                        rb2D.transform.position = new Vector3(upBlinkPoint.transform.position.x,
                                                              upBlinkPoint.transform.position.y,
                                                              rb2D.transform.position.z);
                        canCastBlink = false;
                        blinkTimer = blinkCoolDown;
                    }
                    else
                    {
                        Debug.Log("Cannot blink through cielings, just platforms!");
                    }
                }
            }

            //Horizontal
            else if ((Input.GetAxis("Fire4") != 0 || Input.GetKeyDown(KeyCode.R)) && (currentCharacter == 1))
            {
                if (canCastBlink)
                {
                    if (!Physics2D.Linecast(playerCenterPoint.position, blinkPoint.position, blinkDetectionLayer))
                    {
                        StartCoroutine("makeBlinkParticle");
                        blinkSFX.Play();
                        blinkAnimTimer = 0.3f;
                        rb2D.transform.position = new Vector3(blinkPoint.transform.position.x,
                                                              blinkPoint.transform.position.y,
                                                              rb2D.transform.position.z);

                        canCastBlink = false;
                        blinkTimer = blinkCoolDown;
                    }
                    else
                    {
                        Debug.Log("Cannot blink into ground.");
                    }
                }
            }

            //Reset Blink Animation
            if ((Input.GetAxis("Fire4") == 0 && (currentCharacter == 1)))
            {
                //isBlinking = false;
            }

           

            //////Cyborg
            ////Q - Blast Ability with Ability CoolDown
            if (Input.GetButtonDown("Fire1") && (currentCharacter == 2))
            {
                if (canCastBlast)
                {
                    blastAnimTimer = 0.45f;
                    anim.Play("cyborg_Missle");

                    Instantiate(blast, blastPoint.position, blastPoint.rotation);
                    canCastBlast = false;
                    blastTimer = blastCooldown;

                }
            }

            ////R - Charge Ability with CoolDown
            if (isCharging)
            {
                if (transform.localScale.x > 0)
                    rb2D.velocity = new Vector2(chargeRunningSpeed, rb2D.velocity.y);
                else
                    rb2D.velocity = new Vector2(-chargeRunningSpeed, rb2D.velocity.y);
                actualCharge.transform.localScale = transform.localScale * chargeSize;
                actualCharge.transform.position = transform.position;
            }
            //Quake Ability with CoolDown
            if (!canCastQuake && quakeTimer >= 0.0f)
            {
                quakeTimer -= Time.deltaTime;
            }
            if (quakeTimer <= 0.0f)
            {
                canCastQuake = true;
            }
            if (isQuaking)
            {
                rb2D.velocity = new Vector2(0.0f, rb2D.velocity.y);
                if (isGrounded)
                {
                    actualQuake = Instantiate(theQuake);
                    actualQuake.transform.position = transform.position;
                    actualQuake.transform.localScale = new Vector3(quakeSize, quakeSize, 1.0f);
                    isQuaking = false;
                    rb2D.gravityScale = defaultGravityScale;
                }
            }

            //// Charge
            if ((Input.GetAxis("Fire4") != 0 || Input.GetKeyDown(KeyCode.R)) && (currentCharacter == 2))
            {
                if (canCastCharge)
                {
                    rb2D.gravityScale = 1.0f;
                    actualCharge = Instantiate(charge);
                    actualCharge.transform.position = transform.position;
                    actualCharge.transform.localScale = new Vector3(chargeSize * transform.localScale.x, chargeSize, 1.0f);


                    isCharging = true;
                    canCastCharge = false;
                    chargeTimer = chargeCoolDown;
                }
            }

            if ((Input.GetAxis("Fire4") == 0 || Input.GetKeyDown(KeyCode.R)) && (currentCharacter == 2))
            {
                rb2D.gravityScale = defaultGravityScale;
            }
            //// Quake
            if ((Input.GetButtonDown("Fire2")) && (currentCharacter == 2))
            {
                if (canCastQuake)
                {
                    rb2D.velocity = new Vector2(0.0f, 0.0f);
                    isQuaking = true;
                    rb2D.gravityScale = 10;

                    canCastQuake = false;
                    quakeTimer = quakeCoolDown;
                }



                ////E - RocketJump Ability with CoolDown

                ////R - Charge Ability with CoolDown
            }

            ////Sonic
            ////Q - BackFlip Ability with Ability CoolDown
            if (Input.GetButtonDown("Fire1") && (currentCharacter == 3))
            {
                if (canCastBackFlip)
                {
                    circleCollider.offset = new Vector2(0.0f, -0.84f);
                    backFlipSFX.Play();

                    backFlipAnimTimer = 0.8f;
                    isBackFlipping = true;

                    //anim.Play("sonic_Backflip");

                    //Instantiate(blast, blastPoint.position, blastPoint.rotation);
                    canCastBackFlip = false;

                    backFlipTimer = backFlipCoolDown;
                }
            }

            ////W - Chaos Emerald Activate Ability with Ability CoolDown
            if (Input.GetButtonDown("Fire2") && (currentCharacter == 3))
            {
                if (canCastChaosEmeralds)
                {
                    circleCollider.radius = 0.4f;
                    chaosSFX.Play();
                    chaosEmeraldsAnimTimer = 1.2f;
                    isGoingSuper = true;

                    canCastChaosEmeralds = false;
                    chaosEmeraldTimer = chaosEmeraldCoolDown;
                }
            }

            ////R - SpinDash Ability with CoolDown
            if ((Input.GetAxis("Fire4") != 0 || Input.GetKeyDown(KeyCode.R)) && (currentCharacter == 3))
            {
                if (canCastSpinDash)
                {
                    //circleCollider.radius = 0.4f;

					boxColliders[1].enabled = false;

                    spinDashSFX.Play();
                    spinDashAnimTimer = 1.9f;
                    isSpinDashing = true;

                    canCastSpinDash = false;
                    spinDashTimer = spinDashCoolDown;
                }
            }

            if (isSpinDashing && isGrounded)
            {
                disableInput = true;
            }
            else if (isSpinDashing && !isGrounded)
            {
                disableInput = false;
            }




            ////Ability Timers
            //Itachi
            if (!canCastFireBall && fireBallTimer >= 0.0f)
            {
                fireBallTimer -= Time.deltaTime;
            }
            if (fireBallTimer <= 0.0f)
            {
                canCastFireBall = true;
            }

            if (!canCastDarkStorm && darkStormTimer >= 0.0f)
            {
                darkStormTimer -= Time.deltaTime;
            }
            if (darkStormTimer <= 0.0f)
            {
                canCastDarkStorm = true;
            }

            if (!canCastBlink && blinkTimer >= 0.0f)
            {
                blinkTimer -= Time.deltaTime;
            }
            if (blinkTimer <= 0.0f)
            {
                isBlinking = false;
                canCastBlink = true;
            }

            //Cyborg
            if (!canCastBlast && blastTimer >= 0.0f)
            {
                blastTimer -= Time.deltaTime;
            }
            if (blastTimer <= 0.0f)
            {
                canCastBlast = true;
            }

            if (!canCastCharge && chargeTimer >= 0.0f)
            {
                chargeTimer -= Time.deltaTime;
            }
            if (chargeTimer <= 0.0f)
            {
                canCastCharge = true;
            }
            if (chargeTimer < chargeCoolDown - chargingDuration)
            {
                isCharging = false;
                DestroyObject(actualCharge);
            }

            //Sonic
            if (!canCastBackFlip && backFlipTimer >= 0.0f)
            {
                backFlipTimer -= Time.deltaTime;
            }
            if (backFlipTimer <= 0.0f)
            {
                if (currentCharacter == 3)
                {
                    circleCollider.offset = new Vector2(0.0f, -0.56f);
                }
                canCastBackFlip = true;
            }

            if (!canCastChaosEmeralds && chaosEmeraldTimer >= 0.0f)
            {
                chaosEmeraldTimer -= Time.deltaTime;
            }
            if (chaosEmeraldTimer <= 0.0f)
            {
                circleCollider.radius = 0.2f;

                canCastChaosEmeralds = true;
            }

            if (!canCastSpinDash && spinDashTimer >= 0.0f)
            {
                spinDashTimer -= Time.deltaTime;
            }


            if (spinDashTimer <= 0.0f)
            {
				canCastSpinDash = true;
				boxColliders[1].enabled = true;
            }
        }

        //End Disable Input Zone

        if(Application.loadedLevel == 5)
        {
            if ((Input.GetAxis("Execute") != 0 || Input.GetKeyDown(KeyCode.X)))
            {
                if (canExecuteSasuke && !isExecutingSasuke)
                {
                    currentCharacter = 1;
                    anim.SetBool("isExecuting", true);
                    Vector3 newExecutePosition = sasuke.transform.position;

                    if (transform.localScale.x == 1)
                    {
                        newExecutePosition += new Vector3(-3.26f, 0.0f, 0.0f);
                    }
                    else if (transform.localScale.x == -1)
                    {
                        newExecutePosition += new Vector3(3.26f, 0.0f, 0.0f);
                    }

                    transform.position = newExecutePosition;
                    sasuke.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    sasuke.GetComponent<SpriteRenderer>().sprite = sasukePain;
                    anim.Play("itachi_Execute");
                    executeSasukeSFX.Play();
                    sasuke.sasukeExecuteSFX.Play();
                    executeSasukeAnimTimer = 3.2f;
                    canExecuteSasuke = false;
                    isExecutingSasuke = true;
                }
            }

            if (canExecuteSasuke == false && isExecutingSasuke == false)
            {
                executeSasukeAnimTimer = 3.2f;
            }

            if (executeSasukeAnimTimer >= 0.0f && isExecutingSasuke)
            {
                executeSasukeAnimTimer -= Time.deltaTime;
            }

            if (executeSasukeTimer >= 0.0f && sasuke.GetComponent<SpriteRenderer>().sprite == sasukeDead)
            {

                executeSasukeTimer -= Time.deltaTime;
            }

            if (executeSasukeAnimTimer <= 0.0f)
            {
                anim.SetBool("isExecuting", false);
                isExecutingSasuke = false;
                sasuke.GetComponent<SpriteRenderer>().sprite = sasukeDead;
                sasuke.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                sasuke.GetComponent<BoxCollider2D>().enabled = false;
                sasuke.GetComponent<CircleCollider2D>().enabled = false;
                if (!once)
                {
                    executeSasukeTimer = 2.0f;
                    //anim.Play("itachi_VictoryPost");
                    once = true;
                }


                disableInput = false;
            }

            if (executeSasukeTimer <= 0.0f && !sasukeBossFightOver)
            {
                sasukeBossFightOver = true;
                Vector3 formattedWarpPortalPos = sasuke.transform.position;
                formattedWarpPortalPos += new Vector3(0.0f, 1.5f, 0.0f);
                warpPortal.transform.position = formattedWarpPortalPos;
                Vector3 formattedWarpKeyPos = warpPortal.transform.position;
                formattedWarpKeyPos += new Vector3(-1.0f, 0.0f, 0.0f);
                warpKey.transform.position = formattedWarpKeyPos;
                ////sasukeHP.gameObject.SetActive(false);
                //sasukeHP.enabled = false;
                //sasuke.gameObject.SetActive(false);

            }
        }
       



        ////Update Animator Values
        if (currentCharacter == 1)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("isBlinking", isBlinking);
            anim.SetBool("isOnWall", isOnWall);

            if (blinkAnimTimer >= 0.0f)
            {
                isBlinking = true;
                anim.SetBool("isBlinking", isBlinking);
                blinkAnimTimer -= Time.deltaTime;

            }

            if (blinkAnimTimer <= 0.0f)
            {
                isBlinking = false;
                anim.SetBool("isBlinking", isBlinking);
            }

        }
        else if (currentCharacter == 2)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
            anim.SetBool("isGrounded", isGrounded);

            if (blastAnimTimer >= 0.0f)
            {
                anim.SetBool("castMissle", true);
                blastAnimTimer -= Time.deltaTime;

            }

            if (blastAnimTimer <= 0.0f)
            {
                anim.SetBool("castMissle", false);
            }
        }
        else if (currentCharacter == 3)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
            anim.SetBool("isGrounded", isGrounded);

            if (backFlipAnimTimer >= 0.0f)
            {
                isBackFlipping = true;
                anim.SetBool("isBackflipping", isBackFlipping);
                backFlipAnimTimer -= Time.deltaTime;

            }

            if (backFlipAnimTimer <= 0.0f)
            {
                isBackFlipping = false;
                anim.SetBool("isBackflipping", isBackFlipping);
            }

            if (chaosEmeraldsAnimTimer >= 0.0f)
            {
                chaosEmeraldsAnimTimer -= Time.deltaTime;
                anim.SetBool("isGoingSuper", true);
            }

            if (chaosEmeraldsAnimTimer <= 0.0f)
            {
                isGoingSuper = false;
                anim.SetBool("isGoingSuper", false);

            }

            if (spinDashAnimTimer >= 0.0f)
            {
                spinDashAnimTimer -= Time.deltaTime;
                anim.SetBool("isSpinDashing", true);
            }

            if (spinDashAnimTimer <= 0.0f)
            {
                anim.SetBool("isSpinDashing", false);
                isSpinDashing = false;
                disableInput = false;
                anim.SetBool("isSpinDashing", false);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Projectile")
        {
            switch(currentCharacter)
            {
                case 1:
                    {
                        itachiHurtSFX.Play();
                        break;
                    }
                case 2:
                    {
                        cyborgHurtSFX.Play();
                        break;
                    }
                case 3:
                    {
                        if(!isGoingSuper && !isBackFlipping && !isSpinDashing)
                        {
                            sonicHurtSFX.Play();
                        }
                        else
                        {
                            //Do Nothing
                        }
                        break;
                    }
            }
            
        }

        if (other.tag == "Enemy" && isBackFlipping)
        {
            other.GetComponent<EnemyHealthManager>().takeDamage(backFlipDamage);
			if(other.GetComponent<EnemyMovement>())
			{
				eMScrp = other.GetComponent<EnemyMovement>();
				eMScrp.GetStun(shortStun);
			}
			if( other.GetComponent<EnemyAttack>())
			{
				eAScrp = other.GetComponent<EnemyAttack>();
				eAScrp.GetStun(shortStun);
			}
			if (other.transform.position.x < transform.position.x) 
			{
				other.attachedRigidbody.velocity = new Vector2 (-4, 2); 
			} 
			else
			{
				other.attachedRigidbody.velocity = new Vector2 (4, 2); 
			}
        }

        if(other.tag == "Enemy" && isGoingSuper)
        {
            other.GetComponent<EnemyHealthManager>().enemyHP = 0;
        }

        if(other.tag == "Enemy" && isSpinDashing)
        {
            other.GetComponent<EnemyHealthManager>().takeDamage(spinDashDamage);
			if(other.GetComponent<EnemyMovement>())
			{
				eMScrp = other.GetComponent<EnemyMovement>();
				eMScrp.GetStun(shortStun);
			}
			if( other.GetComponent<EnemyAttack>())
			{
				eAScrp = other.GetComponent<EnemyAttack>();
				eAScrp.GetStun(shortStun);
			}
		
				other.attachedRigidbody.velocity = new Vector2 (0, 8); 
			
        }


        if(other.tag == "Obstacle" && isSpinDashing)
        {
                disableInput = false;
                isSpinDashing = false;
                rb2D.velocity = new Vector2(0.0f, rb2D.velocity.y);           
        }

    }

    //public void WallSlide()
    //{
    //    rb2D.velocity = new Vector2(rb2D.velocity.x, 0.7f);
    //    wallSliding = true;

    //    if(Input.GetButtonDown("Jump"))
    //    {
    //        if(transform.localScale.x > 0)
    //        {
    //            rb2D.AddForce(new Vector2(-2.0f, 5.0f) * jumpHeight);
    //        }
    //        else
    //        {
    //            rb2D.AddForce(new Vector2(2.0f, 5.0f) * jumpHeight);
    //        }
    //    }
    //}

    //public void GrabWall()
    //{
    //    isOnWall = true;
    //    rb2D.gravityScale = 0.0f;
    //    rb2D.drag = 10.0f;

    //}

    //public void ReleaseWall()
    //{
    //    if (rb2D.gravityScale != defaultGravityScale)
    //    {
    //        rb2D.gravityScale = defaultGravityScale;
    //        rb2D.drag = defaultDrag;
    //        isOnWall = false;
    //    }
    //}

    void OnTriggerExit2D(Collider2D other)
    {
        
    }


    void SpinDashMove()
    {
        if(transform.localScale.x >= 0.0f)
        {
            rb2D.velocity = new Vector3(spinDashSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector3(-spinDashSpeed, rb2D.velocity.y);
        }
    }

    void SpinDashEnd()
    {
        
        //Debug.Log("HIt");
    }

   

    //Blink Helper Function
    public IEnumerator makeBlinkParticle()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(blinkParticle, rb2D.transform.position, rb2D.transform.rotation);
    }

    
}