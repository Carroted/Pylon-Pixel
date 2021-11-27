using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateCheckAndLoad : MonoBehaviour
{
    public GameObject updateScreen;
    public TMP_Text versionText;
    public TMP_Text descriptionText;
    private string updateURL = "";

    // Start is called before the first frame update
    void Start()
    {
        //if (Application.platform != RuntimePlatform.Android) return;

        string url = "https://raw.githubusercontent.com/Carroted/Pylon-Pixel/main/versions";
        UnityWebRequest webjson = UnityWebRequest.Get(url);
        StartCoroutine(WaitForRequest(webjson));

    }
    public void UpdateButton()
    {
        Application.OpenURL(updateURL);
    }
    IEnumerator WaitForRequest(UnityWebRequest webRequest)
    {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError($"Failed to fetch data (Connection Error)");
        }
        else if (webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Failed to fetch data (Protocol Error)");
        }
        else
        {
            Debug.Log("Successfully fetched data.");
            bool newVersion = false;
            Version currentVersion = new Version(Application.version);
            foreach (string line in webRequest.downloadHandler.text.Split('\n'))
            {

                UpdateInfo updateInfo = new UpdateInfo(line);

                Version version = new Version(updateInfo.version);

                if (version > currentVersion)
                {

                    updateScreen.SetActive(true);
                    versionText.text = $"Version {version} available";
                    descriptionText.text = updateInfo.description;
                    newVersion = true;
                    updateURL = updateInfo.downloadURL;
                    currentVersion = version;
                }

            }
            if (!newVersion)
            {
                Debug.Log("No new version available.");
            }
            else
            {
                Debug.Log("New version available.");
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class UpdateInfo
{
    public string version;
    public string description;
    public string downloadURL;

    public UpdateInfo(string line)
    {
        if (line != "")
        {
            version = line.Split(';')[0].Trim();
            description = line.Split(';')[1].Trim();
            downloadURL = "https://drive.google.com/u/0/uc?export=download&confirm=gxpY&id=" + line.Split(';')[2].Trim();
        }
        else
        {
            version = "0.0.0";
            description = "No description available";
            downloadURL = "";
        }
    }
}