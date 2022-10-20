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
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (bIsNodeBuilder == false)
            NodeBuildObject.SetActive(false);
        else
            cGameManager.instance.GameStartOrPuase();
    }

    private void KeyEvent()
    {
        if (cGameManager.instance.bIsMoveLine == false ) return;

        if (bIsNodeBuilder == true) return;

        if (Input.GetKeyDown(cGameManager.instance.GetSmallKey()))
        {
            SmallCircleChecker.PressNodeCheckrt(0);
        }
        if (Input.GetKeyDown(cGameManager.instance.GetLargeKey()))
        {
            LargeCircleChecker.PressNodeCheckrt(1);
        }
    }
    public void CheckNodeScore(int _PressType)
    {
        print(_PressType);
    }
    void Update()
    {
        KeyEvent();
    }
}
