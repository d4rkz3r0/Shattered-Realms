//There can be only one GM!
//Accessed from any script GameManager.GM.Whatever
//Can be used as a prefab, meaning we can debug levels without having to intialize this
//from the Main Menu New Game button.
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int playerHP;
    public int playerXP;
    public int playerLVL;
    public int levelsCompleted;

    void Awake()
    {
        if(GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }   
    }

    void Start()
    {
        
    }


    void Update()
    {

    }

    public void SaveGame()
    {
        BinaryFormatter fileWriter = new BinaryFormatter();
        //Creates playerStats.dat binary file in "C:\Users\YOURNAME\AppData\LocalLow\DefaultCompany\Shattered Realms"
        FileStream file = File.Create(Application.persistentDataPath + "/playerStats.dat");
        //Create object to hold data to write
        PlayerData fileData = new PlayerData();
        //Fill in class data
        fileData.playerHP = playerHP;
        fileData.playerXP = playerXP;
        fileData.playerLVL = playerLVL;
        fileData.levelsCompleted = levelsCompleted;
        //Actually write to the file
        fileWriter.Serialize(file, fileData);
        //Always close the file when you are finished
        file.Close();

    }

    public void LoadGame()
    {
        //Check if the file exists
        if(File.Exists(Application.persistentDataPath + "/playerStats.dat"))
        {
            BinaryFormatter fileReader = new BinaryFormatter();
            //Open the binary file
            FileStream file = File.Open(Application.persistentDataPath + "/playerStats.dat", FileMode.Open);
            //Extract data into object (needs to be cast to proper type)
            PlayerData fileData = (PlayerData)fileReader.Deserialize(file);
            //Always close the file when you are finished
            file.Close();
            //Assign class variables to GM variables for use in game
            playerHP = fileData.playerHP;
            playerXP = fileData.playerXP;
            playerLVL = fileData.playerLVL;
            levelsCompleted = fileData.levelsCompleted;
        }
    }
}


//Save File Struct
[Serializable]
class PlayerData
{
    public int playerHP;
    public int playerXP;
    public int playerLVL;
    public int levelsCompleted;
}