using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class GroundCreator : MonoBehaviour
{

    [SerializeField] int landSize = 10;
    [SerializeField] GameObject[] tiles = new GameObject[0];
    [SerializeField] float tileSize = 1f;
    
    Vector3 startingTile = Vector3.zero;
    Vector3 currentTile = Vector3.zero;

    void Update() 
    {   
        float x = (this.transform.position.x - landSize / 2) * tileSize;
        float y = this.transform.position.y;
        float z = (this.transform.position.z - landSize / 2) * tileSize;

        startingTile = new Vector3(x, y, z);

        if(Selection.Contains(this.gameObject) && this.isActiveAndEnabled) 
            GenerateLand();

    }

    public void GenerateLand()
    {
        DeleteLand();     

        for (int x = 0; x < landSize; x++)
        {
            currentTile.z = startingTile.z;
            for (int z = 0; z < landSize; z++)
            {
                GameObject tile = Instantiate(tiles[0], currentTile, Quaternion.identity, this.gameObject.transform);
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

    void OnValidate() 
    {
        landSize = Mathf.Max(landSize, 0);
        tileSize = Mathf.Max(tileSize, 0);
    }
}
