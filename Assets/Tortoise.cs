using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : MonoBehaviour
{
    public GameObject pylon;
    public Sprite up;
    public Sprite down;
    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        pylon = FindObjectOfType<NewBehaviourScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(pylon.transform.position.y >= transform.position.y)
        {
            spr.sprite = up;
        }
        else
        {
            spr.sprite = down;
        }
    }
}
