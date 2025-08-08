using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    public Transform Map;
    public GameObject floorTile;
    public GameObject wallTile;

    // Start is called before the first frame update
    void Start()
    {
        int[,] map = GameManager.Instance.map;

        for(int x = 0; x < map.GetLength(0); x++)
        {
            for(int y  = 0; y < map.GetLength(1); y++)
            {
                Vector3Int floorTilePos = new Vector3Int(x,0,y);
                if (map[x, y] == 1)
                {
                    Instantiate(floorTile, floorTilePos, floorTile.transform.rotation, Map);
                    Instantiate(wallTile,floorTilePos + new Vector3(0,1,0), floorTile.transform.rotation, Map);
                }
                else
                {
                    Instantiate(floorTile,floorTilePos, floorTile.transform.rotation, Map);
                }
            }
        }


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
