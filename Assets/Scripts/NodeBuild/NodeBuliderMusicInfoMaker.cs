using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct MusicNodeInfo
{
    public MusicNodeInfo(float _time, int _type, float _xpos, float _ypos,float _zRotate)
    {
        fSpawnTime = _time;
        nType = _type;
        xPos = _xpos;
        yPos = _ypos;
        zRotate = _zRotate;
    }
    public float fSpawnTime;
    public int nType;
    public float xPos;
    public float yPos;
    public float zRotate;
}
[System.Serializable]
public class MusicNodeInfoList
{
   public List<MusicNodeInfo> nodeList = new List<MusicNodeInfo>();
}
public class NodeBuliderMusicInfoMaker : MonoBehaviour
{
    public static NodeBuliderMusicInfoMaker instance;
    public MusicNodeInfoList NodeList;
    string path;
    private void Awake()
    {
        instance = this;
        if (GameObject.Find("Player").GetComponent<PlayerInfomation>().bIsNodeBuilder == true)
        {
            path = Path.Combine(Application.streamingAssetsPath, "MusicNodeList.Json");
            LoadNodeList();
        }
        else
        {
        }
    }
    public void SetUpMusic(string jsonName)
    {
        path = Path.Combine(Application.streamingAssetsPath, jsonName+".Json");
        LoadNodeList();
    }
    public void LoadNodeList()
    {
        if (File.Exists(path))
        {
            print("MusicNodeList LoadDone");
            string jsonData = File.ReadAllText(path);
            NodeList = JsonUtility.FromJson<MusicNodeInfoList>(jsonData);
        }
        else
        {
            print("Create New MusicNodeList");
            NodeList = new MusicNodeInfoList();
            SaveNodeList();
        }
    }
    public void SaveNodeList()
    {
        print("SaveNodeList");
        string ToJsonData = JsonUtility.ToJson(NodeList);
        print(ToJsonData);
        File.WriteAllText(path, ToJsonData);
    }

}