using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject WARN;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List<string> scenesInBuild = new List<string>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
        if (scenesInBuild.Contains("Multiplayer"))
        {
            WARN.SetActive(true);
            Debug.LogError("Multiplayer scene is in build settings. Please remove it. We cannot allow it to be loaded. Please don't ever think about loading it ever again. We hope you understand.");
            Time.timeScale = 1000f;
        }
    }
}
