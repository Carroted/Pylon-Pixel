using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Terminal : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text console;
    public bool loggedIn = false;
    public GameObject cover;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Enter()
    {
        if (loggedIn)
        {
            Submit();
        }
        else
        {
            Password();
        }
    }
    public void Submit()
    {
        string cmd = inputField.text;
        inputField.text = "";
        console.text += "<color=#00FF06>$<color=#ffffff> " + cmd + "\n";
        if (cmd == "")
        {
            return;
        }
        if (cmd == "help")
        {
            console.text += "help\n";
            console.text += "clear\n";
            console.text += "exit\n";
            console.text += "login\n";
            console.text += "logout\n";
            console.text += "whoami\n";
            console.text += "area unlock (area)\n";
            console.text += "area unlock all\n";
            console.text += "area lock (area)\n";
            console.text += "area lock all\n";
            console.text += "area erase (area) (2 factor authentication code)\n";
            console.text += "area create (area) (JSON contents) (2 factor authentication code)\n";
            console.text += "kill (entity)\n";
            console.text += "kill all\n";
        }
        else if (cmd == "clear")
        {
            console.text = "";
        }
        else if (cmd == "exit")
        {
            SceneManager.LoadScene(0);
        }
        else if (cmd == "login")
        {
            console.text += "You are already logged in.\n";
        }
        else if (cmd == "logout")
        {
            loggedIn = false;
            console.text += "Logged out\n";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (cmd == "whoami")
        {
            console.text += "Michael\n";
        }
        else if (cmd == "whoa" + "r" + "eyou")
        {
            console.text += ":)\n";
        }
        else if (cmd == "area unlock all")
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings - 2; i++)
            {
                if (i != 0)
                {
                    BetterPrefs.SetInt("level" + i, 1);
                    console.text += "Unlocked <color=#00FF06>area " + i + "<color=#ffffff>. If this area doesn't exist, it will be unlocked immediately upon creation.\n";
                }
            }
        }
        else if (cmd == "lynx 0")
        {
            BetterPrefs.SetInt("lynxskin", 0);
            console.text += "<color=#ff4f30>CPVAMCA command override:<color=#ffffff> <color=#00FF06>Skin \"Lynx skin\"<color=#ffffff> unequipped. This is not a real console command, although it appears to be.\n";
        }
        else if (cmd == "lynx 1")
        {
            BetterPrefs.SetInt("lynxskin", 1);
            console.text += "<color=#ff4f30>CPVAMCA command override:<color=#ffffff> <color=#00FF06>Skin \"Lynx skin\"<color=#ffffff> equipped. This is not a real console command, although it appears to be.\n";
        }
        /*
        else if (cmd == "hats.santa 1")
        {
            BetterPrefs.SetInt("xmasHat", 1);
            console.text += "<color=#ff4f30>CPVAMCA command override:<color=#ffffff> <color=#00FF06>Hat \"Christmas Hat\"<color=#ffffff> equipped. This is not a real console command, although it appears to be.\n";
        }
        else if (cmd == "hats.santa 0")
        {
            BetterPrefs.SetInt("xmasHat", 0);
            console.text += "<color=#ff4f30>CPVAMCA command override:<color=#ffffff> <color=#00FF06>Hat \"Christmas Hat\"<color=#ffffff> unequipped. This is not a real console command, although it appears to be.\n";
        }*/
        else if (cmd.StartsWith("area unlock "))
        {
            string area = cmd.Substring(12);
            int areaNum = int.Parse(area);
            BetterPrefs.SetInt("level" + areaNum, 1);
            console.text += "Unlocked <color=#00FF06>area " + area + "<color=#ffffff>. If this area doesn't exist, it will be unlocked immediately upon creation.\n";
        }
        else if (cmd.StartsWith("area load "))
        {
            // substring the area number
            string area = cmd.Substring(10);
            int areaNum = int.Parse(area);
            BetterPrefs.SetInt("level" + areaNum, 1);
            SceneManager.LoadScene(areaNum);
        }
        else if (cmd.StartsWith("area unload "))
        {
            // substring the area number
            string area = cmd.Substring(12);
            int areaNum = int.Parse(area);
            console.text += "Unloaded <color=#00FF06>area " + area + "<color=#ffffff>. If this area doesn't exist, or is already unloaded, nothing will happen.\n";
        }
        else if (cmd.StartsWith("area lock all"))
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings - 2; i++)
            {
                if (i != 0)
                {
                    BetterPrefs.SetInt("level" + i, 0);
                    console.text += "Locked <color=#00FF06>area " + i + "<color=#ffffff>. If this area doesn't exist, it will be locked immediately upon creation.\n";
                }
            }
        }
        else if (cmd.StartsWith("area lock "))
        {
            string area = cmd.Substring(10);
            int areaNum = int.Parse(area);
            BetterPrefs.SetInt("level" + areaNum, 0);
            console.text += "Locked <color=#00FF06>area " + area + "<color=#ffffff>. If this area doesn't exist, it will be locked immediately upon creation.\n";
        }
        else if (cmd.StartsWith("area erase "))
        {
            console.text += "<color=#ff1010>Invalid 2 factor authentication code.\n<color=#ffffff>";
        }
        else if (cmd.StartsWith("area create "))
        {
            console.text += "<color=#ff1010>Invalid 2 factor authentication code.\n<color=#ffffff>";
        }
        else if (cmd.StartsWith("kill "))
        {
            console.text += "<color=#ff1010>Invalid entity.\n<color=#ffffff>";
        }
        else
        {
            console.text += "<color=#ff1010>Unknown command<color=#ffffff>\n";
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Password()
    {
        string pass = inputField.text;
        inputField.text = "";
        if (pass == "")
        {
            console.text += "\n<color=#ff1010>Incorrect";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Everything in the terminal besides the buttons and the password is canonical. The commands are all canonical, the text, but not the password, nor the scrollbar, the exit button, the submit button, and input field.
        else if (pass == "I understand that I am ruining my fun by cheating, and choose to do it anyway.")
        {
            console.text += "******************************************************************************\n<color=#10ff10>Logged in successfully<color=#ffffff>";
            console.text += "\n";
            loggedIn = true;
        }
        else
        {
            console.text += pass + "\n<color=#ff1010>Incorrect";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Enter();
            inputField.Select();
            inputField.ActivateInputField();
        }
        if (inputField.text.Trim() == "kill all")
        {
            // Attempted genocide is a severe violation of CPVAMCA policy and results in a permanent blacklist.
            cover.SetActive(true);
            SceneManager.LoadScene("CPVAMCA");
        }
    }
}
