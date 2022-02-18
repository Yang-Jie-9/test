using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SavingData;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class TestMapLight : MonoBehaviour
{

    public class UGCInfo
    {
        public string resId;
        public int childCount;
    }
    
    public class LightMapInfo
    {
        public string mapId;
        public int point;
        public int spot;
        public Dictionary<string, int> ugcDic;
    }

    public List<LightMapInfo> oriLightMapInfos = new List<LightMapInfo>();
    public List<LightMapInfo> dealLightMapInfos = new List<LightMapInfo>();
    public List<LightMapInfo> errLightMapInfos = new List<LightMapInfo>();
    public List<UGCInfo> ugcInfos = new List<UGCInfo>();


    private LightMapInfo dealingMapInfo;
    private string baseFile = "results-20220217-113144";
    private void Start()
    {
        var oriTextAsset = Resources.Load<TextAsset>(baseFile);
        oriLightMapInfos = JsonConvert.DeserializeObject<List<LightMapInfo>>(oriTextAsset.text);
        var dealTextAsset = Resources.Load<TextAsset>( $"{baseFile}_deal");
        if (dealTextAsset != null)
        {
            dealLightMapInfos = JsonConvert.DeserializeObject<List<LightMapInfo>>(dealTextAsset.text); 
        }

        var errTextAsset = Resources.Load<TextAsset>($"{baseFile}_err");
        if (errTextAsset != null)
        {
            errLightMapInfos = JsonConvert.DeserializeObject<List<LightMapInfo>>(errTextAsset.text);
        }

        var ugcTextAsset = Resources.Load<TextAsset>("UGCInfo");
        if (ugcTextAsset != null)
        {
            ugcInfos = JsonConvert.DeserializeObject<List<UGCInfo>>(ugcTextAsset.text);
        }

        
        if (oriLightMapInfos == null || oriLightMapInfos.Count == 0)
        {
            Debug.Log("Deal All LightMap");
            Application.Quit();
        }
        else
        {
            AutoRender();
            Debug.Log("oriLightMapInfos:" + oriLightMapInfos.Count);
        }
    }

    private int dealCount = 10;
    private void AutoRender()
    {
        if (oriLightMapInfos.Count <= 0)
        {
            Debug.Log("Quit:");
            Application.Quit();
            return;
        }

        
        dealingMapInfo = oriLightMapInfos[0];
        oriLightMapInfos.RemoveAt(0);

        if (dealCount >= 10)
        {
   
            Debug.Log("wait deal map:" + oriLightMapInfos.Count);
            Debug.Log("deal map:" + dealLightMapInfos.Count);
            Debug.Log("err map:" + errLightMapInfos.Count);
            Debug.Log("---------");
            dealCount = 0;
        }

        dealCount++;
        if (dealLightMapInfos.FindIndex(tmp => tmp.mapId == dealingMapInfo.mapId) != -1)
        {
            dealingMapInfo = null;
            AutoRender();
            return;
        }
        var mapInfo = new UgcUntiyMapDataInfo()
        {
            mapId = dealingMapInfo.mapId
        };
        GetMapInfo(JsonConvert.SerializeObject(mapInfo), content =>
        {
            var response = JsonConvert.DeserializeObject<HttpResponse>(content);
            if (!string.IsNullOrEmpty(response.data))
            {
                var tmpMapInfo = JsonConvert.DeserializeObject<GetMapInfo>(response.data).mapInfo;
                if (tmpMapInfo != null && !string.IsNullOrEmpty(tmpMapInfo.mapJson))
                {
                    DealMapJson(tmpMapInfo.mapJson);
                    return;
                }
                Debug.Log("mapJson == null:" + response.data + "," + mapInfo.mapId);
            }
            Debug.Log("response.data == null" );
            errLightMapInfos.Add(dealingMapInfo);
            dealingMapInfo = null;
            AutoRender(); 
        }, err =>
        {
            Debug.Log("GetMapInfo Fail:" + err);
            errLightMapInfos.Add(dealingMapInfo);
            dealingMapInfo = null;
            AutoRender();
        });
    }


    private IEnumerator DownJson(string url, Action<DownLoadUtil.DownCache> callBack)
    {
        var uwq = UnityWebRequest.Get(url);
        yield return uwq.SendWebRequest();
        if (uwq.isDone)
        {
            var cache = new DownLoadUtil.DownCache()
            {
                text = uwq.downloadHandler.text,
                data = uwq.downloadHandler.data,
            };
            callBack?.Invoke(cache);
        }
        else
        {
            callBack?.Invoke(null);
        }

    }

    private void DealMapJson(string mapJson)
    {
        StartCoroutine(DownJson(mapJson, cache =>
        {
            if (cache != null)
            {
                var content = cache.text;
                if (mapJson.EndsWith(".zip"))
                {
                    content = ZipUtils.SaveZipFromByte(cache.data);
                }

                if (!string.IsNullOrEmpty(content))
                {
                    MapData mData = null;
                    try
                    {
                        mData = JsonConvert.DeserializeObject<MapData>(content);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("DeserializeObject:" + e.Message + "," + content + "," + mapJson);
                    }
                    if (mData != null)
                    {
                        var tup = GetLight(mData.pref);
                        dealingMapInfo.point = tup.Item1;
                        dealingMapInfo.spot = tup.Item2;
                        var ugcDic = new Dictionary<string, int>();
                        GetUGCInfo(mData.pref, ref ugcDic);
                        dealingMapInfo.ugcDic = ugcDic;
                        dealLightMapInfos.Add(dealingMapInfo);
                        dealingMapInfo = null;
                        AutoRender();
                        return;
                    }
                }
            }
            Debug.Log("cache == null");
            errLightMapInfos.Add(dealingMapInfo);
            dealingMapInfo = null;
            AutoRender();

            
        }));
   
    }

    private void GetMapInfo(string info, UnityAction<string> onSuccess, UnityAction<string> onFail)
    {
        HttpUtils.MakeHttpRequest("/ugcmap/info", (int)HTTP_METHOD.GET, info, onSuccess, onFail);
    }

    private void OnDestroy()
    {
        if (dealingMapInfo != null)
        {
            Debug.Log("dealingMapInfo != null");
            oriLightMapInfos.Add(dealingMapInfo);
        }
        Debug.Log("OnDestroy:" + oriLightMapInfos.Count);
        var oriLightMapData = JsonConvert.SerializeObject(oriLightMapInfos);
        File.WriteAllText(Application.dataPath + $"/Resources/{baseFile}.json", oriLightMapData);
        
        var dealLightMapData = JsonConvert.SerializeObject(dealLightMapInfos);
        File.WriteAllText(Application.dataPath + $"/Resources/{baseFile}_deal.json", dealLightMapData);

        var errLightMapData = JsonConvert.SerializeObject(errLightMapInfos);
        File.WriteAllText(Application.dataPath + $"/Resources/{baseFile}_err.json", errLightMapData);
        
        var ugcData = JsonConvert.SerializeObject(ugcInfos);
        File.WriteAllText(Application.dataPath + $"/Resources/UGCInfo.json", ugcData);
    }


    private void GetUGCInfo(List<NodeData> pref, ref Dictionary<string, int> ugcDic)
    {
        if (pref == null || pref.Count == 0)
        {
            return;
        }
        foreach (var tmpNodeData in pref)
        {
            if (tmpNodeData.type == 1 && !string.IsNullOrEmpty(tmpNodeData.rid))
            {
                if (ugcDic.ContainsKey(tmpNodeData.rid))
                {
                    ugcDic[tmpNodeData.rid]++;
                }
                else
                {
                    ugcDic[tmpNodeData.rid] = 1;
                }

                if (ugcInfos.FindIndex(tmp => tmp.resId == tmpNodeData.rid) == -1)
                {
                    ugcInfos.Add(new UGCInfo()
                    {
                        resId = tmpNodeData.rid,
                        childCount = tmpNodeData.prims.Count
                    });
                    
                }
            }
            GetUGCInfo(tmpNodeData.prims, ref ugcDic);
        }
    }

    private Tuple<int, int> GetLight(List<NodeData> pref)
    {
        var point = 0;
        var spot = 0;
        if (pref != null)
        {
            foreach (var nodeData in pref)
            {
                if (nodeData.prims != null && nodeData.prims.Count > 0)
                {
                    var tup = GetLight(nodeData.prims);
                    point += tup.Item1;
                    spot += tup.Item2;
                }
                if (nodeData.type == -1 && (nodeData.id == 1005 || nodeData.id == 1006))
                {
                    if (nodeData.id == 1005)
                    {
                        point++;
                    }
                    else
                    {
                        spot++;
                    }
                } 
            }
        }
 
        return new Tuple<int, int>(point, spot);
    }
}
