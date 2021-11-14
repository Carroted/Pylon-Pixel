using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public bool paused = false;
    public GameObject pausemenu;
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
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
            Time.timeScale = 1f;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
            pausemenu.SetActive(!pausemenu.activeSelf);
        }
    }
}
