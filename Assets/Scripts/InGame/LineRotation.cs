using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRotation : MonoBehaviour
{
    [SerializeField]
    [Header("�������� 1���� ���µ� �ɸ��� �ð�")]
    float fSpeed = 1.0f;
    [SerializeField]
    [Header("�������� 1���� ���µ� �ɸ��� �ð��� ���ǵ�")]
    float fSpeedbytick = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        float originrotationz = 0;
            originrotationz = ((360.0f / fSpeed) * cGameManager.instance.fDelayTimeBeforeStart);
        transform.Rotate(new Vector3(0, 0, -originrotationz));
    }
    private void Rotation()
    {
          if (cGameManager.instance.bIsMoveLine == false) return;

        this.transform.Rotate(new Vector3(0, 0, 360.0f/fSpeed) * Time.deltaTime);
        fSpeedbytick = 360.0f / fSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }
}
