using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAndCoverScreen : MonoBehaviour
{
    public GameObject cover;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Load()
    {
        cover.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
