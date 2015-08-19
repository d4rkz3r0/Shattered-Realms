//TiledBackground.cs
/* Attach this script to any object which will have a texture stretched over it such as a Quad.
 * textureSize = the x/y native resolution of the texture
 * newWidth = X tiling value for the texture
 * newHeight = Y tiling value for the texture
 * Ceil is used to ensure no gaps between the window border and the texture.
 * 
 * 
*/
using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour 
{
    public int textureSize = 32; //Powers of 2 Only 16, 32, 64, 128
    private float newWidth;
    private float newHeight;

    public bool scaleHorizontally = true;
    public bool scaleVertically = true;

	void Start ()
    {
        //Ternary Operator
        //(Condition to Check)   If False Do the left side of : , if True do the Right side of :
        newWidth  = !scaleHorizontally ? 1.0f : Mathf.Ceil(Screen.width / textureSize * PixelPerfectCamera.scale);
        newHeight = !scaleVertically   ? 1.0f : Mathf.Ceil(Screen.height / textureSize * PixelPerfectCamera.scale);

        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1.0f);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1.0f);

	}
	
	void Update () 
    {
	
	}
}
//1782x600