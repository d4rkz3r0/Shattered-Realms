using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FileSelectMenuController : MonoBehaviour
{

    public AudioSource ButtonSelectSFX;

    public GameObject HPTEXTHUDELEMENT;
    public GameObject LVLTEXTHUDELEMENT;



	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        HPTEXTHUDELEMENT.GetComponent<Text>().text = GameManager.GM.playerHP.ToString();
        LVLTEXTHUDELEMENT.GetComponent<Text>().text = GameManager.GM.playerLVL.ToString();
	}

    public void LoadFile()
    {
        GameManager.GM.LoadGame();
    }

    public void SaveFile()
    {
        GameManager.GM.SaveGame();
    }

    public void DeleteFile()
    {
        GameManager.GM.DeleteGame();
    }

    public void CreateFile()
    {
        GameManager.GM.CreateGame();
    }

    public void IncrementValues()
    {
        GameManager.GM.playerHP++;
        GameManager.GM.playerLVL++;
    }

    public void DecrementValues()
    {
        GameManager.GM.playerHP--;
        GameManager.GM.playerLVL--;
    }

    public IEnumerator ChangeScene(int sceneChoice, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameOptionData.currentLevel = sceneChoice;
        Application.LoadLevel(sceneChoice);

    }

    public void ChangeScenes(int sceneChoice)
    {
        ButtonSelectSFX.Play();
        StartCoroutine(ChangeScene(sceneChoice, 1.1f));
    }

}
