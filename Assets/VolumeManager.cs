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
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 5);
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 5);
        }
        if (music != null)
        {
            music.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (sfx != null)
        {
            sfx.volume = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (music != null)
        {

            music.volume = PlayerPrefs.GetFloat("MusicVolume") / 10;
        }
        if (sfx != null)
        {
            sfx.volume = PlayerPrefs.GetFloat("SFXVolume") / 10;
        }
    }
}
