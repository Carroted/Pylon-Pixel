using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEveryIncrement : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawner;
    public float increment = 2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= increment)
        {
            timer = 0;
            Instantiate(prefab, spawner.transform.position, Quaternion.identity);
        }
    }
}
