using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using SavingData;
using UnityEngine;
using UnityEngine.Networking;

public class TestLoad : MonoBehaviour
{
    private void Start()
    {
        var getMapInfo = Resources.Load<TextAsset>("_1643394095");
        var renderList = JsonConvert.DeserializeObject<GetMapInfo>(getMapInfo.text).mapInfo;
        Debug.Log("renderList:" + renderList.renderList[0].abList.Length);
        Debug.Log("getMapInfo:" + getMapInfo);
        Debug.Log("DownLoadUtil.Download Start:" +Time.realtimeSinceStartup);
        float startTime = Time.realtimeSinceStartup;
        int count = renderList.renderList[0].abList.Length;
        foreach (var renderData in renderList.renderList[0].abList)
        {
            DownLoadUtil.Download(renderData.renderUrl, cache =>
            {
      
                count--;
                Debug.Log("DownLoadUtil:" + count);
                if (count == 0)
                {
                    Debug.Log("DownLoadUtil.Download Over:" +Time.realtimeSinceStartup);
                    Debug.Log("DownLoadUtil.Download Over:" +(Time.realtimeSinceStartup - startTime));
                }
            }, new DownloadHandlerBuffer());
        }
    }
}
