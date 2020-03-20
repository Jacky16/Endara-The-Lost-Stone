using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public PlayerLifeManager player;
    public Transform[] objectsTransforms;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        print(Application.persistentDataPath + "/game_save/game_data.data");
    }
    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "game_save");
    }
    public void SaveGame()
    {
        string path = Application.persistentDataPath + "/game_save/game_data.data";

        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path,FileMode.OpenOrCreate);
        SaveData data = new SaveData();
        SavePlayer(data);
        file.Close();

        string jsonPlayer = JsonUtility.ToJson(player);
        bf.Serialize(file, jsonPlayer);
        file.Close();
    }
    void SavePlayer(SaveData data)
    {

    }

    [System.Serializable]
    public class Data
    {
        public Vector3 positionPlayer;
        public int lifePlayer;
    }
}
