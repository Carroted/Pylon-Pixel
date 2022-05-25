using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the controls for mobile devices (Android, iOS, etc.) and disables them in certain conditions.
public class MobileControlsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (BetterPrefs.HasKey("MobileControls"))
        {
            if (BetterPrefs.GetInt("MobileControls") == 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            // If we're not on a mobile device, or we're in the editor, then disable the mobile controls. This can be toggled in settings later.
            //if ((Application.isEditor || !Application.isMobilePlatform))
            //{
            //    BetterPrefs.SetInt("MobileControls", 0);
            //    gameObject.SetActive(false);
            //}
            //else
            //{
            BetterPrefs.SetInt("MobileControls", 1);
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
