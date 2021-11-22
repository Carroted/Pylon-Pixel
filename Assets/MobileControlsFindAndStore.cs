using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlsFindAndStore : MonoBehaviour
{
    public GameObject mobileControls;

    // Start is called before the first frame update
    void Awake()
    {
        mobileControls = GameObject.FindGameObjectWithTag("mobile");
    }
}
