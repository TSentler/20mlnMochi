using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPGUI : MonoBehaviour 
{
    [SerializeField] private Inventory _inventory;
    public TextMeshProUGUI displayText;
    public int diamondCount;
    private string template = @"<sprite name=""{0}"">";

    void Start()
    {
        
    }

    private string TMPstringUICreator()
    {
        diamondCount = _inventory.DiamondCount;
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
