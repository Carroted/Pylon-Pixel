using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public bool paused = false;
    public GameObject pausemenu;
    public float timeScale = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Zero()
    {
        paused = true;
        Time.timeScale = 0f;
    }
    public void One()
    {
        paused = false;
        Time.timeScale = timeScale;
    }
    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void StatsAndAchievements()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stats");
    }
    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = timeScale;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
            pausemenu.SetActive(!pausemenu.activeSelf);
        }
    }
}
