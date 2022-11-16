using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    SpriteRenderer renderer;
    [SerializeField]
    [Header("노드빌드용일때 체크하시오")]
   public bool bIsNodeBuilder = false;

    [SerializeField]
    PlayerNodechecker LargeCircleChecker;
    [SerializeField]
    PlayerNodechecker SmallCircleChecker;

    [SerializeField]
    GameObject NodeBuildObject;
    AudioSource audioSource;

    [SerializeField]
    SpriteRenderer rayderImage;

    float RadyerAlpha;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        if (bIsNodeBuilder == false)
            NodeBuildObject.SetActive(false);
        else
            cGameManager.instance.GameStartOrPuase();

        RadyerAlpha = 0.5f;
        rayderImage.color = new Color(1.0f, 1.0f, 1.0f, RadyerAlpha);
    }

    private void PlayTilePressSound()
    {
        RadyerAlpha = 1.0f;
        audioSource.Stop();
        audioSource.Play();
    }
    private void KeyEvent()
    {
        if (cGameManager.instance.bIsMoveLine == false ) return;

        if (bIsNodeBuilder == true) return;

        if (Input.GetKeyDown(cGameManager.instance.GetSmallKey()))
        {
            SmallCircleChecker.PressNodeCheckrt(0);
            PlayTilePressSound();
        }
        if (Input.GetKeyDown(cGameManager.instance.GetLargeKey()))
        {
            LargeCircleChecker.PressNodeCheckrt(1);
            PlayTilePressSound();
        }
    }
    public void CheckNodeScore(int _PressType)
    {
       // print(_PressType);
    }
    void Update()
    {
        KeyEvent();

        if (RadyerAlpha > 0.5f)
        {
            RadyerAlpha -= Time.deltaTime * 2.0f;
        }
        else
        {
            RadyerAlpha = 0.5f;
        }
        rayderImage.color = new Color(1.0f, 1.0f, 1.0f, RadyerAlpha);
    }
}
