using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistic : MonoBehaviour
{
    public string key;
    public string start;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = start + ": " + BetterPrefs.GetInt(key);
    }
}
