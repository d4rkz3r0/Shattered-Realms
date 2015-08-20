using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    public float timeToCompleteLevel;
    private float levelTimer;
    private Text timeRemainingText;

    private int levelTimerInt;
    private int totalMins;
    private int totalSecs;


    private int timerMins;
    private int timerSecs;


	void Start ()
    {
        timeRemainingText = GetComponent<Text>();
        levelTimer = timeToCompleteLevel;
	}
	
	void Update () 
    {
        if(levelTimer > 0.0f)
        {
            levelTimer -= Time.deltaTime;
        }
        
        if (levelTimer <= 0.0f)
        {
            //Kill and Respawn
            HealthManager.DepleteHealth();
        }

        levelTimerInt = (int)Mathf.Round(levelTimer);
        timerSecs = levelTimerInt % 60;
        totalMins = levelTimerInt / 60;
        timerMins = totalMins % 60;

        if(timerSecs <= 9 && timerSecs >= 0)
        {
            timeRemainingText.text = "" + timerMins + ":" + "0" + timerSecs;
        }
        else
        {
            timeRemainingText.text = "" + timerMins + ":" + timerSecs;
        }	    
	}

    public void ResetTimer()
    {
        levelTimer = timeToCompleteLevel;
    }
}
