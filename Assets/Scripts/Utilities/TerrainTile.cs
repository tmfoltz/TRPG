using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class TerrainTile
{
    #region Properties
    public Point position;
    public Unit unit;

    GameObject terrain;
    TerrainTypes terrainType;

    List<GameObject> subTerrain = new List<GameObject>();
    GameObject dirt;

    #region neighboring TerrainTiles
    private TerrainTile NorthTerrain;
    public TerrainTile northTerrain
    {
        get
        {
            return NorthTerrain;
        }
        set
        {
            NorthTerrain = value;
        }
    }
    private TerrainTile SouthTerrain;
    public TerrainTile southTerrain
    {
        get
        {
            return SouthTerrain;
        }
        set
        {
            SouthTerrain = value;
        }
    }
    private TerrainTile EastTerrain;
    public TerrainTile eastTerrain
    {
        get
        {
            return EastTerrain;
        }
        set
        {
            EastTerrain = value;
        }
    }
    private TerrainTile WestTerrain;
    public TerrainTile westTerrain
    {
        get
        {
            return WestTerrain;
        }
        set
        {
            WestTerrain = value;
        }
    }
    #endregion
    #endregion

    #region Public
    public TerrainTile(Point position, GameObject terrain, TerrainTypes terrainType, GameObject dirt)
    {
        this.position = position;
        this.terrain = terrain;
        this.terrainType = terrainType;
        this.dirt = dirt;
        generateTile();
    }

    #endregion
    #region private
    private void generateTile()
    {
        terrain = (GameObject)UnityEngine.MonoBehaviour.Instantiate(terrain, position.vector3, Quaternion.identity);
        if (terrainType == TerrainTypes.Forrest)
        {
            terrain.transform.Rotate(0, 90 * UnityEngine.Random.Range(0, 3), 0);
        }
        int elevationCount = 1;
        while (position.y > elevationCount)
        {
            Vector3 subTerrainV3 = new Vector3(position.x, elevationCount, position.z);
            GameObject ground = (GameObject)UnityEngine.MonoBehaviour.Instantiate(dirt, subTerrainV3, Quaternion.identity);
            subTerrain.Add(ground);
            elevationCount += 1;
        }

    }
    #endregion
}