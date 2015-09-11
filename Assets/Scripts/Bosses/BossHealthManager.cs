using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealthManager : MonoBehaviour
{
    public GameObject deathParticle;

    //Boss Stats
    public int bossHP;
    public int bossMaxHP;
    public int xpReward;
    public bool isBossDead;

    public ChatBoxController chatBoxHUDElement;
    
    //Boss Audio
    private AudioSource sasukeDefeated;

    //Boss Audio Helpers
    private bool hasPlayed;
    private float voiceClipAudioTimer;
    //private float voiceClipDuration = 2.0f;
    
    
    //Dynamic Boss HP Bar
    public Sprite[] bossHPBarSheet;
    private Image currBossHPBarImage;

    
    //Animation
    private Animation sasukeOOHPAnimation;
    private float sasukeOOHPAnimationTimer;
    private float sasukeOOHPAnimationTimerDuration = 1.0f;


    //Static Images
    public Sprite sasukeKnee;
    

    //Spaghetti
    private bool once;
    public bool warpPortalEngaged;

    //References
    private SasukeController sasuke;
    private SpriteRenderer sasukeSpriteRenderer;
    private Animator sasukeAnimator;
    private AudioSource bossHurtSFX;
    public AudioSource bossLowHPSFX;


    
    void Start()
    {
        
        //Just in case.
        if(bossHP == 0)
        {
            bossHP = 8;
        }
        isBossDead = false;

        //Visual Hooks
        currBossHPBarImage = GetComponent<Image>();
        sasukeAnimator = FindObjectOfType<SasukeController>().GetComponent<Animator>();
        sasukeSpriteRenderer = FindObjectOfType<SasukeController>().GetComponent<SpriteRenderer>();
        //Audio Hooks
        bossHurtSFX = GetComponent<AudioSource>();
        hasPlayed = false;


        //Animation Logic
        sasukeOOHPAnimationTimer = sasukeOOHPAnimationTimerDuration;

        //hack
        once = false;
        warpPortalEngaged = false;
    }


    void Update()
    {

        if (bossMaxHP == 8)
        {
            switch (bossHP)
            {
                case 8:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[0];
                        break;
                    }
                case 7:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[1];
                        break;
                    }
                case 6:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[2];
                        break;
                    }
                case 5:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[3];
                        break;
                    }
                case 4:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[4];
                        break;
                    }
                case 3:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[5];
                        break;
                    }
                case 2:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[6];
                        break;
                    }
                case 1:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[7];
                        break;
                    }
                case 0:
                    {
                        currBossHPBarImage.sprite = bossHPBarSheet[8];
                        break;
                    }
                default:
                    {
                        //Empty Bar
                        currBossHPBarImage.sprite = bossHPBarSheet[8];
                        break;
                    }
            }

            if (bossHP < 4 && bossHP > 0)
            {
                if (!hasPlayed)
                {
                    bossLowHPSFX.Play();
                    bossHP = 6;
                    hasPlayed = true;
                }
            }

            if (bossHP >= bossMaxHP)
            {
                bossHP = bossMaxHP;
            }

            if (bossHP <= 0 && !warpPortalEngaged)
            {
                bossHP = 0;
                sasukeAnimator.Play("sasuke_OOHP");
            }

            
            if (sasukeOOHPAnimationTimer >= 0.0f && bossHP == 0)
            {
                FindObjectOfType<SasukeController>().GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                sasukeOOHPAnimationTimer -= Time.deltaTime;
            }
            
            if(sasukeOOHPAnimationTimer <= 0.0f )
            {
                isBossDead = true;
            }

            if (isBossDead)
            {
                
                sasukeAnimator.enabled = false;
                
                if (!once)
                {
                   
                    FindObjectOfType<SasukeController>().canMove = false;
                    
                    sasukeSpriteRenderer.sprite = sasukeKnee;
                    MessageController.textSelection = 26;
                    chatBoxHUDElement.gameObject.SetActive(true);
                    chatBoxHUDElement.startEndBossDialogue = true;
                    once = true;
                }
                
                
            }
        
                
                




                //Instantiate(deathParticle, transform.position, transform.rotation);
                //XPManager.AddToEarnedXPThisLevel(xpReward);
                //Destroy(gameObject);
        }
    }

    public void takeDamage(int damageReceived)
    {
        bossHP -= damageReceived;
        bossHurtSFX.Play();
    }

    public void receiveHealing(int healingAmount)
    {
        bossHP += healingAmount;
    }

    public void MaxHealthRestore()
    {
        bossHP = bossMaxHP;
    }
    public void DepleteHealth()
    {
        bossHP = 0;
    }
}
