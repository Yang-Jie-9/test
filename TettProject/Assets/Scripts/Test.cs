using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private AudioSource source;

    [SerializeField] private AudioClip clip;
    private int position = 0;
    private int samplerate = 132272;
    private float frequency = 124;

    
    private IEnumerator LoadAudio()
    {
        //https://s27.aconvert.com/convert/p3r68-cdx67/xa4qh-41r58.mp3
        //https://drive.google.com/file/d/1O8UnHAUSje2yOF0nbeGpzrMnKbmyXzNK/view?usp=sharing
        

        yield return null;
        
        
        // yield return new WaitForSeconds(3.0f);
        Stopwatch sw = new Stopwatch();
        
        // 开始测量代码运行时间
        sw.Start();
        string url = "https://drive.google.com/file/d/1O8UnHAUSje2yOF0nbeGpzrMnKbmyXzNK/view?usp=sharing";
        var request = new UnityWebRequest(url);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SendWebRequest();
        PcmHeader pcmHeader = default;
        MemoryStream memoryStream = new MemoryStream();
        while (!request.isDone)
        {
            Debug.Log("data:" + request.downloadHandler.data.Length );
            // request.downloadHandler.data
        
            // if (!pcmHeader.Ready)
            // {
            //     try
            //     {
            //         pcmHeader = PcmHeader.FromBytes(request.downloadHandler.data);
            //         Debug.Log("pcmData:" + pcmHeader.Channels + "," + pcmHeader.AudioSampleSize + "," + pcmHeader.AudioSampleCount);
            //     }
            //     catch (Exception e)
            //     {
            //         Debug.Log("pcmHeader:" + e.Message + e.StackTrace);
            //     }
            // }
        
            
            // var pcmData   = PcmData.FromBytes(request.downloadHandler.data);
            // Debug.Log("pcmData:" + pcmData);
            yield return null;
        }
        sw.Stop();
        var data = request.downloadHandler.data;
        Debug.Log("all data:" + data.Length);
        Debug.Log("测量实例得出的总运行时间（毫秒为单位）：" + sw.ElapsedMilliseconds);
        
        
        
        
        while (!request.isDone)
        {
               Debug.Log("download");
               yield return null;
        }     
        

        yield return null;
    }


    private void Start()
    {
        StartCoroutine(LoadAudio());
        
        Debug.Log("clip:" + clip + "," + clip.channels + "," + clip.samples);
        Debug.Log("test:" + clip.samples + "," + clip.channels + "," + clip.frequency);
        // clip.GetData();
        AudioClip.Create("test", clip.samples, clip.channels, clip.frequency, true, OnAudioRead);

    }
    
    void OnAudioRead(float[] data)
    {
        Debug.Log("data:" + data.Length);
        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sign(Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate));
            position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        Debug.Log("OnAudioSetPosition:" + newPosition);
        position = newPosition;
    }
}
