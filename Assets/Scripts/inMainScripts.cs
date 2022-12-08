using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inMainScripts : MonoBehaviour
{
    [SerializeField]
    GameObject MainObjects;
    [SerializeField]
    GameObject CreditObject;
    [SerializeField]
    GameObject SoundSettingObject;

    public void showCreadit()
    {
        MainObjects.SetActive(false);
        CreditObject.SetActive(true);
        SoundSettingObject.SetActive(false);
    }
    public void ShowMain()
    {
        MainObjects.SetActive(true);
        CreditObject.SetActive(false);
        SoundSettingObject.SetActive(false);
    }
    public void ShowSoundSetting()
    {
        MainObjects.SetActive(false);
        CreditObject.SetActive(false);
        SoundSettingObject.SetActive(true);
    }

}
