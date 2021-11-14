using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    public Slider slider;
    public string key;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(key + "Volume"))
        {
            slider.value = PlayerPrefs.GetFloat(key + "Volume");
        }
        else
        {
            PlayerPrefs.SetFloat(key + "Volume", 5f);
        }

    }
    public void OnValueChanged()
    {
        PlayerPrefs.SetFloat(key + "Volume", slider.value);
    }
    // Update is called once per frame
    void Update()
    {

    }
}