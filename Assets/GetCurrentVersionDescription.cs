using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System;

public class GetCurrentVersionDescription : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        string url = "https://raw.githubusercontent.com/Carroted/Pylon-Pixel/main/versions";
        UnityWebRequest webjson = UnityWebRequest.Get(url);
        StartCoroutine(WaitForRequest(webjson));
    }
    IEnumerator WaitForRequest(UnityWebRequest webRequest)
    {
        // Request and wait for the desired page.
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError($"Failed to fetch data (Connection Error)");
            text.text = "Could not get version description. This is due to a connection error.";
        }
        else if (webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Failed to fetch data (Protocol Error)");
            text.text = "Could not get version description. This is due to a protocol error.";
        }
        else
        {
            Debug.Log("Successfully fetched data.");
            bool found = false;
            Version currentVersion = new Version(Application.version);
            foreach (string line in webRequest.downloadHandler.text.Split('\n'))
            {

                UpdateInfo updateInfo = new UpdateInfo(line);

                Version version = new Version(updateInfo.version);

                if (version == currentVersion)
                {
                    text.text = "What's new:\n" + updateInfo.description;
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                text.text = "Could not get version description.";
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}