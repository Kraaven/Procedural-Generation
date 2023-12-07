using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public GameObject defaultTile;

    public int xsize;

    public int ysize;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < xsize; i++)
        {
            for (int j = 0; j < ysize; j++)
            {
                Instantiate(defaultTile, new Vector2((i*0.64f + transform.position.x),(j*0.64f+transform.position.y)),quaternion.identity);
            }
        }
    }

  
}
