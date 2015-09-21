using UnityEngine;
using System.Collections;

public enum Direction {Right, Up, Left, Down};

public class RobotnickWPData : MonoBehaviour {

	public bool used;
	public Direction RobDirection;
	public float RobSpeed;
	public float RobSpeedIncrement;
	public bool RobLaserOn;
	public Direction RobLaserDir;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (HealthManager.playerHP == 0) {
			used = false;
		}
	}
}
