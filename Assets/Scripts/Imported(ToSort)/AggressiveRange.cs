using UnityEngine;
using System.Collections;

public class AggressiveRange : MonoBehaviour 
{
	private GameObject player;
	public GameObject projectile;
	public GameObject temp;
	public Vector2 aiming;
	public Rigidbody2D rb2d;
	public Transform trf;
	public int projectileSpeed;
	public float timer;
	public float aggroRange;

	private float size;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Player");
		projectileSpeed = 5;
		size = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
		timer -= Time.deltaTime;
		aiming = player.transform.position - transform.position;

		if (player.transform.position.x > transform.position.x)
        {
			transform.localScale = new Vector3 (-size, size, 1.0f);

				
		} else
        {
			transform.localScale = new Vector3 (size, size, 1.0f);

		}


		if (timer < 0 && aiming.magnitude < aggroRange)
        {
			timer = 2;
			temp = Instantiate(projectile);
			trf = temp.GetComponent<Transform>();
			trf.position = transform.position;
			rb2d = temp.GetComponent<Rigidbody2D>();
			rb2d.velocity = aiming.normalized*projectileSpeed;
		}
		
	}
}
