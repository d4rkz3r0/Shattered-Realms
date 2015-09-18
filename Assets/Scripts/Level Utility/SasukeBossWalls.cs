using UnityEngine;
using System.Collections;

public class SasukeBossWalls : MonoBehaviour
{
    MasterController player;
    SasukeController sasuke;

	void Start ()
    {
        player = FindObjectOfType<MasterController>();
        sasuke = FindObjectOfType<SasukeController>();
	}
	
	void Update () 
    {
	    
	}
}
