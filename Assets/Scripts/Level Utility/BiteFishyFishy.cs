using UnityEngine;
using System.Collections;

public class BiteFishyFishy : MonoBehaviour 
{
    private float initialJump = 13.0f;
    private Rigidbody2D rb2d;

	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0.0f, initialJump);
	}
	
	void Update () 
    {
        if(rb2d.velocity.y >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (rb2d.velocity.y <= 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
	}
}
