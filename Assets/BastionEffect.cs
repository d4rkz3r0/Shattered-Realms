using UnityEngine;
using System.Collections;

public class BastionEffect : MonoBehaviour {

	private Animator anim;
	private MasterController player;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = FindObjectOfType<MasterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("XDistanceToPlayer", Mathf.Abs (player.transform.position.x - transform.position.x));
	}
}
