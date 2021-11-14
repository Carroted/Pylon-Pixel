using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //public bool main = true;
    //public Camera cameraToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        //if(main)
        //{
            //cameraToLookAt = Camera.main;
        //}
    }
    

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
