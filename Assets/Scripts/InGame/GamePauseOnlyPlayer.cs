using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseOnlyPlayer : MonoBehaviour
{
    [SerializeField]
    [Header("판정선이 1바퀴 도는데 걸리는 시간")]
    float fSpeed = 1.0f;
    [SerializeField]
    [Header("판정선이 1바퀴 도는데 걸리는 시간의 스피드")]
    float fSpeedbytick = 1.0f;

    AudioSource audioSource;

    SelectNode pauseobjectinfo;

    [SerializeField]
    bool IsGameEndingScene;

    float CurrntTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (IsGameEndingScene == false)
        {
            float originrotationz = 0;
            originrotationz = ((360.0f / fSpeed) * cGameManager.instance.fDelayTimeBeforeStart);
            transform.Rotate(new Vector3(0, 0, -originrotationz));
        }
        else
        {
            transform.eulerAngles = Vector3.Lerp(new Vector3(0, 180, 104), new Vector3(0, 180, 255), 0);
        }
    }
    private void PlayTilePressSound()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    private void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.K)|| Input.GetKeyDown(KeyCode.S))
        {
            pauseobjectinfo.SelectEvent();
            PlayTilePressSound();
        }
    }
    private void Update()
    {
        KeyInput();
    }
    private void Rotation()
    {
        this.transform.Rotate(new Vector3(0, 0, 360.0f / fSpeed) * Time.deltaTime);
        fSpeedbytick = 360.0f / fSpeed;
    }
    private void EndingSceneRotation()
    {
        CurrntTime += Time.deltaTime / fSpeed;
        if (CurrntTime >= 2.0f)
            CurrntTime = 0.0f;

        float nowAnglez = CurrntTime;
        if (nowAnglez >= 1.0f)
            nowAnglez = 2.0f - CurrntTime;
        transform.eulerAngles = Vector3.Lerp(new Vector3(0, 180, 104), new Vector3(0, 180, 255), nowAnglez);
        fSpeedbytick = 360.0f / fSpeed;


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGameEndingScene == false)
        {
            Rotation();
        }
        else
        {
            EndingSceneRotation();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SelectNode"))
        {
            pauseobjectinfo = collision.gameObject.GetComponent<SelectNode>();
           // print(pauseobjectinfo.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SelectNode"))
        {
            if (pauseobjectinfo != null)
            {
                if (collision.name == pauseobjectinfo.name)
                {
                    pauseobjectinfo = null;
                }
            }
        }
    }
}
