using UnityEngine;
using System.Collections;

public class PreStoryImages : MonoBehaviour 
{
    public int imageIndex = 0;
    public Sprite[] imageBank;
    public Sprite currImage;

	// Use this for initialization
	void Start () 
    {
        currImage = GetComponent<Sprite>();   
	}
	
	// Update is called once per frame
	void Update ()
    {
        currImage = imageBank[imageIndex];
	}
}
