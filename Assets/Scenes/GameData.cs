using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public WorldMapPlayerControllerData playerControllerData;

	public WorldMap worldMap;

    public static GameData data;
    // Use this for initialization
    void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
            this.playerControllerData = new WorldMapPlayerControllerData();
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, data.playerControllerData.position);
        file.Close();
    }
}
