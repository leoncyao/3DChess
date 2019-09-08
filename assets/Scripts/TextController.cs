using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (UIController.showinfo)
        {
            text.enabled = true;
        }else
        {
            text.enabled = false;
        }
	}
}
