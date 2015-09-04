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
    public float playerRespawnDelay;
    private float cameraSize;
    private float defaultCameraSize;
    public float maxCameraZoomOutSize;
    private float startZoomInTime;
    private float startZoomOutTime;

    //Stores all enemies locations in the level
    public Vector3[] enemyPositionArray;
    public GameObject enemyPrefab;
    private int arraySize;

    //Private References
    public GameObject currCheckpoint;
    private MasterController player;
    //private XPManager xpManager;
    private HealthManager healthManager;
    private TimerManager timerManager;
    private Camera mainCamera;
    
    private bool cameraZoomInEffect;
    private bool cameraZoomOutEffect;
    private float zoomInDuration;
    private float zoomOutDuration;
    
    void Start()
    {
        //levelXPGems = GameObject.FindGameObjectsWithTag("XP Gem");
        arraySize = GameObject.FindObjectsOfType<EnemyHealthManager>().Length;
        enemyPositionArray = new Vector3[arraySize];

        
        
        //Hook to HUD Elements and Checkpoints
        currCheckpoint = GameObject.Find("startCP");
        player = FindObjectOfType<MasterController>();
        healthManager = FindObjectOfType<HealthManager>();
        timerManager = FindObjectOfType<TimerManager>();
        GameOptionData.currentLevel = Application.loadedLevel;

        //Camera Zoom in and out after Player Death
        mainCamera = FindObjectOfType<Camera>();
        cameraSize = mainCamera.orthographicSize;
        zoomOutDuration = playerRespawnDelay * 0.35f;
        zoomInDuration = playerRespawnDelay;
        defaultCameraSize = mainCamera.orthographicSize;
        cameraZoomInEffect = false;
        cameraZoomOutEffect = false;
    }


    void Update()
    {




        float formattedMaxCameraSize = maxCameraZoomOutSize + 0.02f;
        
        if (cameraZoomInEffect)
        {
            if (mainCamera.orthographicSize < formattedMaxCameraSize)
            {
                if(mainCamera.orthographicSize >= maxCameraZoomOutSize)
                {
                    startZoomOutTime = Time.time;
                    cameraZoomInEffect = false;
                    cameraZoomOutEffect = true;
                    
                }

                float lambda = (Time.time - startZoomInTime) / (zoomInDuration);
                cameraSize = Mathf.SmoothStep(defaultCameraSize, maxCameraZoomOutSize, lambda);
                mainCamera.orthographicSize = cameraSize;
            }
        }

        if(cameraZoomOutEffect)
        {
            if(mainCamera.orthographicSize == defaultCameraSize)
            {
                cameraZoomOutEffect = false;
            }
            float lambda = (Time.time - startZoomOutTime) / (zoomOutDuration);
            cameraSize = Mathf.Lerp(maxCameraZoomOutSize, defaultCameraSize, lambda);
            mainCamera.orthographicSize = cameraSize;
        }

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCoRoutine");
    }


    public void RespawnEnemies()
    {
        StartCoroutine("RespawnEnemyCoRoutine");
    }

    public IEnumerator RespawnPlayerCoRoutine()
    {
        
        //Death Occurred
        cameraZoomInEffect = true;
        player.isBlinking = false;
        //Capture Time at Death Start
        startZoomInTime = Time.time;

        if(player.currentCharacter == 1)
        {
            player.GetComponent<Animator>().SetBool("isBlinking", false); //Enable if Itachi is still blinking after death respawn
        }
        
        
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; //Prevent camera from falling
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;




        yield return new WaitForSeconds(playerRespawnDelay);

        //AudioManager
        //Death Timer has Expired
        //if (!AudioManager.currAudio.isPlaying)
        //{
        //    AudioManager.currAudio.Play();
        //}

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
        startZoomOutTime = 0.0f;
        startZoomInTime = 0.0f;
        

    }

    public IEnumerator RespawnEnemyCoRoutine()
    {
        for (int i = 0; i < enemyPositionArray.Length; i++)
        {
            if (enemyPositionArray[i] == new Vector3(0.0f, 0.0f, 0.0f))
            {
                break;
            }
            else
            {
                enemyPrefab = (GameObject)Instantiate(enemyPrefab, enemyPositionArray[i], Quaternion.identity);
            }
        }

            yield return null;
    }
}