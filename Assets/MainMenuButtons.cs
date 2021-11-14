using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    // Level transition circle (covers the screen while level is loading)'s Animator
    private Animator circle;
    // Start is called before the first frame update
    void Start()
    {
        // Get level transition circle's Animator
        circle = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FillNSlider>().circle;
    }
    // Continue game button
    public void Continue()
    {
        // If the player has a save
        if (PlayerPrefs.HasKey("level"))
        {
            // Load the level from save
            LoadLevel(PlayerPrefs.GetInt("level"));
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
        LoadLevel(SceneManager.sceneCountInBuildSettings - 1);
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
    public void EraseAll()
    {
        // WARNING: DO NOT CALL THIS UNLESS YOU WISH TO ERASE ALL PROGRESS

        // Erase all progress
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
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

}
