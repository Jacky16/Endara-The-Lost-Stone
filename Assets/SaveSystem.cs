using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerMovement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/Player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("No esta el archivo");
            return null;
        }
    }
}
