using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPauseObject : MonoBehaviour
{
    public void GameExit()
    {
        cGameManager.instance.ChangeScene("MusicSelect");
    }
    public void MusicRestart()
    {
        cGameManager.instance.ChangeScene("InGame");
    }
    public void GameContinue()
    {
        cGameManager.instance.GameContinue();
    }
}
