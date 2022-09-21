using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    [SerializeField]
    Sprite[] Spirteimage;//�����¿���� �� �� ����
    SpriteRenderer renderer;

    [SerializeField]
    int nType;

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
        //if (nType >= 4)
        //{
        //    nType -= 4;
        //    renderer.color = Color.black;
        //}
        //else
        //{
        //    renderer.color = Color.white;
        //}
        int rand = Random.Range(0, 4);
        renderer.sprite = Spirteimage[rand];
        
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
