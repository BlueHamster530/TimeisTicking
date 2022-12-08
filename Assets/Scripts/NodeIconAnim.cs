using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIconAnim : MonoBehaviour
{
    [SerializeField]
    GameObject JustCircleObject;

    [SerializeField]
    GameObject IconObject;

    [SerializeField]
    GameObject InfoImageObject;

    SpriteRenderer iconrenderer;
    SpriteRenderer InfoImagerenderer;
    float fAlpha;
    bool IsIconSpawn;
    float InfoImageWidth;
    float CurrentInfoImageWidth;
    float infoshowtime;
    bool InfoImageShow;

    private void Start()
    {
        iconrenderer = IconObject.GetComponent<SpriteRenderer>();
        InfoImagerenderer = InfoImageObject.GetComponent<SpriteRenderer>();
        InfoImageWidth = InfoImagerenderer.size.x;
        CurrentInfoImageWidth = 0;
        InfoImagerenderer.size = new Vector2(CurrentInfoImageWidth, InfoImagerenderer.size.y);
        InfoImageShow = false;
        IconObject.SetActive(false);
        InfoImageObject.SetActive(false);
        fAlpha = 1.5f;
        IsIconSpawn = false;
        infoshowtime = 0;
    }
    private void Update()
    {
        if (IsIconSpawn == true)
        {
            fAlpha -= Time.deltaTime*1.5f;
            float RealAlpga = Mathf.Clamp(fAlpha, 0, 1);
            if (fAlpha <= 0)
            {
                fAlpha = 0;
                IsIconSpawn = true;
                JustCircleObject.SetActive(true);
                IconObject.SetActive(false);
            }
            iconrenderer.color = new Color(1, 1, 1, RealAlpga);
        }
        if (InfoImageShow == true)
        {
            if (infoshowtime < 1.0f)
            {
                infoshowtime += Time.deltaTime*2.2f;
                if (infoshowtime >= 1.0f)
                    infoshowtime = 1.0f;
                CurrentInfoImageWidth = Mathf.Lerp(0, InfoImageWidth, infoshowtime);
                InfoImagerenderer.size = new Vector2(CurrentInfoImageWidth, InfoImagerenderer.size.y);
            }
        }
        
    }
    private void EnterPlayer()
    {
        JustCircleObject.GetComponent<JustRotate>().Init();
        JustCircleObject.SetActive(false);
        IconObject.SetActive(true);
        iconrenderer.color = new Color(1, 1, 1, 1);
        IsIconSpawn = true;
        fAlpha = 1.5f;
        if (InfoImageShow == false)
        {
            InfoImageShow = true;
            CurrentInfoImageWidth = 0;
            InfoImagerenderer.size = new Vector2(CurrentInfoImageWidth, InfoImagerenderer.size.y);
            infoshowtime = 0;
            InfoImageObject.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "OutCircle" || collision.name == "InCircle" )
        {
            EnterPlayer();
        } 
    }

}
