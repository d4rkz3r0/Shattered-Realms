using UnityEngine;
using System.Collections;

public class TrapSetActive : MonoBehaviour {

	private Vector3 startingPosition;
	public Transform waypoint1;
	private Vector3 currentWaypoint;
	public bool playertriggered;
	public bool playertriggered2;
	public bool waypointreached = false;
	
	public int speed;
	private float actualSpeed;

	// Use this for initialization
	void Start () {
		playertriggered = false;
		playertriggered2 = false;
		startingPosition = transform.position;
		currentWaypoint = waypoint1.position;
		actualSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (playertriggered == true) {

			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, actualSpeed * Time.deltaTime);

			if(transform.position == currentWaypoint)
			{
				currentWaypoint = startingPosition;
			}

			if(transform.position == startingPosition)
			{
				currentWaypoint = waypoint1.position;
				playertriggered = false;
			}
		}
	}
}
