using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField]
    Transform target;

    // Update is called once per frame
    public void SetupAngle()
    {
        Vector2 direction = new Vector2(transform.position.x - target.position.x, transform.position.y - target.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        this.transform.rotation = angleAxis;
    }
}
