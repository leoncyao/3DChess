using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

public class Server : MonoBehaviour {
    
    public int port = 6321;
    public int whosturn = 0;
    private List<ServerClient> clients;
    private List<ServerClient> disconnectList;

    private TcpListener server;
    private bool serverStarted;
    public void Init()
    {
        whosturn = 0;
        DontDestroyOnLoad(gameObject);
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            StartListening();
            serverStarted = true;
            Debug.Log("I am listening on port " + port);
        }
        catch (Exception e)
        {
            Debug.Log("Socket eror: " + e.Message);
        }
    }
    private void Update()
    {
        if (!serverStarted)
            return;

        foreach(ServerClient c in clients)
        {
            //Is the client still connected?
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            }else
            {
                NetworkStream s = c.tcp.GetStream();
                //print("C is connected is " + (IsConnected(c.tcp)));
                //print(c.clientName);
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();
                    //print("C is " + c.clientName);
                    if(data != null)
                    {
                        OnIncomingData(c, data);
                    }
                }
                    
            }
        }

        for(int i = 0; i < disconnectList.Count - 1; i++)
        {
            // Tell our player somebody has disconnected

            clients.Remove(disconnectList[i]);
            disconnectList.RemoveAt(i);
        }
    }
    private void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }
    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        string allUsers = "";
        foreach (ServerClient i in clients)
        {
            allUsers += i.clientName + '|';
        }
        ServerClient sc = new ServerClient(listener.EndAcceptTcpClient(ar));
        clients.Add(sc);
        
        StartListening();

        Broadcast("SWHO|" + allUsers, clients[clients.Count - 1]);
    }

    private bool IsConnected(TcpClient c)
    {
        try
        {
            if(c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);

                return true;
            }else
            {
                return false;
            }

        }catch
        {
            return false;
        }
    }

    // Server Send
    private void Broadcast(string data, List<ServerClient> cl)
    {
        foreach(ServerClient sc in cl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }catch(Exception e)
            {
                Debug.Log("Write error :" + e.Message);
            }

        }
    }
    private void Broadcast(string data, ServerClient c)
    {
        List<ServerClient> sc = new List<ServerClient> { c };
        Broadcast(data, sc);
    }
    // Server Read
    private void OnIncomingData(ServerClient c, string data)
    {
        //Debug.Log("The data that the Server got was: " + data);
        //Debug.Log("The person who sent this was " + c.clientName);
        string[] aData = data.Split('|');

        switch (aData[0])
        {
            case "CWHO":
                c.clientName = aData[1];
                c.isHost = (aData[2] == "0") ? false : true;
                //print("c.isHost = " + c.isHost);
                Broadcast("SCNN|" + c.clientName, clients);

                break;
            case "CMOV":
                //print()
                if (whosturn == 1)
                {
                    whosturn = 0;
                }
                else
                {
                    whosturn = 1;
                }

                Broadcast("SMOV|"+ aData[1] + "|" + aData[2] + "|" + aData[3] + "|" + aData[4] + "|" + aData[5] + "|" + aData[6], clients[whosturn]);
                break;
        }
    }


}


public class ServerClient
{
    public bool isHost;
    public string clientName;
    public TcpClient tcp;

    public ServerClient(TcpClient tcp)
    {
        this.tcp = tcp;
    }


}