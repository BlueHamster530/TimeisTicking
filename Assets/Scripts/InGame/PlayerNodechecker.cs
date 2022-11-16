using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNodechecker : MonoBehaviour
{
    // Start is called before the first frame update
    Queue<NodeInfo> nodes = new Queue<NodeInfo>();
    [SerializeField]
    PlayerInfomation Playerinfo;
    [SerializeField]
    GameObject ScoreEffect;

    int linetype;
    public void PressNodeCheckrt(int _Type)
    {
        linetype = _Type;
        RaycastHit2D[] hit = Physics2D.CircleCastAll(this.transform.position, 0.3f,this.transform.position);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i])
            {
                if (hit[i].transform.CompareTag("Node"))
                {
                    NodeHitByRayCast(hit[i].transform.GetComponent<NodeInfo>());
                    break;
                }
            }
        }
        //if (nodes.Count > 0)
        //{
        //    DeQueuueNode();
        //}
    }
    private void NodeHitByRayCast(NodeInfo _nodeinfo , NodeScore _Score = NodeScore.Null, float _disabletime = 0.0f)
    {
        NodeInfo clone = _nodeinfo;
        if (clone.nType != linetype) return;

        float fDistance = Vector2.Distance(this.transform.position, clone.transform.position);

        if (_Score == NodeScore.Null)
        {
            if (fDistance <= 0.1f)
            {
                _Score = NodeScore.Perfact;
            }
            else if (fDistance >= 0.2f)
            {
                _Score = NodeScore.Good;
            }
            else if (fDistance >= 0.3f)
            {
                _Score = NodeScore.Normal;
            }
            else
            {
                _Score = NodeScore.Bad;
            }
        }

        cGameManager.instance.AddScore((int)_Score);
        ScoreEffect Effectclone = Instantiate(ScoreEffect, clone.transform.position, Quaternion.identity).GetComponent<ScoreEffect>();
        int scoretype = 0;
        switch (_Score)
        {
            case NodeScore.Perfact:
                {
                    scoretype = 0;
                }
                break;
            case NodeScore.Good:
                {
                    scoretype = 1;
                }
                break;
            case NodeScore.Normal:
                {
                    scoretype = 2;
                }
                break;
            case NodeScore.Bad:
                {
                    scoretype = 3;
                }
                break;
        }
        Effectclone.Init(scoretype);
        clone.DisableObject(_disabletime);
        //Destroy(clone.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Playerinfo.bIsNodeBuilder == true) return;
        //if (collision.CompareTag("Node"))
        //{
        //    nodes.Enqueue(collision.gameObject.transform.GetComponent<NodeInfo>());
        //}
    }
    private void DeQueuueNode(NodeScore _Score = NodeScore.Null,float _disabletime = 0.0f)
    {
        if (nodes.Count <= 0) return;
       NodeInfo clone = nodes.Dequeue();
        if (_Score == NodeScore.Null)
        {
            float fDistance = Vector2.Distance(this.transform.position, clone.transform.position);
            if (fDistance <= 0.15f)
            {
                _Score = NodeScore.Perfact;
            }
            else if (fDistance >= 0.3f)
            {
                _Score = NodeScore.Good;
            }
            else if(fDistance >= 0.45f)
            {
                _Score = NodeScore.Normal;
            }
            else
            {
                _Score = NodeScore.Bad;
            }
        }
        cGameManager.instance.AddScore((int)_Score);
        ScoreEffect Effectclone = Instantiate(ScoreEffect, clone.transform.position, Quaternion.identity).GetComponent<ScoreEffect>();
        int scoretype = 0;
        switch (_Score)
        {
            case NodeScore.Perfact:
                {
                    scoretype = 0;
                }
                break;
            case NodeScore.Good:
                {
                    scoretype = 1;
                }
                break;
            case NodeScore.Normal:
                {
                    scoretype = 2;
                }
                break;
            case NodeScore.Bad:
                {
                    scoretype = 3;
                }
                break;
        }
        Effectclone.Init(scoretype);
        clone.DisableObject(_disabletime);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Playerinfo.bIsNodeBuilder == true) return;

        if (collision.gameObject.activeSelf == true)
        {
            if (collision.CompareTag("Node"))
            {
                 NodeHitByRayCast(collision.GetComponent<NodeInfo>(), NodeScore.Bad, 1.0f);
              //  collision.GetComponent<NodeInfo>().DisableObject(0.5f);
            }
        }
    }
}
