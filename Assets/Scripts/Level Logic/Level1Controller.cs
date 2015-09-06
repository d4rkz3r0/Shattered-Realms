using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1Controller : MonoBehaviour
{
    //Level 1 Specific Objects
    private FakeI fakeItachi;
    private FakeC fakeCyborg;
    private FakeS fakeSonic;
    private Animator animI;
    private Animator animC;
    private Animator animS;



    //Gameplay Events
    public bool startEvents;
    public int eventIndex;
    public float eventTimer;
    public float eventDuration = 2.0f;
    private bool eventReset;
    public bool Event1;

    //Event 1
    public Transform hoverPoint;
    public AudioSource itachiKatonSFX;
    public AudioSource sonicSuperSonicSFX;


    //Text ChatBox Events
    public bool startChatBoxText;
    private bool textEventReset;
    public Sprite[] chatBoxAvatars;
    private Image currChatBoxAvatar;
    private Text currText;
    public int StartMessageTextIndex;
    public float textTimer;
    public float textDuration;
    
    void Awake()
    {

    }

	void Start () 
    {
        startEvents = false;
        eventReset = false;
        textEventReset = false;
        eventIndex = -1;
        Event1 = false;
        fakeItachi = FindObjectOfType<FakeI>();
        fakeCyborg = FindObjectOfType<FakeC>();
        fakeSonic = FindObjectOfType<FakeS>();
        animI = fakeItachi.GetComponent<Animator>();
        animC = fakeCyborg.GetComponent<Animator>();
        animS = fakeSonic.GetComponent<Animator>();
        currChatBoxAvatar = GetComponent<Image>();
        currText = GetComponentInChildren<Text>();
        MessageController.textSelection = StartMessageTextIndex;
        textTimer = textDuration;
        startChatBoxText = true;        
	}
	
	void Update ()
    {

        //Gameplay Events
        if(eventTimer >= 0.0f)
        {
            eventTimer -= Time.deltaTime;
        }

        if (eventTimer <= 0.0f)
        {
            if (eventIndex == 4)
            {
                eventIndex = -1;
                startEvents = false;
                return;
            }
            else
            {
                eventIndex++;
               
            }
        }

        if(Event1)
        {
            Debug.Log("OH YEA, SONIC'S TOO STRONK!!!");
            Debug.Log("PRESS ENTER TO GTFO");
            Debug.Log("WILL FIX LATER!");
            fakeCyborg.transform.position = Vector3.MoveTowards(fakeCyborg.transform.position, hoverPoint.position, 5.0f * Time.deltaTime);
            animC.Play("Cyborg_Hover");

            fakeItachi.transform.position = new Vector3(-125.0f, -175.09f, 0.0f);
            
            animI.Play("itachi_Fireball");

            fakeSonic.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            
            animS.Play("sonic_SuperTransform");
            fakeSonic.transform.position = Vector3.MoveTowards(fakeSonic.transform.position, fakeItachi.transform.position, 5.0f * Time.deltaTime);

            if(Input.GetAxis("Submit") != 0.0f)
            {
                Application.LoadLevel(7);
            }
        }

        if(startEvents)
        {
            switch(eventIndex)
            {
                case 0:
                    
                    {
                        if (!eventReset)
                        {
                            Event1 = true;
                            itachiKatonSFX.Play();
                            sonicSuperSonicSFX.Play();
                            eventTimer = 3.0f;
                            eventReset = true;
                        }
                        break;
                    }
                case 1:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {

                            eventTimer = 1.0f;
                            eventReset = true;
                        }
                        break;
                    }
                case 2:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {

                            eventTimer = 1.0f;
                            eventReset = true;
                        }
                        break;
                    }
                case 3:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {

                            eventTimer = 1.0f;
                            eventReset = true;
                        }
                        break;
                    }
                case 4:
                    {
                        eventReset = false;
                        if (!eventReset && eventTimer <= 0.0f)
                        {

                            eventTimer = 1.0f;
                            eventReset = true;
                            
                        }
                        break;
                    }
            }
        }

        //Text ChatBox Events
        if (textTimer >= 0.0f)
        {
            textTimer -= Time.deltaTime;
        }

        if (textTimer <= 0.0f)
        {
            if (MessageController.textSelection == 115)
            {
                MessageController.textSelection = 0;
                currText.text = "";
                currChatBoxAvatar.enabled = false;
                eventTimer = eventDuration;
                eventIndex = 0;
                startEvents = true;
                //gameObject.SetActive(false);
                return;
            }
            else
            {
                if(currChatBoxAvatar.enabled)
                {
                    MessageController.textSelection++;
                }
                else
                {
                    return;
                } 
            }
        }

	    if(startChatBoxText)
        {
            switch (MessageController.textSelection)
            {
                case 101:
                    {
                        if(!textEventReset)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 102:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 103:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.0f;
                            textEventReset = true;
                            animS.enabled = true;
                            
                        }
                        break;
                    }
                case 104:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            
                            fakeItachi.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 105:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 106:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 107:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeItachi.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 108:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 109:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeSonic.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 110:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 111:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 2.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 112:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 113:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 114:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 2.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 115:
                    {
                        textEventReset = false;
                        if (!textEventReset && textTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                    //End
            } 
        }
    }
}
