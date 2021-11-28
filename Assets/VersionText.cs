using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionText : MonoBehaviour
{
    private TMP_Text text;
    public string start = "Version";
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    private void OnValidate()
    {
        if (text == null)
        {
            text = GetComponent<TMP_Text>();
        }
        text.text = start + " " + Application.version;
    }
    // Update is called once per frame
    void Update()
    {
        text.text = start + " " + Application.version;
    }
}
