using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPlayerController : MonoBehaviour
{

    public TerrainTile terrainTile { get; set; }
    public WorldMapPlayerControllerData data;
    public GameObject mara;

    // Use this for initialization
    void Start()
    {
        if (GameData.data.playerController == null)
        {
            GameData.data.playerController = this;
			if (GameData.data.playerControllerData != null) {
				this.data = GameData.data.playerControllerData;
			} else {
				this.data = GameData.data.playerControllerData;
			}
            initalizeMara();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void initalizeMara()
    {
		this.terrainTile = GameData.data.worldMap.getTerrainTile(data.position);
        if (terrainTile == null)
        {
            this.terrainTile = GameData.data.worldMap.getTerrainTile(new Point(3, .25f, 4));
        }
        updatePosition(terrainTile);
        mara = (GameObject)UnityEngine.MonoBehaviour.Instantiate(mara, data.position.vector3, Quaternion.identity);

        //terrainTile.mara = this;
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