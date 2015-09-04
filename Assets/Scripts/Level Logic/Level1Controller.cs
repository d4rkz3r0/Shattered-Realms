using UnityEngine;
using System.Collections;

public class Level1Controller : MonoBehaviour
{
    private float event1Timer;
    private float event1Duration;

    private MasterController player;

    void Awake()
    {

    }

	void Start () 
    {
        player = FindObjectOfType<MasterController>();
	}
	
	void Update ()
    {
	
	}
}
