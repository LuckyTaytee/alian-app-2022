using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Instance
    private static SaveManager _instance;
    public static SaveManager Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveManager>();
                if(_instance == null)
                {
                    _instance = new GameObject("Spawned SaveManager", typeof(SaveManager)).GetComponent<SaveManager>();
                }
            }

            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public SaveState State { get => state; set => state = value; }
    #endregion

    [Header("Logic")]
    [SerializeField] private string savefileName = "data.ss";
    [SerializeField] private bool loadOnStart = true;
    private SaveState state;
    private BinaryFormatter formatter;

    private void Start()
    {
        //Initialize the formatter, make this script persists
        formatter = new BinaryFormatter();
        //DontDestroyOnLoad(this.gameObject);

        //If loadOnStart is toggled, try loading our save file
        if(loadOnStart)
            Load();
    }

    public void Save()
    {
        // If theres no previous state loaded, create a new one
        if (state == null)
            state = new SaveState();

        // Set the time at whice we've tried saving
        state.LastSaveTime = System.DateTime.Now;

        using (var file = new FileStream(savefileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(file, state);
                file.Close();
            }

        // Open a physical file, on your disk to hold the save
        // var file = new FileStream(savefileName, FileMode.OpenOrCreate, FileAccess.Write);
        // formatter.Serialize(file, state);
        // file.Close();
    }

    public void Load()
    {
        // Open a physical file, on your disk to hold the save
        try
        {
            using (var file = new FileStream(savefileName, FileMode.Open, FileAccess.Read))
                {
                    state = (SaveState)formatter.Deserialize(file);
                    file.Close();
                }
            
            // var file = new FileStream(savefileName, FileMode.Open, FileAccess.Read);
            // // If we found the file, open and read it
            // state = (SaveState)formatter.Deserialize(file);
            // file.Close();
        }
        catch
        {
            Debug.Log("No save file found, creating a new entry...");
            Save();
        }
    }
}
