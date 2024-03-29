using UnityEngine;
using System.Collections;
using UnityEngine.Profiling;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(20, 20, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        //new Color (0.0f, 0.0f, 0.5f, 1.0f);
        style.normal.textColor = Color.white;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
        

        // GUIStyle memoryStyle = new GUIStyle();
        //
        // Rect memoryRect = new Rect(20, 40 + h * 2 / 100, w, h * 2 / 100);
        // memoryStyle.alignment = TextAnchor.UpperLeft;
        // memoryStyle.fontSize = h * 2 / 100;
        // //new Color (0.0f, 0.0f, 0.5f, 1.0f);
        // memoryStyle.normal.textColor = Color.white;
        // string memoryText = $"memory {Profiler.GetTotalAllocatedMemoryLong()}";
        // GUI.Label(memoryRect, memoryText, memoryStyle);
        
    }
}