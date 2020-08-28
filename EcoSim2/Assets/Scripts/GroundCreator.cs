using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[System.Serializable]
public class GroundCreator : MonoBehaviour
{

    [SerializeField] Vector2Int landSize = new Vector2Int(1,1);
    [SerializeField] GameObject[] tiles = new GameObject[0];
    [SerializeField] float tileSize = 1f;
    [SerializeField] float xOrg = 0;
    [SerializeField] float yOrg = 0;
    [SerializeField] float noiseScale = 1f;    

    [SerializeField] bool autoUpdate = true;
    
    [SerializeField] [Range(0,1)] float band1 = .3f;
    [SerializeField] [Range(0,1)] float band2 = .6f;
    
    Vector3 startingTile = Vector3.zero;
    Vector3 currentTile = Vector3.zero;
    
    void Update() 
    {
        CalcStartingTile();

        if(Selection.Contains(this.gameObject) && this.isActiveAndEnabled && autoUpdate) 
            GenerateLand();

    }

    public void GenerateLand()
    {
        DeleteLand();

        float[,] tileNoise = CalcNoise();
        GameObject tileToSet = null;

        for (int x = 0; x < landSize.x; x++)
        {
            currentTile.z = startingTile.z;
            for (int z = 0; z < landSize.y; z++)
            {
                float tileNoiseSample = tileNoise[z,x];
                if(tileNoiseSample < band1) tileToSet = tiles[0];
                else if(tileNoiseSample < band2) tileToSet = tiles[1];
                else tileToSet = tiles[2];

                GameObject tile = Instantiate(tileToSet, currentTile, Quaternion.identity, this.gameObject.transform);
                tile.transform.localScale = new Vector3(tileSize, 1, tileSize);
                currentTile.z += tileSize;                
            }
            currentTile.x += tileSize;
        }        
    }

    public void DeleteLand()
    {
        List<GameObject> children = new List<GameObject>();
        
        foreach (Transform child in this.transform)
        {
            children.Add(child.gameObject);
        }
        foreach (GameObject child in children)
        {
            DestroyImmediate(child);
        }
        currentTile = startingTile;
    }

    float[,] CalcNoise()
    {        
        float [,] tileNoise = new float[landSize.y, landSize.x];
        float sample = 0f;

        for (int y = 0; y < landSize.y; y++)
        {
            for (int x = 0; x < landSize.x; x++)
            {
                float xCoord = xOrg + (float)x / (float)landSize.x * noiseScale;
                float yCoord = yOrg + (float)y / (float)landSize.y * noiseScale;
                sample = Mathf.PerlinNoise(xCoord, yCoord);
                tileNoise[y, x] = sample;                
            }
        }
        return tileNoise;
    }

    void CalcStartingTile()
    {
        float coordx = this.transform.position.x - landSize.x * tileSize / 2 + tileSize / 2;
        float coordy = this.transform.position.y;
        float coordz = this.transform.position.z - landSize.y * tileSize / 2 + tileSize / 2;

        startingTile = new Vector3(coordx, coordy, coordz);
    }

    void OnValidate() 
    {
        landSize.x = Mathf.Max(landSize.x, 1);
        landSize.y = Mathf.Max(landSize.y, 1);
        tileSize = Mathf.Max(tileSize, 0);
    }
}
