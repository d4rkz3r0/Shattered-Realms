using UnityEngine;
using UnityEngine.UI;
//using XInputDotNetPure;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    //Can be accessed from anywhere (be careful)
    public static int playerHP;
    public bool isPlayerDead;

    //Public Inspector Variables
    public int playerStartingHP;
    private int levelStartHP;
    private int playerMaxHP;

    //Dynamic HP Bar
    public Sprite[] hpBarSheet;
    private Image currHPBarImage;

    //Private References
    private LevelManager levelManager;
    private AudioSource playerDeathSFX;
    private AudioSource lowHPMusic;
    private bool lowBGMHasPlayed;
	public static float DamageTakenTimer;
	public Color tempColor;


    //Player Feedback for damage
    //Gamepad Rumble
    //bool playerIndexSet = false;
    //static PlayerIndex playerIndex;
    //static GamePadState state;
    //GamePadState prevState;

    private static float damageVibrationTimer;
    //private static float damageVibrationDuration = 0.5f;

    //Visual Feedback
    private float healthStatusRatio;
    private Color lowHPColor;
    private Color fullHPColor;
    //private Color fullHPBarColor;
    //Player Sprite Tinting
    private SpriteRenderer playerSprite;
    private Color currPlayerSpriteColor;

    //Player HP Bar Sprite Tinting
    private Image hpBarSprite;
    private Color currHPBarSpriteColor;
    
    


    void Awake()
    {


    }

    void Start () 
    {
		DamageTakenTimer = 0.0f;
        lowBGMHasPlayed = false;
        //Pull Player Info
        playerMaxHP = PlayerPrefs.GetInt("PlayerMaxHP");
        lowHPMusic = GameObject.Find("Low HP SFX").GetComponent<AudioSource>();
        //Auto Hook
        levelManager = FindObjectOfType<LevelManager>();
        playerDeathSFX = GetComponent<AudioSource>();
        currHPBarImage = GetComponent<Image>();

        //Sprite Tinting
        lowHPColor = Color.red;
        fullHPColor = Color.white; //Full Alpha
        //fullHPBarColor = Color.green;
        playerSprite = FindObjectOfType<MasterController>().GetComponent<SpriteRenderer>();
        hpBarSprite = GetComponent<Image>();

        //Initial Player Spawn
        playerHP = 10;
            playerMaxHP = 10;
        isPlayerDead = false;
	}

    void Update()
    {

        //Visual Feedback Update
        healthStatusRatio = (float)playerHP / (float)playerMaxHP;
        //Player Sprite
        currPlayerSpriteColor = Color.Lerp(lowHPColor, fullHPColor, healthStatusRatio);
        playerSprite.color = currPlayerSpriteColor;
        //HP Bar Sprite
        currHPBarSpriteColor = Color.Lerp(lowHPColor, fullHPColor, healthStatusRatio);
        hpBarSprite.color = currHPBarSpriteColor;


		//This block of code makes it so that the players hpbar goes 100% transparency if hit 
		//and 50% transparency after 5 seconds if not hit.
		tempColor = gameObject.GetComponent<Image> ().color;
		DamageTakenTimer -= Time.deltaTime;
		if (DamageTakenTimer > 0.0f) {
			tempColor.a = 1.0f;
			gameObject.GetComponent<Image> ().color = tempColor;
			//hpBarSprite.color.a = tempColor;
		} else {
			tempColor.a = 0.25f;
			gameObject.GetComponent<Image> ().color = tempColor;
		}

        if(damageVibrationTimer >= 0.0f)
        {
            damageVibrationTimer -= Time.deltaTime;
        }

        //if(damageVibrationTimer <= 0.0f)
        //{
        //    GamePad.SetVibration(playerIndex, 0.0f, 0.0f);
        //}

        //if (!playerIndexSet || !prevState.IsConnected)
        //{
        //    for (int i = 0; i < 4; ++i)
        //    {
        //        PlayerIndex testPlayerIndex = (PlayerIndex)i;
        //        GamePadState testState = GamePad.GetState(testPlayerIndex);
        //        if (testState.IsConnected)
        //        {
        //            //Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
        //            playerIndex = testPlayerIndex;
        //            playerIndexSet = true;
        //        }
        //    }
        //}
        //prevState = state;
        //state = GamePad.GetState(playerIndex);

        //if(playerMaxHP <= 3)
        //{
        //    sprite.color = lowHPColor;
        //}

        //Constant Updating
        if (playerHP <= 0)
        {
            
            playerHP = 0;
        }

        if (playerHP <= 0 && !isPlayerDead)
        {
            playerHP = 0;
            lowHPMusic.Stop();
            lowBGMHasPlayed = false;
            playerDeathSFX.Play();
            
            levelManager.RespawnPlayer();
            isPlayerDead = true;
        }

        if (playerHP >= playerMaxHP)
        {
            playerHP = playerMaxHP;
        }

        if(playerHP < 4 && playerHP > 0 )
        {
            if (!lowBGMHasPlayed)
            {
                //AudioManager.currAudio.Stop();
                lowHPMusic.Play();
                lowBGMHasPlayed = true;
                
            }
        }
        if(playerHP > 3 && lowBGMHasPlayed)
        {
            lowHPMusic.Stop();
            //AudioManager.currAudio.Play();
            lowBGMHasPlayed = false;
            
        }

        if(playerMaxHP > 5)
        {
            switch (playerHP)
            {
                case 10:
                    {
                        currHPBarImage.sprite = hpBarSheet[0];						
                        break;
                    }
                case 9:
                    {
                        currHPBarImage.sprite = hpBarSheet[1];
                        break;
                    }
                case 8:
                    {
                        currHPBarImage.sprite = hpBarSheet[2];
                        break;
                    }
                case 7:
                    {
                        currHPBarImage.sprite = hpBarSheet[3];
                        break;
                    }
                case 6:
                    {
                        currHPBarImage.sprite = hpBarSheet[4];
                        break;
                    }
                case 5:
                    {
                        currHPBarImage.sprite = hpBarSheet[5];
                        break;
                    }
                case 4:
                    {
                        currHPBarImage.sprite = hpBarSheet[6];
                        break;
                    }
                case 3:
                    {
                        currHPBarImage.sprite = hpBarSheet[7];
                        break;
                    }
                case 2:
                    {
                        currHPBarImage.sprite = hpBarSheet[8];
                        break;
                    }
                case 1:
                    {
                        currHPBarImage.sprite = hpBarSheet[9];
                        break;
                    }
                case 0:
                    {
                        currHPBarImage.sprite = hpBarSheet[10];
                        break;
                    }
                default:
                    {
                        //Empty Bar
                        currHPBarImage.sprite = hpBarSheet[10];
                        break;
                    }
            }
        }
        else if(playerMaxHP <= 5)
        {
            switch (playerHP)
            {
                case 5:
                    {
                        currHPBarImage.sprite = hpBarSheet[0];
                        break;
                    }
                case 4:
                    {
                        currHPBarImage.sprite = hpBarSheet[2];
                        break;
                    }
                case 3:
                    {
                        currHPBarImage.sprite = hpBarSheet[4];
                        break;
                    }
                case 2:
                    {
                        currHPBarImage.sprite = hpBarSheet[6];
                        break;
                    }
                case 1:
                    {
                        currHPBarImage.sprite = hpBarSheet[8];
                        break;
                    }
                case 0:
                    {
                        currHPBarImage.sprite = hpBarSheet[10];
                        break;
                    }
                default:
                    {
                        //Empty Bar
                        currHPBarImage.sprite = hpBarSheet[10];
                        break;
                    }
            }
        }
    }

    public static void FlashSprite()
    {
        //HealthManager.FlashSprites(sprites, 5, 0.05f);
    }

      //Player flash on hit
    public static IEnumerator FlashSprites(SpriteRenderer[] sprites, int numTimes, float delay, bool disable = false)
    {
        // number of times to loop
        for (int loop = 0; loop < numTimes; loop++)
        {
            // cycle through all sprites
            for (int i = 0; i < sprites.Length; i++)
            {
                if (disable)
                {
                    // for disabling
                    sprites[i].enabled = false;
                }
                else
                {
                    // for changing the alpha
                    sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 0.5f);
                }
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);

            // cycle through all sprites
            for (int i = 0; i < sprites.Length; i++)
            {
                if (disable)
                {
                    // for disabling
                    sprites[i].enabled = true;
                }
                else
                {
                    // for changing the alpha
                    sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1);
                }
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);
        }
    }

    public static void takeDamage(int damageReceived)
    {
        //damageVibrationTimer = damageVibrationDuration;
        //GamePad.SetVibration(playerIndex, 0.25f, 1.0f);
        ////fakePlayer.StartCoroutine("FlashPlayerCoRoutine");
        

        
        //Death Value
        playerHP -= damageReceived;
		DamageTakenTimer = 5.0f;
    }

    //public IEnumerator FlashPlayerCoRoutine()
    //{
    //    ////Hit by projectile
    //    //for (int i = 0; i < sprites.Length; i++)
    //    //{
    //    //    sprites[i].color = Color.red;
    //    //    yield return new WaitForSeconds(0.5f);
    //    //    sprites[i].color = Color.red;

    //    //}
    //}

    public static void receiveHealing(int healingAmount)
    {
        
        playerHP += healingAmount;
    }

    public static void respawnRumbleStart()
    {
        //damageVibrationTimer = 1.0f;
        //GamePad.SetVibration(playerIndex, 1.0f, 1.0f);
    }


    public void MaxHealthRestore()
    {
        playerHP = playerMaxHP;
    }

    public static void DepleteHealth()
    {
        playerHP = 0;
    }

   
}
