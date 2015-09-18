using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyHP;
    public int EnemyMaxHP;
    public GameObject deathParticle;
    private AudioSource enemyHurtSFX;
    
    public bool isDead;
    public bool deathAnimation;


    private LevelManager LM;
    private MasterController player;
    private EnemyAnimation enemyAnim;
    private PortalController warpPortal;
    private KeyPickup warpKey;

	void Start () 
    {
        deathAnimation = false;
        isDead = false;
        EnemyMaxHP = enemyHP;
        player = FindObjectOfType<MasterController>();
        LM = FindObjectOfType<LevelManager>();
        warpPortal = FindObjectOfType<PortalController>();
        warpKey = FindObjectOfType<KeyPickup>();
        enemyHurtSFX = GetComponent<AudioSource>();
        

        if (GetComponent<EnemyAnimation>() != null)
        {
            enemyAnim = FindObjectOfType<EnemyAnimation>();
        }
        else
        {
            enemyAnim = null;
        }   
	}
	

	void Update () 
    {
        if(enemyHP <= 0)
        {
            isDead = true;
        }

	    if(isDead)
        {
            if(Application.loadedLevel == 12 && gameObject.name == "Gizmo")
            {
                Vector3 formattedWarpPortalPos = gameObject.transform.position;
                formattedWarpPortalPos += new Vector3(0.0f, 1.0f, 0.0f);
                warpPortal.transform.position = formattedWarpPortalPos;
                if (warpKey != null)
                {
                    Vector3 formattedWarpKeyPos = warpPortal.transform.position;
                    formattedWarpKeyPos += new Vector3(-1.0f, 0.0f, 0.0f);
                    warpKey.transform.position = formattedWarpKeyPos;

                }
                Instantiate(deathParticle, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if(Application.loadedLevel == 16 && gameObject.name == "Mario")
            {
                Vector3 formattedWarpPortalPos = gameObject.transform.position;
                formattedWarpPortalPos += new Vector3(0.0f, 1.0f, 0.0f);
                warpPortal.transform.position = formattedWarpPortalPos;
                if(warpKey != null)
                {
                    Vector3 formattedWarpKeyPos = warpPortal.transform.position;
                    formattedWarpKeyPos += new Vector3(-1.0f, 0.0f, 0.0f);
                    warpKey.transform.position = formattedWarpKeyPos;

                }
                Instantiate(deathParticle, transform.position, transform.rotation);
                Destroy(gameObject);
                
            }

            else
            {

                if(enemyAnim != null)
                {
                    deathAnimation = true;
                    return;
                }
                else
                {
                    if(gameObject.name == "Ranged Sound Ninja")
                    {
                        deathAnimation = true;
                        return;
                    }
                    Instantiate(deathParticle, transform.position, transform.rotation);
                    gameObject.SetActive(false);
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
