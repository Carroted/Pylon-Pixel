using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the controls for mobile devices (Android, iOS, etc.) and disables them in certain conditions.
public class MobileControlsManager : MonoBehaviour
{
    // Unity Inspector tooltip
    [Tooltip("Show the mobile controls even on non-mobile devices. This is only used in editor to test mobile controls, and should NEVER be used in build.")]
    public bool fakeMobile = false;
    // Start is called before the first frame update
    void Awake()
    {
        // If we're not on a mobile device, or we're in the editor and we're not testing mobile controls, then disable the mobile controls.
        if ((Application.isEditor || !Application.isMobilePlatform) && !fakeMobile)
        {
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
