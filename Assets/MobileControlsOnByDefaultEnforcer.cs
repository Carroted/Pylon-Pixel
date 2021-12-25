using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlsOnByDefaultEnforcer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MobileControls"))
        {
            PlayerPrefs.SetInt("MobileControls", 1);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
