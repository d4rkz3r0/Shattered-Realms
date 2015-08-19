using UnityEngine;
using System.Collections;

public class Bomber : MonoBehaviour {

	public float timeBetweenAttacks;
	public float timer;

	public float projectileSpeed;

	public GameObject projectile;
	private GameObject temp;

	private Rigidbody2D rb2d;
	private Transform trf;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > timeBetweenAttacks) {	
			timer =0 ;
			temp = Instantiate(projectile);
			trf = temp.GetComponent<Transform>();
			trf.position = transform.position;
			rb2d = temp.GetComponent<Rigidbody2D>();
			rb2d.velocity = new Vector2(0,-projectileSpeed);
		}
	}
}
