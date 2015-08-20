using UnityEngine;
using System.Collections;

public class BossHealthManager : MonoBehaviour
{
    public int bossHP;
    public int xpReward;
    public GameObject deathParticle;
    private AudioSource bossHurtSFX;


    void Start()
    {
        bossHurtSFX = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (bossHP <= 0)
        {

            Instantiate(deathParticle, transform.position, transform.rotation);
            XPManager.AddToEarnedXPThisLevel(xpReward);
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damageReceived)
    {
        bossHP -= damageReceived;
        bossHurtSFX.Play();
    }
}
