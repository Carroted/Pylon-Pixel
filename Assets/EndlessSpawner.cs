using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public GameObject[] chunks;
    public float offset = 40f;
    public GameObject prev;
    public GameObject prevprev;
    public GameObject prevprevprev;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(prevprevprev != null)
            {
                Destroy(prevprevprev);
            }
            
            prevprevprev = prevprev;
            prevprev = prev;
            prev = Instantiate(chunks[Random.Range(0, chunks.Length)], gameObject.transform.position, Quaternion.identity);
            transform.position += new Vector3(offset, 0f);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
