using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPlayerController:MonoBehaviour
{

    public TerrainTile terrainTile { get; set; }
    public WorldMapPlayerControllerData data;
	public GameObject mara;

	void Start()
	{
		if (GameData.data.playerControllerData != null) {
			this.data = GameData.data.playerControllerData;
		} else {
			this.data = GameData.data.playerControllerData;
		}
		initalizeMara();
	}
		
    public void initalizeMara()
    {
		this.terrainTile = WorldMap.worldMap.getTerrainTile(data.position);
        if (terrainTile == null)
        {
            this.terrainTile = WorldMap.worldMap.getTerrainTile(new Point(3, .25f, 4));
        }
        updatePosition(terrainTile);
    }

    private void updatePosition(TerrainTile newTerrain)
    {
        data.position = newTerrain.position;
        data.position = new Point(data.position.x, data.position.y + .5f, data.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (terrainTile.westTerrain != null)
            {
                updatePosition(terrainTile.westTerrain);
				mara.transform.position = data.position.vector3;
                //terrainTile.mara = null;
                terrainTile = terrainTile.westTerrain;
                //terrainTile.mara = this;

            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (terrainTile.northTerrain != null)
            {
                updatePosition(terrainTile.northTerrain);
				mara.transform.position = data.position.vector3;
                //terrainTile.mara = null;
                terrainTile = terrainTile.northTerrain;
                //terrainTile.mara = this;

            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (terrainTile.eastTerrain != null)
            {
                updatePosition(terrainTile.eastTerrain);
				mara.transform.position = data.position.vector3;
                //terrainTile.mara = null;
                terrainTile = terrainTile.eastTerrain;
                //terrainTile.mara = this;

            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (terrainTile.southTerrain != null)
            {
                updatePosition(terrainTile.southTerrain);
				mara.transform.position = data.position.vector3;
                //terrainTile.mara = null;
                terrainTile = terrainTile.southTerrain;
                //terrainTile.mara = this;

            }
        }
    }
}

[System.Serializable]
public class WorldMapPlayerControllerData
{
    public Point position = new Point(3, .25f, 4);
}