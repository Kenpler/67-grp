using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class ConsoleManager : MonoBehaviour
{
    public static ConsoleManager instance;
    [SerializeField] List<ConsolePage> pageList = new List<ConsolePage>();
    [Header("References")]
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI currentPageText;
    private void Awake()
    {
        instance = this;
    }
    public void ChangePage(string pageCommand)
    {
        bool foundPage = false;
        foreach (ConsolePage page in pageList)
        {
            if (pageCommand == page.command)
            {
                currentPageText.text = page.page;
                foundPage = true;
                break;
            }
        }
        if (!foundPage)
        {
            currentPageText.text = "This page doesn't exist.";
        }
        inputField.ActivateInputField();
        inputField.text = "";
    }
    public void Exit()
    {
        inputField.DeactivateInputField();
    }
}
[Serializable]
public class ConsolePage
{
    [TextArea(1, 2)]
    public string command;
    [TextArea(10, 20)]
    public string page;
    public ConsolePage(string command, string page)
    {
        this.command = command;
        this.page = page;
    }
}