///***********************************************************************
//Class: Checkpoint.cs
/*Notes:
 * Checkpoints are invisible GameObjects that the player can collide with.
 * Once the player collides with a checkpoint, that checkpoint becomes the
 * "currCheckpoint" handled by the LevelManager.
 * 
 * 
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    //Private References
    private LevelManager levelManager;

    void Start()
    {
        //Auto Hook
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //If the player touches a checkpoint update the currentCheckpoint.
            levelManager.currCheckpoint = gameObject;
            //Debug.Log("Checkpoint @ " + transform.position + " activated!");
        }
    }
}
