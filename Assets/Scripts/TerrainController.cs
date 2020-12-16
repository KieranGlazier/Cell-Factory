using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TerrainData terrainData = new TerrainData();
        GameObject terrainObject = Terrain.CreateTerrainGameObject(terrainData);
        Vector3 position = Vector3.zero;
        
        Terrain t = terrainObject.GetComponent<Terrain>();
        t.terrainData.heightmapScale.Set(2, 2, 2);
        Debug.Log("");
        
        float divRange = Random.Range(6, 15);
        float tileSize = 20;
        int k = 0;
        float[,] heights = new float[t.terrainData.heightmapResolution, t.terrainData.heightmapResolution];
        for (int i = 0; i < t.terrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < t.terrainData.heightmapResolution; j++)
            {
                //heights[i, j] = k;
                //k++;
                heights[i, j] = Random.Range(-10, 10);
               // heights[i, j] = Mathf.PerlinNoise(((float)i / (float)t.terrainData.heightmapResolution) * tileSize,
                 //   ((float)j / (float)t.terrainData.heightmapResolution) * tileSize) / divRange;
            }
        }
        terrainData.SetHeights(0, 0, heights);
        GameObject terrain = Instantiate(terrainObject, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
