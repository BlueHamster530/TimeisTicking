using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwa : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float distance;

    private void Update()
    {
        distance = Vector2.Distance(this.transform.position, target.transform.position);
    }
}
