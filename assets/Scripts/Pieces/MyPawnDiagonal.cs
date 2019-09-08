using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPawnDiagonal : MyPawn {

    // Use this for initialization
    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8, 8];
        ChessPiece c1, c2;

        if (isWhite)
        {
            //piece is WHITE

            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 7)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY + 1, CurrentZ+1];
                if (c1 != null && !c1.isWhite)
                    r[CurrentX - 1, CurrentY + 1, CurrentZ + 1] = true;
            }
            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 7)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY + 1, CurrentZ + 1];
                if (c1 != null && !c1.isWhite)
                    r[CurrentX + 1, CurrentY + 1, CurrentZ + 1] = true;
            }

            if (CurrentY != 7)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1,CurrentZ+1];
                if (c1 == null)
                    r[CurrentX, CurrentY + 1,CurrentZ+1] = true;



            }
            //firstmove
            if (CurrentY == 1)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1,CurrentZ+1];
                c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ + 2];

                if (c1 == null && c2 == null)
                    r[CurrentX, CurrentY + 2, CurrentZ + 2] = true;

            }

        }
            else
        {
            //Piece is BLACK
            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 0)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY - 1, CurrentZ - 1];
                if (c1 != null && c1.isWhite)
                    r[CurrentX - 1, CurrentY - 1, CurrentZ - 1] = true;
            }
            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 0)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY - 1, CurrentZ - 1];
                if (c1 != null && c1.isWhite)
                    r[CurrentX + 1, CurrentY - 1, CurrentZ - 1] = true;
            }
            //middle
            if (CurrentY != 0)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ - 1];
                if (c1 == null)
                    r[CurrentX, CurrentY - 1, CurrentZ - 1] = true;



            }
            //firstmove
            if (CurrentY == 6)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ - 1];
                c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ - 2];

                if (c1 == null && c2 == null)
                    r[CurrentX, CurrentY - 2, CurrentZ - 2] = true;

            }
        }


        return r;
    }
}
