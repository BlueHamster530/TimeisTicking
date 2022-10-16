using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject NodePrefab;
    [SerializeField]
    PlayerInfomation player;

    [SerializeField]
    Transform LargeCircleTransform;
    [SerializeField]
    Transform SmallCircleTransform;


    MusicNodeInfoList nodeList = new MusicNodeInfoList();

    float fCurrentNodeBuildPlayTime;

    // Start is called before the first frame update
    public void AddNodeList(float _Time, int _Type, Vector3 Position, float _zRotate)
    {
        MusicNodeInfo clone = new MusicNodeInfo(_Time, _Type, Position.x, Position.y, _zRotate);
        nodeList.nodeList.Add(clone);
    }

    private void KeyEvent()
    {
        if (cGameManager.instance.bIsStart == false) return;

        if (Input.GetKeyDown(cGameManager.instance.GetSmallKey()))
        //if (Input.GetKeyDown(KeyCode.S))
        {
            PushNodePrefab(fCurrentNodeBuildPlayTime, 0, SmallCircleTransform.position);
        }
        if (Input.GetKeyDown(cGameManager.instance.GetLargeKey()))
        {
            PushNodePrefab(fCurrentNodeBuildPlayTime, 1, LargeCircleTransform.position);
        }
    }
    [ContextMenu("SaveNodeList")]
    public void SaveNodeList()
    {
        print(nodeList.nodeList.Count);
        NodeBuliderMusicInfoMaker.instance.NodeList = nodeList;
        NodeBuliderMusicInfoMaker.instance.SaveNodeList();
    }
    private void PushNodePrefab(float _fTime, int Type, Vector3 _Position)
    {
        Quaternion Angle = Quaternion.identity;
        Angle.eulerAngles = new Vector3(0, 0, 360.0f - player.transform.eulerAngles.z);
         AddNodeList(_fTime, Type, _Position, Angle.eulerAngles.z);
        GameObject clone = Instantiate(NodePrefab, _Position, Angle);
        clone.GetComponent<NodeInfo>().Init(Type);
        Destroy(clone, 1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        KeyEvent();
        fCurrentNodeBuildPlayTime = cGameManager.instance.fCurrnetPlayTime - cGameManager.instance.fDelayTimeBeforeStart;
    }
}
