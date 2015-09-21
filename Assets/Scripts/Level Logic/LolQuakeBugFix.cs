using UnityEngine;
using System.Collections;

public class LolQuakeBugFix : MonoBehaviour
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            yield return new WaitForSeconds(3.1f);
            Destroy(gameObject);
        }
    }
}
