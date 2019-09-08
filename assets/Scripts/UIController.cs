using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour{
    public static Vector3 input123 = Vector3.zero;
    public static bool entered = false;
    public static bool flag = true;
    public static bool StartGame = false;   
    public static string view;
    public static int count = 0;
    public static bool showinfo = true;
    public static int[] inputs = { 0, 0, 0 };
    public static UIController Instance
    {
        set;
        get;
    }
    void Start () {
        Instance = this;
        inputs = new int[3]{ -1,-1,-1};
        view = "1";
        count = 0;
	}
	void Update () {
        //print("view is " + view);
        if (MyBoardManager.Instance.isWhitePlayer == MyBoardManager.Instance.isWhiteTurn)
        {
            switchCamera();
            flag = true;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ThisIsStupid")))
                {
                    //if(hit.point.x < 8 && hit.point.x > 0 && hit.point.y < 8 && hit.point.y > 0 && hit.point.z < 8 && hit.point.z > 0)
                    //{
                    flag = false;
                    // }
                }
                //print(flag);
                MyBoardHighlights.Instance.HideSelections();
                if (flag)
                {
                    if (count == 4)
                    {
                        count = 0;
                        ///*
                        print("is this running");
                        inputs[0] = -1;
                        inputs[1] = -1;
                        inputs[2] = -1;
                        //*/
                    }
                    else
                    {
                        //print("view is " + view);
                        //print("inputs was " + inputs[0] + " " + inputs[1] + " " + inputs[2]);
                        UpdateSelectionXY();
                        UpdateSelectionZY();
                        UpdateSelectionZX();
                        MyBoardHighlights.Instance.HighlightSelections(inputs);
                        print(inputs[0] + " " + inputs[1] + " " + inputs[2]);

                    }
                }
                count += 1;

            }
            if (Input.GetKeyDown("return"))
            {
                Confirmation_Click();

            }
        }
          
	}
    public static Vector3 getInput123()
    {
        return input123;
    }
    public void Button_Click()
    {
        StartGame = true;
    }
    public void Confirmation_Click()
    {
        print(inputs[0] + " " + inputs[1] + " " + inputs[2]);
        if (inputs[0] != -1 && inputs[1] != -1 && inputs[2] != -1)
        {
            entered = true;
            MyBoardHighlights.Instance.HideSelections();
            count = 0;
        }
        //else
        //{
        //    print("non perpendicular planes selected");
        //}
        //
    }
    public void Text_Changed(string numb)
    {
        int num = int.Parse(numb);
        int numright = num/100 ;
        int numforward = num%100/10 ; 
        int numup = num %100 %10 ;
        int[] temparray = new int[3];
        temparray[0] = numright;
        temparray[1] = numforward;
        temparray[2] = numup;
        inputs = temparray;
        /*
        int numright = int.Parse(text.Substring(0, 0));
        int numforward = int.Parse(text.Substring(1, 0));
        int numup = int.Parse(text.Substring(2, 0));
        */
        //Debug.Log("numright " + numright + " numforward " + numforward + " numup " + numup);
        input123 = Vector3.forward * numforward + Vector3.up * numup + Vector3.right * numright;   
    }
    public void InformationClick()
    {
        if (showinfo)
        {
            showinfo = false;
        }
        else
        {
            showinfo = true;    
        }
    }
    private void UpdateSelectionXY()
    {
        //print("check2");
        if (!Camera.main)
            return;
        //print("is This running");
        //int[] temparray = new int[2];
        RaycastHit hit;
        //print("check3");
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("UI")))
        {
            Confirmation_Click();
        }
        else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("SelectionPlaneXY")))
        {
            //print("HIT XY");
            //print(inputs[0] + " " + inputs[1] + " " + inputs[2]);
            if (inputs[0] == -1)
            {
                //print(hit.point.x);
                inputs[0] = (int)hit.point.x;
                //print(inputs[0]);
            }
            if (inputs[1] == -1)
            {
                inputs[1] = (int)hit.point.y;
            }
            //print("check4");
        }/*else
        {
            print("check2");
            inputs[0] = -1;
            inputs[1] = -1;
        }*/
        
        //print(temparray[0] + " " + temparray[1]);
    }
    private void UpdateSelectionZY()
    {
        
        if (!Camera.main)
            return;
        //print("is This running");
        int[] temparray = new int[2];
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("UI")))
        {
            Confirmation_Click();
        }else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("SelectionPlaneZY")))
        {
            print("HIT ZY");
            if (inputs[2] == -1)
                inputs[2] = (int)hit.point.z;
            if (inputs[1] == -1)
                inputs[1] = (int)hit.point.y;
        }/*
        else
        {
            inputs[2] = -1;
            inputs[1] = -1;
        }
        */
        //print(temparray[0] + " " + temparray[1]);
    }
    private void UpdateSelectionZX()
    {
        
        if (!Camera.main)
            return;
        //print("is This running");
        int[] temparray = new int[2];
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("UI")))
        {
            Confirmation_Click();
        }
        else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("SelectionPlaneZX")))
        {
            print("HIT ZX");
            if (inputs[2] == -1)
                inputs[2] = (int)hit.point.z;
            if (inputs[0] == -1)
                inputs[0] = (int)hit.point.x;
        }/*
        else 
        {
            inputs[2] = -1;
            inputs[0] = -1;
        }
        */
        //print(temparray[0] + " " + temparray[1]);
    }
    private void switchCamera()
    {
        Quaternion orientation = new Quaternion(0,0,0,0);
        Vector3 test;
        if (Input.GetKeyDown("1")){
            //FRONT
            test = Vector3.zero + Vector3.forward * -10 + Vector3.up * 4 + Vector3.right * 4;
            Camera.main.transform.localEulerAngles = new Vector3(0, 0, 0);
            Camera.main.transform.position = test;
            view = "1";
        }
        else if (Input.GetKeyDown("2"))
        {
            //LEFT
            test = Vector3.zero + Vector3.forward * 4 + Vector3.up * 4 + Vector3.right * -10;                            
            Camera.main.transform.position = test;
            Camera.main.transform.localEulerAngles = new Vector3(0, 90, 0);
            view = "2";
        }
        else if (Input.GetKeyDown("3"))
        {
            //TOP
            test = Vector3.zero + Vector3.forward * 4 + Vector3.up * 18 + Vector3.right * 4;
            Camera.main.transform.localEulerAngles = new Vector3(90, 0 , 0);
            Camera.main.transform.position = test;
            view = "3";
        }
        else if (Input.GetKeyDown("4"))
        {
            //BEHIND
            test = Vector3.zero + Vector3.forward * 18 + Vector3.up * 4 + Vector3.right * 4;
            Camera.main.transform.localEulerAngles = new Vector3(0, 180, 0);
            Camera.main.transform.position = test;
            view = "4";
        }
        else if (Input.GetKeyDown("5"))
        {
            //RIGHT
            test = Vector3.zero + Vector3.forward * 4 + Vector3.up * 4 + Vector3.right * 18;
            Camera.main.transform.localEulerAngles = new Vector3(0, -90, 0);
            Camera.main.transform.position = test;
            view = "5";
        }
        else if (Input.GetKeyDown("6"))
        {
            //BOT
            test = Vector3.zero + Vector3.forward * 4 + Vector3.up * -10 + Vector3.right * 4;
            Camera.main.transform.localEulerAngles = new Vector3(-90, 0, 0);
            Camera.main.transform.position = test;
            view = "6";
        }
    }





}






