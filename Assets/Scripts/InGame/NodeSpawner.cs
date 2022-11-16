using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    int nCurrentIndex;
    MusicNodeInfoList NodeList;

    [SerializeField]
    NodeInfo[] NodePrefabs;

    LookAtTarget[] NodePrefabsLookAt;
    // Start is called before the first frame update
    void Start()
    {
        nCurrentIndex = 0;
        NodePrefabsLookAt = new LookAtTarget[NodePrefabs.Length];
        int maxScore = NodePrefabs.Length * (int)NodeScore.Good;
        PlayerPrefs.SetInt("MaxScore", maxScore);
        for (int i = 0; i < NodePrefabs.Length; i++)
        {
            NodePrefabsLookAt[i] = NodePrefabs[i].GetComponent<LookAtTarget>();
        }
    }
    private void nodeSpawn()
    {
        if (cGameManager.instance.bIsStart == false) return;

        if(NodeList.nodeList.Count <=0 || NodeList.nodeList.Count <= nCurrentIndex) return;
        if (cGameManager.instance.fCurrnetPlayTime >= NodeList.nodeList[nCurrentIndex].fSpawnTime)
        {
            EnableNode(NodeList.nodeList[nCurrentIndex].nType, NodeList.nodeList[nCurrentIndex].xPos, NodeList.nodeList[nCurrentIndex].yPos, NodeList.nodeList[nCurrentIndex].zRotate);
            nCurrentIndex++;
         // NodeList.nodeList.RemoveAt(0);
        }
    }
    public void LookAt2D(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.forward);
    }
    private void EnableNode(int _Type, float _x, float _y, float _zRotate)
    {
        bool bIsCheck = true;
        for (int i = 0; i < NodePrefabs.Length; i++)
        {
            if (NodePrefabs[i].gameObject.activeSelf == false)
            {
                NodePrefabs[i].Init(_Type);
                NodePrefabs[i].transform.position = new Vector3(_x, _y, 0);
                NodePrefabsLookAt[i].SetupAngle();
                NodePrefabs[i].gameObject.SetActive(true);
                bIsCheck = false;
                break;
            }
        }
        if (bIsCheck == true)
        {
            print("��� ������ �迭�� ����");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (NodeList == null)
        {
            NodeList = NodeBuliderMusicInfoMaker.instance.NodeList;
        }
        nodeSpawn();
    }
}
