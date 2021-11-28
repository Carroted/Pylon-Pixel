using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Open()
    {
        Application.OpenURL(url);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
