using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    [SerializeField]
    GameObject[] scoreimage;

    public void Init(int _ScoreType)
    {
        Instantiate(scoreimage[_ScoreType], transform.position, Quaternion.identity);
        EndEvent();
    }
    // Update is called once per frame

    public void EndEvent()
    {
        Destroy(gameObject);
    }
}
