using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject board;
    public bool[] possibleStates;
    public bool closed;

    public void Awake()
    {
        possibleStates = new []{true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
    }

    public void Start()
    {
        closed = false;
        socketState = new Vector4(0, 0, 0, 0);
    }



    public void collapse()
    {
        int selectState = Random.Range(0, 15);
         setState(selectState);

         if (possibleStates[selectState] == false)
         {
             while (possibleStates[selectState] == false)    
             {
                 selectState = Random.Range(0, 15);
             }
         }
         closed = true;
         setState(selectState);

    }

    public void setState(int state)
    {
        switch (state)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = A;
                socketState = new Vector4(1, 1, 0, 0);
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = B;
                socketState = new Vector4(0, 0, 1, 1);
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = C;
                socketState = new Vector4(0, 0, 1, 0);
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = D;
                socketState = new Vector4(0, 0, 0, 1);
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = E;
                socketState = new Vector4(1, 0, 0, 0);
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = F;
                socketState = new Vector4(0, 1, 0, 0);
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = G;
                socketState = new Vector4(0, 1, 0, 1);
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = H;
                socketState = new Vector4(1, 0, 0, 1);
                break;
            case 8:
                GetComponent<SpriteRenderer>().sprite = I;
                socketState = new Vector4(1, 0, 1, 0);
                break;
            case 9:
                GetComponent<SpriteRenderer>().sprite = J;
                socketState = new Vector4(0, 1, 1, 0);
                break;
            case 10:
                GetComponent<SpriteRenderer>().sprite = K;
                socketState = new Vector4(1, 1, 1, 0);
                break;
            case 11:
                GetComponent<SpriteRenderer>().sprite = L;
                socketState = new Vector4(1, 1, 0, 1);
                break;
            case 12:
                GetComponent<SpriteRenderer>().sprite = M;
                socketState = new Vector4(1, 0, 1, 1);
                break;
            case 13:
                GetComponent<SpriteRenderer>().sprite = N;
                socketState = new Vector4(0, 1, 1, 1);
                break;
            case 14:
                GetComponent<SpriteRenderer>().sprite = O;
                socketState = new Vector4(1, 1, 1, 1);
                break;
            default:
                Debug.Log("Not a possible state, ERROR");
                break;
        }
        Debug.Log("Collapsed Tile");
        Debug.Log(socketState.ToString());
        affect();
        
    }


    public void affect()
    {
        if (closed)
        {
            Debug.Log("Tile ID: "+position.x+" "+position.y+ ", Has filter process");

            if (socketState.x == 0 && position.x != 0)
            {
                board.GetComponent<GenerateBoard>().tilepositions[(int)position.x-1,(int)position.y].GetComponent<GenerateTile>().deleteRIGHT();
            }

            if (socketState.y == 0 && position.x != board.GetComponent<GenerateBoard>().xsize)
            {
                board.GetComponent<GenerateBoard>().tilepositions[(int)position.x+1,(int)position.y].GetComponent<GenerateTile>().deleteLEFT();
            }

            if (socketState.z == 0 && position.y != board.GetComponent<GenerateBoard>().ysize)
            {
                board.GetComponent<GenerateBoard>().tilepositions[(int)position.x,(int)position.y+1].GetComponent<GenerateTile>().deleteDOWN();
            }

            if (socketState.w == 0 && position.y != 0)
            {
                board.GetComponent<GenerateBoard>().tilepositions[(int)position.x,(int)position.y-1].GetComponent<GenerateTile>().deleteUP();
            }
        }
    }
    public void deleteUP()
    {
        possibleStates[0] = false;
        possibleStates[3] = false;
        possibleStates[4] = false;
        possibleStates[5] = false;
        possibleStates[6] = false;
        possibleStates[7] = false;
        possibleStates[11] = false;
        Debug.Log("Tile ID: "+position.x+" "+position.y+ " Has Has Deleted UP");
        Debug.Log(possibleStates.ToString());
    }

    public void deleteDOWN()
    {
        possibleStates[0] = false;
        possibleStates[2] = false;
        possibleStates[4] = false;
        possibleStates[5] = false;
        possibleStates[8] = false;
        possibleStates[9] = false;
        possibleStates[10] = false;
        Debug.Log("Tile ID: "+position.x+" "+position.y+ " Has Has Deleted DOWN");
        Debug.Log(possibleStates.ToString());
    }

    public void deleteLEFT()
    {
        possibleStates[1] = false;
        possibleStates[2] = false;
        possibleStates[3] = false;
        possibleStates[5] = false;
        possibleStates[6] = false;
        possibleStates[9] = false;
        possibleStates[13] = false;
        Debug.Log("Tile ID: "+position.x+" "+position.y+ " Has Has Deleted LEFT");
        Debug.Log(possibleStates.ToString());
    }

    public void deleteRIGHT()
    {
        possibleStates[1] = false;
        possibleStates[2] = false;
        possibleStates[3] = false;
        possibleStates[4] = false;
        possibleStates[7] = false;
        possibleStates[8] = false;
        possibleStates[12] = false;
        Debug.Log("Tile ID: "+position.x+" "+position.y+ " Has Has Deleted RIGHT");
        Debug.Log(possibleStates.ToString());
    }
    
    
}
