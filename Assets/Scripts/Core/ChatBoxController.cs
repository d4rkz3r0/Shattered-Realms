using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatBoxController : MonoBehaviour
{
    //ChatBoxes
    public Sprite[] chatBoxAvatars;
    private Image currChatBoxAvatar;
    public AudioSource[] voiceClips;
    public int voiceClipIndex;
    private bool hasPlayed;
    private bool hasEndPlayed;
    public float voiceClipAudioTimer;
    public float voiceClipEndAudioTimer;
    public float voiceClipDuration = 2.0f;
    public float voiceClipEndDuration = 0.8f;
    private Text currText;


    public bool startBossDialogue;
    public bool startEndBossDialogue;


    private MasterController player;
	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<MasterController>();
        currChatBoxAvatar = GetComponent<Image>();
        currText = GetComponentInChildren<Text>();
        hasPlayed = false;
        hasEndPlayed = false;
        voiceClipIndex = 0;
        startBossDialogue = false;
        startEndBossDialogue = false;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(startBossDialogue == false && startEndBossDialogue == false)
        {
            voiceClipAudioTimer = voiceClipDuration;
        }
        

        if(startEndBossDialogue == false)
        {
            voiceClipEndAudioTimer = voiceClipEndDuration;
        }

        if (voiceClipAudioTimer >= 0.0f)
        {
            voiceClipAudioTimer -= Time.deltaTime;
        }

        if (voiceClipEndAudioTimer >= 0.0f)
        {
            voiceClipEndAudioTimer -= Time.deltaTime;
        }



        if (voiceClipEndAudioTimer <= 0.0f)
        {
            if(MessageController.textSelection == 28)
            {
                MessageController.textSelection = 0;
                currText.text = "";
                gameObject.SetActive(false);
                return;
            }
            else
            {
                MessageController.textSelection += 1;
                voiceClipIndex++;
            }
            
        }

        if (voiceClipAudioTimer <= 0.0f && startEndBossDialogue == false)
        {
            if(MessageController.textSelection == 25)
            {
                MessageController.textSelection = 0;
                ++voiceClipIndex;
                currText.text = "";
                gameObject.SetActive(false);
                return;
            }
            else
            {
                MessageController.textSelection += 1;
                voiceClipIndex++;
            }
            
        }

	    if(startBossDialogue || startEndBossDialogue)
        {
            gameObject.SetActive(true);

            switch (MessageController.textSelection)
            {
                case 20:
                    {
                        if (!hasPlayed)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipAudioTimer = 2.22f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 21:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && voiceClipAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipAudioTimer = 1.85f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 22:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && voiceClipAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipAudioTimer = 2.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 23:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && voiceClipAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipAudioTimer = 1.93f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 24:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && voiceClipAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipAudioTimer = 1.04f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 25:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && voiceClipAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipAudioTimer = 1.845f;
                            hasPlayed = true;
                        }
                        break;
                    }
                    //End
                case 26:
                    {
                        if (!hasEndPlayed)
                        {
                            player.currentCharacter = 1;
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipEndAudioTimer = 0.717f;
                            hasEndPlayed = true;
                        }
                        break;
                    }
                case 27:
                    {
                        hasEndPlayed = false;
                        if (!hasEndPlayed && voiceClipEndAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipEndAudioTimer = 4.39f;
                            hasEndPlayed = true;
                        }
                        break;
                    }
                case 28:
                    {
                        hasEndPlayed = false;
                        if (!hasEndPlayed && voiceClipEndAudioTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            voiceClips[voiceClipIndex].Play();
                            voiceClipEndAudioTimer = 6.0f;
                            
                            player.currentCharacter = 1;
                            player.canExecuteSasuke = true;
                            player.disableInput = true;
                            hasEndPlayed = true;
                        }
                        break;
                    }
            }
        }
	}
}
