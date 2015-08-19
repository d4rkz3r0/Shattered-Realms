using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour
{
    //Public Inspector Globals
    public int damageAmount;
    //Default Values
    public float timeBetweenAttacks = 1.0f;
    private float timer = 1.0f;
	

    //Private References
    

	void Start ()
    {
          
	}
	
	void Update () 
    {
        timer += Time.deltaTime;
	}


	void OnTriggerStay2D(Collider2D other)
    {
        if ((other.name == "Player") && (timer > timeBetweenAttacks))
        {
            timer = 0.0f;
            HealthManager.takeDamage(damageAmount);
        }
    }
}
