///***********************************************************************
//Class: LevelManager.cs
/*Notes:
 * The LevelManager class handles Respawning the Player and playing the
 * associated particles from the particle System. It also handles the level
 * checkpoints.
 * currCheckpoint - Stores the last checkpoint that the player has reached.
 * respawnDelay - how long to wait after death before respawning.
 * 
 * 
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    //Public Vars
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    //public AudioSource victoryMusic;

    //Private References
    public GameObject currCheckpoint;
    private MasterController player;
    //private XPManager xpManager;
    private HealthManager healthManager;
    private TimerManager timerManager;
    


    void Start()
    {
        //Auto Hook
        currCheckpoint = GameObject.Find("startCP");
        player = FindObjectOfType<MasterController>();
        healthManager = FindObjectOfType<HealthManager>();
        //xpManager = FindObjectOfType<XPManager>();
        timerManager = FindObjectOfType<TimerManager>();
        
    }


    void Update()
    {

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCoRoutine");
    }

    public IEnumerator RespawnPlayerCoRoutine()
    {

        //Death Occurred
        player.isBlinking = false;
        if(player.currentCharacter == 1)
        {
            player.GetComponent<Animator>().SetBool("isBlinking", false); //Enable if Itachi is still blinking after death respawn
        }
        
        
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; //Prevent camera from falling
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //xpManager.ResetEarnedXPThisLevel();

        Debug.Log("Respawn Event Triggered");
        yield return new WaitForSeconds(respawnDelay);

        //Death Timer has Expired
        if (!AudioManager.currAudio.isPlaying)
        {
            AudioManager.currAudio.Play();
        }

        player.isGrounded = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().gravityScale = 5.0f;
        player.transform.position = currCheckpoint.transform.position;
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        healthManager.MaxHealthRestore();
        healthManager.isPlayerDead = false;
        //HealthManager.respawnRumbleEnd();

        timerManager.ResetTimer();
        Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
    }
}