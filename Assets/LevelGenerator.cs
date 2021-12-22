using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
// This script generates a level in the Unity Editor with a menu in the top bar to pick how many chunks to generate, and a picker of which chunks to use. Chunks are an array of GameObjects, and the script will randomly pick one of them to instantiate. Each chunk is 40x40, so each new chunk is placed 40 units to the right of the previous chunk.
public class LevelGenerator : EditorWindow
{
    private int numberOfChunks;
    private GameObject[] chunks = new GameObject[8];

    // Create a menu in the Unity Editor top bar (bar which shows File, Edit, Assets, etc.)
    [MenuItem("Level Generator/Generate Level")]

    // Create the Generate Level window
    public static void ShowWindow()
    {
        // Create a new window
        LevelGenerator levelGenerator = (LevelGenerator)EditorWindow.GetWindow(typeof(LevelGenerator));

    }
    void OnGUI()
    {
        // Create a label to show the user what the script does
        GUILayout.Label("This script generates a level in the Unity Editor with a menu in the top bar to pick how many chunks to generate, and a picker of which chunks to use. Chunks are an array of GameObjects, and the script will randomly pick one of them to instantiate. Each chunk is 40x40, so each new chunk is placed 40 units to the right of the previous chunk.");
        // Create a label to show the user what the script does
        GUILayout.Label("Select the number of chunks to generate");
        // Create a slider to pick how many chunks to generate
        numberOfChunks = EditorGUILayout.IntSlider(numberOfChunks, 1, 10);
        // Create 8 ObjectFields to pick which chunks to use

        chunks[0] = (GameObject)EditorGUILayout.ObjectField("Chunk 1", chunks[0], typeof(GameObject), false);
        chunks[1] = (GameObject)EditorGUILayout.ObjectField("Chunk 2", chunks[1], typeof(GameObject), false);
        chunks[2] = (GameObject)EditorGUILayout.ObjectField("Chunk 3", chunks[2], typeof(GameObject), false);
        chunks[3] = (GameObject)EditorGUILayout.ObjectField("Chunk 4", chunks[3], typeof(GameObject), false);
        chunks[4] = (GameObject)EditorGUILayout.ObjectField("Chunk 5", chunks[4], typeof(GameObject), false);
        chunks[5] = (GameObject)EditorGUILayout.ObjectField("Chunk 6", chunks[5], typeof(GameObject), false);
        chunks[6] = (GameObject)EditorGUILayout.ObjectField("Chunk 7", chunks[6], typeof(GameObject), false);
        chunks[7] = (GameObject)EditorGUILayout.ObjectField("Chunk 8", chunks[7], typeof(GameObject), false);

        // Create a button to generate the level
        if (GUILayout.Button("Generate Level"))
        {
            // Generate the level
            GenerateLevel(numberOfChunks, chunks);
        }
    }
    // Create a function called GenerateLevel
    public static void GenerateLevel(int numberOfChunks, GameObject[] chunks)
    {
        Vector3 spawnPosition = new Vector3(60, -20, 0);
        for (int i = 0; i < numberOfChunks; i++)
        {
            // Pick a random chunk from the array of chunks
            int randomChunk = Random.Range(0, chunks.Length);

            // Instantiate the chunk at the spawn position
            GameObject spawned = PrefabUtility.InstantiatePrefab(chunks[randomChunk]) as GameObject;
            // Set the position of the chunk to the spawn position
            spawned.transform.position = spawnPosition;

            // Move the spawn position 40 units to the right
            spawnPosition += new Vector3(40, 0, 0);
        }
        Debug.Log("Level generated successfully with " + numberOfChunks + " chunks");
    }
}
