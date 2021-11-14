using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExactFollow : MonoBehaviour
{
    public float speed = -0.1f;
    public GameObject cam;
    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {

        prevPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position += (prevPos - cam.transform.position) * (speed);
        prevPos = cam.transform.position;
    }
}
