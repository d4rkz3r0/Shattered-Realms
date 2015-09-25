using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1ChatBoxController : MonoBehaviour
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
    public bool startChatBoxDialogue;


    //Private References
    private Text currChatBoxText;
    private Level1EventManager L1EM;

    void Start()
    {
        FindObjectOfType<MasterController>().moveSpeed = 0.0f;
        startingTextIndex -= 1;
        textIndex = startingTextIndex;
        MessageController.textSelection = textIndex;
        startChatBoxDialogue = true;
        currChatBoxAvatar = GetComponent<Image>();

        fakeItachi = FindObjectOfType<FakeI>();
        fakeCyborg = FindObjectOfType<FakeC>();
        fakeSonic = FindObjectOfType<FakeS>();
        animI = fakeItachi.GetComponent<Animator>();
        animC = fakeCyborg.GetComponent<Animator>();
        animS = fakeSonic.GetComponent<Animator>();
        L1EM = FindObjectOfType<Level1EventManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            fakeItachi.skipIntro();
        }

        if (startChatBoxDialogue == false)
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
                L1EM.startEvents = true;
                gameObject.SetActive(false);
                return;
            }
            else
            {
                MessageController.textSelection += 1;
                textIndex++;
            }
        }

        if (startChatBoxDialogue)
        {
            gameObject.SetActive(true);

            switch (textIndex)
            {
                case 101:
                    {
                        if (!textEventReset)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 2.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 102:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 2.0f;
                            textEventReset = true;
                            animS.enabled = true;
                        }
                        break;
                    }
                case 103:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.0f;
                            textEventReset = true;
                            

                        }
                        break;
                    }
                case 104:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {

                            fakeItachi.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 105:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 106:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 107:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeItachi.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 108:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 109:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeSonic.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 110:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 2.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 111:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 3.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 112:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 3.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 113:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 3.5f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 114:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 3.0f;
                            textEventReset = true;
                        }
                        break;
                    }
                case 115:
                    {
                        textEventReset = false;
                        if (!textEventReset && textDisplayTimer <= 0.0f)
                        {
                            fakeCyborg.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
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
