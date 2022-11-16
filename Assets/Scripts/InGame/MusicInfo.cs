using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInfo : MonoBehaviour
{
    AudioSource audio;

    [SerializeField]
    public AudioClip clip;
    [SerializeField]
    PlayerInfomation player;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent <AudioSource> ();
        if (player.bIsNodeBuilder == false)
        {
            //audio.clip = clip;
            if (GameInfomationManager.instance == null)
            {
                MusicSetup(clip);
                NodeBuliderMusicInfoMaker.instance.SetUpMusic("0.Life_is_Journey");
            }
            else
            {
                MusicSetup(GameInfomationManager.instance.GetSelectedMuslicClip());
                NodeBuliderMusicInfoMaker.instance.SetUpMusic(GameInfomationManager.instance.GetMusicName());
            }
        }
        else
        {
            MusicSetup(clip);
        }
    }

    public void MusicSetup(AudioClip _clip)
    {
        clip = _clip;
        audio.clip = clip;
        string musicname = audio.clip.name.Substring(0,1);
        int musicindex = int.Parse(musicname);
        PlayerPrefs.SetInt("MusicIndex", musicindex);
    }

    public void MusicStartOrPause(bool _Value)
    {
        if (audio.clip == null) return;

        if (_Value == false)
            audio.Pause();
        else
            audio.Play();
    }
}
