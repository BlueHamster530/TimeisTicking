using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    [SerializeField]
    Sprite[] scoreimage;

    SpriteRenderer renderer;

    [SerializeField]
    float fDisapearTime = 1.0f;

    float fCurrentDisaperTime;
    Vector3 vDisapearVector;
    public void Init(int _ScoreType)
    {
        if (renderer == null)
            renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = scoreimage[_ScoreType];
        // fDisaperTime = 1.0f;
        fCurrentDisaperTime = 0.0f;
        vDisapearVector = transform.position + (transform.position * 0.2f);

    //    switch (_ScoreType)
    //    {
    //        case 0:
    //            {
    //                renderer.color = Color.white;
    //            }
    //            break;
    //        case 1:
    //            {
    //                renderer.color = Color.green;
    //            }
    //            break;
    //        case 2:
    //            {
    //                renderer.color = Color.blue;
    //            }
    //            break;
    //        case 3:
    //            {
    //                renderer.color = Color.black;
    //            }
    //            break;
    //    }
    }

    // Update is called once per frame
    void Update()
    {
        fCurrentDisaperTime += Time.deltaTime;
        if (fCurrentDisaperTime >= fDisapearTime)
        {
            Destroy(this.gameObject);
        }
        transform.position = Vector3.Slerp(this.transform.position, vDisapearVector, fCurrentDisaperTime);


    }
}
