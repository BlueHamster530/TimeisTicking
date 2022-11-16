using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour
{
    [SerializeField]
    float speed;


    private void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}
