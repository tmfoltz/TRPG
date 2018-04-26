using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class WorldMap : MonoBehaviour
{
    public GameObject dirt;
    public GameObject grass;
    public GameObject forrest;
    public GameObject water;

    public GameObject worldMenu;
	public GameObject mara;
    
	public static WorldMap worldMap;
    List<List<TerrainTile>> terrain = new List<List<TerrainTile>>();


    /// <summary>
    /// Use this for initialization
    /// </summary>
	void Start()
	{
		terrain = generateWorldMap();
		worldMenu.SetActive(false);
		mara = (GameObject)UnityEngine.MonoBehaviour.Instantiate(mara, GameData.data.playerControllerData.position.vector3, Quaternion.identity);
		worldMap = this;
	}

    public TerrainTile getTerrainTile(Point? position)
    {
        if (position != null)
        {
            Point point = position ?? default(Point);
            foreach (List<TerrainTile> tiles in terrain)
            {
                foreach (TerrainTile tile in tiles)
                {
                    if ((tile.position.x == point.x) && (tile.position.z == point.z))
                    {
                        return tile;
                    }
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Generates the world map
    /// </summary>
    /// <returns></returns>
    public List<List<TerrainTile>> generateWorldMap()
    {
        int Width = 150;
        int Height = 150;

        //string filePath = @"C:\Users\tmfoltz\Documents\Unity\The Legend of Mara\Assets\Scenes\WorldMap\worldMap.csv";
        string filePath = @"C:\Users\RDCERTMF\Documents\DF\The Legend of Mara\Assets\Scenes\WorldMap\worldMap.csv";
        string[][] data = File.ReadAllLines(filePath).Select(x => x.Split(',')).ToArray();
        TerrainTile terrainTile;
        List<List<TerrainTile>> terrainTiles = new List<List<TerrainTile>>();
        for (int x = 0; x < Width; x++)
        {
            List<TerrainTile> terrainTileRow = new List<TerrainTile>();
            for (int y = 0; y < Height; y++)
            {
                string terrainType = data[Width - y - 1][x];
				string value = data [Width - y - 1] [x + Width];
				Debug.Log (value);
				float elevation = (float)Math.Round(float.Parse(value)*1.5)/4f;
                Point point = new Point(x, elevation, y);
                switch (terrainType)
                {
                    case "w":
                        terrainTile = new TerrainTile(point, water, TerrainTypes.Water, dirt);
                        break;
                    case "g":
                        terrainTile = new TerrainTile(point, grass, TerrainTypes.Grass, dirt);
                        break;
                    case "m":
                        terrainTile = new TerrainTile(point, dirt, TerrainTypes.Dirt, dirt);
                        break;
                    case "f":
                        terrainTile = new TerrainTile(point, forrest, TerrainTypes.Dirt, dirt);
                        break;
                    default:
                        terrainTile = new TerrainTile(point, dirt, TerrainTypes.Dirt, dirt);
                        break;
                }
                terrainTileRow.Add(terrainTile);
            }
            terrainTiles.Add(terrainTileRow);
        }
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (j + 1 < Height)
                {
                    terrainTiles[i][j].northTerrain = terrainTiles[i][j + 1];
                }
                if (j - 1 >= 0)
                {
                    terrainTiles[i][j].southTerrain = terrainTiles[i][j - 1];
                }
                if (i + 1 < Width)
                {
                    terrainTiles[i][j].eastTerrain = terrainTiles[i + 1][j];
                }
                if (i - 1 >= 0)
                {
                    terrainTiles[i][j].westTerrain = terrainTiles[i - 1][j];
                }
            }
        }

        return terrainTiles;
    }

    public void toggleWorldMapMenu()
    {
        if (worldMenu.activeSelf == true)
        {
            worldMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            worldMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            toggleWorldMapMenu();
        }
    }
}
