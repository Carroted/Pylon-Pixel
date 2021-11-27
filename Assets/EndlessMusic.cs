using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMusic : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            print(Random.Range(0, music.Length));
            source.clip = music[Random.Range(0, music.Length)];
            source.Play();
        }
    }
}
