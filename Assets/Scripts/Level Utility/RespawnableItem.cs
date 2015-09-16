using UnityEngine;
using System.Collections;

public class RespawnableItem : MonoBehaviour
{
    //Containers
    private Vector3 startingPosition;

	void Start () 
    {
        startingPosition = gameObject.transform.position;
	}
	
	void Update () 
    {
	
	}

    public void ResetSelf()
    {
        gameObject.transform.position = startingPosition;
        gameObject.SetActive(true);
    }
}
