using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BestHTTP;
using BestHTTP.JSON;
using UnityEngine.Events;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using SavingData;
using HTTPRequest = BestHTTP.HTTPRequest;

public enum RequestMode
{
    SET_MAP = 1,
    GET_MAP = 2,
    SET_PEOPLE_IMAGE = 3,
    GET_PEOPLE_IMAGE = 4,
}

public class HttpUtils : MonoBehaviour
{
    public static SavingData.UnityBaseInfo tokenInfo = new SavingData.UnityBaseInfo();
    public static string RequestUrl = "";
    public static bool IsMaster = false;

    private static UnityEvent<string> onHttpRequest = new UnityEvent<string>();
    private static UnityEvent<string> onSaveFail = new UnityEvent<string>();

    private const string setMapUrl = "https://api-test.joinbudapp.com/ugcmap/set";
    private const string getMapUrl = "https://api-test.joinbudapp.com/ugcmap/info";
    private const string setPeopleImageUrl = "https://api-test.joinbudapp.com/image/setImage";
    private const string getPeopleImageUrl = "https://api-test.joinbudapp.com/image/getImage";


    public static void MakeHttpRequest(string _path, int _requestType, string _paramStr, UnityAction<string> onReceive, UnityAction<string> onFail)
    {
        SavingData.HTTPRequest requestData = new SavingData.HTTPRequest
        {
            path = _path,
            requestType = _requestType,
            paramStr = _paramStr
        };
        onSaveFail.RemoveAllListeners();
        onSaveFail.AddListener(onFail);
        onHttpRequest.RemoveAllListeners();
        onHttpRequest.AddListener(onReceive);

        string url = "";
#if !UNITY_EDITOR
        url = RequestUrl;
        if (string.IsNullOrEmpty(RequestUrl))
        {
            url = "https://api.joinbudapp.com";
        }
#else
        if (IsMaster)
        {
            url = "https://api-test.joinbudapp.com";
        }
        else
        {
            url = "https://api.joinbudapp.com";
        }
#endif


        if (!string.IsNullOrEmpty(requestData.paramStr) && (_requestType != (int)HTTP_METHOD.POST))
        {
            JObject jObject = JObject.Parse(requestData.paramStr);
            IEnumerable<string> nameValues = jObject
                .Properties()
                .Select(x => $"{x.Name}={x.Value}");

            url += requestData.path + "?" + string.Join("&", nameValues);
        }
        else
        {
            url += requestData.path;
        }


        HTTPRequest request;

        if (_requestType == (int)HTTP_METHOD.POST)
        {
             request = new HTTPRequest(new Uri(url), HTTPMethods.Post, OnInternalRequestCallback);
             request.RawData = Encoding.UTF8.GetBytes(_paramStr);
             request.Timeout = TimeSpan.FromSeconds(45);
        }
        else {
             request = new HTTPRequest(new Uri(url), HTTPMethods.Get, OnInternalRequestCallback);
             request.Timeout = TimeSpan.FromSeconds(45);
        }

#if !UNITY_EDITOR

        LoggerUtils.Log("tokenInfo = " + JsonConvert.SerializeObject(tokenInfo));
        request.AddHeader("uid", tokenInfo.uid);
        request.AddHeader("baseUrl", tokenInfo.baseUrl);
        request.AddHeader("environment", tokenInfo.environment);
        request.AddHeader("device", tokenInfo.device);
        request.AddHeader("platform", "U3D");
        request.AddHeader("generation", tokenInfo.generation);
        request.AddHeader("token", tokenInfo.token);
        request.AddHeader("version", GameManager.Inst.unityConfigInfo.appVersion);
#else
        request.AddHeader("uid", "1476091808982634496");
        request.AddHeader("baseUrl", "123");
        request.AddHeader("environment", "master");
        request.AddHeader("device", "123");
        request.AddHeader("platform", "U3D");
        request.AddHeader("generation", "123");
        request.AddHeader("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjQ3OTQzNjI2ODYsImlhdCI6MTY0MDc2MjY4NiwibmJmIjoxNjQwNzYyNjg2LCJ1aWQiOiIxNDc2MDkxODA4OTgyNjM0NDk2In0.kOFjTBMEHXSAOLHz7qLtU5scOrywy7WDd5-G3AZMqPY");
        request.AddHeader("version", "1.14.0");
#endif
        if (Application.platform == RuntimePlatform.Android)
        {
            request.AddHeader("mobile", "android");
        } else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            request.AddHeader("mobile", "ios");
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            // 编辑器状态下默认视为android
            request.AddHeader("mobile", "android");
        }
        request.Send();
    }

    private static void OnInternalRequestCallback(HTTPRequest req, HTTPResponse resp)
    {
         string reason = string.Empty;

        //LoggerUtils.LogError(string.Format("in HttpUtils OnInternalRequestCallback. ========> Status Code: {0} Message: {1} Text: {2} Reason: {3}", resp.StatusCode.ToString(), resp.Message, resp.DataAsText, reason));
        //LoggerUtils.Log("data = " + responseData.data);
        SavingData.HttpResponse responseData = new SavingData.HttpResponse
        {
            identifier = "",
            isSuccess = 0 //1 success
        };
        string resultRspFail = "";

        switch (req.State)
        {
            case HTTPRequestStates.Finished:
                HTTPManager.Logger.Information("HttpUtils", string.Format("Request finished. Status Code: {0} Message: {1}", resp.StatusCode.ToString(), resp.Message));
                if (resp.IsSuccess)
                {
                    SavingData.HttpResponseRaw responseDataRaw = JsonConvert.DeserializeObject<SavingData.HttpResponseRaw>(resp.DataAsText);
                    if (responseDataRaw.result != 0)
                    {
                        HttpRequestReceiveFail(responseDataRaw.rmsg);
                        return;
                    }
                    responseData.data = JsonConvert.SerializeObject(responseDataRaw.data);
                    responseData.isSuccess = 1;
                    // The request upgraded successfully.
                    string resultRspSuccess = JsonConvert.SerializeObject(responseData);
                    HttpRequestReceiveSuccess(resultRspSuccess);
                    return;
                }
                else
                {
                    reason = string.Format("Request Finished Successfully, but the server sent an error. Status Code: {0}-{1} Message: {2}",
                                resp.StatusCode,
                                resp.Message,
                                resp.DataAsText);
                    HttpRequestReceiveFail(reason);
                }
                break;

            // The request finished with an unexpected error. The request's Exception property may contain more info about the error.
            case HTTPRequestStates.Error:
                reason = "Request Finished with Error! " + (req.Exception != null ? ("Exception: " + req.Exception.Message + req.Exception.StackTrace) : string.Empty);
                HttpRequestReceiveFail(resultRspFail);
                break;

            // The request aborted, initiated by the user.
            case HTTPRequestStates.Aborted:
                reason = "Request Aborted!";
                HttpRequestReceiveFail(resultRspFail);
                break;

            // Connecting to the server is timed out.
            case HTTPRequestStates.ConnectionTimedOut:
                reason = "Connection Timed Out!";
                HttpRequestReceiveFail(reason);
                break;

            // The request didn't finished in the given time.
            case HTTPRequestStates.TimedOut:
                reason = "Processing the request Timed Out!";
                HttpRequestReceiveFail(reason);
                break;

            default:
                HttpRequestReceiveFail("Oops! Something Wrong: (");
                return;
        }
    }

    private static void HttpRequestReceiveSuccess(string msg)
    {
        onHttpRequest?.Invoke(msg);
    }

    private static void HttpRequestReceiveFail(string msg)
    {
        onSaveFail?.Invoke(msg);
    }

    private string GetPath(RequestMode requestMode) {
        string url = "";
        switch (requestMode)
        {
            case (RequestMode.SET_MAP):
                url = setMapUrl;
                break;

            case (RequestMode.GET_MAP):
                url = getMapUrl;
                break;

            case (RequestMode.SET_PEOPLE_IMAGE):
                url = setPeopleImageUrl;
                break;

            case (RequestMode.GET_PEOPLE_IMAGE):
                url = getPeopleImageUrl;
                break;
        }
        return url;
    }
}

