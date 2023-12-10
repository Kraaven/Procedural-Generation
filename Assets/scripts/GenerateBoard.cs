using System;
using System.Collections;
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
    public GameObject UserButton;
    public bool watch;
    public float GenerationSpeed;

    public GameObject[,] tilepositions;
    // Start is called before the first frame update

    public void Start()
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
            }
        }
    }

    public void StartGeneration()
    {
        
        UserButton.SetActive(false);
        tilepositions[Random.Range(0, xsize), Random.Range(0, ysize)].GetComponent<GenerateTile>().collapse();
        GenerationSpeed /= 100; 
        StartCoroutine(CollapseTile());  
        

    }

    IEnumerator CollapseTile()
    {
        while (count < xsize * ysize *2)
        {
            GameObject tile = tilepositions[Random.Range(0, xsize), Random.Range(0, ysize)];
            tile.GetComponent<GenerateTile>().collapse();
            yield return new WaitForSeconds(GenerationSpeed);
        }
        
    }
    
    
}
