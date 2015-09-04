using UnityEngine;
using System.Collections;

public class PlatformHealthManager : MonoBehaviour {
	public int enemyHP;
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
	
	void Start () 
	{
		deathAnimation = false;
		isDead = false;
		EnemyMaxHP = enemyHP;
		player = FindObjectOfType<MasterController>();
		LM = FindObjectOfType<LevelManager>();
		enemyHurtSFX = GetComponent<AudioSource>();
		
		if (GetComponent<Animator>() != null)
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

			if(enemyAnim != null)
			{
				deathAnimation = true;
				return;
			}
				else
				{
					Instantiate(deathParticle, transform.position, transform.rotation);
					Destroy(gameObject);
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
	}
}
