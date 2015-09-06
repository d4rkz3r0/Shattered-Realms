using UnityEngine;
using System.Collections;

public class phoenixFlowerController : MonoBehaviour 
{
    public int abilityDamageAmount;
    public float abilitySpeed;

    private Rigidbody2D rb2D;
    private MasterController player;
    private SasukeController sasuke;
    private bool reflectProj;

	void Start () 
    {
        reflectProj = false;
        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<MasterController>();
        sasuke = FindObjectOfType<SasukeController>();

        if (sasuke.transform.localScale.x < 0.0f)
        {
            
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if (sasuke.transform.localScale.x > 0.0f)
        {
            //abilitySpeed = -abilitySpeed;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        
	}
	
	// Update is called once per frame
	void Update () 
    {
       
        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if(!reflectProj)
            {
                rb2D.position = Vector3.MoveTowards(transform.position, player.transform.position, (abilitySpeed * Time.deltaTime));
            }
            else
            {
                rb2D.position = Vector3.MoveTowards(transform.position, sasuke.transform.position, (abilitySpeed * Time.deltaTime));
            }
            
        }
        else if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            if (!reflectProj)
            {
                rb2D.position = Vector3.MoveTowards(transform.position, player.transform.position, (abilitySpeed * Time.deltaTime));
            }
            else
            {
                rb2D.position = Vector3.MoveTowards(transform.position, sasuke.transform.position, (abilitySpeed * Time.deltaTime));
            }
        }

        if (Mathf.Round(transform.position.x) == Mathf.Round(sasuke.transform.position.x))
        {
            FindObjectOfType<BossHealthManager>().takeDamage(abilityDamageAmount);
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HealthManager.takeDamage(abilityDamageAmount);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "darkStorm(Clone)")
        {
            reflectProj = true;
        }
    }
}
