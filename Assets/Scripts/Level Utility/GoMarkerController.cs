using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoMarkerController : MonoBehaviour
{
    public bool shouldFlash;
    private float displayTime = 2.5f;

	// Use this for initialization
	void Start ()
    {
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
