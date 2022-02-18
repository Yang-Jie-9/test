using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;
using OfflineRender;
using SavingData;
using UnityEngine;
using UnityEngine.Events;

public class TestClient : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int clientPort = 30062;
    
    [SerializeField]
    private int serverPort = 30061;

    [SerializeField] private bool isMaster = false;


    private List<string> renderIds = null;
    private string nowRenderId = null;
    
    private static Server server;
    
    

    public static TestClient Instance;
    
    public const int RenderSingle = 0;
    public const int RenderAll = 1;

    private void Awake()
    {
        Instance = this;
        HttpUtils.IsMaster = isMaster;
    }


    class ServerImpl : RenderService.RenderServiceBase
    {
        // Server side handler of the FinishRender RPC
        public override Task<FinishRenderRsp> FinishRender(FinishRenderReq request, ServerCallContext context)
        {
 
            Debug.Log("ResultCode: " + request.ResultCode + "," + request.PathAndroid);
            Instance.nowRenderId = null;
            if (request.ResultCode != 0)
            {
                Instance.renderIds.Add(request.MapId);
            }
            Instance.AutoRender();

            return Task.FromResult(new FinishRenderRsp { ResultCode = 0 });
        }
    } 
    
    private void Start()
    {
        var testJson = Resources.Load<TextAsset>("test");

        renderIds = JsonConvert.DeserializeObject<List<string>>(testJson.text);

        server = new Server
        {
            Services = { RenderService.BindService(new ServerImpl()) },
            Ports = { new ServerPort("localhost", clientPort, ServerCredentials.Insecure) }
        };
        server.Start();

        AutoRender();
    }

    private void OnApplicationQuit()
    {
        if (nowRenderId != null)
        {
            renderIds.Add(nowRenderId);
        }

        var idDatas = JsonConvert.SerializeObject(renderIds);
        File.WriteAllText(Application.dataPath + "/Resources/test.json", idDatas);
    }

    private void AutoRender()
    {
        if (renderIds == null || renderIds.Count <= 0) return;
        var renderId = renderIds[0];
        renderIds.RemoveAt(0);
        GetRenderReq(renderId, StartRender, arg0 =>
        {
            renderIds.Add(renderId);
            AutoRender();
        });
    }

    private void GetMapInfo(string info, UnityAction<string> onSuccess, UnityAction<string> onFail)
    {
        HttpUtils.MakeHttpRequest("/ugcmap/info", (int)HTTP_METHOD.GET, info, onSuccess, onFail);
    }

    private void GetRenderReq(string id, UnityAction<StartRenderReq> onSuccess,  UnityAction<string> onFail)
    {
        var mapInfo = new UgcUntiyMapDataInfo()
        {
            mapId = id,
            mapName = id
        };
        Debug.Log("GetMapInfo  Thread:" + Thread.CurrentThread.ManagedThreadId.ToString());
        GetMapInfo(JsonConvert.SerializeObject(mapInfo), 
            content =>
            {
            
                var response = JsonConvert.DeserializeObject<HttpResponse>(content);
                Debug.Log("response:" + response.data);
                var tmpPropInfo = JsonConvert.DeserializeObject<GetMapInfo>(response.data).mapInfo;
                if (tmpPropInfo != null)
                {
                    if (tmpPropInfo.dataType == 1)
                    {
                        Debug.Log("propsJson:" + tmpPropInfo.propsJson);
                        if (string.IsNullOrEmpty(tmpPropInfo.propsJson))
                        {
                            tmpPropInfo.propsJson = "https://cdn.joinbudapp.com/PropsZipFile/1463463891752488960/1463463891752488960_1644545563m.zip";
                        }
                        onSuccess?.Invoke(new StartRenderReq()
                        {
                            MapId = id,
                            JsonUrl = tmpPropInfo.propsJson,
                            CmdType = RenderSingle,
                        });
                    }
                    else
                    {
                        Debug.Log("mapJson:" + tmpPropInfo.mapJson);
                        if (string.IsNullOrEmpty(tmpPropInfo.mapJson))
                        {
                            tmpPropInfo.mapJson = "https://cdn.joinbudapp.com/UgcJson/1470252278983499776/1470252278983499776_1640374798.json";
                        }
                        onSuccess?.Invoke(new StartRenderReq()
                        {
                            MapId = id,
                            JsonUrl = tmpPropInfo.mapJson,
                            CmdType = RenderAll
                        });
                    }
           
                }
                else
                {
                    onFail?.Invoke("No Prop Data:" + id);
                }
    
            }, err =>
            {
                onFail?.Invoke(err);
            });
    }

    private void StartRender(StartRenderReq req)
    {
        Channel channel = new Channel("127.0.0.1"+":"+ serverPort, ChannelCredentials.Insecure);

        var client = new RenderService.RenderServiceClient(channel);
        
        var response = client.StartRender(req);
        nowRenderId = req.MapId;
        
        // var response = client.StartRender(new StartRenderReq()
        // {
        //     MapId = "1469198713455931392_1640072957_3",
        //     JsonUrl = "https://cdn.joinbudapp.com/PropsJson/1469198713455931392/1469198713455931392_1640101716m.json",
        // });
        //
        // var response = client.StartRender(new StartRenderReq()
        // {
        //     MapId = "1450306028838199296_1640322356_3",
        //     JsonUrl = "https://buddy-app-bucket.s3.us-west-1.amazonaws.com/PropsJson/1450306028838199296/1450306028838199296_1640304317m.json",
        // });
        Console.WriteLine("ResultCode: " + response.ResultCode);

        channel.ShutdownAsync().Wait();
    }

}
