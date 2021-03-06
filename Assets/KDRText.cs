using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KDRText : MonoBehaviour
{
    public TMP_Text text;
    private float kdr;
    public string[] killKeyNames;
    private int deaths;
    private int kills;
    // Start is called before the first frame update
    void Start()
    {
        if (BetterPrefs.HasKey("deaths"))
        {
            deaths = BetterPrefs.GetInt("deaths");
        }
        else
        {
            deaths = 0;
        }


        foreach (string key in killKeyNames)
        {
            if (BetterPrefs.HasKey(key))
            {
                kills += BetterPrefs.GetInt(key);
            }
        }
        kdr = (float)kills / (float)deaths;
        print(kdr);
        text.text = "KDR: " + kdr.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
