using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalChild : MonoBehaviour
{
    private Vector3 parentPrev;
    // Start is called before the first frame update
    void Start()
    {
        parentPrev = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.parent.position - parentPrev;
        parentPrev = transform.parent.position;
    }
}
