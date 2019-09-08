using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MyBoardManager : MonoBehaviour {
    public bool isWhitePlayer;
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;
    public ChessPiece[,,] ChessPieces
    {
        set;
        get;
    }
    private List<GameObject> activeChessPieces;
    public static MyBoardManager Instance
    {
        set;
        get;
    }
    private bool[,,] allowedMoves
    {
        set;
        get;
    }
    public bool CwasEntered;
    private int SelectionX;
    private int SelectionY;
    private int SelectionZ;

    public bool isWhiteTurn;

    private ChessPiece selectedChessPiece;
    private Material previousMat;
    public Material selectedMat;
    private Quaternion orientation;
    public List<GameObject> ChessPiecePrefabs;
    private Client client;


    void Start () {
        client = FindObjectOfType<Client>();
        print("Client name is " + client.clientName);
        print("Did this run twice?");
        if (client != null)
        {
            isWhitePlayer = client.isHost;
        }else
        {
            isWhitePlayer = false;
        }
        print("isWhitePlayer = " + isWhitePlayer);
        Instance = this;
        isWhiteTurn = true;
        SelectionX = -1;
        SelectionY = -1;
        SelectionZ = -1;
        orientation = Quaternion.Euler(270, 180, 0);
        CwasEntered = false;
        ChessPieces = new ChessPiece[8, 8, 8];
        activeChessPieces = new List<GameObject>();


        //SpawnChessPiece(1, 4, 4, 4);
        SpawnAllChessPieces();
        //print(ChessPieces[8, 8, 8]);
        //TESTING if deleteing the gameobject deletes the thing off the ChessPieces board, which it doesnt
        //ChessPiece Test = ChessPieces[0, 0, 0];
        //print(Test);
        //ChessPieces[4, 4, 4] = Test;
        //Test = null;
        //print(ChessPieces[4, 4, 4]);
        //print(Test);
        //Destroy(Test.gameObject);
        //print(Test);

        //SpawnChessPiece(14, 0, 0, 3); 
        /*
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    
                    if(ChessPieces[i, j, k])
                    {
                        print("coordinates " + i + j + k);
                        print(ChessPieces[i, j, k]);
                    }
                    
                }
            }
        }
        */


    }
    void Update()
    {
        //print(UIController.StartGame);
        

            if (UIController.StartGame)
            {
                StartGame();
                UIController.StartGame = false;
            }
            //DrawChessboard();
            CwasEntered = UIController.entered;
            //randomMoveMaker();
            if (CwasEntered)
            {
                UpdateSelection();
                //randomMoveMaker();
                ///*
                if (SelectionX >= 0 && SelectionX < 8 && SelectionY >= 0 && SelectionY < 8 && SelectionZ >= 0 && SelectionZ < 8)
                {
                    if (selectedChessPiece == null)
                    {
                        SelectChessPiece(SelectionX, SelectionY, SelectionZ);
                        UIController.inputs = new int[3] { -1, -1, -1 };
                    }
                    else
                    {

                        MoveChessPiece(SelectionX, SelectionY, SelectionZ);
                        UIController.inputs = new int[3] { -1, -1, -1 };
                    }
                }
                //*/
            }
            //CwasEntered = false;
            UIController.entered = false;

        
    }
    public void StartGame()
    {
        EndGame();
        isWhiteTurn = true;
        SelectionX = -1;
        SelectionY = -1;
        SelectionZ = -1;
        orientation = Quaternion.Euler(270, 180, 0);
        CwasEntered = false;
        ChessPieces = new ChessPiece[8,8,8];
        activeChessPieces = new List<GameObject>();
        SpawnAllChessPieces();
        
    }
    public void UpdateSelection()
    {
        //print("Got a confirmation");
        print(UIController.inputs[0] + " " + UIController.inputs[0] + " " + UIController.inputs[0]);
            int[] newinputs = UIController.inputs;
            //print("am i here");
            /*
            print(newinputs[0]);
            print(newinputs[1]);
            print(newinputs[2]);
            */
            SelectionX = newinputs[0];
            SelectionZ = newinputs[1];           
            SelectionY = newinputs[2];      
    }
    public void SelectChessPiece(int x, int y, int z)
    {
        //print("WAS THIS CALLED");
        //print("x y z are " + x + y + z);
        //print("chess[x,y,z] " + ChessPieces[x, y, z].GetType());
        //print("isWhiteTurn is " + isWhiteTurn);
        if (ChessPieces[x, y, z] == null)
        {
            print("no chess piece at location");
            return;
        }
        
        else if (ChessPieces[x, y, z].isWhite != isWhitePlayer)
        {
            print("Other player's chess piece");
            return;
        }
        selectedChessPiece = ChessPieces[x, y, z];
        print("the selected chessPiece is a " + selectedChessPiece.GetType() + " at " + x + y + z);
        allowedMoves = selectedChessPiece.PossibleMove();
        selectedChessPiece = ChessPieces[x, y,z];
        previousMat = selectedChessPiece.GetComponent<MeshRenderer>().material;
        selectedMat.mainTexture = previousMat.mainTexture;
        selectedChessPiece.GetComponent<MeshRenderer>().material = selectedMat;
        MyBoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
        /*
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    print(allowedMoves[i, j, k]);
                }
            }
        }
        */
    }
    public void MoveChessPiece(int x, int y, int z)
    {
        print("moved");
        if (allowedMoves[x, y, z])
        {
            //print("the piece moved");
            ChessPiece c = ChessPieces[x, y, z];
            if (c != null && c.isWhite != isWhiteTurn)
            {
                if (c.GetType() == typeof(MyKing))
                {
                    EndGame();
                }
                //print("A PIECE WAS TAKEN AT " + x + y + z);
                activeChessPieces.Remove(c.gameObject);
                Destroy(c.gameObject);
                //ChessPieces[x, y, z] = null;
            }
            /*
            foreach (GameObject go in activeChessPieces)
            {
                if (go.transform.position.x == x && go.transform.position.z == y && go.transform.position.y == z)
                    print("THERE WAS A PIECE OR A GAMEOBJECT AT " + x + y + z);
            }
            */
            string msg = "CMOV|";
            Vector3 temp = GetCoorFromCenter(selectedChessPiece.transform.position);
            msg += temp.x+ "|"+ temp.z + "|" + temp.y + "|" + x + "|" + y + "|" + z;
            //msg += new Vector3(x, y, z);
            client.Send(msg);
            ChessPieces[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY, selectedChessPiece.CurrentZ] = null;
            selectedChessPiece.transform.position = GetTileCenter(x, y, z);
            //print("moved1 to " + GetTileCenter(x, y, z));
            //print("moved2 to " + x + y +  z);
            selectedChessPiece.SetPosition(x, y, z);
            ChessPieces[x, y ,z] = selectedChessPiece;
            
            isWhiteTurn = !isWhiteTurn;
        }
        selectedChessPiece.GetComponent<MeshRenderer>().material = previousMat;
        MyBoardHighlights.Instance.Hidehighlights();
        selectedChessPiece = null;
    }
    public void RecieveMove(int sx,int sy,int sz,int ex,int ey,int ez)
    {
        print("did this run?");
        print(sx + " " + sy + " " + sz + " " + ex + " " + ey + " " + ez);
        /*
         * int selectedx = (int)start.x;
        int selectedy = (int)start.z;
        int selectedz = (int)start.y;
        int endx = (int)end.x;
        int endy = (int)end.z;
        int endz = (int)end.y;
        */
        

        ChessPiece c = ChessPieces[ex, ey, ez];
        if (c != null && c.isWhite != isWhiteTurn)
        {
            if (c.GetType() == typeof(MyKing))
            {
                EndGame();
            }
            activeChessPieces.Remove(c.gameObject);
            Destroy(c.gameObject);
        }
        selectedChessPiece = ChessPieces[sx, sy, sz];
        ChessPieces[ex, ey, ez] = selectedChessPiece;
        selectedChessPiece.transform.position = GetTileCenter(ex, ey, ez);
        selectedChessPiece.SetPosition(ex, ey, ez);
        ChessPieces[sx, sy, sz] = null;
        isWhiteTurn = !isWhiteTurn;
        selectedChessPiece = null;
    }
    public void EndGame()
    {
        foreach(GameObject piece in activeChessPieces)
        {
            Destroy(piece);
        }
    }
    public void SpawnAllChessPieces()
    {
        ChessPieces = new ChessPiece[8, 8, 8];
        activeChessPieces = new List<GameObject>();
        
        //white team
        //top back corner row - white
        
        SpawnChessPiece(0, 0, 0, 0);
        SpawnChessPiece(1, 1, 0, 0);
        SpawnChessPiece(2, 2, 0, 0);
        SpawnChessPiece(3, 3, 0, 0);
        SpawnChessPiece(4, 4, 0, 0);
        SpawnChessPiece(2, 5, 0, 0);
        SpawnChessPiece(1, 6, 0, 0);
        SpawnChessPiece(0, 7, 0, 0);

        //front row white pawns
        ///*
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(5, i, 1 ,0);
        }
        //top row white pawns
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(6, i, 0, 1);
        }
        //diagonal row white pawns
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(7, i, 1, 1);
        }
        //*/
        //black team
        
        SpawnChessPiece(8, 0, 7, 7);
        SpawnChessPiece(9, 1, 7, 7);
        SpawnChessPiece(10, 2, 7, 7);
        SpawnChessPiece(11, 3, 7, 7);
        SpawnChessPiece(12, 4, 7, 7);
        SpawnChessPiece(10, 5, 7, 7);
        SpawnChessPiece(9, 6, 7, 7);
        SpawnChessPiece(8, 7, 7, 7);
        
        //front row black pawns
        ///*
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(13, i, 6, 7);
        }
        
        //bot row black pawns
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(14, i, 7, 6);
        }
        //diagonal row black pawns
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(15, i, 6, 6);
        }
        //*/     
    }
    public void SpawnChessPiece(int Type,int x, int y, int z)
    {
        if(Type == 9)
        {
            orientation = Quaternion.Euler(270, 0, 0);
        }
        GameObject go = Instantiate(ChessPiecePrefabs[Type], GetTileCenter(x, y, z), orientation) as GameObject;
        go.transform.SetParent(transform);
        ChessPieces[x, y, z] = go.GetComponent<ChessPiece>();
        ChessPieces[x, y, z].SetPosition(x, y, z);
        activeChessPieces.Add(go);

        if (Type == 9)
        {
            orientation = Quaternion.Euler(270, 180, 0);
        }
    }
    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 lengthLine = Vector3.forward * 8;
        Vector3 heightLine = Vector3.up * 8;
        for (int k = 0; k <= 8; k++)
        {
            for (int i = 0; i <= 8; i+=1)
            {
                Vector3 start2 = Vector3.forward * i + Vector3.up * k;
                Debug.DrawLine(start2, start2 + widthLine,Color.black,1,true);
                for (int h = 0; h <= 8; h+=1)
                {
                    Vector3 start1 = Vector3.right * h + Vector3.forward*i;
                    Debug.DrawLine(start1, start1 + heightLine, Color.black,1, true);
                }
            }
            for (int j = 0; j <= 8; j+=1)
            {
                Vector3 start3 = Vector3.right * j + Vector3.up * k;
                Debug.DrawLine(start3, start3 + lengthLine, Color.black, 1, true);
            }
        }   
    }
    private Vector3 GetTileCenter(int x, int y ,int z)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        origin.y = z;
        return origin;
    }
    private Vector3 GetCoorFromCenter(Vector3 coor)
    {
        Vector3 origin = Vector3.zero;
        origin.x += coor.x - TILE_OFFSET;
        origin.y = coor.y;
        origin.z += coor.z - TILE_OFFSET;
        return origin;
    }
    public void randomMoveMaker()
    {
        List<Vector3> coordinates = new List<Vector3>();
        foreach (GameObject piece in activeChessPieces)
        {
            //finds all the coordinates of the activePieces and puts them into int form
            //print(piece.transform.position.x + " " + piece.transform.position.y +" " + piece.transform.position.z);
            //print(piece.GetComponent(typeof(ChessPiece)));
            //print(piece.transform.position);
            Vector3 coor = GetCoorFromCenter(piece.transform.position);
            //Vector3 coor = GetTileCenter((int)piece.transform.position.x, (int)piece.transform.position.y, (int)piece.transform.position.z);
            //print("GetTileFromCenter" + coor);

            //MAYBE i should make a list for only white or black pieces depending on the turn, but thats hard
            ChessPiece TestPiece = ChessPieces[(int)coor.x, (int)coor.z, (int)coor.y];
            if(TestPiece == null)
            {
                print("THESE MADE IT CRASH" + (int)coor.x + (int)coor.z + (int)coor.y);
                
            }else if (true)
            {

                if (piece.GetComponent(typeof(ChessPiece))/*piece.GetComponent(typeof(ChessPiece)).GetType() == typeof(MyKnight) piece.GetComponent(typeof(ChessPiece)).GetType() == typeof(MyBishop)|| piece.GetComponent(typeof(ChessPiece)).GetType() == typeof(MyRook) || piece.GetComponent(typeof(ChessPiece)).GetType() == typeof(MyPawnDiagonal) || piece.GetComponent(typeof(ChessPiece)).GetType() == typeof(MyPawnHorizontal) || piece.GetComponent(typeof(ChessPiece)).GetType() == typeof(MyPawnVertical)*/)
                {
                    coordinates.Add(coor);
                }
            }
        }
        //print("Choosing new Piece");
        System.Random rnd = new System.Random();
        int randomPieceIndex = rnd.Next(1, coordinates.Count);
        //print("Currently trying " + coordinates[randomPieceIndex]);
        
            ChessPiece randomPiece = ChessPieces[(int)coordinates[randomPieceIndex].x, (int)coordinates[randomPieceIndex].z, (int)coordinates[randomPieceIndex].y];
        if (randomPiece == null)
        {
            print(coordinates[randomPieceIndex]);
            print("RANDOMPIECE WAS NULL");
            return;
        }
            //print(randomPiece);
        //try {
            while (randomPiece.isWhite != isWhiteTurn)
            {

                rnd = new System.Random();
                randomPieceIndex = rnd.Next(0, coordinates.Count);
               // print("Currently trying " + coordinates[randomPieceIndex]);
                randomPiece = ChessPieces[(int)coordinates[randomPieceIndex].x, (int)coordinates[randomPieceIndex].z, (int)coordinates[randomPieceIndex].y];
               // print(randomPiece);
            //Debug.Assert(randomPiece.isWhite);
            if(randomPiece == null)
            {
                print("it was NULL and it broke, " + coordinates[randomPieceIndex]);
                return;
            }
            }

           // print("Final coordinates" + coordinates[randomPieceIndex]);
            selectedChessPiece = randomPiece;
        if (randomPiece == null)
        {
            print("it was null and it broke, " + coordinates[randomPieceIndex]);
            return;
        }   
            print(randomPiece.GetType() + "random piece is white is " + randomPiece.isWhite);
            //print(randomPiece.CurrentX+" " + randomPiece.CurrentY + " " + randomPiece.CurrentZ);

            allowedMoves = randomPiece.PossibleMove();
       /* 
        previousMat = selectedChessPiece.GetComponent<MeshRenderer>().material;
        selectedMat.mainTexture = previousMat.mainTexture;
        selectedChessPiece.GetComponent<MeshRenderer>().material = selectedMat;
        MyBoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
        */
        
            List<int[]> possibleAllowedMoves = new List<int[]>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (allowedMoves[i, j, k])
                        {
                            int[] temp = new int[] { i, j, k };
                            possibleAllowedMoves.Add(temp);
                        }
                    }
                }
            }
        if (possibleAllowedMoves.Count <= 0)
        {
            print("THERE WERE NO MOVES LEFT FOR THIS PIECE which was at" + coordinates);
            return;
        }
            int randompicker = rnd.Next(0, possibleAllowedMoves.Count);
            int[] picked = possibleAllowedMoves[randompicker];

            MoveChessPiece(picked[0], picked[1], picked[2]);
        print("moved to " + picked[0] + picked[1] + picked[2] + " From " + coordinates[randomPieceIndex]);
        
        /*}
        catch ( System.ArgumentNullException ex)
        {

        }
    }*/
    }


}
