using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementsChecker : MonoBehaviour
{
    public AchievementRequirement[] achievements;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        int unlocked = 0;
        foreach (AchievementRequirement achievement in achievements)
        {
            if (achievement.unlocked)
            {
                unlocked++;
            }
        }
        text.text = "Achievements: " + unlocked + "/" + achievements.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
