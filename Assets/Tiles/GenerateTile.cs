using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public void Awake()
    {
        possibleStates = new []{true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
        possibleStates[14] = false;
        possibleStates[6] = false;
        possibleStates[7] = false;
        possibleStates[8] = false;
        possibleStates[9] = false;
    }

    public void Start()
    {
        socketState = new Vector4(0, 0, 0, 0);
    }



    public void collapse()
    {
         int selectState = Random.Range(0, 15);
         setState(selectState);

         if (possibleStates[selectState] == false)
         {
             Debug.Log("State: "+ possibleStates[selectState]+", "+"of type: "+ selectState);
         }
         if (possibleStates[selectState] == false)
         {
             while (possibleStates[selectState] == false)    
             {
                 selectState = Random.Range(0, 15);
             }
         }
         setState(selectState);

    }

    public void setState(int state)
    {
        Debug.Log(state.ToString());
        switch (state)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = A;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = B;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = C;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = D;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = E;
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = F;
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = G;
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = H;
                break;
            case 8:
                GetComponent<SpriteRenderer>().sprite = I;
                break;
            case 9:
                GetComponent<SpriteRenderer>().sprite = J;
                break;
            case 10:
                GetComponent<SpriteRenderer>().sprite = K;
                break;
            case 11:
                GetComponent<SpriteRenderer>().sprite = L;
                break;
            case 12:
                GetComponent<SpriteRenderer>().sprite = M;
                break;
            case 13:
                GetComponent<SpriteRenderer>().sprite = N;
                break;
            case 14:
                GetComponent<SpriteRenderer>().sprite = O;
                break;
            default:
                Debug.Log("Not a possible state, ERROR");
                break;
        }
    }
}
