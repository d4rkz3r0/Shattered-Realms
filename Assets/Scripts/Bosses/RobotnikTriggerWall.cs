using UnityEngine;
using System.Collections;

public class RobotnikTriggerWall : MonoBehaviour 
{
    private MasterController player;
    private GameObject robotnik;
    private float IntroTimer;
    private float IntroTimerDuration = 6.19f;
    public ChatBoxController chatBoxHUDElement;
    private bool start;

	void Start () 
    {
        start = false;
        player = FindObjectOfType<MasterController>();
        robotnik = GameObject.Find("Robotnick");

        MessageController.textSelection = 1;
	}
	
	void Update ()
    {
        if (IntroTimer >= 0.0f)
        {
            IntroTimer -= Time.deltaTime;
        }
        if (IntroTimer <= 0.0f && start)
        {
            chatBoxHUDElement.gameObject.SetActive(false);
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IntroTimer = IntroTimerDuration;
            chatBoxHUDElement.startBossDialogue = true;
            chatBoxHUDElement.gameObject.SetActive(true);
            MessageController.textSelection = 35;
            start = true;
        }
    }
}
