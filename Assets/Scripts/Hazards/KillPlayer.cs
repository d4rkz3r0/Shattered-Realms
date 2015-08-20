///***********************************************************************
//Class: KillPlayer.cs
/*Notes:
 * This KillPlayer class respawns the player. This script should be attached
 * to enemies/obstacles/hazards which auto-kill the player.
 * 
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    //Private References
    private LevelManager levelManager;

    void Start()
    {
        //Auto Hook
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealthManager.respawnRumbleStart();
            HealthManager.playerHP = 0;
            levelManager.RespawnPlayer();
        }
    }
}
