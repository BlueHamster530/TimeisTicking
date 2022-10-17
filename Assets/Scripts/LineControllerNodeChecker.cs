using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllerNodeChecker : MonoBehaviour
{
    [SerializeField]
    LineController line;


    SelectNode nodeinfo;
    public void NodePressButton()
    {
        if (nodeinfo == null) return;

        if (line.bIsNodeSelect == true)
        {
            nodeinfo.SelectEvent();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SelectNode"))
        {
            nodeinfo = collision.gameObject.GetComponent<SelectNode>();
        }
    }

}
