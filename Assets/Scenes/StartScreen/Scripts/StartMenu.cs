using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    /// <summary>
    /// Generates a new game
    /// </summary>
    public void NewGame()
    {
#if UNITY_EDITOR
        GameData.data.playerControllerData = new WorldMapPlayerControllerData();
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene("WorldMap", LoadSceneMode.Single);
        
#else
        SceneManager.LoadScene("WorldMap", LoadSceneMode.Single);
#endif
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/gameInfo.dat");
            GameData.data.playerControllerData.position = (Point)bf.Deserialize(file);
            file.Close();
#if UNITY_EDITOR
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("WorldMap", LoadSceneMode.Single);

#else
        SceneManager.LoadScene("WorldMap", LoadSceneMode.Single);
#endif
        }
    }

    /// <summary>
    /// Quits the application
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
