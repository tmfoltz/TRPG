using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenu : MonoBehaviour {

    WorldMap worldMap;

    
    public WorldMenu(WorldMap worldMap)
    {
        if(worldMap == null)
        {
            this.worldMap = worldMap;
        }
    }

    public void Resume()
    {
        worldMap.toggleWorldMapMenu();
    }


    public void ReturnToMainMenu()
    {
#if UNITY_EDITOR
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
#else
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
#endif
    }


    public void Save()
    {
        GameData.Save();
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
