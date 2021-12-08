using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartupEventsProbably : MonoBehaviour
{
    public UnityEvent start;

    // Start is called before the first frame update
    void Start()
    {
        start.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
