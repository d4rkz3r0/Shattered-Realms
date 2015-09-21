using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level2ChatBoxController : MonoBehaviour
{
    //ChatBox Avatar Images (Who is participating in the conversation?)
    public Sprite[] chatBoxAvatars;
    //The current avatar image to show the player.
    private Image currChatBoxAvatar;

    //The starting index matching the starting case index in Message Controller, where you want the text to begin from.
    public int startingTextIndex;

    //The ending index matching the ending case index in Message Controller, where you want the text to end.
    public int endingTextIndex;

    //Keeps track of which text message to show the player, usually incremented by 1.
    private int textSelectionIndex;
    
    //Used to prevent all of the text scrolling through before the player has a chance to read it.
    //Also serves the purpose of buffering audio clips, if you desire.
    private bool hasPlayed;

    //The internal timer that controls how long the current text is displayed.
    private float textDisplayTimer;
    
    //Set the duration of the first text event here, this is kept constantly charged until the ChatBox is activated
    //then it is depleted.
    private float textDisplayDuration = 2.0f;

    //Optional
    //Toggle this bool with a Trigger if you want the ChatBox to activate some time
    //other than the start of a level, this enables the ChatBox Game Object
    //Default Behavior: Enabled
    public bool startChatBoxDialogue;
    
    

    //Private References
    private Text currChatBoxText; //The GUI Text Element

	void Start ()
    {
        startingTextIndex -= 1;
        textSelectionIndex = startingTextIndex;
        MessageController.textSelection = textSelectionIndex;
        startChatBoxDialogue = true;
        currChatBoxAvatar = GetComponent<Image>();
	}
	
	void Update ()
    {
        if(startChatBoxDialogue == false)
        {
            textDisplayTimer = textDisplayDuration;
        }

        if(textDisplayTimer >= 0.0f)
        {
            textDisplayTimer -= Time.deltaTime;
        }

        if(textDisplayTimer <= 0.0f)
        {
            if(textSelectionIndex == endingTextIndex)
            {
                MessageController.textSelection = 0;
                gameObject.SetActive(false);
                return;
            }
            else
            {
                MessageController.textSelection += 1;
                textSelectionIndex++;
            }
        }

        


	    if(startChatBoxDialogue)
        {
            //Activate the ChatBox if it isn't already activated
            gameObject.SetActive(true);

            switch(MessageController.textSelection)
            {
                case 150:
                    {
                        if (!hasPlayed)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.22f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 151:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[1];
                            textDisplayTimer = 1.85f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 152:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[2];
                            textDisplayTimer = 2.6f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 153:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[3];
                            textDisplayTimer = 2.22f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 154:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[3];
                            textDisplayTimer = 2.5f;
                            hasPlayed = true;
                        }
                        break;
                    }
                case 155:
                    {
                        hasPlayed = false;
                        if (!hasPlayed && textDisplayTimer <= 0.0f)
                        {
                            currChatBoxAvatar.sprite = chatBoxAvatars[0];
                            textDisplayTimer = 2.0f;
                            hasPlayed = true;
                        }
                        break;
                    }
            }
        }
	}
}
