using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json;
using SavingData;
using UnityEngine;
using UnityEngine.Networking;

public class TestWait : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private AudioSource _audioSource;
    
    private int count = 0;

    private Coroutine test;
    
    [Serializable]
    public class OfflineResInfo
    {
        public string name;
        public uint size;
        public uint useCount;
    }
    
    void Start()
    {
        Dictionary<string, OfflineResInfo> offlineResInfos = new Dictionary<string, OfflineResInfo>()
        {
            {"aa", new OfflineResInfo(){}}
        };
        offlineResInfos.Remove("aa");
        offlineResInfos.Remove("aa");
        offlineResInfos.Remove("aa");
        Debug.Log("remove:" + offlineResInfos.Count);
        // var data = JsonConvert.SerializeObject(offlineResInfos);
        // Debug.Log("offlineResInfos:" + data);
        // var serData = JsonConvert.DeserializeObject<Dictionary<string, OfflineResInfo>>(data);
        // Debug.Log("offlineResInfos:" + serData["aa"]);


        return;
        string url =
            "file://C:/Users/yj517/AppData/LocalLow/DefaultCompany/budGame3D_Global/U3D/1483331466082783232-1643011473-Audio-2022-01-24-7.mp3";

        // var audioClip = Resources.Load<AudioClip>("1642454211_Audio-2022-01-17-6");
        // Debug.Log("audioClip:" + audioClip.length);
        // _audioSource.clip = audioClip;
        // _audioSource.Play();
        
        StartCoroutine(LoadURL(url, clip =>
        {
        
            _audioSource.clip = clip;
            _audioSource.Play();
        }, () => { }));
        // test = StartCoroutine(TestCoroutine1());
        // var tmp = JsonConvert.DeserializeObject<MapInfo>("http error request.State:");
        // Debug.Log("tmp:" + tmp);
    }

    private void Update()
    {
        if (_audioSource.clip != null && _audioSource.isPlaying)
        {
            Debug.Log("_audioSource:" + _audioSource.time);
        }
    }


    IEnumerator LoadURL(string url, Action<AudioClip> suc, Action fail)
    {
        
        // var uwr = new UnityWebRequest(url);
        // uwr.downloadHandler = new DownloadHandlerAudioClip();
        
        using var request = UnityWebRequest.Get(url);
        var downloadHandler = new DownloadHandlerAudioClip(url, AudioType.MPEG);
        downloadHandler.streamAudio = false;
        downloadHandler.compressed = false;
        
        
        request.downloadHandler = downloadHandler;
        
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            fail?.Invoke();
        }
        else
        {
            var audioClip = ((DownloadHandlerAudioClip) request.downloadHandler).audioClip;
            Debug.Log("length:" + audioClip.length);
            
            // audioClip.GetData()
            suc?.Invoke(audioClip);
        }
        //
        //
        //
        // using (var uwr = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        // {
        //     
        //     yield return uwr.SendWebRequest();
        //     if (uwr.result != UnityWebRequest.Result.Success)
        //     {
        //         fail?.Invoke();
        //     }
        //     else
        //     { 
        //         var clip = DownloadHandlerAudioClip.GetContent(uwr);
        //         suc?.Invoke(clip);
        //     }
        // }
        
    }

    IEnumerator TestCoroutine1()
    {

        int i = 500000;
        while (i >= 0)
        {
            i--;
            Debug.Log("TestCoroutine1");
            yield return TestCoroutine2();
            yield return null;
        }
        
        test = null;
    }

    IEnumerator TestCoroutine2()
    {

        int j = 10;
        while (j >= 0)
        {
            j--;
            Debug.Log("TestCoroutine2");
            yield return null;
        }
    }

    public void TestStop()
    {
        if (test != null)
        {
            Debug.Log("TestStop Start");
            StopCoroutine(test);
            test = null;
        }

        Debug.Log("TestStop");
    }


    // private void Update()
    // {
    //     Debug.Log("Update");
    // }


    // void Update()
    // {
    //     count++;
    //     if (count%5 == 0)
    //     {
    //         Debug.Log("Update:" + count);
    //     }
    //
    // }

    // public IEnumerator LoadAudio()
    // {
    //
    //     while (true)
    //     {
    //         Debug.Log("downloadedBytes time:" + Time.realtimeSinceStartup);
    //         yield return null;
    //     }
    //     
    // }


}
