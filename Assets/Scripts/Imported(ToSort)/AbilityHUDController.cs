using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityHUDController : MonoBehaviour 
{
    public Sprite[] character1AbilitySheet;
    public Sprite[] character2AbilitySheet;
    public Sprite[] character3AbilitySheet;

    private GameObject firstAbilityHUDElement;
    private GameObject secondAbilityHUDElement;
    private GameObject thirdAbilityHUDElement;
    private GameObject fourthAbilityHUDElement;

    private Text firstAbilityText;
    private Text secondAbilityText;
    private Text thirdAbilityText;
    private Text fourthAbilityText;

    private MasterController player;

    private int charToShow;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<MasterController>();
        charToShow = player.currentCharacter;

        firstAbilityHUDElement = GameObject.Find ("Q Ability Image");
        secondAbilityHUDElement = GameObject.Find("W Ability Image");
        thirdAbilityHUDElement = GameObject.Find ("E Ability Image");
        fourthAbilityHUDElement = GameObject.Find("R Ability Image");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Always Update
        charToShow = player.currentCharacter;

        if (charToShow == 1)
        {
            firstAbilityHUDElement.GetComponent<Image>().sprite = character1AbilitySheet[0];
            secondAbilityHUDElement.GetComponent<Image>().sprite = character1AbilitySheet[1];
            thirdAbilityHUDElement.GetComponent<Image>().sprite = character1AbilitySheet[2];
            fourthAbilityHUDElement.GetComponent<Image>().sprite = character1AbilitySheet[3];
        }
        else if(charToShow == 2)
        {
            firstAbilityHUDElement.GetComponent<Image>().sprite = character2AbilitySheet[0];
            secondAbilityHUDElement.GetComponent<Image>().sprite = character2AbilitySheet[1];
            thirdAbilityHUDElement.GetComponent<Image>().sprite = character2AbilitySheet[2];
            fourthAbilityHUDElement.GetComponent<Image>().sprite = character2AbilitySheet[3];
        }
        else if (charToShow == 3)
        {
            firstAbilityHUDElement.GetComponent<Image>().sprite = character3AbilitySheet[0];
            secondAbilityHUDElement.GetComponent<Image>().sprite = character3AbilitySheet[1];
            thirdAbilityHUDElement.GetComponent<Image>().sprite = character3AbilitySheet[2];
            fourthAbilityHUDElement.GetComponent<Image>().sprite = character3AbilitySheet[3];
        }

        else
        {
            Debug.Log("Invalid Character Specified");
        }
	    
	}
}
