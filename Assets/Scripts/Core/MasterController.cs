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
	private float idleTimer;

	public GameObject damAnim;

	private BoxCollider2D[] groundWallC;

	//Wall Climbing
	private bool playerWantsToWallClimb;
	private bool canWallClimb;

	private bool wallClimbing;
	private float wallClimbingTimer;

	private float afterClimbEffTimer;
	private bool afterClimbEffing;

	private bool wallIsToTheRight;

	public float itachiWallClimbSpeed;
	public float cyborgWallClimbSpeed;
	public float sonicWallClimbSpeed;

	//private bool wallQuaking;
	//private WallClimbingCheck wallCheck;


    //Movement Abilities
    public bool stunned;
    public float jumpHeight;
    public int numOfJumps;
    private int jumpsRemaining;
    public float moveSpeed;
   
    private float defaultGravityScale;
    private float stunTimer;
    
    //private float defaultDrag;
    

    //Collision Detection
    public Transform groundCheckTransform;
    public Transform wallCheckTransform;
    public Transform playerCenterPoint;
    public LayerMask groundCheckLayer;
    public LayerMask enemyCheckLayer;
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
	public AudioSource springSFX;
    
    //Player and Character Animation Abilities
    private Animation blastProjectileAnimation;
    private float blastAnimTimer = 0.45f; //Must Match ability cooldown!
    public bool isGrounded;
    public bool hasTouchedEnemy;
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

	//Tsukuyomi
	public GameObject daTsuku;
	private GameObject privTsu;
	public float tsukuyomiCoolDown;
	private float tsukuyomiTimer;
	private bool canCastTsukuyomi;

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
	public bool isCharging;
    public bool canCastCharge;
	public GameObject charge;
	public float chargingDuration;
	public float chargeRunningSpeed;
	private GameObject actualCharge;
	public float chargeSize;

	//Quake
	public float quakeCoolDown;
	private float quakeTimer;
	public bool isQuaking;
	public bool canCastQuake;
	public GameObject theQuake;
	private GameObject actualQuake;
	public float quakeSize;

	//Lightning
	public float lightningCoolDown;
	private float lightningTimer;
	private bool canCastLightning;
	public GameObject theLightning;
	private GameObject actualLightning;
	private LightningController lC;


    //Sonic
	//Knocking Back Enemies
	private EnemyMovement eMScrp;
	private EnemyAttack eAScrp;
	public float shortStun;
    public int sonicJumpDamage;

    //Q - Back Flip
    public float backFlipCoolDown;
    public int backFlipDamage;
    private float backFlipTimer;
    private bool canCastBackFlip;
    private float backFlipAnimTimer; //Must Match ability cooldown!
    public bool isBackFlipping;
	private float bfHitCD;
    
    //W - Chaos Emeralds
    public float chaosEmeraldCoolDown;
    private float chaosEmeraldTimer;
    private bool canCastChaosEmeralds;
    private float chaosEmeraldsAnimTimer; //Must Match ability cooldown!
    public bool isGoingSuper;

	//E - Spring
	public float springCoolDown;
	public int springDamage;
	private float springTimer;
	private bool canCastSpring;
	public bool isSpringing;
	public float springSpeed;
	private SpriteRenderer spRender;
	//private float springAnimTimer; //Must Match ability cooldown!

    //R - Spin Dash
    public float spinDashSpeed;
    public float spinDashCoolDown;
    public int spinDashDamage;
    private float spinDashTimer;
    private bool canCastSpinDash;
    private float spinDashAnimTimer;
    public bool isSpinDashing;
    public bool disableInput;
    
    
	//Sasuke 
    public Sprite sasukePain;
    public Sprite sasukeDead;
    public bool canExecuteSasuke;
    public bool isExecutingSasuke;
    public bool once;
    public bool sasukeBossFightOver;
    public float executeSasukeTimer;
    private float executeSasukeAnimTimer;


    //Gizmo
    private GameObject gizmo;
    public bool gizmoBossFightOver;


    ////Private References
    private Rigidbody2D rb2D;
    private Animator anim;
    private HealthManager healthManager;
    private SasukeController sasuke;
    private PortalController warpPortal;
    private KeyPickup warpKey;
    private BossHealthManager sasukeHP;
    //private PauseOverlay PauseMenu;


    


    void Start()
    { 


        hasTouchedEnemy = false;
		groundWallC = GetComponentsInChildren<BoxCollider2D> ();
		afterClimbEffing = false;
	//	wallCheck = GetComponentInChildren<WallClimbingCheck> ();
		wallClimbing = false;
        releaseControl = false;
		//Debug.Log("1");
        disableInput = false;
        canExecuteSasuke = false;
        isExecutingSasuke = false;
        once = false;
        //aboutToCastFireball = false;
        levelUpAnimTimer = 0.0f;
		wallClimbingTimer = 0.0F;
        playedOnce = false;
        stunned = false;
		//wallQuaking = false;
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
		spRender = GetComponent<SpriteRenderer> ();
        //PauseMenu = FindObjectOfType<PauseOverlay>();

        //defaultDrag = rb2D.drag;

        if(Application.loadedLevel == 9)
        {
            executeSasukeTimer = 2.0f;
            sasukeBossFightOver = false;
            sasuke = FindObjectOfType<SasukeController>();
        }

        if(Application.loadedLevel == 12)
        {
            gizmoBossFightOver = false;
            gizmo = GameObject.Find("Gizmo");
        }

        switch(currentCharacter)
        {
            case 1:
                {
            //       boxColliders[0].offset = new Vector2(0.0f, 0.05f);
            //       circleCollider.offset = new Vector2(0.0f, -0.83f);
                    anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    
                    break;
                }
            case 2:
                {
//	boxColliders[0].offset = new Vector2(0.0f, 0.05f);
  //             circleCollider.offset = new Vector2(0.0f, -0.83f);
                    anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    break;
                }
            case 3:
                {
//            boxColliders[0].offset = new Vector2(0.0f, 0.05f);
 //           circleCollider.offset = new Vector2(0.0f, -0.56f);
 //           transform.position = new Vector3(transform.position.x, transform.position.y - 0.26992f, transform.position.z);
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
		canCastSpring = true;
		canCastTsukuyomi = true;
		canCastLightning = true;

        //Local Player Ability Animation
        isBlinking = false;
        isBackFlipping = false;
        isGoingSuper = false;
        isSpinDashing = false;
		isSpringing = false;
    }

    void FixedUpdate()
    {
        //Player Collision
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheckTransform.position, wallCheckRadius, wallCheckLayer);
        hasTouchedEnemy = Physics2D.OverlapCircle(groundCheckTransform.position, 2.0f, enemyCheckLayer);

    }

    void Update() 
    {
		//Wall Climbing Update
		if(Input.GetAxis("WallRun") != 0 || Input.GetButton("WallRunKeyboard")){
			playerWantsToWallClimb = true;
		}
		else{
			playerWantsToWallClimb = false;
		} 

		if (!playerWantsToWallClimb && wallClimbing) {
			FromClimbingToAfterClimb();
		}

		if (wallClimbing) {
			wallClimbingTimer += Time.deltaTime;
			switch(currentCharacter)
			{
			case 1:
				rb2D.velocity = new Vector2(0,itachiWallClimbSpeed);
				if(wallClimbingTimer > 0.5f){
					FromClimbingToAfterClimb();
				}
				break;
			case 2:
				rb2D.velocity = new Vector2(0,1);
				if(wallClimbingTimer > 0.2f){
					FromClimbingToAfterClimb();
				}
				break;
			case 3:
				rb2D.velocity = new Vector2(0,1);
				if(wallClimbingTimer > 0.2f){
					FromClimbingToAfterClimb();
				}
				break;
			}
		}
		else if (afterClimbEffing) {
			Debug.Log("frames after climbing");
			afterClimbEffTimer += Time.deltaTime;
			switch(currentCharacter)
			{
			case 1:
				if(afterClimbEffTimer > 0.3f){
					FromAfterClimbToNormal();
				}
				break;
			case 2:
				if(afterClimbEffTimer > 0.8f){
					FromAfterClimbToNormal();
				}
				break;
			case 3:
				if(afterClimbEffTimer > 0.5f){
					FromAfterClimbToNormal();
				}
				break;
			}
		}




		if (currentCharacter == 3) {
			groundWallC[2].offset = new Vector2 (-0.05f,0.24f);
		}
		else{
			groundWallC[2].offset = new Vector2 (-0.05f,-0.028f);
		}

		if (isBackFlipping) {
			bfHitCD -= Time.deltaTime;
		}

		if (Application.loadedLevel == 9) {
			sasukeHP = FindObjectOfType<BossHealthManager> ();
		}

		//BETTER EMERGENCY FAILSAFE
		if (spinDashAnimTimer <= 0 && !FindObjectOfType<ChatBoxController>() && !wallClimbing && !afterClimbEffing) 
        {
			isSpinDashing = false;
			disableInput = false;
		}

		//EMERGENCY FAILSAFE
		//if (disableInput) 
        //{
		//	idleTimer += Time.deltaTime;
		//	if (idleTimer > 3)
        //    {
        //        if(Application.loadedLevel != 9)
        //        {
        //            disableInput = false;
        //        }				
		//	}
		//} 
		//else {
		//	idleTimer = 0;
		//}


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

            //Straight Selection
            if(Input.GetButtonDown("Char1") && currentCharacter != 1)
            {
                currentCharacter = 1;
                boxColliders[1].offset = new Vector2(0.0f, 0);
                boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
                circleCollider.offset = new Vector2(0.0f, -0.83f);
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.26992f, transform.position.z);
                anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
            }

            if (Input.GetButtonDown("Char2") && currentCharacter != 2)
            {
                currentCharacter = 2;
                boxColliders[1].offset = new Vector2(0.0f, 0);
                boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
                circleCollider.offset = new Vector2(0.0f, -0.83f);
                anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
            }

            if (Input.GetButtonDown("Char3") && currentCharacter != 3)
            {
                currentCharacter = 3;
                boxColliders[0].offset = new Vector2(0.0f, 0.61127716f / 2);
                circleCollider.offset = new Vector2(0.0f, -0.56f);
                boxColliders[1].offset = new Vector2(0.0f, 0.56f / 2);
                anim.runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
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
					//boxColliders[0].size = new Vector2(boxColliders[0].size.x, 1.86f);
					boxColliders[1].offset = new Vector2(0.0f, 0);
					boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
					circleCollider.offset = new Vector2(0.0f, -0.83f);
                            anim.runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                            break;
                        }
                    case 2:
                        {
                            currentCharacter = 3;
					boxColliders[0].offset = new Vector2(0.0f, 0.61127716f/2);
					circleCollider.offset = new Vector2(0.0f, -0.56f);
					boxColliders[1].offset = new Vector2(0.0f, 0.56f/2);
                            anim.runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                            break;
                        }
                    case 3:
                        {
                            currentCharacter = 1;
					//boxColliders[0].size = new Vector2(boxColliders[0].size.x, 1.86f);
					boxColliders[1].offset = new Vector2(0.0f, 0);
					boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
					circleCollider.offset = new Vector2(0.0f, -0.83f);
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
					boxColliders[0].offset = new Vector2(0.0f, 0.61127716f/2);
               circleCollider.offset = new Vector2(0.0f, -0.56f);
					boxColliders[1].offset = new Vector2(0.0f, 0.56f/2);
                            anim.runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                            break;
                        }
                    case 2:
                        {
					currentCharacter = 1;
	//boxColliders[0].size = new Vector2(boxColliders[0].size.x, 1.86f);
					boxColliders[1].offset = new Vector2(0.0f, 0);
	boxColliders[0].offset = new Vector2(0.0f, 0.05127716f);
               circleCollider.offset = new Vector2(0.0f, -0.83f);

                            anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                            break;
                        }
                    case 3:
                        {
                            currentCharacter = 2;
					boxColliders[1].offset = new Vector2(0.0f, 0);
	//boxColliders[0].size = new Vector2(boxColliders[0].size.x, 1.86f);
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

            ////E - Tsukuyomi Guard Ability with CoolDown
			if ((Input.GetButtonDown("Fire3")) && (currentCharacter == 1))
			{
				if (canCastTsukuyomi)
				{
					privTsu = Instantiate(daTsuku);
					canCastTsukuyomi = false;
					tsukuyomiTimer = tsukuyomiCoolDown;
				}
			}

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
                if (isGrounded || hasTouchedEnemy)
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
            }
			//// Lightning
			if ((Input.GetButtonDown("Fire3")) && (currentCharacter == 2))
			{
				if (canCastLightning)
				{
					actualLightning = Instantiate(theLightning);
					lC = actualLightning.GetComponent<LightningController>();
					lC.isInitial = true;
					actualLightning.transform.position = transform.position;
					canCastLightning = false;
					lightningTimer = lightningCoolDown;
				}  
			}

            ////Sonic
            ////Q - BackFlip Ability with Ability CoolDown
            if (Input.GetButtonDown("Fire1") && (currentCharacter == 3))
            {
                if (canCastBackFlip)
                {
					bfHitCD = 0;
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
                    chaosEmeraldsAnimTimer = 3;
                    isGoingSuper = true;

                    canCastChaosEmeralds = false;
                    chaosEmeraldTimer = chaosEmeraldCoolDown;
                }
            }

			////E - SpringActivate Ability with Ability CoolDown
			if (Input.GetButtonDown("Fire3") && (currentCharacter == 3))
			{
				if (canCastSpring)
				{
					springSFX.Play();
					rb2D.velocity = new Vector2(0,springSpeed);
					spRender.color = Color.yellow;
					isSpringing = true;			
					canCastSpring = false;
					springTimer = springCoolDown;
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
					disableInput = true;
                    canCastSpinDash = false;
                    spinDashTimer = spinDashCoolDown;
                }
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

			if(privTsu){
				privTsu.transform.position = transform.position;
			}
			
			if (!canCastTsukuyomi && tsukuyomiTimer >= 0.0f)
			{
				tsukuyomiTimer -= Time.deltaTime;
			}
			if (tsukuyomiTimer <= 0.0f)
			{
				canCastTsukuyomi = true;
				tsukuyomiTimer = tsukuyomiCoolDown;
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
			if (!canCastLightning && lightningTimer >= 0.0f)
			{
				lightningTimer -= Time.deltaTime;
			}
			if (lightningTimer <= 0.0f)
			{
				canCastLightning = true;
			}

            //Sonic
			if(currentCharacter == 3){
            if (!canCastBackFlip && backFlipTimer >= 0.0f)
            {
                backFlipTimer -= Time.deltaTime;
            }
            if (backFlipTimer <= 0.0f)
            {
                {
//		boxColliders[0].offset = new Vector2(0.0f, 0.45f);
//			boxColliders[0].size = new Vector2(boxColliders[0].size.x, 1.45f);
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

			if (!canCastSpring && springTimer >= 0.0f)
			{
				springTimer -= Time.deltaTime;
			}
			if (springTimer <= 0.0f)
			{
				canCastSpring = true;
			}
			if(rb2D.velocity.y < 0){
				isSpringing = false;
				spRender.color = Color.white;

			}

            if (!canCastSpinDash && spinDashTimer >= 0.0f)
            {
                spinDashTimer -= Time.deltaTime;
            }
            if (spinDashTimer <= 0.0f)
            {
					isSpinDashing = false;
					disableInput = false;
				canCastSpinDash = true;
            }
			}
        }

        //End Disable Input Zone

        //N - Skip Level (Debugging)
        if (Input.GetKeyDown(KeyCode.N))
        {
            warpKey.isPickedUp = true;
            transform.position = warpPortal.transform.position;
        }

        if(Application.loadedLevel == 9)
        {
            if ((Input.GetAxis("Execute") != 0 || Input.GetKeyDown(KeyCode.X)))
            {
                currentCharacter = 1;
                sasuke.GetComponent<BoxCollider2D>().enabled = true;
                //sasuke.GetComponent<CircleCollider2D>().radius = 0.5f;

                if (canExecuteSasuke && !isExecutingSasuke)
                {
                    currentCharacter = 1;
                    boxColliders[0].offset = new Vector2(0.0f, 0.05f);
                    circleCollider.offset = new Vector2(0.0f, -0.83f);
                    anim.runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;

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
                    sasuke.sasukeExecuteSFX.Play();
                    executeSasukeAnimTimer = 3.2f;
                    canExecuteSasuke = false;
                    isExecutingSasuke = true;
                    sasuke.GetComponent<BoxCollider2D>().enabled = false;
                    //sasuke.GetComponent<CircleCollider2D>().enabled = false;
                    //sasuke.GetComponent<EnemyAnimation>().enabled = false;
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
                

                //sasuke.GetComponent<CircleCollider2D>().enabled = true;
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
                sasuke.gameObject.SetActive(false);
            }
        }

        //WARNING: FIX THIS SPAGHETTI, Interdependent code module: EnemyHealthManager.cs!
        if(Application.loadedLevel == 12)
        {
            if (gizmoBossFightOver)
            {
                Debug.Log("Not here");
                gizmoBossFightOver = false;
                Vector3 formattedWarpPortalPos = gizmo.transform.position;
                formattedWarpPortalPos += new Vector3(0.0f, 1.5f, 0.0f);
                warpPortal.transform.position = formattedWarpPortalPos;
                Vector3 formattedWarpKeyPos = warpPortal.transform.position;
                formattedWarpKeyPos += new Vector3(-1.0f, 0.0f, 0.0f);
                warpKey.transform.position = formattedWarpKeyPos;
                Destroy(gizmo);
            }
        }
       



        ////Update Animator Values
        if (currentCharacter == 1)
        {
			anim.SetBool("wallClimbing", wallClimbing);
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
				//Debug.Log("HIIIIIIII");
				boxColliders[1].offset = new Vector2(0.0f, 0.56f/2);
				circleCollider.radius = 0.2f;
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
				boxColliders[1].enabled = true;

                isSpinDashing = false;
                if(Application.loadedLevel != 9 && isSpinDashing)
                {
					Debug.Log("5");
                    disableInput = false;
                }
                else
                {
                    if(FindObjectOfType<ChatBoxController>() != null)
                    {
                        //disableInput = true;
                    }
                }
                anim.SetBool("isSpinDashing", false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

		if (!canWallClimb && (other.tag == "Ground" || other.tag == "Platform")) {
			if (currentCharacter == 2 && afterClimbEffing ) {
				actualQuake = Instantiate(theQuake);
				actualQuake.transform.localScale = new Vector3(quakeSize,quakeSize,1);
				actualQuake.transform.position = transform.position;
				FromAfterClimbToNormal();
			}
			FromAfterClimbToNormal();
			canWallClimb = true;
		}

        if (other.tag == "Enemy" && isBackFlipping && bfHitCD <= 0)
        {
			bfHitCD = 1;
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

		//Debug.Log("trying");
        if (other.tag == "Boss" && isBackFlipping && bfHitCD <= 0)
        {
			bfHitCD = 1;
           if (sasukeHP != null)
           {
			Debug.Log("bH FOR SHO");
            sasukeHP.takeDamage(backFlipDamage);
				if (other.transform.position.x < transform.position.x) 
				{
					other.attachedRigidbody.velocity = new Vector2 (-4, 2); 
				} 
				else
				{
					other.attachedRigidbody.velocity = new Vector2 (4, 2); 
				}
           }
           else
           {
               return;
           }

        }
		
		if (other.tag == "Enemy" && isSpringing) {
			other.GetComponent<EnemyHealthManager>().takeDamage(springDamage);
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
		}

        if(other.tag == "Enemy" && isGoingSuper && other.name != "Gizmo")
        {
            other.GetComponent<EnemyHealthManager>().enemyHP = 0;
			if( other.GetComponent<EnemyAttack>())
			{
				eAScrp = other.GetComponent<EnemyAttack>();
				eAScrp.GetStun(shortStun);
			}
		
        }

		if (other.tag == "Boss" && isSpinDashing) {
			if (sasukeHP != null)
			{
				Debug.Log("bH FOR SHO");
				sasukeHP.takeDamage(spinDashDamage);
				other.attachedRigidbody.velocity = new Vector2 (0, 8);
			}
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

        if(currentCharacter == 3 && !isGrounded)
        {
            if(other.tag == "Enemy")
            {
                other.GetComponent<EnemyHealthManager>().takeDamage(sonicJumpDamage);
            }
            if(other.tag == "Boss")
            {
                if(Application.loadedLevel == 9)
                {
                    //Sasuke Takes Dmg
                    if (GameObject.FindObjectOfType<BossHealthManager>() != null)
                    {
                        GameObject.FindObjectOfType<BossHealthManager>().takeDamage(sonicJumpDamage);
                    }
                }
                else if(Application.loadedLevel == 12)
                {
                    //Gizmo Takes Dmg
                    gizmo.GetComponent<EnemyHealthManager>().takeDamage(sonicJumpDamage);
                }
                else if (Application.loadedLevel == 15)
                {
                    //Robotnik Takes Double Dmg
                    sonicJumpDamage *= 2;
                    //robotink.GetComponent<RobotnikController>().takeDamage(sonicJumpDamage);
                }
            }
        }
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

    public void SpinDashEnd()
  {
      disableInput = false;
  }

    //Blink Helper Function
    public IEnumerator makeBlinkParticle()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(blinkParticle, rb2D.transform.position, rb2D.transform.rotation);
    }
	
    public void RechargeAbilities()
    {
        blinkTimer = 0.0f;
        tsukuyomiTimer = 0.0f;
        chaosEmeraldTimer = 0.0f;
        springTimer = 0.0f;
        spinDashTimer = 0.0f;
        quakeTimer = 0.0f;
        lightningTimer = 0.0f;
    }

    public void abilityReset()
    {
        switch(currentCharacter)
        {
            case 1:
                {

                    break;
                }
            case 2:
                {
                    break;
                }
            case 3:
                {
                    break;
                }

        }
    }

	public void FromNormalToClimbing(){
		Debug.Log("normal to climb");
		canWallClimb = false;
		disableInput = true;
		wallClimbing = true;
		afterClimbEffing = false;
		afterClimbEffTimer = 0;
		wallClimbingTimer = 0;
		if (wallIsToTheRight) {
			transform.eulerAngles = new Vector3 (0, 0, 90);
		} else {
			transform.eulerAngles = new Vector3(0,0,-90);
		}

	}
	public void FromClimbingToAfterClimb(){
		Debug.Log("climb to after");
		transform.eulerAngles = new Vector3(0,0,0);
		wallClimbing = false;
		afterClimbEffing = true;
		afterClimbEffTimer = 0;
		wallClimbingTimer = 0;
		switch (currentCharacter) {
		case 1:
			if(wallIsToTheRight){
				rb2D.velocity = new Vector2(-itachiWallClimbSpeed/3,itachiWallClimbSpeed);
			}else{
				rb2D.velocity = new Vector2(itachiWallClimbSpeed/3,itachiWallClimbSpeed);
			}
			break;
		case 2:
			if(wallIsToTheRight){
				rb2D.velocity = new Vector2(-cyborgWallClimbSpeed,-cyborgWallClimbSpeed);
			}else{
				rb2D.velocity = new Vector2(cyborgWallClimbSpeed,-cyborgWallClimbSpeed);
			}
			actualCharge = Instantiate(charge);
			actualCharge.transform.position = transform.position;
			actualCharge.GetComponent<Rigidbody2D>().velocity = rb2D.velocity;
			actualCharge.transform.localScale = new Vector3(chargeSize,chargeSize,1);
			break;
		case 3:
			if(wallIsToTheRight){
				rb2D.velocity = new Vector2(-sonicWallClimbSpeed,sonicWallClimbSpeed/2);
			}else{
				rb2D.velocity = new Vector2(sonicWallClimbSpeed,sonicWallClimbSpeed/2);
			}
			springSFX.Play();
			canWallClimb = true;
			break;
		}

	}
	public void FromAfterClimbToNormal(){
		Debug.Log("after to normal");
		afterClimbEffing = false;
		afterClimbEffTimer = 0;
		wallClimbingTimer = 0;
		disableInput = false;
	}

	void OnTriggerStay2D(Collider2D other){
		if (playerWantsToWallClimb && other.tag == "Wall" && canWallClimb) {
			if(other.transform.position.x > transform.position.x){
				wallIsToTheRight = true;
			}
			else{
				wallIsToTheRight = false;
			}
			
			FromNormalToClimbing();
		}

	}

}