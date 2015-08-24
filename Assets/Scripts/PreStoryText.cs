using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreStoryText : MonoBehaviour
{
    public static int textIndex;
    private float scrollSpeed;
    private Text currText;

    void Start () 
    {
        currText = GetComponent<Text>();
        textIndex = 0;
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    switch(textIndex)
        {
            case 0:
                {
                    currText.color = Color.white;
                    currText.text = "A magic force ripples throughout the timeline...\n\n" +
                        "Paradoxes are being created and realms from\n" +
                        "multiple universes are being merged...\n\n" +
                        "Elsewhere in a sunny, grassy location,\n" +
                        "a certain hedgehog is enjoying a much needed vacation...";
                    break;
                }
            case 1:
                {
                    currText.color = Color.black;
                    //currText.rectTransform.position = new Vector3(currText.rectTransform.position.x, 1061.0f, currText.rectTransform.position.z);
                    currText.text = "Sonic: \"After collecting a shitload of\n" +
                        "rings for the thousandth time, it's time\n" +
                        "to kickback for some much needed R&R!\"";
                        break;
                }
            case 2:
                {
                    currText.color = Color.white;
                    currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sonic: \"Awww yea, Walker: Texas\n" +
                        " Ranger is on! Amy get me another Martini!\"";
                    break;
                }
            case 3:
                {
                    currText.color = Color.white;
                    currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sonic: \"Awww yea, Walker: Texas\n" +
                        " Ranger is on! Amy get me another Martini!\"";
                    break;
                }
        }
	}
}
