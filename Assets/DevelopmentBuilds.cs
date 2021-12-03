using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopmentBuilds : MonoBehaviour
{
    public GameObject devIcon;
    // Start is called before the first frame update
    void Start()
    {
        if (Debug.isDebugBuild)
        {
            devIcon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
