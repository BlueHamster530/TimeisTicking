using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeMusicInfo : MonoBehaviour
{
    [SerializeReference]
    AudioClip MusicClip;
    [SerializeField]
    string MusicName;
    [SerializeField]
    Sprite MusicSelectImage;

    [SerializeField]
    Image NodeInfoImage;
    public void SetUpMusic()
    {
        GameInfomationManager.instance.SetSeletedMusicClip(MusicClip);
        GameInfomationManager.instance.SetMusicName(MusicName);
        MusicSelectManager.instance.ShowMusicInfoPannel(MusicClip);
        NodeInfoImage.sprite = MusicSelectImage;
        GameInfomationManager.instance.BGMPause();
    }

}
