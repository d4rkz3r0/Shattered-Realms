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

	void Start () 
    {
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
            
            Instantiate(deathParticle, transform.position, transform.rotation);
            XPManager.AddToEarnedXPThisLevel(xpOnDeath);
            Destroy(gameObject);
        }
	}

    public void takeDamage(int damageReceived)
    {
        enemyHP -= damageReceived;
        enemyHurtSFX.Play();
    }

    
}
