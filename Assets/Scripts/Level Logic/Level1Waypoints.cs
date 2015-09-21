using UnityEngine;
using System.Collections;

public class Level1Waypoints : MonoBehaviour 
{
    public bool startMoving;
    private Vector3 currentWaypoint;
    private Vector3 startingPosition;
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform waypoint4;
    public Transform waypoint5;
    public Transform waypoint6;
    public Transform waypoint7;
    public float moveSpeed;

	void Start () 
    {
        startMoving = false;
        startingPosition = transform.position;
        currentWaypoint = waypoint1.position;
	}
	
	void Update ()
    {
        if(startMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, moveSpeed * Time.deltaTime);
            //Debug.Log(transform.position);
            //Debug.Log(currentWaypoint);
            if (ComparePositions(currentWaypoint, transform.position))
            {
                if (ComparePositions(waypoint1.position, transform.position))
                {
                    moveSpeed = 16.5f;
                    currentWaypoint = waypoint2.position;
                }
                else if (ComparePositions(waypoint2.position, transform.position))
                {
                    moveSpeed = 18.5f;
                    currentWaypoint = waypoint3.position;
                }
                else if (ComparePositions(waypoint3.position, transform.position))
                {
                    moveSpeed = 12.5f;
                    currentWaypoint = waypoint4.position;
                }
                else if (ComparePositions(waypoint4.position, transform.position))
                {
                    moveSpeed = 13.5f;
                    currentWaypoint = waypoint5.position;
                }
                else if (ComparePositions(waypoint5.position, transform.position))
                {
                    moveSpeed = 15.5f;
                    currentWaypoint = waypoint6.position;
                }
                else if (ComparePositions(waypoint6.position, transform.position))
                {
                    moveSpeed = 16.5f;
                    currentWaypoint = waypoint7.position;
                }
                else if (ComparePositions(waypoint7.position, transform.position))
                {
                    moveSpeed = 13.5f;
                    currentWaypoint = startingPosition;
                }
                else if (ComparePositions(startingPosition, transform.position))
                {
                    moveSpeed = 0.0f;
                    FindObjectOfType<Level1EventManager>().constantRotate = false;
                    FindObjectOfType<Level1EventManager>().increment = false;
                    Debug.Log("Reached starting point");
                    currentWaypoint = waypoint1.position;
                }
            }
        }
        else
        {
            transform.position = new Vector3(-125.13f, -173.4725f, 0.0f);
        }
        
	}

    bool ComparePositions(Vector3 pos1, Vector3 pos2)
    {
        if (pos1.x < pos2.x + 0.01f && pos1.x > pos2.x - 0.01f && pos1.y < pos2.y + 0.01f && pos1.y > pos2.y - 0.01f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
