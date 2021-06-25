using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    private int depth = 21;

    private int width = 256;
    private int height = 256;
    private float scale;
    private int inverse;

    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(0.0f, 8.0f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain (TerrainData terrainData)
    {
        inverse = Random.Range(0, 2);
        print(inverse);

        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, 2);

        terrainData.SetHeights(0, 0, generateHeights(inverse));
        

        return terrainData;
    }

    float[,] generateHeights(int inv)
    {
        float[,] heights = new float[width, height];

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(0, y);
                
                if(inverse == 1)
                {
                    heights[x, y] = (1 - heights[x, y]) - heights[x,y];
                }
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float yCoord = (float)y / height * scale;

        return Mathf.PerlinNoise(0f, yCoord);
    }

}
