using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour
{
    //References
    EnemyHealthManager enemyHealthManager;
    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;
    EnemyAnimation enemyAnimation;
    Animator enemyAnimator;

    //Containers
    private Vector3 startingPosition;
    private int startingHP;
    private float enemyDefeatedAnimDuration;



	void Start ()
    {
        if (GetComponent<EnemyAnimation>() != null)
        {
            enemyAnimation = FindObjectOfType<EnemyAnimation>();
            enemyDefeatedAnimDuration = enemyAnimation.enemyDefeatedAnimDuration;
        }
        else
        {
            enemyAnimation = null;
        }   
	    //Auto Hook
		if (GetComponent<EnemyHealthManager> ()) {
			enemyHealthManager = GetComponent<EnemyHealthManager> ();
		} 
		//else {
		//	enemyHealthManager = GetComponentInChildren<EnemyHealthManager> ();
		//}
		// Adding "In Chidren" fixes errors, but generates whorst ones. Its probably necesary though.

		enemyAttack = GetComponent<EnemyAttack> ();
		enemyMovement = GetComponent<EnemyMovement> ();
		enemyAnimator = GetComponent<Animator> ();
        //Initial Save
        startingPosition = gameObject.transform.position;
        startingHP = enemyHealthManager.enemyHP;
        

	}
	
	void Update ()
    {
	
	}

    public void ResetSelf()
    {
        gameObject.transform.position = startingPosition;

        enemyHealthManager.enemyHP = startingHP;
        enemyHealthManager.isDead = false;
        enemyHealthManager.deathAnimation = false;
        enemyAttack.enabled = true;
        enemyMovement.enabled = true;

        if(enemyAnimation != null)
        {
            enemyAnimation.enemyDefeatedAnimDuration = enemyDefeatedAnimDuration;
        }
        gameObject.SetActive(true);
    }
}
