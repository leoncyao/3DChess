using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPawnVertical : MyPawn {

    // Use this for initialization
    // Use this for initialization
    //formoving2atatime
    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8, 8];
        ChessPiece c1, c2, c3, c4;
        //int[] e = MyBoardManager.Instance.EnPassantmove;
        if (isWhite)
        {

            if (CurrentZ < 7) { 

                //print(CurrentX + " " + CurrentY + " " + CurrentZ);
                //Diagonal Left - 1
                if (CurrentX > 1 && CurrentZ < 6)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY, CurrentZ + 1];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX - 2, CurrentY, CurrentZ + 2];
                    if (c1 == null)
                    {
                        if (c2 != null && !c2.isWhite)
                        {
                            r[CurrentX - 2, CurrentY, CurrentZ + 2] = true;
                        }
                    }
                    else if (!c1.isWhite)
                    {
                        r[CurrentX - 1, CurrentY, CurrentZ + 1] = true;
                    }


                }
                else if (CurrentX != 0 && CurrentZ != 7)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY, CurrentZ + 1];
                    if (c1 != null && !c1.isWhite)
                        r[CurrentX - 1, CurrentY, CurrentZ + 1] = true;

                }


            // Diagon Right
            if (CurrentX < 6 && CurrentZ < 6)
            {
                /*
                if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                }*/

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY, CurrentZ + 1];
                c2 = MyBoardManager.Instance.ChessPieces[CurrentX + 2, CurrentY, CurrentZ + 2];
                if (c1 == null)
                {
                    if (c2 != null && !c2.isWhite)
                    {
                        r[CurrentX + 2, CurrentY, CurrentZ + 2] = true;
                    }
                }
                else if (!c1.isWhite)
                {
                    r[CurrentX + 1, CurrentY, CurrentZ + 1] = true;
                }


            }
            else if (CurrentX != 7 && CurrentZ != 7)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY, CurrentZ + 1];
                ////print("where is the error");
                /*
                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                }
                */


                if (c1 != null && !c1.isWhite)
                    r[CurrentX + 1, CurrentY, CurrentZ + 1] = true;

            }
                // Middle
                if (CurrentZ < 6)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 1];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 2];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY, CurrentZ + 1] = true;
                        if (c2 == null)
                        {
                            r[CurrentX, CurrentY, CurrentZ + 2] = true;
                        }
                    }

                }
                else
                {
                    if (CurrentZ < 7)
                    {
                        c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 1];
                        if (c1 == null)
                        {
                            r[CurrentX, CurrentY, CurrentZ + 1] = true;
                        }
                    }
                }
            if (CurrentZ == 1)
            {

                c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 1];
                c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 2];
                c3 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 3];
                c4 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ + 4];

                if (c1 == null && c2 == null && c3 == null && c4 == null)
                    r[CurrentX, CurrentY, CurrentZ + 4] = true;

            }


        }else if(CurrentZ == 7)
            {
                //print("this piece was white");
                //print(CurrentX + " " + CurrentY + " " + CurrentZ);
                //Diagonal Left - 1
                if (CurrentX > 1 && CurrentY < 6)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY + 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX - 2, CurrentY + 2, CurrentZ];
                    if (c1 == null)
                    {

                        if (c2 != null && !c2.isWhite)
                        {
                            r[CurrentX - 2, CurrentY + 2, CurrentZ] = true;
                        }
                    }
                    else if (!c1.isWhite)
                    {
                        r[CurrentX - 1, CurrentY + 1, CurrentZ] = true;
                    }




                }
                else if (CurrentX != 0 && CurrentY != 7)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY + 1, CurrentZ];
                    if (c1 != null && !c1.isWhite)
                        r[CurrentX - 1, CurrentY + 1, CurrentZ] = true;

                }


                // Diagon Right
                if (CurrentX < 6 && CurrentY < 6)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY + 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX + 2, CurrentY + 2, CurrentZ];
                    if (c1 == null)
                    {
                        if (c2 != null && !c2.isWhite)
                        {
                            r[CurrentX + 2, CurrentY + 2, CurrentZ] = true;
                        }
                    }
                    else if (!c1.isWhite)
                    {
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                    }
                }
                else if (CurrentX != 7 && CurrentY != 7)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY + 1, CurrentZ];
                    //print("where is the error");
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                    }
                    */


                    if (c1 != null && !c1.isWhite)
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;

                }
                // Middle
                if (CurrentY < 6)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 2, CurrentZ];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY + 1, CurrentZ] = true;
                        if (c2 == null)
                        {
                            r[CurrentX, CurrentY + 2, CurrentZ] = true;
                        }
                    }

                }
                else if (CurrentY < 7)
                {
                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY + 1, CurrentZ] = true;
                    }



                }

            }




        }
        else
        {
            //black

            if (CurrentZ > 0)
            {
                //print("this piece cannot go any further horizontally");
                //print(CurrentX + " " + CurrentY + " " + CurrentZ);
                //Diagonal Left - 1
                if (CurrentX > 1 && CurrentZ > 1)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY, CurrentZ - 1];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX - 2, CurrentY, CurrentZ - 2];
                    if (c1 == null)
                    {
                        if (c2 != null && c2.isWhite)
                        {
                            r[CurrentX - 2, CurrentY, CurrentZ - 2] = true;
                        }
                    }
                    else if (c1.isWhite)
                    {
                        r[CurrentX - 1, CurrentY, CurrentZ - 1] = true;
                    }


                }
                else if (CurrentX != 0 && CurrentZ != 0)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY, CurrentZ - 1];
                    if (c1 != null && c1.isWhite)
                        r[CurrentX - 1, CurrentY, CurrentZ - 1] = true;

                }


                // Diagon Right
                if (CurrentX < 6 && CurrentZ > 1)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY, CurrentZ - 1];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX + 2, CurrentY, CurrentZ - 2];
                    if (c1 == null)
                    {
                        if (c2 != null && c2.isWhite)
                        {
                            r[CurrentX + 2, CurrentY, CurrentZ - 2] = true;
                        }
                    }
                    else if (c1.isWhite)
                    {
                        r[CurrentX + 1, CurrentY, CurrentZ - 1] = true;
                    }


                }
                else if (CurrentX != 7 && CurrentZ != 0)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY, CurrentZ - 1];
                    ////print("where is the error");
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                    }
                    */


                    if (c1 != null && c1.isWhite)
                        r[CurrentX + 1, CurrentY, CurrentZ - 1] = true;

                }
                // Middle
                if (CurrentZ > 1)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 1];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 2];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY, CurrentZ - 1] = true;
                        if (c2 == null)
                        {
                            r[CurrentX, CurrentY, CurrentZ - 2] = true;
                        }
                    }

                }
                else if (CurrentZ > 0)
                {
                    //print("did this run");
                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 1];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY, CurrentZ - 1] = true;
                    }

                }

                if (CurrentZ == 6)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 1];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 2];
                    c3 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 3];
                    c4 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ - 4];

                    if (c1 == null && c2 == null && c3 == null && c4 == null)
                        r[CurrentX, CurrentY, CurrentZ - 4] = true;

                }

            }

            else if (CurrentZ == 0)
            {
                //print("this piece was black");
                //print(CurrentX + " " + CurrentY + " " + CurrentZ);
                //Diagonal Left - 1
                if (CurrentX > 1 && CurrentY > 1)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY - 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX - 2, CurrentY - 2, CurrentZ];
                    if (c1 == null)
                    {
                        if (c2 != null && c2.isWhite)
                        {
                            r[CurrentX - 2, CurrentY - 2, CurrentZ] = true;
                        }
                    }
                    else if (c1.isWhite)
                    {
                        r[CurrentX - 1, CurrentY - 1, CurrentZ] = true;
                    }

                }
                else if (CurrentX != 0 && CurrentY != 0)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY - 1, CurrentZ];
                    if (c1 != null && c1.isWhite)
                        r[CurrentX - 1, CurrentY - 1, CurrentZ] = true;

                }


                // Diagon Right
                if (CurrentX < 6 && CurrentY > 1)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }*/

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY - 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX + 2, CurrentY - 2, CurrentZ];
                    if (c1 == null)
                    {
                        if (c2 != null && c2.isWhite)
                        {
                            r[CurrentX + 2, CurrentY - 2, CurrentZ] = true;
                        }
                    }
                    else if (c1.isWhite)
                    {
                        r[CurrentX + 1, CurrentY - 1, CurrentZ] = true;
                    }

                }
                else if (CurrentX != 7 && CurrentY != 0)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY - 1, CurrentZ];
                    ////print("where is the error");
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                    }
                    */


                    if (c1 != null && c1.isWhite)
                        r[CurrentX + 1, CurrentY - 1, CurrentZ] = true;

                }
                // Middle
                if (CurrentY > 1)
                {

                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 2, CurrentZ];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY - 1, CurrentZ] = true;
                        if (c2 == null)
                        {
                            r[CurrentX, CurrentY - 2, CurrentZ] = true;
                        }
                    }

                }
                else if (CurrentY > 0)
                {
                    c1 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ];
                    if (c1 == null)
                    {
                        r[CurrentX, CurrentY - 1, CurrentZ] = true;
                    }
                }




            }

        }
            
        
        return r;
    }

    //for moving 1 at a time
    /*
    public override bool[,,] PossibleMove()
    {
        bool[,,] r = new bool[8, 8, 8];
        ChessPiece c, c2;
        //int[] e = MyBoardManager.Instance.EnPassantmove;
        if (isWhite)
        {
            //Diagonal Left
            if (CurrentY < 7)
            {
                //print("this piece was white");
                //print(CurrentX + " " + CurrentY + " " + CurrentZ);
                if (CurrentX != 0 && CurrentY != 7)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }
                    
                    c = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY + 1, CurrentZ];
                    if (c != null && !c.isWhite)
                        r[CurrentX - 1, CurrentY + 1, CurrentZ] = true;

                }
                // Diagon Right
                if (CurrentX != 7 && CurrentY != 7)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY + 1, CurrentZ];
                    ////print("where is the error");
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                    }
                    


                    if (c != null && !c.isWhite)
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;

                }
                // Middle
                if (CurrentY != 7)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];
                    if (c == null)
                        r[CurrentX, CurrentY + 1, CurrentZ] = true;



                }

                if (CurrentY == 1)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];

                    if (c == null && c2 == null)
                        r[CurrentX, CurrentY + 2, CurrentZ] = true;

                }



            }
            else if (CurrentY == 7){
                //print("this horizontal piece can no longer move horizontally");
                //print(CurrentX + " " + CurrentY + " " + CurrentZ);

                if (CurrentX != 0 && CurrentZ != 7)
                {
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX - 1, CurrentY + 1,CurrentZ] = true;
                    }
                    
                    c = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY, CurrentZ+1];
                    if (c != null && !c.isWhite)
                        r[CurrentX - 1, CurrentY , CurrentZ+1] = true;

                }
                // Diagon Right
                if (CurrentX != 7 && CurrentZ != 7)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY, CurrentZ+1];
                    ////print("where is the error");
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                    {
                        r[CurrentX + 1, CurrentY + 1, CurrentZ] = true;
                    }
                    


                    if (c != null && !c.isWhite)
                        r[CurrentX + 1, CurrentY , CurrentZ+1] = true;

                }
                // Middle
                if (CurrentZ != 7)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY, CurrentZ+1];
                    if (c == null)
                        r[CurrentX, CurrentY, CurrentZ+1] = true;



                }
                /*
                if (CurrentY == 1)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY + 1, CurrentZ];

                    if (c == null && c2 == null)
                        r[CurrentX, CurrentY + 2, CurrentZ] = true;

                }
                
            }
        }
        else
        {
            //black
            //print("thie piece was black");
            if (CurrentY > 0)
            {
                if (CurrentX != 0 && CurrentY != 0)
                {
                    c = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY - 1, CurrentZ];
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                    {
                        r[CurrentX - 1, CurrentY - 1, CurrentZ] = true;
                    }

                    if (c != null && c.isWhite)
                        r[CurrentX - 1, CurrentY - 1, CurrentZ] = true;
                       
                }
                // Diagon Right
                if (CurrentX != 7 && CurrentY != 0)
                {
                    c = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY - 1, CurrentZ];
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
                    {
                        r[CurrentX + 1, CurrentY - 1, CurrentZ] = true;
                    }
                    
                    if (c != null && c.isWhite)
                        r[CurrentX + 1, CurrentY - 1, CurrentZ] = true;

                }
                // Middle
                if (CurrentY != 0)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ];
                    if (c == null)
                        r[CurrentX, CurrentY - 1, CurrentZ] = true;



                }

                if (CurrentY == 6)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 2, CurrentZ];

                    if (c == null && c2 == null)
                        r[CurrentX, CurrentY - 2, CurrentZ] = true;

                }
            }else if (CurrentY == 0)
            {
                //print("this piece cannot go horizontally no more");
                if (CurrentX != 0 && CurrentZ  != 0)
                {
                    c = MyBoardManager.Instance.ChessPieces[CurrentX - 1, CurrentY, CurrentZ-1];
                    /*
                    if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                    {
                        r[CurrentX - 1, CurrentY - 1, CurrentZ] = true;
                    }

                    if (c != null && c.isWhite)
                        r[CurrentX - 1, CurrentY - 1, CurrentZ] = true;
                       
                }
                // Diagon Right
                if (CurrentX != 7 && CurrentZ != 0)
                {
                    c = MyBoardManager.Instance.ChessPieces[CurrentX + 1, CurrentY , CurrentZ-1];
                    /*
                    if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
                    {
                        r[CurrentX + 1, CurrentY - 1, CurrentZ] = true;
                    }
                    
                    if (c != null && c.isWhite)
                        r[CurrentX + 1, CurrentY , CurrentZ-1] = true;

                }
                // Middle
                if (CurrentZ != 0)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY , CurrentZ-1];
                    if (c == null)
                        r[CurrentX, CurrentY, CurrentZ-1] = true;



                }
                /*
                if (CurrentY == 6)
                {

                    c = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 1, CurrentZ];
                    c2 = MyBoardManager.Instance.ChessPieces[CurrentX, CurrentY - 2, CurrentZ];

                    if (c == null && c2 == null)
                        r[CurrentX, CurrentY - 2, CurrentZ] = true;

                }
                
            }
        }



        return r;
    }
    */
}
