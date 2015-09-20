using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoMarkerController : MonoBehaviour
{
    public bool shouldFlash;
    private float displayTime = 2.5f;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        //Itachi Marker

        if(Application.loadedLevel == 7 ||
           Application.loadedLevel == 8 ||
           Application.loadedLevel == 9)
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/GoMarker") as RuntimeAnimatorController;
        }
        //Cyborg Marker
        if (Application.loadedLevel == 10 ||
           Application.loadedLevel == 11 ||
           Application.loadedLevel == 12)
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/cyborgGoMarker") as RuntimeAnimatorController;
        }
        //Sonic Marker
        if (Application.loadedLevel == 13 ||
           Application.loadedLevel == 14 ||
           Application.loadedLevel == 15)
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/sonicGoMarker") as RuntimeAnimatorController;
        }
        //Mario Marker
        if(Application.loadedLevel == 16)
        {
            //To Be Created
            return;
        }
        shouldFlash = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(displayTime >= 0.0f)
        {
            displayTime -= Time.deltaTime;
        }

        if(displayTime <= 0.0f)
        {
            shouldFlash = false;
        }
        if (shouldFlash)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
