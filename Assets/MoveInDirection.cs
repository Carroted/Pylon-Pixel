using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    public Vector3 move;
    public bool locall = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(locall)
        {
            transform.localPosition += move * Time.deltaTime;
        }
        else
        {
            transform.position += move * Time.deltaTime;
        }
    }
}
