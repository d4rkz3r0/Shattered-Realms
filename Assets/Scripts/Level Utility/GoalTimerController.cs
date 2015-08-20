using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalTimerController : MonoBehaviour
{
    public float levelGoalTime;
    private float goalTimer;
    private Text goalTimerText;

    private bool isFlashing;
    private int goalTimerInt;
    private int totalMins;
    private int totalSecs;

    private int timerMins;
    private int timerSecs;


	// Use this for initialization
	void Start () 
    {
        goalTimerText = GetComponent<Text>();
        goalTimer = levelGoalTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(goalTimer > 0.0f)
        {
            goalTimer -= Time.deltaTime;
        }

        if (goalTimer < 0.1f)
        {
            goalTimer = 0.0f;
        }

        if(goalTimer <= 0.0f)
        {
            goalTimerText.color = Color.red;
        }

        goalTimerInt = (int)Mathf.Round(goalTimer);
        timerSecs = goalTimerInt % 60;
        totalMins = goalTimerInt / 60;
        timerMins = totalMins % 60;

        if (timerSecs <= 9 && timerSecs >= 0)
        {
            goalTimerText.text = "" + timerMins + ":" + "0" + timerSecs;
        }
        else
        {
            goalTimerText.text = "" + timerMins + ":" + timerSecs;
        }
    }

    //Not Needed but JIC
    public void ResetTimer()
    {
        goalTimer = levelGoalTime;
    }
}
