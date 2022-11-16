using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inMainScripts : MonoBehaviour
{
    [SerializeField]
    GameObject MainObjects;
    [SerializeField]
    GameObject CreditObject;

    public void showCreadit()
    {
        MainObjects.SetActive(false);
        CreditObject.SetActive(true);
    }
    public void ShowMain()
    {
        MainObjects.SetActive(true);
        CreditObject.SetActive(false);
    }

}
