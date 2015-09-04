using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level1Controller : MonoBehaviour
{
    private float event1Timer;
    private float event1Duration;

    private FakeI fakeItachi;
    private FakeC fakeCyborg;
    private FakeS fakeSonic;

    //ChatBoxes
    public bool startChatBoxText;
    private bool hasPlayed;
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
        hasPlayed = false;
        fakeItachi = FindObjectOfType<FakeI>();
        fakeCyborg = FindObjectOfType<FakeC>();
        fakeSonic = FindObjectOfType<FakeS>();
        currChatBoxAvatar = GetComponent<Image>();
        currText = GetComponentInChildren<Text>();
        MessageController.textSelection = StartMessageTextIndex;
        textTimer = textDuration;
        startChatBoxText = true;        
	}
	
	void Update ()
    {
        Debug.Log(MessageController.textSelection);

        if (textTimer >= 0.0f)
        {
            textTimer -= Time.deltaTime;
        }

        if (textTimer <= 0.0f)
        {
            if (MessageController.textSelection == 113)
            {
                MessageController.textSelection = 0;
                currText.text = "";
                gameObject.SetActive(false);
                return;
            }
            else
            {
                MessageController.textSelection++;
            }
        }

	    if(startChatBoxText)
        {
            switch (MessageController.textSelection)
            {
                case 101:
                    {
                        if(!hasPlayed)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.0f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 102:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.0f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 103:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.0f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 104:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 105:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 106:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 107:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 108:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 109:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 110:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 111:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 112:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 113:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 114:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 115:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textTimer = 1.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                    //End
            } 
        }
    }
}
