using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateBoard : MonoBehaviour
{
    public GameObject defaultTile;
    [Range(1, 9)] public int collapseThreshold;
    public int xsize;
    public int ysize;
    public int count;

    public GameObject[,] tilepositions;
    // Start is called before the first frame update
    void Start()
    {
        tilepositions = new GameObject[xsize, ysize];
        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                tilepositions[i,j] = Instantiate(defaultTile, new Vector2((i*0.64f + transform.position.x),(j*0.64f+transform.position.y)),quaternion.identity);
                tilepositions[i, j].transform.parent = gameObject.transform;
                tilepositions[i, j].GetComponent<GenerateTile>().position = new Vector2(i, j);
                tilepositions[i, j].GetComponent<GenerateTile>().board = gameObject;
                tilepositions[i, j].GetComponent<GenerateTile>().CT = collapseThreshold;
            }
        }

        tilepositions[Random.Range(0, xsize), Random.Range(0, ysize)].GetComponent<GenerateTile>().collapse();
        StartCoroutine(CollapseTile());
    }

    IEnumerator CollapseTile()
    {
        while (count < xsize * ysize)
        {
            GameObject tile = tilepositions[Random.Range(0, xsize), Random.Range(0, ysize)];
            tile.GetComponent<GenerateTile>().collapse();
            Debug.Log("Tile Of position: "+tile.GetComponent<GenerateTile>().position.x + ", "+tile.GetComponent<GenerateTile>().position.y);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    
}
