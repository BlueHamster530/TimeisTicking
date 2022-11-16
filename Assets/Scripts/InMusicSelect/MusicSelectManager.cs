using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSelectManager : MonoBehaviour
{
    static public MusicSelectManager instance;
    [SerializeField]
    GameObject MusicInfoPannel;
    [SerializeField]
    LineController line;
    // Start is called before the first frame update

    AudioSource pannelaudioSource;
    void Start()
    {
        instance = this;
        MusicInfoPannel.SetActive(false);
        pannelaudioSource = MusicInfoPannel.GetComponent<AudioSource>();
        GameInfomationManager.instance.BGMPlay();
    }
    public void ShowMusicInfoPannel(AudioClip musicclip)
    {
        MusicInfoPannel.SetActive(true);
        pannelaudioSource.clip = musicclip;
        pannelaudioSource.Stop();
        line.bIsNodeSelect = false;
        pannelaudioSource.Play();

    }
    public void CloseMusicInfoPannel()
    {
        pannelaudioSource.Stop();
        MusicInfoPannel.SetActive(false);
        line.bIsNodeSelect = true;
        GameInfomationManager.instance.BGMPlay();
    }

    private void Update()
    {
        if(line.bIsNodeSelect == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {//���ӽ���
                SceneManager.LoadScene("InGame");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {//�����ٽð���
                CloseMusicInfoPannel();
            }
        }
    }
}
