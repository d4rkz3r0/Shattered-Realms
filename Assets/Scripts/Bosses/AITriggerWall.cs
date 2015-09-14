using UnityEngine;
using System.Collections;

public class AITriggerWall : MonoBehaviour
{
    private MasterController player;
    private SasukeController sasuke;
    private float IntroTimer;
    private float IntroTimerDuration = 10.585f;
    public ChatBoxController chatBoxHUDElement;
    public BossHealthManager sasukeHPBarHUDElement;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<MasterController>();
        sasuke = FindObjectOfType<SasukeController>();
        
        MessageController.textSelection = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(IntroTimer >= 0.0f)
        {
            IntroTimer -= Time.deltaTime;
        }
        if(IntroTimer >= 0.0f && IntroTimer <= 3.5f)
        {
            sasukeHPBarHUDElement.gameObject.SetActive(true);
        }

        if(IntroTimer <= 0.0f && MessageController.textSelection == 0)
        {
            chatBoxHUDElement.startBossDialogue = false;
            sasukeHPBarHUDElement.GetComponent<Animator>().enabled = false;
            sasuke.canMove = true;
            player.disableInput = false;
            
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            chatBoxHUDElement.gameObject.SetActive(true);
            IntroTimer = IntroTimerDuration;
            chatBoxHUDElement.startBossDialogue = true;
            MessageController.textSelection = 20;
            sasuke.canMove = false;
            player.disableInput = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //if(chatBoxHUDElement.gameObject.active == true)
    }
}
