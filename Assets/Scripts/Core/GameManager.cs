//There can be only one GM!
//Accessed from any script GameManager.GM.Whatever
//Can be used as a prefab, meaning we can debug levels without having to intialize this
//from the Main Menu New Game button.
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    //Save Files
    //public static List<PlayerData> saveFiles = new List<PlayerData>();
    public static PlayerData saveFile;
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

    public void CreateGame()
    {
        BinaryFormatter fileWriter = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/playerStats.dat"))
        {
            PlayerData fileData = new PlayerData();
            FileStream file = File.Create(Application.persistentDataPath + "/playerStats.dat");
            //Actually write to the file
            fileWriter.Serialize(file, fileData);
            //Always close the file when you are finished
            file.Close();
        }
        else
        {
            Debug.Log("Save File already exists...");
            return;
        }
    }

    public void SaveGame()
    {
        BinaryFormatter fileWriter = new BinaryFormatter();
        //Create object to hold data to write
        PlayerData fileData = new PlayerData();

        //Creates playerStats.dat binary file in "C:\Users\YOURNAME\AppData\LocalLow\DefaultCompany\Shattered Realms"
        if (File.Exists(Application.persistentDataPath + "/playerStats.dat"))
        {
            FileStream file = File.Create(Application.persistentDataPath + "/playerStats.dat");
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
        else
        {
            Debug.Log("No File to Save to!");
            return;
        }
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
        else
        {
            Debug.Log("No Save File to Load!");
            return;
        }
    }

    public void OverwriteGame()
    {
        saveFile = new PlayerData();
    }

    public void DeleteGame()
    {
        if(File.Exists(Application.persistentDataPath + "/playerStats.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerStats.dat");
        }
        else
        {
            Debug.Log("No Save File to Delete...");
        }
    }
}


//Save File Struct
[Serializable]
public class PlayerData
{
    public int playerHP;
    public int playerXP;
    public int playerLVL;
    public int levelsCompleted;

    public PlayerData()
    {
        playerHP = 10;
        playerXP = 0;
        playerLVL = 1;
        levelsCompleted = 0;
    }
}