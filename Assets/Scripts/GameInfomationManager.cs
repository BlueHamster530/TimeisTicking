using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfomationManager : MonoBehaviour
{
    static public GameInfomationManager instance;

    [SerializeField]
    AudioClip SelectedMusicClip;
    [SerializeField]
    string MusicName;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetSeletedMusicClip(AudioClip clip)
    {
        SelectedMusicClip = clip;
    }
    public void SetMusicName(string Name)
    {
        MusicName = Name;
    }

    public AudioClip GetSelectedMuslicClip()
    {
        if (SelectedMusicClip == null)
        {
            Debug.LogError("선택된 노래가 없습니다 휴먼");
            return null;
        }
        return SelectedMusicClip;
    }
    public string GetMusicName()
    {
        return MusicName;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
