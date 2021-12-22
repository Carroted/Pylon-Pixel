using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DailyLevel
{
    public DateTime date;
    public GameObject[] chunks;
    public DailyLevel(DateTime date, GameObject[] chunks)
    {
        this.date = date;
        this.chunks = chunks;
    }
}
public class DailyLevelMenu : MonoBehaviour
{
    // Prefab of a level button
    public GameObject levelButtonPrefab;
    // How much to offset between each level button
    public float levelButtonOffset = 148.51f;
    // The ScrollView content
    public GameObject levelButtonParent;

    public GameObject[] chunks;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

        string levels = Application.persistentDataPath + "/dailylevels.pypixdl";
        if (File.Exists(levels))
        {
            // Read file with StreamReader
            StreamReader file = new StreamReader(levels);
            string text = file.ReadToEnd();
            file.Close();
            // If there isn't a level for today, create one
            if (!text.Contains(DateTime.Today.ToString("yyyy/MM/dd")))
            {
                int chunksAmount = 8;
                // Create a random array of chunks
                string[] chunksArray = new string[chunksAmount];
                for (int i = 0; i < chunksAmount; i++)
                {
                    chunksArray[i] = UnityEngine.Random.Range(0, chunks.Length).ToString();
                }

                // Write daily level in format "yyyy/MM/dd|(chunk IDs separated by commas)" in a new line
                StreamWriter savefile = new StreamWriter(levels, true);
                savefile.WriteLine(DateTime.Today.ToString("yyyy/MM/dd") + "|" + string.Join(",", chunksArray));
                savefile.Close();
            }

            // Generate level buttons

            string[] lines = text.Split(
    new string[] { Environment.NewLine },
    StringSplitOptions.RemoveEmptyEntries
);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('|');
                GameObject levelButton = Instantiate(this.levelButtonPrefab, this.levelButtonParent.transform);
                levelButton.transform.parent = levelButtonParent.transform;
                levelButton.transform.localPosition = new Vector3(0, (i * levelButtonOffset) + -282.74f, 0);
                levelButton.GetComponent<LevelButton>().levelName = line[0];
                levelButton.GetComponent<LevelButton>().levelMenu = this.gameObject;
                /* Chunks are stored by an integer index in the file. The chunks variable is an array of GameObjects. The integer index is used to find the GameObject in the chunks array.
                The file contains multiple chunks, separated by a comma. The chunks are in order, and should be loaded in the same order.
                We take each integer in the line, find its chunk, and the resulting array of GameObjects are used as the levelButton's LevelButton.DailyLevel.chunks.
                */
                string[] chunkIndices = line[1].Split(',');

                GameObject[] chunksToUse = new GameObject[chunkIndices.Length];
                for (int j = 0; j < chunkIndices.Length; j++)
                {
                    int chunkIndex = int.Parse(chunkIndices[j]);
                    chunksToUse[j] = chunks[chunkIndex];
                }

                levelButton.GetComponent<LevelButton>().DailyLevel = new DailyLevel(DateTime.Parse(line[0]), chunksToUse);
            }
        }
        else
        {
            // Create new FileStream
            FileStream fs = new FileStream(levels, FileMode.Create);
            fs.Close();

            int chunksAmount = 8;
            // Create a random array of chunks
            string[] chunksArray = new string[chunksAmount];
            for (int i = 0; i < chunksAmount; i++)
            {
                chunksArray[i] = UnityEngine.Random.Range(0, chunks.Length).ToString();
            }

            // Write daily level in format "yyyy/MM/dd|(chunk IDs separated by commas)" in a new line by creating a new StreamWriter
            StreamWriter savefile = new StreamWriter(levels, true);
            savefile.WriteLine(DateTime.Today.ToString("yyyy/MM/dd") + "|" + string.Join(",", chunksArray));
            savefile.Close();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}