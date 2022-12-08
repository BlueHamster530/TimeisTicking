using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundVolume : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (audio == null)
        {
            print(this.name + "오디오소스없음");
        }
        audio.volume =  PlayerPrefs.GetFloat("SoundVolume");
    }
    private void Update()
    {
        if(audio.volume != PlayerPrefs.GetFloat("SoundVolume"))
            audio.volume = PlayerPrefs.GetFloat("SoundVolume");
    }
}
