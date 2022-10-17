using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]
    [Header("판정선이 1바퀴 도는데 걸리는 시간")]
    float fSpeed = 1.0f;
    [SerializeField]
    [Header("판정선이 1바퀴 도는데 걸리는 시간의 스피드")]
    float fSpeedbytick = 1.0f;

    [SerializeField]
    LineControllerNodeChecker OutSide;
    [SerializeField]
    LineControllerNodeChecker InSide;
    // Start is called before the first frame update

   public bool bIsNodeSelect;
    void Start()
    {
        float originrotationz = 0;
        originrotationz = ((360.0f / fSpeed));
    }
    private void Rotation()
    {
        this.transform.Rotate(new Vector3(0, 0, 360.0f / fSpeed) * Time.deltaTime);
        fSpeedbytick = 360.0f / fSpeed;
    }
    private void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            InSide.NodePressButton();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            OutSide.NodePressButton();
        }
    }
    private void Update()
    {
        KeyInput();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }

}
