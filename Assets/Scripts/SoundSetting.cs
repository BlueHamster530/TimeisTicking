using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    [SerializeField]
    AudioSource audio;
    // Start is called before the first frame update
    [SerializeField]
    float SoundVolume;

    public void SetSoundVolume()
    {
        audio.Stop();
        PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
        audio.volume = SoundVolume;
        audio.Play();
    }

}
