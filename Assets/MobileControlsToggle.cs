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
        toggle.isOn = BetterPrefs.GetInt("MobileControls") == 1;
    }
    void Start()
    {
        if (mobileControlsFindAndStore != null)
        {
            mobileControls = mobileControlsFindAndStore.mobileControls;
        }
    }
    public void OnValueChanged()
    {
        if (mobileControls == null)
        {
            if (mobileControlsFindAndStore != null)
            {
                mobileControls = mobileControlsFindAndStore.mobileControls;
            }

        }

        if (toggle.isOn)
        {
            Debug.Log("Mobile Controls On");
            BetterPrefs.SetInt("MobileControls", 1);
            if (mobileControls != null)
            {
                mobileControls.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Mobile Controls Off");
            BetterPrefs.SetInt("MobileControls", 0);
            if (mobileControls != null)
            {
                mobileControls.SetActive(false);
            }
        }
        BetterPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        graphic.SetActive(toggle.isOn);
    }
}
