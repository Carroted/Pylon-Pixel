using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementRequirement : MonoBehaviour
{
    public GameObject lockGroup;
    public string achievementKey;
    public int count;
    public bool unlocked = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey(achievementKey))
        {
            if (PlayerPrefs.GetInt(achievementKey) >= count)
            {
                lockGroup.SetActive(false);
                unlocked = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
