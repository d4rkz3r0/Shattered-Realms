using UnityEngine;
using System.Collections;

public class TsukuController : MonoBehaviour {

	private SpriteRenderer spRender;
	private float timer;
	public float duration;

	// Use this for initialization
	void Start () {
		spRender = GetComponent<SpriteRenderer> ();
		spRender.color = new Color(spRender.color.r, spRender.color.g, spRender.color.b, 0.3f);
		timer = duration;
	}
	
	// Update is called once per frame
	void Update () {	
		timer -= Time.deltaTime;
		if (transform.localScale.x < 70) {
			transform.localScale += new Vector3 (1, 1, 0);
		}
		if (timer <= 0) {
			Destroy(gameObject);
		}
	}
}
