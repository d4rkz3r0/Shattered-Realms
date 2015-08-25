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

    private MasterController player;

	void Start () 
    {
        deathAnimation = false;
        player = FindObjectOfType<MasterController>();
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
            if(Application.loadedLevel == 8)
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

    
}
