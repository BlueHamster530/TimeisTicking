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
    void Start()
    {
        instance = this;
        MusicInfoPannel.SetActive(false);
    }
    public void ShowMusicInfoPannel()
    {
        MusicInfoPannel.SetActive(true);
        line.bIsNodeSelect = false;
    }
    public void CloseMusicInfoPannel()
    {
        MusicInfoPannel.SetActive(false);
        line.bIsNodeSelect = true;
    }

    private void Update()
    {
        if(line.bIsNodeSelect == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {//게임시작
                SceneManager.LoadScene("InGame");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {//뮤직다시고르기
                CloseMusicInfoPannel();
            }
        }
    }
}
