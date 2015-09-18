using UnityEngine;
using System.Collections;

public class SwimSwimFishy : MonoBehaviour 
{
    private float swimSpeed;
    private float distance;
    private float distanceTimer;
    private bool switchDirection;
    private Rigidbody2D rb2d;


	// Use this for initialization
	void Start ()
    {
        distance = Random.Range(2.0f, 5.0f);
        swimSpeed = Random.Range(1.5f, 2.5f);
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (distanceTimer >= 0.0f)
        {
            distanceTimer -= Time.deltaTime;
        }

        if (distanceTimer <= 0.0f)
        {
            switchDirection = !switchDirection;
            distanceTimer = distance;
        }

        if (switchDirection)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            rb2d.velocity = new Vector2(swimSpeed, rb2d.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            rb2d.velocity = new Vector2(-swimSpeed, rb2d.velocity.y);
        }
	}

    
}
