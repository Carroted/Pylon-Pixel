using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string levelName;
    public DailyLevel DailyLevel;
    int emptyLevelScene;
    public GameObject levelMenu;
    void Awake()
    {
        emptyLevelScene = SceneManager.sceneCountInBuildSettings - 5;
    }
    public void OnClick()
    {
        Scene original = SceneManager.GetActiveScene();
        // Start the LoadYourAsyncScene coroutine
        StartCoroutine(LoadYourAsyncScene(original.buildIndex));
    }
    IEnumerator LoadYourAsyncScene(int original)
    {
        // Load the empty level scene asynchronomously, and generate the level using the DailyLevel.chunks array. Each chunk is a GameObject, and they should all be 40 units apart, with the first one being at (60, -20, 0).

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(emptyLevelScene, LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        int i = 0;
        foreach (GameObject chunk in DailyLevel.chunks)
        {

            // Instantiate the chunk at the correct position in the other scene
            GameObject newChunk = Instantiate(chunk, new Vector3(60, -20, 0), Quaternion.identity);
            SceneManager.MoveGameObjectToScene(newChunk, SceneManager.GetSceneByBuildIndex(emptyLevelScene));
            newChunk.transform.position += new Vector3(i * 40, 0, 0);
            i++;
        }
        print("Loaded daily level " + levelName);

        // Unload this scene
        SceneManager.UnloadSceneAsync(original);
        // Sacrifice DailyLevelMenu and self along with it to save memory :'(
        Destroy(this.levelMenu);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
