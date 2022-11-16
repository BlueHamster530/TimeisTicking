using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetSpectrumDataExample : MonoBehaviour
{
    AudioSource audio;
    float[] spectrum = new float[64];
    [SerializeField]
    float test = 0;

    [SerializeField]
    ParticleSystem Particle;


    ParticleSystem.MainModule psMain;

    [SerializeField]
    float VolumSize = 1.0f;
    [SerializeField]
    float asdaw = 1.0f;
    [SerializeField]
    CameraController CameraController;
    float [] CheckingSoundVolume = new float[2];
    void Start()
    {
        audio = GetComponent<AudioSource>();
        psMain = Particle.main;
        Particle.time = 150.0f;
        CheckingSoundVolume[0] = -1.0f;
        CheckingSoundVolume[1] = 0.0f;
    }

    void Update()
    {
        audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        //int i = 1;
        //while (i < spectrum.Length - 1)
        //{
        //    Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
        //    i++;
        //}
        test = spectrum[0];
        psMain.simulationSpeed = 3.0f + (test * 15.0f);
        //if (CheckingSoundVolume[0] <= -1.0f)
        //{
        //    CheckingSoundVolume[0] = test;
        //}
        //else
        //{
        //    CheckingSoundVolume[1] = test;
        //    float _distance = CheckingSoundVolume[1] - CheckingSoundVolume[0];
        //    if (_distance >= VolumSize)
        //    {
        //
        //        CameraController.CloseUpForTime(5.0f, 5.3f, 0.1f, 1.0f);
        //    }
        //
        //    CheckingSoundVolume[0] = CheckingSoundVolume[1];
        //}
        asdaw = psMain.simulationSpeed;
    }
}
