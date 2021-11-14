using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownThenUp : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.localPosition.y <= -5.333333f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
        }
    }
}
