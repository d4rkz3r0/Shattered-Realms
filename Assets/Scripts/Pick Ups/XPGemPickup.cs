///***********************************************************************
//Class: GemPickup.cs
/*Notes:
 * The GemPickup class handles Gem Behavior/Stats.
 * XPToAdd - amount of XP to add. (Will Vary depending on Gem Type/Color)
 * OnTrigger2D() - gem only adds XP if a player picks it up, also cleans up
 * object.
 */
///***********************************************************************
using UnityEngine;
using System.Collections;

public class XPGemPickup : MonoBehaviour
{
    public int XPToAdd;
    private AudioSource gemSFX;

    void Start()
    {
        gemSFX = GetComponentInParent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Only allow the Player To pick up XP Gems
        if (other.GetComponent<MasterController>() == null)
        {   
            return;
        }
        
        XPManager.AddToEarnedXPThisLevel(XPToAdd);
        ++XPGemManager.playerGemCount;
        gemSFX.Play();
        Destroy(gameObject);
    }
}