using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBishop : ChessPiece
{

    // Use this for initialization
    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8,8];
        


        
        ChessPiece c;
        int i, j , z;

        //NorthWestUp

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i--;
            j++;
            z++;
            if (i < 0 || j > 7 || z > 7)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[i, j , z];
            if (c == null)
            {
                r[i, j , z] = true;
            }
            else
            {
                if (isWhite != c.isWhite)
                {
                    r[i, j , z] = true;
                }
                break;
            }




        }
        
        //NorthWestDown

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i--;
            j++;
            z--;
            if (i < 0 || j >= 8 || z < 0)
                break;
            c = MyBoardManager.Instance.ChessPieces[i, j, z];
            if (c == null)
            {
                r[i, j, z] = true;
            }
            else
            {
                if (isWhite != c.isWhite)
                {
                    r[i, j, z] = true;
                }
                break;
            }




        }

        
        
        //NorthEastUp

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {
            i++;
            j++;
            z++;
            if (i > 7 || j > 7 || z > 7)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[i, j, z];
            if (c == null)
            {
                r[i, j, z] = true;
            }
            else
            {


                if (isWhite != c.isWhite)
                {

                    r[i, j,z] = true;

                }

                break;
            }




        }
        ///*
        //NorthEastDown

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {
            i++;
            j++;
            z--;
            if (i >= 8 || j >= 8 || z < 0)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[i, j, z];
            if (c == null)
            {
                r[i, j, z] = true;
            }
            else
            {


                if (isWhite != c.isWhite)
                {

                    r[i, j, z] = true;

                }

                break;
            }




        }
        
        //SouthWestUp

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i--;
            j--;
            z++;
            if (i < 0 || j < 0 || z>=8)
            {

                break;

            }

            c = MyBoardManager.Instance.ChessPieces[i, j,z];
            if (c == null)
            {
                r[i, j,z] = true;

            }
            else
            {


                if (isWhite != c.isWhite)
                {

                    r[i, j,z] = true;

                }

                break;
            }




        }
        //SouthWestDown

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i--;
            j--;
            z--;
            if (i < 0 || j < 0 || z < 0)
            {

                break;

            }

            c = MyBoardManager.Instance.ChessPieces[i, j, z];
            if (c == null)
            {
                r[i, j, z] = true;

            }
            else
            {


                if (isWhite != c.isWhite)
                {

                    r[i, j, z] = true;

                }

                break;
            }




        }

        
        //SouthEastUp

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i++;
            j--;
            z++;
            if (i >= 8 || j < 0|| z >=8)
            {

                break;

            }

            c = MyBoardManager.Instance.ChessPieces[i, j, z];
            if (c == null)
            {
                r[i, j,z] = true;

            }
            else
            {


                if (isWhite != c.isWhite)
                {

                    r[i, j,z] = true;

                }

                break;
            }




        }
        //SouthEastDown

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i++;
            j--;
            z--;
            if (i >= 8 || j < 0 || z < 0)
            {

                break;

            }

            c = MyBoardManager.Instance.ChessPieces[i, j, z];
            if (c == null)
            {
                r[i, j, z] = true;

            }
            else
            {


                if (isWhite != c.isWhite)
                {

                    r[i, j, z] = true;

                }

                break;
            }




        }
        //*/
        return r;

    }
}
