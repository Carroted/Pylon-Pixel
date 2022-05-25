using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{

    // Level transition circle (covers the screen while level is loading)'s Animator
    private Animator circle;
    public GameObject sorry; // Sorry that the move to BetterPrefs caused some inconveniences
    public TMP_InputField importPath; // Input field for importing the S A V E   D A T A
    public TMP_InputField exportPath; // Input field for exporting the S A V E   D A T A

    public GameObject successfulImport; // Text that appears when importing is successful
    public GameObject successfulExport; // Text that appears when exporting is successful

    public GameObject errorImport; // Text that appears when importing is unsuccessful
    public GameObject errorExport; // Text that appears when exporting is unsuccessful

    // Start is called before the first frame update

    void OnApplicationQuit()
    {
        BetterPrefs.Save();
    }

    void Awake()
    {
        BetterPrefs.Load(Application.persistentDataPath + "/save.pypix"); // pypix is short for Pylon Pixel
    }
    void Start()
    {
        // Get level transition circle's Animator
        circle = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FillNSlider>().circle;

        // For loop that goes from 1 to 55
        for (int i = 1; i <= 55; i++)
        {
            if (PlayerPrefs.HasKey("level" + i))
            {
                // Move to BetterPrefs
                BetterPrefs.SetInt("level" + i, PlayerPrefs.GetInt("level" + i));

                // Delete PlayerPref
                PlayerPrefs.DeleteKey("level" + i);

                sorry.SetActive(true);
            }
        }

        if (PlayerPrefs.HasKey("gold"))
        {
            BetterPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 800); // compensation for the imperfect move to BetterPrefs
            PlayerPrefs.DeleteKey("gold");
        }

        if (PlayerPrefs.HasKey("egold"))
        {
            BetterPrefs.SetInt("egold", PlayerPrefs.GetInt("egold"));
            PlayerPrefs.DeleteKey("egold");
        }

        if (PlayerPrefs.HasKey("strip"))
        {
            BetterPrefs.SetString("strip", PlayerPrefs.GetString("strip"));
            PlayerPrefs.DeleteKey("strip");
        }

        if (PlayerPrefs.HasKey("base"))
        {
            BetterPrefs.SetString("base", PlayerPrefs.GetString("base"));
            PlayerPrefs.DeleteKey("base");
        }

        if (PlayerPrefs.HasKey("color"))
        {
            BetterPrefs.SetString("color", PlayerPrefs.GetString("color"));
            PlayerPrefs.DeleteKey("color");
        }

        if (PlayerPrefs.HasKey("hat"))
        {
            BetterPrefs.SetString("hat", PlayerPrefs.GetString("hat"));
            PlayerPrefs.DeleteKey("hat");
        }

        if (PlayerPrefs.HasKey("DeadZoneVolume"))
        {
            BetterPrefs.SetFloat("DeadZoneVolume", PlayerPrefs.GetFloat("DeadZoneVolume"));
            PlayerPrefs.DeleteKey("DeadZoneVolume");
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            BetterPrefs.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
            PlayerPrefs.DeleteKey("MusicVolume");
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            BetterPrefs.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
            PlayerPrefs.DeleteKey("SFXVolume");
        }

        if (PlayerPrefs.HasKey("MobileControls"))
        {
            BetterPrefs.SetInt("MobileControls", PlayerPrefs.GetInt("MobileControls"));
            PlayerPrefs.DeleteKey("MobileControls");
        }

        if (PlayerPrefs.HasKey("antikills"))
        {
            BetterPrefs.SetInt("antikills", PlayerPrefs.GetInt("antikills"));
            PlayerPrefs.DeleteKey("antikills");
        }

        if (PlayerPrefs.HasKey("eliteantikills"))
        {
            BetterPrefs.SetInt("eliteantikills", PlayerPrefs.GetInt("eliteantikills"));
            PlayerPrefs.DeleteKey("eliteantikills");
        }

        if (PlayerPrefs.HasKey("deaths"))
        {
            BetterPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths"));
            PlayerPrefs.DeleteKey("deaths");
        }

        if (!BetterPrefs.HasKey("antikills"))
        {
            BetterPrefs.SetInt("antikills", 0);
        }

        if (!BetterPrefs.HasKey("eliteantikills"))
        {
            BetterPrefs.SetInt("eliteantikills", 0);
        }

        if (!BetterPrefs.HasKey("deaths"))
        {
            BetterPrefs.SetInt("deaths", 0);
        }
    }
    // Continue game button
    public void Continue()
    {
        // If the player has a save
        if (BetterPrefs.HasKey("level"))
        {
            // Load the level from save
            LoadLevel(BetterPrefs.GetInt("level"));
        }
        else
        {
            // Otherwise, load the first level
            LoadLevel(1);
        }
    }
    // Endless mode button
    public void Endless()
    {
        // Load the last level (the endless level)
        LoadLevel(SceneManager.sceneCountInBuildSettings - 3);
    }
    public void LoadLevel(int index)
    {
        // Loads the level with the given index
        StartCoroutine(StartTransitionAndLoad(index));
    }
    IEnumerator StartTransitionAndLoad(int index)
    {
        // Start the transition animation
        circle.SetTrigger("EndLevel");

        // Wait for the animation to finish
        yield return new WaitForSeconds(1f);

        // Begin loading the level
        SceneManager.LoadScene(index);
    }
    public void StatsAndAchievementsy()
    {

        // Load the stats and achievements scene
        SceneManager.LoadScene("Stats");
    }
    public void EraseAll()
    {
        // WARNING: DO NOT CALL THIS UNLESS YOU WISH TO ERASE ALL PROGRESS

        // Erase all progress
        BetterPrefs.DeleteAll();
        BetterPrefs.Save();
    }
    public void CloseGame()
    {
        // Close the game
        Application.Quit();
    }
    public void Settings()
    {
        // Not implemented yet
    }

    public void ExportSave(string path)
    {
        BetterPrefs.Save(path);
    }

    public bool ImportSave(string path)
    {
        if (System.IO.File.Exists(path))
        {
            // Delete
            System.IO.File.Delete(Application.persistentDataPath + "/save.pypix");

            // Copy
            System.IO.File.Copy(path, Application.persistentDataPath + "/save.pypix");

            // Load
            BetterPrefs.Load(Application.persistentDataPath + "/save.pypix");

            return true;
        }
        else
        {
            return false;
        }
    }

    public void ExportSave()
    {
        try
        {
            ExportSave(exportPath.text);
            successfulExport.SetActive(true);
        }
        catch
        {
            errorExport.SetActive(true);
            successfulExport.SetActive(false);
        }
    }

    public void ImportSave()
    {
        if (ImportSave(importPath.text))
        {
            successfulImport.SetActive(true);
            errorImport.SetActive(false);
        }
        else
        {
            errorImport.SetActive(true);
            successfulImport.SetActive(false);
        }
    }
}
