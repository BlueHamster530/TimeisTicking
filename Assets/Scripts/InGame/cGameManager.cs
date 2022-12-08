using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum NodeScore
{
    Null = -1, Bad = 0, Normal = 30, Good = 60, Perfact = 100
}
public class cGameManager : MonoBehaviour
{
    public static cGameManager instance;
    // Start is called before the first frame update

    public bool bIsStart;
    public bool bIsMoveLine;

    [SerializeField]
    MusicInfo musicinfo;

    [SerializeField]
    [Header("초반 딜레이 시간 설정")]
    public float fDelayTimeBeforeStart;

    [SerializeField]
     KeyCode SmallKey = KeyCode.S;
    [SerializeField]
    KeyCode LargeKey = KeyCode.K;

    [SerializeField]
    TextMeshProUGUI ScoreText;
    [SerializeField]
    TextMeshProUGUI ComboText;


    [SerializeField]
    GameObject GamePauseOnly;

    [SerializeField]
    Image continueCountDown;

    [SerializeField]
    GameObject GamePauseNotCountDownObject;


    [SerializeField]
    Sprite[] pausecount;

    public float fCurrnetPlayTime { get; set; }
    public float fMusicPlayDelayTime { get; set; }
    private int nScore;
    private int nCombo { get; set; }
    private int nMaxcombo;
    private bool bIsMusicAlreayStart = false;
    void Awake()
    {
        instance = this;
        bIsStart = true;
        bIsMoveLine = true;
        nScore = 0;
        fCurrnetPlayTime = 0;
        bIsMusicAlreayStart = false;
        if (musicinfo == null)
            musicinfo = GameObject.Find("MusicInfo").GetComponent<MusicInfo>();

        fMusicPlayDelayTime = 0;
        GamePauseOnly.SetActive(false);
        continueCountDown.sprite = pausecount[2];
        continueCountDown.gameObject.SetActive(false);
        GamePauseNotCountDownObject.SetActive(false);

        nCombo = 0 ;
        AddScore(0);
    }
    public KeyCode GetSmallKey()
    {
        return SmallKey;
    }
    public KeyCode GetLargeKey()
    {
        return LargeKey;
    }
    private void FixedUpdate()
    {
        if (bIsStart == true)
        {
            fCurrnetPlayTime += Time.deltaTime;//이게 초반 딜레이할때도 같이 돌아야 노드가 더 늦게 돌기시작함
            if (bIsMusicAlreayStart == false)
            {
                fMusicPlayDelayTime += Time.deltaTime;
                if (fMusicPlayDelayTime >= fDelayTimeBeforeStart)
                {
                    bIsMusicAlreayStart = true;
                    musicinfo.MusicStartOrPause(true);
                }
            }
            else
            {
                if (fCurrnetPlayTime >= musicinfo.clip.length + 3.0f)
                {
                    //게임종료
                    PlayerPrefs.SetInt("Score", nScore);
                    PlayerPrefs.SetInt("Combo", nMaxcombo);
                    SceneManager.LoadScene("GameEnd");
                }
            }
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && bIsStart == true)
        {
            GameStartOrPuase();
        }
    }
    public void GameStartOrPuase()
    {
        bIsMoveLine = !bIsMoveLine;
        bIsStart = !bIsStart;
        if (bIsMusicAlreayStart == true)
        {
            musicinfo.MusicStartOrPause(bIsStart);
        }
        if (bIsStart == false)
        {
            GamePauseOnly.SetActive(true);
            GamePauseNotCountDownObject.SetActive(true);
        }
    }
    public void GameContinue()
    {
        StartCoroutine("GameContinuCountDown");
    }
    private IEnumerator GameContinuCountDown()
    {

        GamePauseNotCountDownObject.SetActive(false);
        continueCountDown.gameObject.SetActive(true);
      

        for (int i = 3; i >= 1; i--)
        {
            //  continueCountDown.text = i.ToString();
            continueCountDown.sprite = pausecount[i-1];
            yield return new WaitForSeconds(1.0f);
        }

        continueCountDown.gameObject.SetActive(false);

        GamePauseOnly.SetActive(false);
        GameStartOrPuase();
        yield return null;
    }
    public void AddScore(int _Score)
    {
        nScore += _Score;
        ScoreText.text = "SCORE  " + nScore.ToString();
        nCombo++;
        if (_Score == 0)
            nCombo = 0;

        if (nCombo >= nMaxcombo)
            nMaxcombo = nCombo;
        ComboText.text = nCombo.ToString() + "  Combo";
    }
    public int GetScore()
    {
        return nScore;
    }
}
