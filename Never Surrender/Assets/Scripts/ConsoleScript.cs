using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class ConsoleScript : MonoBehaviour
{
    public GameObject console;
    public TMP_InputField inputField;
    public TMP_Text consoleText, fps;
    public static bool noclip, showfps;
    public static bool tgm;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (console.activeSelf)
            {
                console.SetActive(false);
                inputField.text = "";
            }
            else
            {
                console.SetActive(true);
                inputField.Select();
                inputField.ActivateInputField();
                inputField.text = "";
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (console.activeSelf)
            {
                consoleText.text += "\n";
                consoleText.text += inputField.text;
                inputField.text.ToLower();
                inputField.text = Regex.Replace(inputField.text, @"\s+", "");
                inputField.text = Regex.Replace(inputField.text, "`", "");
                inputField.text = Regex.Replace(inputField.text, "/", "");
                if (inputField.text == "noclip")
                {
                    if (noclip)
                    {
                        noclip = false;
                        consoleText.text += " - noclip deactivated";
                    }
                    else
                    {
                        noclip = true;
                        consoleText.text += " - noclip activated";
                    }
                }else if (inputField.text == "tgm")
                {
                    if (tgm)
                    {
                        tgm = false;
                        consoleText.text += " - god mode deactivated";
                    }
                    else
                    {
                        tgm = true;
                        consoleText.text += " - god mode activated";
                    }
                }else if (inputField.text == "help")
                {
                    consoleText.text += "\nCommands:\n-noclip - Lets the player fly around and go through walls\n-tgm - Toggle god mode, allows the player to be invulnerable\n-showfps - shows fps on screen\n-ver - Shows actual version of the game";
                }
                else if (inputField.text == "showfps")
                {
                    if (showfps)
                    {
                        fps.gameObject.SetActive(false);
                        showfps = false;
                        consoleText.text += " - hide fps";
                    }
                    else
                    {
                        fps.gameObject.SetActive(true);
                        showfps = true;
                        consoleText.text += " - show fps";
                    }
                }else if(inputField.text == "ver")
                {
                    consoleText.text += " - Version: Beta 1.2.1 ";
                }
                else
                {
                    consoleText.text += " - command doesn't exists";
                }
                inputField.Select();
                inputField.ActivateInputField();
                inputField.text = "";
            }
        }
    }
}
