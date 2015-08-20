/*Text Database
 *  0  - Debug Text
 *  1  - 10 - Itachi's Abilities
 *  11 - 20 - Cyborg's Abilities
 *  21 - 30 - Giggle's Abilities
 *  50 - 70 - Player HUD Text
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class HUDToolTipMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int textSelectionInt;
    
    public static bool isAbilityText;
    public int fontSize = 20;

    private string toolTipText;
    private int currentCharacter;
    private bool isMousedOver;
    private float rectWidth;
    private float rectHeight;
    private float rectX;
    private float rectY;
    private GUIStyle guiStyleForegroundTextStyle;
    private GUIStyle guiStyleBackgroundTextStyle;
    private MasterController player;

	void Start () 
    {
        player = FindObjectOfType<MasterController>();
        currentCharacter = player.currentCharacter;
        isMousedOver = false;
        rectWidth = 250;
        rectHeight = 300;
        rectX = Screen.width * (1 - rectWidth) * 0.5f;
        rectY = Screen.height * (1 - rectHeight) * 0.5f;

	    guiStyleForegroundTextStyle = new GUIStyle();
        guiStyleForegroundTextStyle.normal.textColor = Color.black;
        guiStyleForegroundTextStyle.alignment = TextAnchor.MiddleCenter;
        guiStyleForegroundTextStyle.wordWrap = true;
        guiStyleForegroundTextStyle.fontSize = fontSize;

        guiStyleBackgroundTextStyle = new GUIStyle();
        guiStyleBackgroundTextStyle.normal.textColor = Color.red;
        guiStyleBackgroundTextStyle.alignment = TextAnchor.MiddleCenter;
        guiStyleBackgroundTextStyle.wordWrap = true;
        guiStyleBackgroundTextStyle.fontSize = fontSize;
	}

    void Update()
    {
        currentCharacter = player.currentCharacter;
        RetrieveText(textSelectionInt);
    }

    void OnGUI()
    {
        if (isMousedOver)
        {
            GUI.Label(new Rect(rectX, rectY + 175, Screen.width * rectWidth, Screen.height * rectHeight),
                               toolTipText, guiStyleForegroundTextStyle);
            GUI.Label(new Rect(rectX - 1, rectY + 176, Screen.width * rectWidth, Screen.height * rectHeight),
                               toolTipText, guiStyleBackgroundTextStyle);
        }
    }

    public void RetrieveText(int textSelection)
    {
        switch (textSelection)
        {
            case 0:
                toolTipText = "Placeholder Text, set the textSelection.";
                break;
            //Q W E R Abilities
            case 1:
                {
                    if (currentCharacter == 1)
                    {
                        toolTipText = @"Q - Fireball
Light Ranged Projectile
Damage: 1
CoolDown: 0.5 Sec";
                    }
                    else if(currentCharacter == 2)
                    {
                        toolTipText = @"Q - Blast
Melee Knockback w/Stun
Damage: 2
CoolDown: 0.45 Sec";
                    }
                    break;
                }
                
            case 2:
                {
                    if (currentCharacter == 1)
                    {
                        toolTipText = @"W - Flame Pillar
Defensive Shield
Reflects Enemy Projectiles
CoolDown: 2.0 Sec";
                    }
                    else if (currentCharacter == 2)
                    {
                        toolTipText = @"W - Quake
AoE Ground Stomp (Can be used while Airborne)
Damage: 2
CoolDown: 3.0 Sec";
                    }
                    break;
                }
                
            case 3:
                {
                    if (currentCharacter == 1)
                    {
                        toolTipText = @"E - Ability Disabled
Taking Suggestions
Damage: N/A
CoolDown: N/A";
                    }
                    else if (currentCharacter == 2)
                    {
                        toolTipText = @"E - Ability Disabled
Taking Suggestions
Damage: N/A
CoolDown: N/A";
                    }
                    break;
                }
                
            case 4:
                {
                    if (currentCharacter == 1)
                    {
                        toolTipText = @"R + Directional Key - Blink
Horizontal & Vertical Teleportation
Can be combined with Double Jump
CoolDown: 0.8 Sec";
                    }
                    else if (currentCharacter == 2)
                    {
                        toolTipText = @"R - Charge
Dash with Damage, Knockback & Stun
Damage: 2
CoolDown: 2.0 Sec";
                    }
                    break;
                }
                
            case 5:
                toolTipText = "";
                break;
            case 6:
                toolTipText = "";
                break;
            case 7:
                toolTipText = "";
                break;
            case 8:
                toolTipText = "";
                break;
            case 9:
                toolTipText = "";
                break;
            case 10:
                toolTipText = "";
                break;
            //Cyborg
            case 11:
                toolTipText = "";
                break;
            case 12:
                toolTipText = "";
                break;
            case 13:
                toolTipText = "";
                break;
            case 14:
                toolTipText = "";
                break;
            case 15:
                toolTipText = "";
                break;
            case 16:
                toolTipText = "";
                break;
            case 17:
                toolTipText = "";
                break;
            case 18:
                toolTipText = "";
                break;
            case 19:
                toolTipText = "";
                break;
            case 20:
                toolTipText = "";
                break;
            //Giggles
            case 21:
                toolTipText = "";
                break;
            case 22:
                toolTipText = "";
                break;
            case 23:
                toolTipText = "";
                break;
            case 24:
                toolTipText = "";
                break;
            case 25:
                toolTipText = "";
                break;
            case 26:
                toolTipText = "";
                break;
            case 27:
                toolTipText = "";
                break;
            case 28:
                toolTipText = "";
                break;
            case 29:
                toolTipText = "";
                break;
            case 30:
                toolTipText = @"This is your XP Bar, it represents the
amount of xp you have collected.";
                break;
            //HUD
            case 50:
                toolTipText = @"This is your HP Bar, if your HP reaches zero,
you will lose collected XP and
respawn. Restore your HP by
collecting Red HP Gems.";
                break;
            case 51:
                toolTipText = @"The is the Level Key slot, there is a key
hidden throughout each level.
You cannot use the Warp Portal
until the key is located.";
                break;
            case 52:
                toolTipText = @"This is your Player Level, level up by
collecting Blue XP Gems and
killing enemies. XP is tallied
upon successful completion of the level.";
                break;
            case 53:
                toolTipText = @"This is the Level Timer, once the timer
reaches zero you will die and 
lose any accrued XP.";
                break;
            case 54:
                toolTipText = @"This is the Goal Timer, if you complete
a level within it's Goal Time
you will be rewarded with Bonus XP
and absolutely nothing else.";
                break;
                //Character Avatar Info
            case 55:
                toolTipText = @"Name: Itachi Uchiha
Series: Naruto
Notes: ""Likes his eggs scrambled.""";
                break;
            case 56:
                toolTipText = @"Name: Victor Stone(Cyborg)
Series: Teen Titans
Notes: ""Booyah!""";
                break;
            case 57:
                toolTipText = @"Name: Ziggs
Game: League Of Legends
Notes: ""Banned from airports.""";
                break;
                //Continue HUD Messages
                case 58:
                toolTipText = @"Try to collect all the XP Gems
without dying.";
                break;
                case 59:
                toolTipText = @"XP Gems Remaining";
                break;
                case 60:
                toolTipText = @"Enemies Remaining";
                break;
        }
}


    public void OnPointerEnter(PointerEventData eventData)
    {
        isMousedOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMousedOver = false;
    }
}