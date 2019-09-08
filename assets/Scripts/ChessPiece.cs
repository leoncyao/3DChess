using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public int CurrentZ { set; get; }
    public void SetPosition(int x, int y,int z)
    {
        CurrentX = x;
        CurrentY = y;
        CurrentZ = z;

    }
    public bool isWhite;
    public virtual bool[,,] PossibleMove()
    {

        return new bool[8,8, 8];

    }

}

