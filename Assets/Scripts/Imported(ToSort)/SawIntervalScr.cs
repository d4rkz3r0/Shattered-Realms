using UnityEngine;
using System.Collections;

public class SawIntervalScr : MonoBehaviour {

	public float sawTimer;
	public int toogleTime;
	public bool onOff = true;
	public GameObject saw;

	// Use this for initialization
	void Start () {
		sawTimer = 0;
		toogleTime = 1 + Random.Range(1,4);
	}
	
	// Update is called once per frame

	
	void Update () {
		sawTimer += Time.deltaTime;
		if (sawTimer >= toogleTime) 
		{
			toogleTime = Random.Range(1,4) + 1;
			sawTimer = 0;
			if (onOff == true)
			{
				onOff = false;
				saw.SetActive(false);
			}
			else
			{
                saw.SetActive(true);
				onOff = true;
			}
		}
	}
}
