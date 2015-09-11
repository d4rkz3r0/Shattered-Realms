using UnityEngine;
using System.Collections;

public class GoalTimerAnimation : MonoBehaviour
{

	void Start ()
    {
	
	}
	
	void Update () 
    {
	
	}

    public void EndGoalTimerAnimationEvent()
    {
        GetComponent<Animator>().enabled = false;
    }
}
