using System;

namespace SavingData
{
    [Serializable]
    public struct HTTPRequest
    {
        public string path;
        public int requestType;
        public string paramStr;
        public string identifier;
        public string headerStr;
    }

    [Serializable]
    public struct HttpResponse
    {
        public string identifier;
        public int isSuccess; //1 success
        public string data;
    }
    
    [Serializable]
    public class UnityBaseInfo
    {
        public string uid = "";
        public string baseUrl = "";
        public string environment = "";
        public string device = "";
        public string platform = "";
        public string generation = "";
        public string token = "";
    }
    
    [Serializable]
    public struct HttpResponseRaw
    {
        public int result;
        public string rmsg;
        public object data;
    }
    enum HTTP_METHOD
    {
        GET = 0,
        POST = 1
    }
    
    [Serializable]
    public class UgcUntiyMapDataInfo
    {
        public string mapId = "";
        public string mapName = "";
    }
    
    [Serializable]
    public struct GetMapInfo
    {
        public MapInfo mapInfo;
    }
    
    [Serializable]
    public class MapInfo
    {
        public string mapId = "";
        public int dataType = 0;//0:map 1:prop
        public string mapCover = "";
        public string mapName = "";
        public string mapJson = "";
        public string propsJson = "";
        public string mapDesc = "";
        public string[] propList;
        public OfflineRenderListObj[] renderList;

    }
    
    public class OfflineRenderData
    {
        public string resId;
        public string renderUrl;
    }

    [Serializable]
    public class OfflineRenderListObj
    {
        [Obsolete("该字段属于老版本兼容字段, 已移动到abList中")]
        public string mapId;
        
        [Obsolete("该字段属于老版本兼容字段, 已移动到abList中")]
        public string renderUrl;

        public string version;

        public OfflineRenderData[] abList;

    }

}
