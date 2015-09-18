using UnityEngine;
using System.Collections;

public class Level2Logic : MonoBehaviour 
{
    public float fishJumpHeight;
    private CameraController mainCamera;
	void Start ()
    {
        mainCamera = FindObjectOfType<CameraController>();
	}
	
	void Update ()
    {
        fishJumpHeight = Random.Range(8.5f, 13.5f);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "PinkFish")
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fishJumpHeight);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            mainCamera.IncreaseYBounds();
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mainCamera.ResetYBounds();
        }
    }
}
