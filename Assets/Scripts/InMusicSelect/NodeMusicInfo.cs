using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMusicInfo : MonoBehaviour
{
    [SerializeReference]
    AudioClip MusicClip;
    [SerializeField]
    string MusicName;

    public void SetUpMusic()
    {
        GameInfomationManager.instance.SetSeletedMusicClip(MusicClip);
        GameInfomationManager.instance.SetMusicName(MusicName);
        MusicSelectManager.instance.ShowMusicInfoPannel(MusicClip);
    }

}
