using UnityEngine;
using System.Collections;

public class GameMessage : MonoBehaviour
{
    public int textSelection;

	void Start () 
    {
        //textSelection = 100;
	}
	
	void Update () 
    {
	    
	}

    void OnTriggerStay2D(Collider2D other)
    {
           if(other.tag == "Player")
           {
               MessageController.textSelection = textSelection;
           }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            MessageController.textSelection = 0;
        }
    }
}
