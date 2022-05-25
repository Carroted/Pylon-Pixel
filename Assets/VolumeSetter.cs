using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    public float middle = 5f;
    public Slider slider;
    public string key;

    // Start is called before the first frame update
    void Start()
    {
        if (BetterPrefs.HasKey(key + "Volume"))
        {
            slider.value = BetterPrefs.GetFloat(key + "Volume");
        }
        else
        {
            BetterPrefs.SetFloat(key + "Volume", middle);
        }

    }
    public void OnValueChanged()
    {
        BetterPrefs.SetFloat(key + "Volume", slider.value);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
