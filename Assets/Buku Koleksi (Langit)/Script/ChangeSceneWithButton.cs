using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public PlayerData player;
    public string saveFile;
    public static ChangeSceneWithButton instance;
    
    public string selectedButterflyPath = "";

    public void Awake()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
        instance = this; 
    }

    public void Start() {
        if (File.Exists(saveFile))
        {
            player = ReadFile();
        }
        else 
        {
            player = new PlayerData();
        }
    }

    public PlayerData ReadFile()
    {
        string fileContents = File.ReadAllText(saveFile);
        // Deserialize the JSON data 
        //  into a pattern matching the GameData class.
        return JsonUtility.FromJson<PlayerData>(fileContents);
    }

    public void writeFile()
    {
        // Serialize the object into JSON and save string.
        player.selectedButterfly = selectedButterflyPath;
        string jsonString = JsonUtility.ToJson(player);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
        Debug.Log(jsonString);
    }


    public void LoadScene(string sceneName)
    {
        writeFile();
        SceneManager.LoadScene(sceneName);
    }

   
}
