using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreStoryText : MonoBehaviour
{
    public static int textIndex;
    private Text currText;
    private AudioBank audioBank;
    private static int audioIndex;
    public bool hasPlayed1;
    public bool hasPlayed2;
    public bool hasPlayed3;
    public bool hasPlayed4;
    public bool hasPlayed5;
    public bool hasPlayed6;
    public bool hasPlayed7;
    public bool hasPlayed8;
    public bool hasPlayed9;
    //private Camera mainCamera;
    //private PreStoryImages image;

    void Start () 
    {
        //image = FindObjectOfType<PreStoryImages>();
        //mainCamera = FindObjectOfType<Camera>();
        hasPlayed1 = false;
        hasPlayed2 = false;
        hasPlayed3 = false;
        hasPlayed4 = false;
        hasPlayed5 = false;
        hasPlayed6 = false;
        hasPlayed7 = false;
        hasPlayed8 = false;
        hasPlayed9 = false;

        audioBank = FindObjectOfType<AudioBank>();
        currText = GetComponent<Text>();
        textIndex = 0;
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            textIndex++;
            
        }

	    switch(textIndex)
        {
            case 0:
                {
                    //mainCamera.GetComponent<Skybox>().enabled = false;
                    //image.currImage = image.imageBank[0];
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
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sonic: \"Awww yea, Walker: Texas\n" +
                        " Ranger is on! Amy get me another Martini!\"";
                    break;
                }
            case 3:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sonic: \"What's going on? It feels\n" +
                        "like the very fabric of time is being ripped apart!\"";
                    break;
                }
            case 4:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "WHOOOSH!\n" +
                        "Sonic: \" AhhhhhhhHHHH! This is sooo horrifying!\"";
                    break;
                }
            case 5:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sonic is warped away to an unknown universe...\n" +
                        "Sonic: \"B-but my Martiniiiiii!!!\"";
                    break;
                }
            case 6:
                {
                    //currText.color = Color.black;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Elsewhere in Jump City...\n" +
                        "BeastBoy: \"This pizza is awful, why am I eating it?\"\n" +
                        "Cyborg: \"Yo dawg, whats good, yea fo\n" +
                        "realz muh boi, BOOYAH!!!\"\n" +
                        "BeastBoy: \"Are you okay CB? \"";
                    break;
                }
            case 7:
                {
                    //currText.color = Color.black;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Cyborg: Something is up with\n" +
                        "the fabric of space, my sensors are going nuts!\"\n" +
                        "BeastBoy: \"Let's get back to the tower, I don't\n" +
                        "feel so good...\"";
                    break;
                }
            case 8:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Later back at the Tower...";
                    break;
                }
            case 9:
                {
                    currText.color = Color.red;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Robin: \"God damn, Kanye West's album is\n" +
                        "pleb tier garbage! Who would willingly listen to this?\"\n";
                    break;
                }
            case 10:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Cyborg: \"Something's going on here\n" +
                        "and I'm going to get to the bottom of it!\"\n" +
                        "BeastBoy: \"Yo, why you trippin CB?\"";
                    break;
                }
            case 11:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Cyborg: \"What the? An earthquake?\"\n" +
                        "Robin: \"A interdimensional portal has opened!\n" +
                        "Titans! We need to track down its location!\"\n" +
                        "Titans! Go!\"";
                    break;
                }
            case 12:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Cyborg: \"Damn it, it's too late!\"\n\n" +
                        "Cyborg: \"Ahhhhhhh! Oh the humanity!!!\"";
                    break;
                }
            case 13:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Cyborg is warped away to an unknown universe...\n" +
                        "Cyborg: \"I didn't even get to finish my pizza!!!\"";
                    break;
                }
            case 14:
                {
                    currText.color = Color.black;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Elsewhere in the Shinobi World...\n" +
                        "*The sounds of kunai and ninja stars clashing echo\n" +
                        "throughout a certain ninja village...*";
                    if (!hasPlayed1)
                    {
                        audioBank.audioDB[0].Play();
                        hasPlayed1 = true;
                    }
                    break;
                }
            case 15:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sasuke: \"I'm done playing along with your parlor tricks...\"";

                    if (!hasPlayed2)
                    {
                        audioBank.audioDB[1].Play();
                        hasPlayed2 = true;
                    }
                    break;
                }
            case 16:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Itachi: \"Confidence is fine... but Sasuke,\n" +
                                    "it appears that you still do not possess\n" +
                                    "the same eyes as I do.\"";

                    if (!hasPlayed3)
                    {
                        audioBank.audioDB[2].Play();
                        hasPlayed3 = true;
                    }
                    break;
                }
            case 17:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Itachi: \"So you just couldn't do it.\n"+
                        "Couldn't kill your best friend.\n" +
                        "And you dare to come here?\n" +
                        "To face me with such weak resolve?\"";
                    if (!hasPlayed4)
                    {
                        audioBank.audioDB[3].Play();
                        hasPlayed4 = true;
                    }
                    break;
                }
            case 18:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sasuke: \"All right, then just hurry it up\n" +
                                    "and try to kill me with your Mangekyo Sharingan.\n" +
                                    "Or am I too strong now for you to dare to test\n" +
                                    "your capabilities against mine?\"";
                    if (!hasPlayed5)
                    {
                        audioBank.audioDB[4].Play();
                        hasPlayed5 = true;
                    }
                    break;
                }
            case 19:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Sasuke: \"What?!\"\n" +
                        "The whole room is shaking?! An earthquake? Now?!\"";
                    if (!hasPlayed6)
                    {
                        audioBank.audioDB[5].Play();
                        hasPlayed6 = true;
                    }
                    break;
                }
            case 20:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Itachi: \"Battling longer would be pointless...\"\n" +
                        "I will investigate this strange phenomenon.\n" +
                    "Sasuke: Wait! Brother, we haven't finished our fight!\"\n" +
                    "Itachi: Don't you dare follow me, or you will regret it...\"";
                    if (!hasPlayed7)
                    {
                        audioBank.audioDB[6].Play();
                        hasPlayed7 = true;
                    }
                    break;
                }
            case 21:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "Itachi is warped away to an unknown universe...\n" +
                        "Itachi: \"Let's see where this leads...\"";
                    if (!hasPlayed8)
                    {
                        audioBank.audioDB[7].Play();
                        hasPlayed8 = true;
                    }
                    break;
                }
            case 22:
                {
                    currText.color = Color.white;
                    //currText.rectTransform.position = new Vector3(157.0f, 713.0f, 0.0f);
                    currText.text = "";
                    if (!hasPlayed9)
                    {
                        audioBank.audioDB[8].Play();
                        hasPlayed9 = true;
                    }
                    break;
                }
        }
	}
}
