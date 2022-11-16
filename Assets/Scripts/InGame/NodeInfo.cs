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
    public int nType;

    float fCurrentLiveTime;
    //[SerializeField]
    //GameObject LightObject;
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
        //int rand = Random.Range(0, 4);
        //if(nType ==1)//1이면 안쪽원
        //    renderer.sprite = InSideSpirteimage[rand];
        //else
        //    renderer.sprite = OutSideSpirteimage[rand];
        renderer.sprite = OutSideSpirteimage[0];
        //rand = Random.Range(0, 200);
        //rand = rand % 4; 
        //LightObject.GetComponent<SpriteRenderer>().sprite = LightSpirteimage[rand];
        fCurrentLiveTime = 0;
        transform.localScale = Vector3.Lerp(new Vector3(0.7f, 0.7f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), fCurrentLiveTime);
    }
    private void FixedUpdate()
    {
        fCurrentLiveTime += Time.deltaTime*0.7f;
        if (fCurrentLiveTime >= 1.0f)
            fCurrentLiveTime = 1.0f;
        renderer.color = Color.Lerp(new Color(1, 1, 1, 0.6f), new Color(1, 1, 1, 0.6f), fCurrentLiveTime);
        transform.localScale = Vector3.Lerp(new Vector3(0.7f, 0.7f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f), fCurrentLiveTime);
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
