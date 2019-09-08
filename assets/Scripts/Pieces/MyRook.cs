using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRook : ChessPiece{

    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8,8];
        ChessPiece c;
        int i;

            //East
            i = CurrentX;
            while (true)
            {
                i++;

                if (i >= 8)
                {
                    break;
                }
                c = MyBoardManager.Instance.ChessPieces[i, CurrentY,CurrentZ];
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
