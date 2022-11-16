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


    AudioSource audioSource;

    [SerializeField]
    SpriteRenderer rayderImage;

    float RadyerAlpha;
    void Start()
    {
        float originrotationz = 0;
        originrotationz = ((360.0f / fSpeed));
        bIsNodeSelect = true;
        audioSource = GetComponent<AudioSource>();
        RadyerAlpha = 0.5f;
        rayderImage.color = new Color(1.0f, 1.0f, 1.0f, RadyerAlpha);
    }
    private void Rotation()
    {
        this.transform.Rotate(new Vector3(0, 0, 360.0f / fSpeed) * Time.deltaTime);
        fSpeedbytick = 360.0f / fSpeed;
    }
    private void PlayTilePressSound()
    {
        RadyerAlpha = 1.0f;
        audioSource.Stop();
        audioSource.Play();
    }
    private void KeyInput()
    {
        if (bIsNodeSelect == true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                InSide.NodePressButton();
                PlayTilePressSound();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                OutSide.NodePressButton();
                PlayTilePressSound();
            }
        }
    }
    private void Update()
    {
        KeyInput();
        if (RadyerAlpha > 0.5f)
        {
            RadyerAlpha -= Time.deltaTime*2.0f;
        }
        else
        {
            RadyerAlpha = 0.5f;
        }
        rayderImage.color = new Color(1.0f, 1.0f, 1.0f, RadyerAlpha);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }

}
