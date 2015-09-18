using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageController : MonoBehaviour 
{
    public static int textSelection;
    private Text displayedText;
	private float timer;

	private bool pressedUp;

    //private float textFadeTimer;
    //private float defaultTextFadeDuration;
    //public float timeBetweenText;
    //private float textTimer;


	// Use this for initialization
	void Start ()
    {
        displayedText = GetComponent<Text>();
		timer = 0;
		pressedUp = false;
        //textTimer = timeBetweenText;
	}
	
	// Update is called once per frame
	void Update () 
    {
		timer += Time.deltaTime;
        //if(textFadeTimer > 0.0f)
        //{
        //    textFadeTimer -= Time.deltaTime;
        //}

        //if(textFadeTimer < 0.0f)
        //{
        //    textSelection = 0;
        //}

        //if (textTimer >= 0.0f)
        //{
        //    textTimer -= Time.deltaTime;
        //}

        //if(textTimer <= 0.0f)
        //{
        //    //++textSelection;
        //   // textTimer = timeBetweenText;
        //}

        switch (textSelection)
        {
            case 0:
                {
                    displayedText.text =
                        "";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 1:
                {
                   /* displayedText.text =
                        "Welcome To the Tutorial!";*/
                    break;
                }
            case 2:
                {

                    displayedText.text =
                        "Press A to Jump.";
		
				
                    break;
                }
            case 3:
                {
                    displayedText.text =
                        "Press A twice to Double Jump.";
                    break;
                }
            case 4:
                {
                 /*  displayedText.text =
                        "Press A three times to Triple Jump.";*/
                    break;
                }
            case 5:
                {
                    displayedText.text =
                        "Press X to Attack.";
                    break;
                }
            case 6:
                {
                    displayedText.text =
                        "Press LB to switch between characters.";
                    //displayedText.text =
                    //    "You can switch between characters\n"
                    //    + "by pressing 1, 2 or 3.";
                    break;
                }
            case 7:
                {
                    displayedText.text =
                        "Cyborg's X has shorter range but more power.\nAnd Sonic's even more!";
                    //displayedText.text =
                    //    "Press Q,W,E,R to use your abilities.";
                    break;
                }
            case 8:
                {
                    displayedText.text =
                        "Press RT for each characters' movement ability.";
                    //displayedText.text =
                    //    "Reach the end of the level\nif you can.";
                    break;
                }
            case 9:
                {
                    displayedText.text =
                        "Cyborg's Charge damages enemies.";
                    //displayedText.text =
                    //    "Hazards and Enemies will try to stop you.";
                    break;
                }
            case 10:
                {
                    displayedText.text =
                        "Itachi's Blink works horizontally and vertically.";
                    //displayedText.text =
                    //    "Good luck!";
                    break;
                }
            case 11:
                {
                   /* displayedText.text =
                        "Spikes deal damage and apply knockback.";*/
                    break;
                }
            case 12:
                {
                    displayedText.text =
                        "Red Gems replenish your HP Bar.\nBlue Gems increase your XP.";
                    break;
                }
            case 13:
                {
                    displayedText.text =
                        "Lost? Signs will point you in the right direction.";
                    break;
                }
            case 14:
                {
                    displayedText.text =
                        "Itachi's second ability deflects bullets!\nPress B to use it.";
                    break;
                }
            case 15:
                {
                    displayedText.text =
				"Cyborg's second ability can only be used while in th air!\nPress B to use it.";
                    break;
                }
            case 16:
                {
				if(!pressedUp)
			{
                    displayedText.text =
                        "Use the Portal by going UP\nwith the analog stick.";
			}
                    break;
                }
            case 17:
                {
			displayedText.text = "";
                       
                    break;
                }
            case 18:
                {
                    displayedText.text =
                        "You have collected all of the\nXP Gems! Head to the warp Portal!";

                    break;
                }
            case 19:
                {
			pressedUp = true;
                    displayedText.text =
                        "You must find the key before you\ncan warp out of here!";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 20:
                {
                    pressedUp = true;
                    displayedText.text =
                        "How much can I see\nwith these?";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 21:
                {
                    pressedUp = true;
                    displayedText.text =
                        "What I'm seeing right\nnow...";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 22:
                {
                    pressedUp = true;
                    displayedText.text =
                        "Is you dead at my\nfeet!";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 23:
                {
                    pressedUp = true;
                    displayedText.text =
                        "You see me dead do\nyou?";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 24:
                {
                    pressedUp = true;
                    displayedText.text =
                        "Well then...";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 25:
                {
                    pressedUp = true;
                    displayedText.text =
                        "Make it happen!";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 26:
                {
                    pressedUp = true;
                    displayedText.text =
                        "What?!";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 27:
                {
                    pressedUp = true;
                    displayedText.text =
                        "Itachi! All these\nyears nothing has\nchanged...";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 28:
                {
                    pressedUp = true;
                    displayedText.text =
                        "I'll handle this...\n(Press X or LT)";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 29:
                {
                    pressedUp = true;
                    displayedText.text =
                        "Make it happen!";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 30:
                {
                    pressedUp = true;
                    displayedText.text =
                        "You must find the key before you\ncan warp out of here!";
                    //textFadeTimer = defaultTextFadeDuration;
                    break;
                }
            case 31:
                {
                    displayedText.text =
                        "Are you out of your\n" +
                        "stinking mind?!";
                    break;
                }
            case 32:
                {
                    displayedText.text =
                        "Uhhhh... YEAH?!";
                    break;
                }
            case 35:
                {
                    displayedText.text =
                        "Ah ha ha ho!\n" +
                        "Are you fast";
                    break;
                }
            case 36:
                {
                    displayedText.text =
                        "enough to dodge\n" +
                        "this?!";
                    break;
                }
            case 37:
                {
                    displayedText.text =
                        "Hey! That's\n" +
                        "my line!!";
                    break;
                }
            case 100:
                {
                    displayedText.text =
                        "Game Message Event Triggered.";
                    break;
                }

            case 101:
                {
                    displayedText.text =
                        "Ahhhhhh!";
                    break;
                }
            case 102:
                {
                    displayedText.text =
                        "Oh nooo!";
                    break;
                }
            case 103:
                {
                    displayedText.text =
                        "...";
                    break;
                }
            case 104:
                {
                    displayedText.text =
                        "Is this some sort of\n" +
                        "Genjutsu?";
                    break;
                }
            case 105:
                {
                    displayedText.text =
                        "What a ride, my head\n" +
                        "hurts...";
                    break;
                }
            case 106:
                {
                    displayedText.text =
                        "Ow! That smarts...\n" +
                        "Where am I?";
                    break;
                }
            case 107:
                {
                    displayedText.text =
                        "It seems I have company...";
                    break;
                }
            case 108:
                {
                    displayedText.text =
                        "Yo ninja-dude, nice\n" +
                        "threads!";
                    break;
                }
            case 109:
                {
                    displayedText.text =
                        "Do you guys work for\n" +
                        "Eggman?";
                    break;
                }
            case 110:
                {
                    displayedText.text =
                        "Egg-what?";
                    break;
                }
            case 111:
                {
                    displayedText.text =
                        "You are mistaken, creature\n" +
                        "Begone before you get hurt.";
                    break;
                }
            case 112:
                {
                    displayedText.text =
                        "What?! I don't know what's\n" +
                        "going on but I don't like\n" +
                        "it!";
                    break;
                }
            case 113:
                {
                    displayedText.text =
                        "I also don't like your\n" +
                        "attitude ninja-dude!\n";
                    break;
                }
            case 114:
                {
                    displayedText.text =
                        "Can everyone PLEASE\n" +
                        "calm down?";
                    break;
                }
            case 115:
                {
                    displayedText.text =
                        "This creature has\n" +
                        "a death wish. I shall\n" +
                        "grant it...";
                    break;
                }


            default:
                {
                    //
                    break;
                }


        }

	}
}
