using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    private Vector2 offset = Vector2.zero; //Starting Offset
    private Material material;
    

	void Start () 
    {
        material = GetComponent<Renderer>().material;

        //"_MainTex" is the main diffuse texture. This is specified in the Unity Docs.
        offset = material.GetTextureOffset("_MainTex");

	}
	
	void Update ()
    {
        offset += speed * Time.deltaTime; //No matter what the frame rate, consistent speed.

        material.SetTextureOffset("_MainTex", offset);
	}
}
