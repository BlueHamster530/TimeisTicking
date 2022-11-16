using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEndingManager : MonoBehaviour
{
    [SerializeField]
    Image EndingInfo;

    [SerializeField]
    Sprite[] musicendingimage;

    int musicindex;
    int nscore;
    int ncombo;
    int nmaxscore;

    [SerializeField]
    TextMeshProUGUI ScoreText;
    [SerializeField]
    TextMeshProUGUI ComboText;
    [SerializeField]
    TextMeshProUGUI RankText;
    // Start is called before the first frame update
    void Start()
    {
        musicindex = PlayerPrefs.GetInt("MusicIndex");
        nscore = PlayerPrefs.GetInt("Score");
        ncombo = PlayerPrefs.GetInt("Combo");
        nmaxscore = PlayerPrefs.GetInt("MaxScore");
        EndingInfo.sprite = musicendingimage[musicindex];
        ScoreText.text = nscore.ToString();
        ComboText.text = ncombo.ToString();

        if (nscore >= nmaxscore * 0.9f)
        {
            RankText.text = "S Rank";
        }
        else if (nscore >= nmaxscore * 0.8f)
        {
            RankText.text = "A Rank";
        }
        else if (nscore >= nmaxscore * 0.7f)
        {
            RankText.text = "B Rank";
        }
        else if (nscore >= nmaxscore * 0.6f)
        {
            RankText.text = "C Rank";
        }
        else
        {
            RankText.text = "D Rank";
        }
    }

}
