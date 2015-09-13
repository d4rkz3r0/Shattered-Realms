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
            if(Application.loadedLevel == 11 && gameObject.name == "Gizmo")
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
                XPManager.AddToEarnedXPThisLevel(xpOnDeath);
                Destroy(gameObject);
            }

            if(Application.loadedLevel == 15 && gameObject.name == "Mario")
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
                XPManager.AddToEarnedXPThisLevel(xpOnDeath);
                Destroy(gameObject);
                
            }

            else
            {

                if(enemyAnim != null)
                {
                    deathAnimation = true;
                    XPManager.AddToEarnedXPThisLevel(xpOnDeath);
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

    //public IEnumerator RespawnSelf()
    //{
    //    for (int i = 0; i < LM.enemyPositionArray.Length; i++)
    //    {
    //        if (LM.enemyPositionArray[i] == new Vector3(0.0f, 0.0f, 0.0f))
    //        {
    //            LM.enemyPositionArray[i] = transform.position;
    //            break;
    //        }
    //    }
           
    //    Destroy(gameObject);
    //    yield return null;
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    RespawnSelf();
    //    //if(other.tag == "Player")
    //    //{
    //    //    LM.RespawnEnemies();
    //    //}
    //}

    
}
