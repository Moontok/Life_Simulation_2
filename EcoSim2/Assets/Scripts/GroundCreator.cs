using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GroundCreator : MonoBehaviour
{

    [SerializeField] int landSize = 10;

    [SerializeField] GameObject waterTile = null;
    [SerializeField] GameObject grassTile = null;
    [SerializeField] GameObject dirtTile = null;

    [SerializeField] float tileSize = 1f;
    [SerializeField] Vector3 tileLocation = Vector3.zero;

    void Start() 
    {
        GenerateLand();
    }

    public void GenerateLand()
    {
        for (int i = 0; i < landSize; i++)
        {
            Debug.Log($"Placing tile: {i}");
            Instantiate(waterTile, tileLocation, Quaternion.identity, this.gameObject.transform);
            //tileLocation.x += tileSize;
        }
        
    }


}
