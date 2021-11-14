using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource src;
    public AudioClip healthfruit;
    public AudioClip poisonfruit;
    public AudioClip damage;
    public AudioClip playerGetDamage;
    public AudioClip shoot;
    public AudioClip hit;
    public AudioClip gold;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Play(AudioClip clip, float volume = 1f)
    {
        src.PlayOneShot(clip, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
