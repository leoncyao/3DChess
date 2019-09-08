using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    public float Tx = 0;
    public float Ty = 0;
    private Vector3 dragOrigin ;
    public Vector3 TargetPosition = new Vector3(4, 4, 4);
    public float Ax = 0;
    public Vector3 lastDragPos;
    void Start()
    {
        dragOrigin = new Vector3(4, 4, 4);
    }
    void Update()
    {
        //print(lastDragPos);
        
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            //lastDragPos = dragOrigin;
            return;
        }

        if (!Input.GetMouseButton(1))
        {
            //dragOrigin = Input.mousePosition;
            //print("is this running");
            // dragOrigin = Input.mousePosition;
            return;
        }
        //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        //Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
        //transform.Translate(move, Space.World);
        //Vector3 difference = Vector3.forward * getCircle((Input.mousePosition.x - dragOrigin.x));

        
        
        if(Input.mousePosition.x - dragOrigin.x > 1)
        {
            Tx += Input.mousePosition.x - dragOrigin.x;
            //dragOrigin.x += (Input.mousePosition.x - dragOrigin.x)/10;
            dragOrigin.x += 1;
            //Tx -= Ax;
        }
        else if (Input.mousePosition.x - dragOrigin.x < 1 && Input.mousePosition.x - dragOrigin.x > -1)
        {
            dragOrigin.x = Input.mousePosition.x;
        }else if (Input.mousePosition.x - dragOrigin.x < -1){
            Tx += Input.mousePosition.x - dragOrigin.x;
            dragOrigin.x -= 1;
            //Tx += Ax;
        }

        if (Input.mousePosition.y - dragOrigin.y > 1)
        {
            Ty += Input.mousePosition.y - dragOrigin.y;
            //dragOrigin.y += (Input.mousePosition.y - dragOrigin.y)/10;
            dragOrigin.y += 1;
            //Ty -= Ay;
        }
        else if (Input.mousePosition.y - dragOrigin.y < 1 && Input.mousePosition.y - dragOrigin.y > -1)
        {
            dragOrigin.y = Input.mousePosition.y;
        }
        else if (Input.mousePosition.y - dragOrigin.y < -1)
        {
            Ty += Input.mousePosition.y - dragOrigin.y;
            dragOrigin.y -= 1;
            //Tx += Ax;
        }

        transform.position = getCircleXY(Tx) - getCircleZY(Ty);
        transform.rotation = Quaternion.LookRotation(TargetPosition - transform.position);
    }
    public Vector3 getCircleZY(float t)
    {
        t /= 10000;
        Vector3 z = Vector3.up * Mathf.Sin(t) * 24; 
        //Vector3 y = Vector3.right * Mathf.Cos(t) * 12;
        Vector3 position = z;
        return position;
    }

    public Vector3 getCircleXY(float t)
    {
      
        t /= 5000;
        Vector3 x = Vector3.forward * Mathf.Sin(t) * 12;
        Vector3 y = Vector3.right * Mathf.Cos(t) * 12;
        //Vector3 z = Vector3.up * (Mathf.Sin(t)) * 12;
        Vector3 constant = Vector3.forward * 4 + Vector3.right * 4 + Vector3.up*4;
        Vector3 position = x + y + constant;
        return position;
    }


}