using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBoardHighlights : MonoBehaviour {

    public GameObject highlightPrefab;
    public GameObject selectedPrefab;
    public static MyBoardHighlights Instance { set; get; }
    private List<GameObject> highlights;
    private List<GameObject> Selections;
    private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
        Selections = new List<GameObject>();
    }

    private GameObject GetHighlightObject()
    {

        GameObject go = highlights.Find(g => !g.activeSelf);
        if (go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
        }
        return go;
    }
    private GameObject GetSelectedObject()
    {
        GameObject go = Selections.Find(g => !g.activeSelf);
        if (go == null)
        {
            go = Instantiate(selectedPrefab);
            Selections.Add(go);
        }
        return go;
    }
    public void HighlightSelections(int[] coordinates)
    {
        if (coordinates[0] != -1 && coordinates[1] != -1 && coordinates[2] != -1)
        {
            GameObject go = GetSelectedObject();
            go.SetActive(true);
            go.transform.position = new Vector3(coordinates[0] + 0.5f, coordinates[1] + 0.5f, coordinates[2] + 0.5f);
        }
        else if(coordinates[0] == -1)
        {
            if (coordinates[1] >= 0 && coordinates[1] < 8 && coordinates[2] >= 0 && coordinates[2] < 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject go = GetSelectedObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, coordinates[1] + 0.5f, coordinates[2] + 0.5f);
                }
            }
        }
        else if (coordinates[1] == -1)
        {
            if (coordinates[0] >= 0 && coordinates[0] < 8 && coordinates[2] >= 0 && coordinates[2] < 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject go = GetSelectedObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(coordinates[0] + 0.5f, i + 0.5f, coordinates[2] + 0.5f);
                }
            }
        }
        else if (coordinates[2] == -1)
        {
            if (coordinates[1] >= 0 && coordinates[1] < 8 && coordinates[0] >= 0 && coordinates[0] < 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject go = GetSelectedObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(coordinates[0] + 0.5f, coordinates[1] + 0.5f, i + 0.5f);
                }
            }
        }
    }
    public void HighlightAllowedMoves(bool[,,] moves)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int z = 0; z < 8; z++)
                {
                    if (moves[i, j, z])
                    {
                        GameObject go = GetHighlightObject();
                        go.SetActive(true);
                        //go.GetComponent<Material>().SetFloat("_Mode", 0f);
                        go.transform.position = new Vector3(i + 0.5f, z + 0.5f, j + 0.5f);

                    }
                }
            }

        }


    }
    public void HideSelections()
    {
        foreach (GameObject go in Selections)
        {
            go.SetActive(false);

        }


    }
    public void Hidehighlights()
    {
        foreach (GameObject go in highlights)
        {
            go.SetActive(false);

        }


    }
}
