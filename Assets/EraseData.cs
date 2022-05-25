using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EraseData : MonoBehaviour
{
    public void EraseAll()
    {
        // WARNING: DO NOT CALL THIS UNLESS YOU WISH TO ERASE ALL PROGRESS

        // Erase all progress
        BetterPrefs.DeleteAll();
        BetterPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
