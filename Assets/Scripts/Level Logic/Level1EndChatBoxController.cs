using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1EndChatBoxController : MonoBehaviour
{
    //Level 1 Specific Objects
    private FakeI fakeItachi;
    private FakeC fakeCyborg;
    private FakeS fakeSonic;
    private Animator animI;
    private Animator animC;
    private Animator animS;

    public int textIndex;

    //Starting Text
    public Sprite[] chatBoxAvatars;
    private Image currChatBoxAvatar;
    public int startingTextIndex;
    public int endingTextIndex;
    private bool textEventReset;
    private float textDisplayTimer;
    private float textDisplayDuration = 2.0f;
    public bool startEndingChatBoxDialogue;


    public AudioSource cyborgCrySFX;
    public AudioSource sonicCakeSFX;

    public AudioSource itachiHurtSFX;
    public AudioSource cyborgHurtSFX;
    public AudioSource sonicHurtSFX;


    //Private References
    private Text currChatBoxText;

    void Start()
    {
        startingTextIndex -= 1;
        textIndex = startingTextIndex;
        MessageController.textSelection = textIndex;
        startEndingChatBoxDialogue = true;
        currChatBoxAvatar = GetComponent<Image>();

        fakeItachi = FindObjectOfType<FakeI>();
        fakeCyborg = FindObjectOfType<FakeC>();
        fakeSonic = FindObjectOfType<FakeS>();
        animI = fakeItachi.GetComponent<Animator>();
        animC = fakeCyborg.GetComponent<Animator>();
        animS = fakeSonic.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            textIndex = 131;
            MessageController.textSelection = textIndex;
        }

        if (startEndingChatBoxDialogue == false)
        {
            textDisplayTimer = textDisplayDuration;
        }

        if (textDisplayTimer >= 0.0f)
        {
            textDisplayTimer -= Time.deltaTime;
        }

        if (textDisplayTimer <= 0.0f)
        {
            if (textIndex == endingTextIndex)
            {
                MessageController.textSelection = 0;
                gameObject.SetActive(false);
                return;
            }
            else
            {
                MessageController.textSelection += 1;
                textIndex++;
            }
        }

        if (startEndingChatBoxDialogue)
        {
            gameObject.SetActive(true);


            //fakeItachi.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            //fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            //fakeSonic.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);


            switch (textIndex)
            {
                case 116:
                    {
                        if (!textEventReset)
                        {
                            itachiHurtSFX.Play();
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 0.7f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 117:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            cyborgHurtSFX.Play();
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 0.7f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 118:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            sonicHurtSFX.Play();
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 0.7f;
                            textEventReset = true;
                            
                        }
                        break;
                    }
                case 119:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {

                            
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.7f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 120:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            fakeItachi.event1 = false;
                            animI.enabled = true;
                            textDisplayTimer = 2.7f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 121:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            fakeCyborg.event1 = false;
                            animC.enabled = true;
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 122:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            fakeSonic.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            fakeSonic.event1 = false;
                            animS.enabled = true;
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 123:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 1.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 124:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.8f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 125:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.8f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 126:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            textDisplayTimer = 3.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 127:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 3.25f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 128:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 3.25f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 129:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            fakeItachi.acceptChars = true;
                            fakeItachi.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                            fakeItachi.GetComponent<CircleCollider2D>().enabled = false;
                            
                            
                            textDisplayTimer = 2.8f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 130:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            
                            cyborgCrySFX.Play();
                            fakeCyborg.moveToItachi = true;
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            
                            textDisplayTimer = 2.2f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 131:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            
                            sonicCakeSFX.Play();
                            fakeSonic.moveToItachi = true;
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 3.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                //End
            }
        }
    }
}
