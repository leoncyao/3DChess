using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKing : ChessPiece
{

	// Use this for initialization
	public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8,8];
        
        ChessPiece c;
        int i, j, z;
        print("CurrentX CurrentY CurrentZ " + CurrentX + CurrentY + CurrentZ);
        //NORTHROWS
        //NorthRowDown
        i = CurrentX - 1;
        j = CurrentY + 1;
        z = CurrentZ - 1;
        if (CurrentY != 7 && CurrentZ != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j,z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j,z] = true;

                    }
                   
                }
                i++;
            }
        }
        //NorthRowMiddle
        i = CurrentX - 1;
        j = CurrentY + 1;
        z = CurrentZ;
        if (CurrentY != 7 )
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }
                    
                }
                i++;
            }
        }
        //NorthRowBottom
        i = CurrentX - 1;
        j = CurrentY + 1;
        z = CurrentZ + 1;
        if (CurrentY != 7 && CurrentZ != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }
                    
                }
                i++;
            }
        }





        //MIDDLE ROWS
        //MiddleRowUp
        i = CurrentX - 1;
        j = CurrentY;
        z = CurrentZ + 1;
        if (CurrentY != 7 && CurrentZ != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }

                }
                i++;
            }
        }

        //MiddleRowMiddle
        i = CurrentX - 1;
        j = CurrentY;
        z = CurrentZ;
        if (CurrentY != 7)
        {
            for (int k = 0; k < 3; k+=1)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }

                }
                i++;
            }
        }

        //MiddleRowDown
        i = CurrentX - 1;
        j = CurrentY;
        z = CurrentZ - 1;
        if (CurrentY != 7 && CurrentZ != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }

                }
                i++;
            }
        }






        //SOUTHROWS
        //SouthRowDown
        i = CurrentX - 1;
        j = CurrentY - 1;
        z = CurrentZ - 1;
        if (CurrentY != 0 && CurrentZ != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }
                    
                }
                i++;
            }
        }
        //SouthRowMiddle
        i = CurrentX - 1;
        j = CurrentY - 1;
        z = CurrentZ;
        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }
                    
                }
                i++;
            }
        }
        //SouthRowTop
        i = CurrentX - 1;
        j = CurrentY - 1;
        z = CurrentZ + 1;
        if (CurrentY != 0 && CurrentZ != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    //print("i j z" + i + j + z);
                    //print(CurrentY == 0);
                    //print("CurrentX CurrentY CurrentZ " + CurrentX + CurrentY + CurrentZ);
                    c = MyBoardManager.Instance.ChessPieces[i, j, z];
                    if (c == null)
                        r[i, j, z] = true;
                    else if (isWhite != c.isWhite)
                    {
                        r[i, j, z] = true;

                    }
                    
                }
                i++;
            }
        }











        return r;
        
    }
}
