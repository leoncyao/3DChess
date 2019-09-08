using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance
    {
        set;
        get;
    }

    public GameObject mainMenu;
    public GameObject serverMenu;
    public GameObject connectMenu;

    public GameObject serverPrefab;
    public GameObject clientPrefab;

    public InputField nameInput;

	void Start () {
        //Vector3 test = new Vector3(1, 2, 3);
        //print(test.ToString());
        Instance = this;
        DontDestroyOnLoad(gameObject);
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);


    }

    public void ConnectButton()
    {
        mainMenu.SetActive(false);
        connectMenu.SetActive(true);

    }

    public void HostButton()
    {
        mainMenu.SetActive(false);
        serverMenu.SetActive(true);

        try
        {
            Server s = Instantiate(serverPrefab).GetComponent<Server>();
            s.Init();
            //s.clientName = nameInput.text;
            Client c = Instantiate(clientPrefab).GetComponent<Client>();

            c.isHost = true;
            c.clientName = nameInput.text;
            c.ConnectToServer("127.0.0.1", 6321);
            
            if (c.clientName == "")
            {
                c.clientName = "Host";
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }



    }
	
    public void ConnectToServerButton()
    {
        string hostAddress = GameObject.Find("HostInput").GetComponent<InputField>().text;
        if (hostAddress == "")
            hostAddress = "127.0.0.1";
        try
        {
            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.ConnectToServer(hostAddress, 6321);
            connectMenu.SetActive(false);
            c.clientName = nameInput.text;
            c.isHost = false;
            if (c.clientName == "")
            {
                c.clientName = "Client";
            }
        }catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    
    public void BackButton()
    {
        mainMenu.SetActive(true);
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);

        Server s = FindObjectOfType<Server>();
        if (s != null)
        {
            Destroy(s.gameObject);
        }
        Client c = FindObjectOfType<Client>();
        if (c != null)
        {
            Destroy(c.gameObject);
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
	
}
