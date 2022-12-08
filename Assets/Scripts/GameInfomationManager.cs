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
    public AudioSource audioSource;
    public float BGMCurrentTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
        BGMCurrentTime = 0;
        DontDestroyOnLoad(this.gameObject);
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1.0f);
        }
    }
    public void SenceLoad(string SceneName)
    {
        BGMCurrentTime = audioSource.time;
        SceneManager.LoadScene(SceneName);
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            audioSource.Stop();
            BGMCurrentTime = 0;
        }
        else
        {
            if (audioSource.clip.length >= BGMCurrentTime)
            {
                BGMCurrentTime = 0;
            }
            audioSource.time = BGMCurrentTime;
            audioSource.Play();
        }
    }
    public void BGMPause()
    {
        audioSource.Pause();
    }
    public void BGMPlay()
    {
        audioSource.Play();
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
