using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKnight : ChessPiece
{

    // Use this for initialization
    public void KnightMove(int x, int y, int z, ref bool[,,] r)
    {
        if (x >= 0 && x < 8 && y >= 0 & y < 8 && z >= 0 & z < 8)
        {
            ChessPiece c;
            c = MyBoardManager.Instance.ChessPieces[x, y,z];
            if (c == null)
            {
                r[x, y, z] = true;
            }
            else if (isWhite != c.isWhite)
            {

                r[x, y, z] = true;

            }
        }
    }
    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8,8];
        //NorthWestUp
        KnightMove(CurrentX - 1, CurrentY + 2, CurrentZ + 1, ref r);
        //NorthEastUp
        KnightMove(CurrentX + 1, CurrentY + 2, CurrentZ + 1, ref r);
        //EastNorthUp
        KnightMove(CurrentX + 2, CurrentY + 1, CurrentZ + 1, ref r);
        //NorthSouthUp
        KnightMove(CurrentX + 2, CurrentY - 1, CurrentZ + 1, ref r);

        //NorthWestUp
        KnightMove(CurrentX + 1, CurrentY - 2, CurrentZ + 1, ref r);
        //NorthEastUp
        KnightMove(CurrentX - 1, CurrentY - 2, CurrentZ + 1, ref r);
        //EastNorthUp
        KnightMove(CurrentX - 2, CurrentY + 1, CurrentZ + 1, ref r);
        //NorthSouthUp
        KnightMove(CurrentX - 2, CurrentY - 1, CurrentZ + 1, ref r);

        //NorthWestDown
        KnightMove(CurrentX + 1, CurrentY - 2, CurrentZ - 1, ref r);
        //NorthEastDown
        KnightMove(CurrentX - 1, CurrentY - 2, CurrentZ - 1, ref r);
        //EastNorthDown
        KnightMove(CurrentX - 2, CurrentY + 1, CurrentZ - 1, ref r);
        //NorthSouthDown
        KnightMove(CurrentX - 2, CurrentY - 1, CurrentZ - 1, ref r);

        //NorthWestDown
        KnightMove(CurrentX - 1, CurrentY + 2, CurrentZ - 1, ref r);
        //NorthEastDown
        KnightMove(CurrentX + 1, CurrentY + 2, CurrentZ - 1, ref r);
        //EastNorthDown
        KnightMove(CurrentX + 2, CurrentY + 1, CurrentZ - 1, ref r);
        //NorthSouthDown
        KnightMove(CurrentX + 2, CurrentY - 1, CurrentZ - 1, ref r);

        //UpNorthWest
        KnightMove(CurrentX - 1, CurrentY + 1, CurrentZ + 2, ref r);
        //UpNorthEast
        KnightMove(CurrentX + 1, CurrentY + 1, CurrentZ + 2, ref r);
        //UpSouthWest
        KnightMove(CurrentX - 1, CurrentY - 1, CurrentZ + 2, ref r);
        //UpSouthEast
        KnightMove(CurrentX + 1, CurrentY - 1, CurrentZ + 2, ref r);

        //DownNorthWest
        KnightMove(CurrentX - 1, CurrentY + 1, CurrentZ - 2, ref r);
        //DownNorthEast
        KnightMove(CurrentX + 1, CurrentY + 1, CurrentZ - 2, ref r);
        //DownSouthWest
        KnightMove(CurrentX - 1, CurrentY - 1, CurrentZ - 2, ref r);
        //DownSouthEast
        KnightMove(CurrentX + 1, CurrentY - 1, CurrentZ - 2, ref r);

        return r;

    }
}
