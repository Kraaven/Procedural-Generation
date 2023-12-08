using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTile : MonoBehaviour
{
    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;
    public Sprite E;
    public Sprite F;
    public Sprite G;
    public Sprite H;
    public Sprite I;
    public Sprite J;
    public Sprite K;
    public Sprite L;
    public Sprite M;
    public Sprite N;
    public Sprite O;

    public Vector2 position;

    public Vector4 socketState;

    public bool[] possibleStates;
    public void Start()
    {
        possibleStates = new bool[15]{true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
        socketState = new Vector4(0, 0, 0, 0);
    }



    public void collapse()
    {
        
    }
}
