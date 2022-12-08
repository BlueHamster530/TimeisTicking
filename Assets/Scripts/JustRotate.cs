using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour
{
    SpriteRenderer renderer;

    [SerializeField]
    float SpawnTime;
    [SerializeField]
    float speed;

    [SerializeField]
    bool IsJustRotate= false;

    bool bIsSpawned;
    float fAlpha;


    private void Start()
    {
        bIsSpawned = false;
        renderer = GetComponent<SpriteRenderer>();
        if (IsJustRotate == false)
        {
            Init();
        }
        SpawnTime = SpawnTime - 1.5f;
    }
    public void Init()
    {
        fAlpha = 0;
        renderer.color = new Color(1, 1, 1, fAlpha);
        transform.localScale = Vector3.one * 0.6f;
    }
    private void Update()
    {
        if (IsJustRotate == true) return;

        if (bIsSpawned == false)
        {
            if (SpawnTime < 0)
            {
                bIsSpawned = true;
            }
            else
            {
                SpawnTime -= Time.deltaTime;
            }
        }
        else
        {
            if (fAlpha < 1.0f)
            {
                fAlpha += Time.deltaTime * 1.75f;
                if (fAlpha >= 1.0f)
                {
                    fAlpha = 1.0f;
                }
                transform.localScale = Vector3.Lerp(Vector3.one * 0.6f, Vector3.one, fAlpha);
                renderer.color = new Color(1, 1, 1, fAlpha);
            }
        }
    }


    private void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}
