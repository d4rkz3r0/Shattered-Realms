using UnityEngine;
using System.Collections;

public class GizmoTriggerWall : MonoBehaviour 
{
    private MasterController player;
    private GameObject gizmo;
    private float IntroTimer;
    private float IntroTimerDuration = 3.6f;
    private EnemyHealthManager gizmoHP;
    public ChatBoxController chatBoxHUDElement;
    public BossHealthManager gizmoHPBarHUDElement;
    private bool start;

	void Start () 
    {
        start = false;
        player = FindObjectOfType<MasterController>();
        gizmo = GameObject.Find("Gizmo");

        MessageController.textSelection = 0;
	}
	
	void Update () 
    {
        if (IntroTimer >= 0.0f)
        {
            IntroTimer -= Time.deltaTime;
        }
        if (IntroTimer <= 0.0f && start)
        {
            if (GameObject.Find("Boss HP Bar Image").GetComponent<Animator>() != null)
            {
                GameObject.Find("Boss HP Bar Image").GetComponent<Animator>().enabled = false;
            }
            
            chatBoxHUDElement.gameObject.SetActive(false);
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IntroTimer = IntroTimerDuration;
            gizmoHPBarHUDElement.gameObject.SetActive(true);
            chatBoxHUDElement.startBossDialogue = true;
            chatBoxHUDElement.gameObject.SetActive(true);
            MessageController.textSelection = 31;
            start = true;
        }
    }
}
