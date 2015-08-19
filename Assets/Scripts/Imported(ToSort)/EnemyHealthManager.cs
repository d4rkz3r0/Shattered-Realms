using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyHP;
    public int xpOnDeath;
    public GameObject deathParticle;
    private AudioSource enemyHurtSFX;
    public int EnemyMaxHP;

	void Start () 
    {
        EnemyMaxHP = enemyHP;
        enemyHurtSFX = GetComponent<AudioSource>();
	}
	

	void Update () 
    {

	    if(enemyHP <= 0)
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
