using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageController : MonoBehaviour 
{
    public static int textSelection;
    private Text displayedText;
	private float timer;
    private MasterController player;

	private bool pressedUp;
    private bool tutAudio1;

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

        if(Application.loadedLevel == 7)
        {
            tutAudio1 = false;
            player = FindObjectOfType<MasterController>();
        }
        else if(Application.loadedLevel == 9)
        {
            player = FindObjectOfType<MasterController>();
        }
        else
        {
            player = null;
        }
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
            //case 1:
            //    {
            //       displayedText.text =
            //            "Welcome To the Tutorial!";
            //        break;
            //    }
            //case 2:
            //    {

            //        displayedText.text =
            //            "Press A to Jump.";
		
				
            //        break;
            //    }
            //case 3:
            //    {
            //        displayedText.text =
            //            "Press A twice to Double Jump.";
            //        break;
            //    }
            case 4:
                {
                    displayedText.text =
                         "Damage Treasure Chests to\n" +
                          "see what's inside!";
                    break;
                }
            //case 5:
            //    {
            //        displayedText.text =
            //            "This is a practice enemy,\n" +
            //            "Practice your abilities on him...";
            //        break;
            //    }
            //case 6:
            //    {
            //        displayedText.text =
            //            "Cyborg's 1st ability is\n" +
            //            "Blast. It knockbacks and\n" +
            //            "applies stun. Use it with X.";
            //        break;
            //    }
            //case 7:
            //    {
            //        displayedText.text =
            //            "Cyborg's X has shorter range but more power.\nAnd Sonic's even more!";
            //        //displayedText.text =
            //        //    "Press Q,W,E,R to use your abilities.";
            //        break;
            //    }
            //case 8:
            //    {
            //        displayedText.text =
            //            "Press RT for each characters' movement ability.";
            //        //displayedText.text =
            //        //    "Reach the end of the level\nif you can.";
            //        break;
            //    }
            //case 9:
            //    {
            //        displayedText.text =
            //            "Cyborg's Charge damages enemies.";
            //        //displayedText.text =
            //        //    "Hazards and Enemies will try to stop you.";
            //        break;
            //    }
            //case 10:
            //    {
            //        displayedText.text =
            //            "Itachi's Blink works horizontally and vertically.";
            //        //displayedText.text =
            //        //    "Good luck!";
            //        break;
            //    }
            case 11:
                {
                    displayedText.text =
                         "Spikes deal damage and apply\n" +
                         "knockback.";
                    break;
                }
            case 12:
                {
                    displayedText.text =
                        "Red Gems replenish your HP.\n" +
                        "Your life is displayed by\n" +
                        "the bar in the top left.";
                    break;
                }
            //case 13:
            //    {
            //        displayedText.text =
            //            "Lost? Signs will point you in the right direction.";
            //        break;
            //    }
            //case 14:
            //    {
            //        displayedText.text =
            //            "Itachi's second ability deflects bullets!\nPress B to use it.";
            //        break;
            //    }
            //case 15:
            //    {
            //        displayedText.text =
            //    "Cyborg's second ability can only be used while in th air!\nPress B to use it.";
            //        break;
            //    }
            case 16:
                {
				if(!pressedUp)
			    {
                    displayedText.text =
                        "Use the Portal by pressing UP\n" +
                        "on the analog stick.";
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
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
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
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
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
                        "";
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
                //Tutorial Text Starts Here
            case 40:
                {
                    displayedText.text =
                    "Welcome to the Tutorial.";
                    break;
                }
            case 41:
                {
                    displayedText.text =
                    "Press A to Jump.";
                    break;
                }
            case 42:
                {
                    displayedText.text =
                    "Press A twice to\n" +
                    "Double Jump.";
                    break;
                }
            case 43:
                {
                    displayedText.text =
                    "Switch between characters\n" +
                    "with LB and RB.";
                    break;
                }
            case 44:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "This ninja has been captured,\n" +
                    "practice Itachi's 1st ability\n"  +
                    "on him by pressing X.";
                    break;
                }
            //case 45:
            //    {
            //        displayedText.text =
            //        "Itachi's 1st Ability is a,\n" +
            //        "ranged fireball. (Light Damage)";
            //        break;
            //    }
            //case 46:
            //    {
                    
            //        displayedText.text =
            //        "Cyborg's 1st Ability is a,\n" +
            //        "short ranged energy blast.\n" +
            //        "(Light Damage w/ Stun & Knockback)";
            //        break;
            //    }
            //case 47:
            //    {
            //        displayedText.text =
            //        "Sonic's 1st Ability is a,\n" +
            //        "ground spin.\n" +
            //        "(Med Damage w/ Knockback)";
            //        break;
            //    }
            case 48:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "Itachi's 2nd Ability is\n" +
                    "Dark Storm. It can reflect\n" +
                    "most projectiles.";
                    break;
                }
            case 49:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "Reflect the kunai\n" +
                    "by pressing B.";
                    break;
                }
            case 50:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "Itachi's 3rd Ability is\n" +
                    "his Tsukuyomi. It slows\n" +
                    "enemies within a radius.";
                    break;
                }
            case 51:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "Slow these fatties\n" +
                    "down by pressing Y!";
                    break;
                }
            case 52:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "Itachi's 4th Ability is\n" +
                    "Blink. It teleports you\n" +
                    "horizontally and vertically.";
                    break;
                }
            case 53:
                {
                    player.currentCharacter = 1;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Itachi") as RuntimeAnimatorController;
                    displayedText.text =
                    "Reach the other side\n" +
                    "without relying on\n" +
                    "jumping and using Blink!";
                    break;
                }
            case 54:
                {
                    displayedText.color = Color.white;
                    displayedText.text =
                    "Tornadoes can either\n" +
                    "be friend or foe!";
                    break;
                }
            case 55:
                {
                    displayedText.color = Color.black;
                    displayedText.text =
                    "Congrats, you made it!";
                    break;
                }
            case 56:
                {
                    player.currentCharacter = 2;
                    displayedText.text =
                    "You can rotate characters\n" + 
                    "by pressing LB and RB.";
                    break;
                }
            case 57:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;

                    displayedText.text =
                    "Cyborg's 1st ability is\n" +
                    "Blast. It knockbacks and\n" +
                    "applies stun. Use it with X.";
                    break;
                }
            case 58:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Help these chit-chatters\n" +
                    "into The Sparta Pit with\n" +
                    "Cyborg's Blast!";
                    break;
                }
            case 59:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    if (!tutAudio1)
                    {
                        GameObject.Find("victoryFanFareSFX").GetComponent<AudioSource>().Play();
                        tutAudio1 = true;
                    }
                    
                    displayedText.text =
                    "That felt good, didn't\n" +
                    "it?";
                    break;
                }
            case 60:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Cyborg's 2nd Ability is\n" +
                    "Quake, it deals massive\n" +
                    "AoE Damage upon landing.";
                    break;
                }
            case 61:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Take a Leap of Quake\n" +
                    "and press B while in Air.";
                    break;
                }
            case 62:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Phew, close one!\n" +
                    "Do you always do what\n" +
                    "a random narrator suggests?";
                    break;
                }
            case 63:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Try using Cyborg's Quake\n" +
                    "again. This time get more\n" +
                    "altitude, trust me!";
                    break;
                }
            case 64:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Use the Tornado to climb\n" +
                    "back up.";
                    break;
                }
            case 65:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "How unfortunate... ;)";
                    break;
                }
            case 66:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Glory awaits! Jump!";
                    break;
                }
            case 67:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Cyborg's 3rd ability is\n" +
                    "Chain Spark, it is used\n" +
                    "by pressing Y.";
                    break;
                }
            case 68:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Chain Spark is most\n" +
                    "effective on groups\n" +
                    "of bunched enemies.";
                    break;
                }
            case 69:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Cyborg's 4th Ability is\n" +
                    "Charge, it is used by\n" +
                    "using RT.";
                    break;
                }
            case 70:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Charge is great for\n" +
                    "countering aggressive\n" +
                    "ground enemies.";
                    break;
                }
            case 71:
                {
                    player.currentCharacter = 2;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Cyborg") as RuntimeAnimatorController;
                    displayedText.text =
                    "Give it a test run\n" +
                    "on these slopes!";
                    break;
                }
            case 72:
                {
                    player.currentCharacter = 3;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                    displayedText.text =
                    "Sonic's 1st ability is\n" +
                    "Backflip. It is used by\n" +
                    "pressing X.";
                    break;
                }
            case 73:
                {
                    player.currentCharacter = 3;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                    displayedText.text =
                    "Sonic's 2nd ability is\n" +
                    "Chaos Activation. It is\n" +
                    "used by pressing B.";
                    break;
                }
            case 74:
                {
                    player.currentCharacter = 3;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                    displayedText.text =
                    "Sonic's 3rd ability is\n" +
                    "Spring. It is used by\n" +
                    "pressing Y.";
                    break;
                }
            case 75:
                {
                    player.currentCharacter = 3;
                    player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/Sonic") as RuntimeAnimatorController;
                    displayedText.text =
                    "Sonic's 4th ability is\n" +
                    "SpinDash. It is used by\n" +
                    "pressing RT.";
                    break;
                }
            case 76:
                {
                    displayedText.text =
                    "To progress through each\n" +
                    "level you must find the\n" +
                    "green Warp Key.";
                    break;
                }
            case 77:
                {
                    displayedText.text =
                    "Once the key is collected\n" +
                    "you can use this portal to\n" +
                    "warp to the next level!";
                    break;
                }
            case 78:
                {
                    displayedText.text =
                    "Press UP on the analog\n" +
                    "stick to use the Portal.";
                    break;
                }
            case 79:
                {
                    displayedText.text =
                    "Warp Key Collected!!";
                    break;
                }
            case 80:
                {
                    displayedText.text =
                    "Gotta go FAAAST!!";
                    break;
                }
            case 99:
                {
                    displayedText.text =
                    "You found the ninja\n" +
                    "scroll! Keep your eyes\n" +
                    "peeled for these!";
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
                //Level 1 End Starting Dialouge
                //Level 1 Start Ending Dialogue
            case 116:
                {
                    displayedText.text =
                        "*Ugh!*";
                    break;
                }
            case 117:
                {
                    displayedText.text =
                        "*Gah!*";
                    break;
                }
            case 118:
                {
                    displayedText.text =
                        "*Uff!*";
                    break;
                }
            case 119:
                {
                    displayedText.text =
                        "You two seem somewhat...\n" +
                        "competent, perhaps we can";
                    break;
                }
            case 120:
                {
                    displayedText.text =
                        "come to an agreement\n" + 
                        "of sorts?";
                    break;
                }
            case 121:
                {
                    displayedText.text =
                        "At this point\n" +
                        "I'm just hungry!";
                    break;
                }
            case 122:
                {
                    displayedText.text =
                        "Yea, I could sure use\n" +
                        "a really spicy Chili Dog";
                    break;
                }
            case 123:
                {
                    displayedText.text =
                        "right about now...";
                    break;
                }
            case 124:
                {
                    displayedText.text =
                        "Hmmmm...battling longer\n" +
                        "would be pointless.";
                    break;
                }
            case 125:
                {
                    displayedText.text =
                        "It seems our worlds\n" +
                        "have been merged...";
                    break;
                }
            case 126:
                {
                    displayedText.text =
                        "Maybe, we should form\n" +
                        "a team!";
                    break;
                }
            case 127:
                {
                    displayedText.text =
                        "I really don't know\n" +
                        "about anything anymore";
                    break;
                }
            case 128:
                {
                    displayedText.text =
                        "but I DO want to get\n" +
                        "to the bottom of this!";
                    break;
                }
            case 129:
                {
                    displayedText.text =
                        "Very well then, follow\n" +
                        "my lead!";
                    break;
                }
            case 130:
                {
                    displayedText.text =
                        "BOOYAH!!";
                    break;
                }
            case 131:
                {
                    displayedText.text =
                        "Piece of cake!!";
                    break;
                }
                //Level 1 End Ending Dialogue

                //Begin Level 2 Sample Text Dialogue
            case 150:
                {
                    displayedText.text =
                        "This place reeks\n" +
                        "of incompetence...";
                    break;
                }
            case 151:
                {
                    displayedText.text =
                        "This seems right\n" +
                        "up your alley\n" +
                        "Itachi!";
                    break;
                }
            case 152:
                {
                    displayedText.text =
                        "Can we get moving?\n" +
                        "I know Eggman is\n" +
                        "behind all this!";
                    break;
                }
            case 153:
                {
                    displayedText.text =
                        "...";
                    break;
                }
            case 154:
                {
                    displayedText.text =
                        "I've found you\n" +
                        "brother, I can\n" +
                        "see everything now!";
                    break;
                }
            case 155:
                {
                    displayedText.text =
                        "Hmm...";
                    break;
                }
                //End Level 2 Sample Text Dialogue

            case 200:
                {
                    displayedText.text =
                        "You think you can stop me?";
                    break;
                }
            case 201:
                {
                    displayedText.text =
                        "You Don't have what it\n" + 
						"takes!\n";
                    break;
                }
            case 202:
                {
                    displayedText.text =
                        "Go ahead and try!\n" +
                        "My minions will stop you!\n";
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
