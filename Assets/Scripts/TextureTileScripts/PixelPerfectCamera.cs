//PixelPerfectCamera.cs
/* Resizes camera based on the resolution of the game, ensuring crystal clear artwork.
 * Only runs once per game, so if the resolution changes mid game this script will not adjust.
 * 
 * 
*/
using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour 
{
    //Default Pixels to Units for artwork = 1
    public static float pixelsToUnits = 1.0f;
    public static float scale = 1.0f;
    public Vector2 nativeResolution = new Vector2(1024.0f, 768.0f);

    Camera Camera;

    //Called before Start()
    void Awake()
    {
        Camera = GetComponent<Camera>();

        //If 2D Mode (Duh)
        if(Camera.orthographic)
        {
            //Current Height / Native Resolution = Scale
            scale = Screen.height / nativeResolution.y;
            pixelsToUnits *= scale;
            Camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
        }

    }

	void Start () 
    {
	    
	}
	
	void Update () 
    {
	    
	}
}
