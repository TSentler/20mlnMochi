using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPGUI : MonoBehaviour 
{
    public TextMeshProUGUI displayText;
    public int diamondCount = 541200;
    //public string UItext = "";
    private string template = @"<sprite name=""{0}"">";

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(string.Format(template, UItext[0]));
    }

    private string TMPstringUICreator()
    {
        string outputText = "";
        string UItext = diamondCount.ToString();
        for (int i = 0; i < UItext.Length; i++)
        {
            outputText += string.Format(template, UItext[i]);
        }
        return outputText;
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = TMPstringUICreator();
    }
}
