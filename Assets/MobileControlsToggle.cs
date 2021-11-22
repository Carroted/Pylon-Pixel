using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileControlsToggle : MonoBehaviour
{
    public Toggle toggle;
    private GameObject mobileControls;
    public MobileControlsFindAndStore mobileControlsFindAndStore;
    public GameObject graphic;

    // Start is called before the first frame update
    void Awake()
    {
        toggle.isOn = PlayerPrefs.GetInt("MobileControls") == 1;
    }
    void Start()
    {
        mobileControls = mobileControlsFindAndStore.mobileControls;
    }
    public void OnValueChanged()
    {
        if (mobileControls == null)
        {
            mobileControls = mobileControlsFindAndStore.mobileControls;
        }
        if (toggle.isOn)
        {
            Debug.Log("Mobile Controls On");
            PlayerPrefs.SetInt("MobileControls", 1);
            mobileControls.SetActive(true);
        }
        else
        {
            Debug.Log("Mobile Controls Off");
            PlayerPrefs.SetInt("MobileControls", 0);
            mobileControls.SetActive(false);
        }
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        graphic.SetActive(toggle.isOn);
    }
}
