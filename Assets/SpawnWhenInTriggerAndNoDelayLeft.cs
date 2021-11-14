using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWhenInTriggerAndNoDelayLeft : MonoBehaviour
{
    public GameObject pylon;
    public GameObject antip;
    public GameObject eliteantip;
    public GameObject spawn1;
    public GameObject spawn2;
    public bool x = false;

    public void XtoFalse()

    {
        x = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Random.Range(1, 300) == 50)
            {
                Instantiate(antip, spawn1.transform.position, Quaternion.identity);
                Instantiate(antip, spawn2.transform.position, Quaternion.identity);

            }
            else if (Random.Range(1, 900) == 50)
            {
                Instantiate(eliteantip, spawn1.transform.position, Quaternion.identity);
                Instantiate(eliteantip, spawn2.transform.position, Quaternion.identity);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!x)
        {
            transform.position = new Vector3(transform.position.x, pylon.transform.position.y + 6f);
        }
        else
        {
            transform.position = new Vector3(pylon.transform.position.x, transform.position.y);
        }
    }
}
