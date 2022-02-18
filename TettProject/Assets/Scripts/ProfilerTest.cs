using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class ProfilerTest : MonoBehaviour
{

    ProfilerRecorder systemMemoryRecorder;
    ProfilerRecorder gcMemoryRecorder;
    ProfilerRecorder mainThreadTimeRecorder;
    ProfilerRecorder callRecorder;
    private ProfilerRecorder trianglesRecorder;
    private ProfilerRecorder totalUsedMemoryRecorder;
    private ProfilerRecorder cpuRecorder;
    void OnEnable()
    {
        cpuRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "" );
        systemMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        totalUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
        gcMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        callRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "SetPass Calls Count");
        trianglesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render,"Triangles Count");
        mainThreadTimeRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 15);
        
    }

    void OnDisable()
    {
        systemMemoryRecorder.Dispose();
        gcMemoryRecorder.Dispose();
        mainThreadTimeRecorder.Dispose();
    }

    private void Update()
    {
        Debug.Log("trianglesRecorder:" + trianglesRecorder.LastValue);
        Debug.Log("callRecorder:" + callRecorder.LastValue);
        Debug.Log("totalUsedMemoryRecorder:" +(totalUsedMemoryRecorder.LastValue /  (1024 * 1024)) + "MB");
    
    }
}
