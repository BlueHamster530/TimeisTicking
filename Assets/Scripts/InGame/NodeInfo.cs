using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    [SerializeField]
    Sprite[] InSideSpirteimage;//상하좌우순서 흰 검 순서
    [SerializeField]
    Sprite[] OutSideSpirteimage;//상하좌우순서 흰 검 순서
    [SerializeField]
    Sprite[] LightSpirteimage;//상하좌우순서 흰 검 순서
    SpriteRenderer renderer;

    [SerializeField]
    int nType;

    [SerializeField]
    GameObject LightObject;
    // Start is called before the first frame update
    //private void Start()
    //{
        //renderer = GetComponent<SpriteRenderer>();
        //Init(nType);
    //}
    public void Init(int _type)
    {
        if(renderer == null)
            renderer = GetComponent<SpriteRenderer>();
        SetUpSprite(_type);
    }
    private void SetUpSprite(int _type)
    {
        nType = _type;
        int rand = Random.Range(0, 4);
        if(nType ==0)//0이면 안쪽원
            renderer.sprite = InSideSpirteimage[rand];
        else
            renderer.sprite = OutSideSpirteimage[rand];

        rand = Random.Range(0, 200);
        rand = rand % 4; 
        LightObject.GetComponent<SpriteRenderer>().sprite = LightSpirteimage[rand];
    }
    public void DisableObject(float _time = 0.0f)
    {
        StartCoroutine(UnAbleObject(_time));
    }
    private IEnumerator UnAbleObject(float _time)
    {
       yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
        yield return null;
    }
}
