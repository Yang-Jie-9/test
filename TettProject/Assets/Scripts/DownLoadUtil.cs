using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// UnityWebRequest下载接口封装
/// 避免网络卡顿时重复下载，导致协成数量太多
/// </summary>
public class DownLoadUtil 
{
    private static Dictionary<string, DownCache> m_cacheDownload = new Dictionary<string, DownCache>();//下载缓存
    private static Dictionary<string, TaskInfo> m_taskCallBack = new Dictionary<string, TaskInfo>();//下载回调缓存
    
    private static List<string> m_waitDownloadTask = new List<string>();//等待下载的列表
    private static List<string> m_curDownloadTask = new List<string>();//当前正在下载的列表

    private static int m_maxDownloadNum = 1;//最大可同时下载数量
    private static int m_DownloadTimeOut = 5;//下载超时
    
    /// <summary>
    /// 一个url对应一个TaskInfo，里面保存了该url的下载类型DownloadHandler，所有监听该url下载的回调
    /// </summary>
    private class TaskInfo 
    {
        private List<Action<DownCache>> m_callBacks = new  List<Action<DownCache>>();
        
        public string Url;
        public DownloadHandler Handle;

        public TaskInfo(string url, DownloadHandler handle) 
        {
            Url = url;
            Handle = handle;
        }

        public void AddCallBack(Action<DownCache> callBack) 
        {
            if (!m_callBacks.Contains(callBack)) {
                m_callBacks.Add(callBack);
            }
        }
        
        public void RemoveCallBack(Action<DownCache> callBack) {
            if (m_callBacks.Contains(callBack)) {
                m_callBacks.Remove(callBack);
            }
        }

        public void ClearCallBack() {
            m_callBacks.Clear();
        }

        public int Count() {
            return m_callBacks.Count;
        }

        public void DownloadEnd(DownCache cache) {
            for (int i = 0; i < m_callBacks.Count; i++) {
                if (m_callBacks[i] != null) {
                    m_callBacks[i](cache);
                }
            }

            ClearCallBack();
        }
    }
    
    public class DownCache {
        public byte[] data;
        public string text;
        public Texture tex;
        public string url;
    }

    //下载
    public static void Download(string url, Action<DownCache> callBack, DownloadHandler handle = null) {
        if (callBack == null) return;
        
        DownCache cache;
        if (m_cacheDownload.TryGetValue(url, out cache)) 
        {
            callBack(cache);
            return;
        }

        TaskInfo taskInfo = null;
        if (!m_taskCallBack.TryGetValue(url, out taskInfo)) 
        {
            taskInfo = new TaskInfo(url, handle);
            m_taskCallBack.Add(url, taskInfo);
        }
        
        taskInfo.AddCallBack(callBack);

        //不在当前的下载、等待列表，加入执行队列
        if (!m_waitDownloadTask.Contains(url) && !m_curDownloadTask.Contains(url)) {
            CastTask(url);
        }
    }

    private static void CastTask(string url) 
    {
        if (string.IsNullOrEmpty(url)) 
        {
            if (m_waitDownloadTask.Count == 0) {
                return;//没有等待下载的任务
            }
            
            url = m_waitDownloadTask[0];
            m_waitDownloadTask.RemoveAt(0);
        }

        //当前并发下载数大于3，缓存
        if (m_curDownloadTask.Count > m_maxDownloadNum) 
        {
            m_waitDownloadTask.Add(url);
        } else {
            int taskId = TaskManager.Instance.Create(RealDownload(url));
            m_curDownloadTask.Add(url);
        }
    }

    private static IEnumerator RealDownload(string url) 
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        req.timeout = m_DownloadTimeOut;
        
        TaskInfo taskInfo = null;
        if (m_taskCallBack.TryGetValue(url, out taskInfo)) {
            req.downloadHandler = taskInfo.Handle;
        }
        
        yield return req.SendWebRequest();
        if (req.isNetworkError || req.isHttpError)
        {
            DownloadEnd(url);
            yield break; 
        }

        HandleDownload(url, req.downloadHandler);
        req.Dispose();

        DownloadEnd(url);
    }

    //下载错误、下载结束都清掉这个url任务
    private static void DownloadEnd(string url) {
        m_taskCallBack.Remove(url);
        m_curDownloadTask.Remove(url);
        CastTask(null);
    }

    private static void HandleDownload(string url, DownloadHandler handle) {
        Texture tex = null;
        if (handle is DownloadHandlerTexture texHandle) {
            tex = texHandle.texture;

            if (tex) {
                tex.name = url;
            }
        }

        DownCache cacheHandle = new DownCache();//缓存，req.Dispose会销毁handle，所以这边单独缓存
        cacheHandle.data = handle.data;
        cacheHandle.text = handle.text;
        cacheHandle.tex = tex;
        cacheHandle.url = url;
        
        if(!m_cacheDownload.ContainsKey(url))
            m_cacheDownload.Add(url, cacheHandle);
        
        TaskInfo taskInfo = null;
        if (m_taskCallBack.TryGetValue(url, out taskInfo)) 
        {
            taskInfo.DownloadEnd(cacheHandle);
            m_taskCallBack.Remove(url);
        }
    }
    
    //移除某个链接下载
    public static void RemoveHandle(string url) 
    {
        m_taskCallBack.Remove(url);
        if (m_waitDownloadTask.Contains(url))
            m_waitDownloadTask.Remove(url);
    }
    
    //移除单个下载任务
    public static void RemoveHandle(string url, Action<DownCache> callBack) 
    {
        TaskInfo taskInfo = null;
        if (m_taskCallBack.TryGetValue(url, out taskInfo)) {
            taskInfo.RemoveCallBack(callBack);

            if (taskInfo.Count() == 0) {
                m_taskCallBack.Remove(url);
            }
        }
    }

    #region 贴图下载封装
    private class TextureTaskInfo 
    {
        private List<Action<Texture, string>> m_callBacks = new List<Action<Texture, string>>();
        
        public void AddCallBack(Action<Texture, string> callBack) 
        {
            if (!m_callBacks.Contains(callBack)) {
                m_callBacks.Add(callBack);
            }
        }
        
        public void RemoveCallBack(Action<Texture, string> callBack) {
            if (m_callBacks.Contains(callBack)) {
                m_callBacks.Remove(callBack);
            }
        }

        public void ClearCallBack() {
            m_callBacks.Clear();
        }

        public int Count() {
            return m_callBacks.Count;
        }

        public void DownloadEnd(DownCache cache) {
            bool isGif = cache.text.StartsWith("GIF");
            for (int i = 0; i < m_callBacks.Count; i++) {
                if (isGif) //gif
                {
                    m_callBacks[i](null, cache.url);
                } else {
                    m_callBacks[i](cache.tex, cache.url);
                }
            }

            ClearCallBack();
        }
    }
    
    private static Dictionary<string, TextureTaskInfo> m_texCallBack = 
        new Dictionary<string, TextureTaskInfo>();//下载回调缓存
    
    //下载贴图
    public static void DownloadTexture(string url, Action<Texture, string> callBack) {
        TextureTaskInfo texCallBack = null;
        if (!m_texCallBack.TryGetValue(url, out texCallBack)) {
            texCallBack = new TextureTaskInfo();
            m_texCallBack.Add(url, texCallBack);
        }

        texCallBack.AddCallBack(callBack);
        
        Download(url, (cacheHandle) => 
        {
            TextureTaskInfo finalCallBack = null;
            if (!m_texCallBack.TryGetValue(cacheHandle.url, out finalCallBack)) {
                return;
            }
            
            finalCallBack.DownloadEnd(cacheHandle);
            m_texCallBack.Remove(cacheHandle.url);
        }, new DownloadHandlerTexture());
    }

    public static void RemoveTexTask(string url, Action<Texture, string> callBack) {
        TextureTaskInfo callBackList = null;
        if (m_texCallBack.TryGetValue(url, out callBackList)) {
            callBackList.RemoveCallBack(callBack);
            if (callBackList.Count() == 0) {
                m_texCallBack.Remove(url);
            }
        }
    }
    
    public static void RemoveTexTask(string url) {
        m_texCallBack.Remove(url);
    }

    #endregion
}