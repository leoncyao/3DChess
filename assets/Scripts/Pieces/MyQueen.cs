    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQueen : ChessPiece
{

    // Use this for initialization
    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8,8];
        ChessPiece c;
        int i, j, z;
        

        //BishopPartOfTheQueen
        //NorthWestUp

        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;
        while (true)
        {

            i--;
            j++;
            z++;
            if (i < 0 || j >= 8 || z >= 8)
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
            if (i >= 8 || j >= 8 || z >= 8)
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
            if (i < 0 || j < 0 || z >= 8)
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
            if (i >= 8 || j < 0 || z >= 8)
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
        //SouthEastDown

       
        i = CurrentX;
        j = CurrentY;
        z = CurrentZ;


        while (true)
        {

            i++;
            j--;
            z--;
            if (i >= 8 || j < 0 || z <= 0)
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


        //Rook Part of the Queen
        
        //East
        i = CurrentX;
        while (true)
        {
            i++;

            if (i >= 8)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[i, CurrentY, CurrentZ];
            if (c == null)
            {

                r[i, CurrentY, CurrentZ] = true;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY, CurrentZ] = true;


                }

                break;
            }

        }

        //West
        i = CurrentX;
        while (true)
        {
            i--;

            if (i < 0)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[i, CurrentY, CurrentZ];
            if (c == null)
            {

                r[i, CurrentY, CurrentZ] = true;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY, CurrentZ] = true;


                }

                break;
            }

        }


        //North
        i = CurrentY;
        while (true)
        {
            i++;

            if (i >= 8)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[CurrentX, i, CurrentZ];
            if (c == null)
            {

                r[CurrentX, i, CurrentZ] = true;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i, CurrentZ] = true;


                }

                break;
            }

        }
        //South
        i = CurrentY;
        while (true)
        {
            i--;

            if (i < 0)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[CurrentX, i, CurrentZ];
            if (c == null)
            {

                r[CurrentX, i, CurrentZ] = true;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i, CurrentZ] = true;


                }

                break;
            }

        }


        //Up
        i = CurrentZ;
        while (true)
        {
            i++;

            if (i >= 8)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, i];
            if (c == null)
            {

                r[CurrentX, CurrentY, i] = true;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, CurrentY, i] = true;


                }

                break;
            }

        }

        //Down
        i = CurrentZ;
        while (true)
        {
            i--;

            if (i < 0)
            {
                break;
            }
            c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, i];
            if (c == null)
            {

                r[CurrentX, CurrentY, i] = true;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, CurrentY, i] = true;


                }

                break;
            }

        }




        return r;

    }
}
