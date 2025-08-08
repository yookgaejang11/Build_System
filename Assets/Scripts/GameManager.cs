using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Maze maze;
    public int width = 10;
    public int height = 10;
    public bool[,] occupied;    //true = 타일에 건물 있음
    public bool isBuilding = false; //건물을 지을 수 있는 상태
    public int[,] map;

    private void Awake()
    {
        Instance = this;
        /* map = new int[width, height];

         for (int z = 0; z < height; z++)
         {
             for (int x = 0; x < width; x++)
             {
                 map[x, z] = 0;
             }
         }*/
    }

    public void CreateMaze(int[,] mapData)
    {
        map = mapData;
        occupied = new bool[map.GetLength(0), map.GetLength(1)];
        for (int z = 0; z < map.GetLength(0); z++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[x,z] == 1)
                {
                    occupied[x,z] = true;
                }
            }
        }
    }

    public bool IsAreaFree(Vector2Int start, Vector2Int size)
    {
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                int checkX = start.x + x;
                int checkY = start.y + y;
                if (checkX < 0 || checkY < 0 || checkX >= width || checkY >= height)
                {
                    return false;
                }
                if(occupied[checkX, checkY])
                {
                    return false;
                }
            }
        }
        return true;
    }


    public void OccupyArea(Vector2Int start, Vector2Int size)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                occupied[start.x + x, start.y + y] = true;
            }
        }
    }

    public void DisableArea(Vector2Int start, Vector2Int size)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                occupied[start.x + x, start.y + y] = false;
            }
        }
    }

}
