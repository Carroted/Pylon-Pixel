using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(BetterPrefs.HasKey("level2"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
