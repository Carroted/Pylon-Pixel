using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAndDontCoverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
