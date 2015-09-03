using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyHP;
    public int xpOnDeath;
    public GameObject deathParticle;
    private AudioSource enemyHurtSFX;
    public int EnemyMaxHP;
    public bool isDead;
    public bool deathAnimation;

    //Enemy Respawning
    public GameObject EnemyPrefab;
    public bool isRespawnable;

    private Vector3 lastPosition;
    private LevelManager LM;
    private MasterController player;

	void Start () 
    {
        deathAnimation = false;
        player = FindObjectOfType<MasterController>();
        LM = FindObjectOfType<LevelManager>();
        isDead = false;
        EnemyMaxHP = enemyHP;
        enemyHurtSFX = GetComponent<AudioSource>();
        
	}
	

	void Update () 
    {

        if(enemyHP <= 0)
        {
            isDead = true;
        }

	    if(isDead)
        {
            if(Application.loadedLevel == 11)
            {
                player.gizmoBossFightOver = true;
                Instantiate(deathParticle, transform.position, transform.rotation);
                XPManager.AddToEarnedXPThisLevel(xpOnDeath);
            }
            else
            {
                if(GetComponent<Animator>() != null)
                {
                    deathAnimation = true;
                    XPManager.AddToEarnedXPThisLevel(xpOnDeath);
                    return;
                }
                else
                {
                    Instantiate(deathParticle, transform.position, transform.rotation);
                    XPManager.AddToEarnedXPThisLevel(xpOnDeath);
                    Destroy(gameObject);
                }
                
            }
            
        }
	}

    public void takeDamage(int damageReceived)
    {
        enemyHP -= damageReceived;
        enemyHurtSFX.Play();
    }

    public IEnumerator RespawnSelf()
    {
        for (int i = 0; i < LM.enemyPositionArray.Length; i++)
        {
            if (LM.enemyPositionArray[i] == new Vector3(0.0f, 0.0f, 0.0f))
            {
                LM.enemyPositionArray[i] = transform.position;
                break;
            }
        }
           
        Destroy(gameObject);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RespawnSelf();
        //if(other.tag == "Player")
        //{
        //    LM.RespawnEnemies();
        //}
    }

    
}
