using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public AudioSource sfx;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        if (!BetterPrefs.HasKey("SFXVolume"))
        {
            BetterPrefs.SetFloat("SFXVolume", 5);
        }
        if (!BetterPrefs.HasKey("MusicVolume"))
        {
            BetterPrefs.SetFloat("MusicVolume", 5);
        }
        if (music != null)
        {
            music.volume = BetterPrefs.GetFloat("MusicVolume");
        }
        if (sfx != null)
        {
            sfx.volume = BetterPrefs.GetFloat("SFXVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (music != null)
        {

            music.volume = BetterPrefs.GetFloat("MusicVolume") / 10;
        }
        if (sfx != null)
        {
            sfx.volume = BetterPrefs.GetFloat("SFXVolume") / 10;
        }
    }
}
