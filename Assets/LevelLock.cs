using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public MainMenuButtons mmb;
    public int level;
    public GameObject lockk;
    public Button button;
    public bool neverLocked = false;
    public void Play()
    {
        mmb.LoadLevel(level);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (neverLocked)
        {
            return;
        }

        if (PlayerPrefs.HasKey("level" + level))
        {

            button.interactable = PlayerPrefs.GetInt("level" + level) == 1;
            lockk.SetActive(PlayerPrefs.GetInt("level" + level) == 0);

        }
        else
        {
            PlayerPrefs.SetInt("level" + level, 0);
            PlayerPrefs.Save();
            button.interactable = false;
            lockk.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
