using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataUtils
{
    private static Vector3 colorMultiplier = new Vector3(1.3f, 1.3f, 1.3f);
    public static string dataDir => Application.persistentDataPath + "/U3D/";
    public static string ExceptionReportFileName => "ExceptionReport.json";

    public static string Vector3ToString(Vector3 target)
    {
        string str = target.ToString("f4");
        str = str.Substring(1, str.Length - 2);
        return str;
    }

    public static Vector3 LimitVector3(Vector3 target, float min = 0.0001f)
    {
        for (int i = 0; i < 3; i++)
        {
            target[i] = Mathf.Max(target[i],min);
        }
        return target;
    }

    public static string Vector2ToString(Vector2 target)
    {
        string str = target.ToString("f4");
        str = str.Substring(1, str.Length - 2);
        return str;
    }

    public static Vector3 DeSerializeVector3(string target)
    {
        string[] split = target.Split(',');
        float x = float.Parse(split[0], CultureInfo.InvariantCulture);
        float y = float.Parse(split[1], CultureInfo.InvariantCulture);
        float z = float.Parse(split[2], CultureInfo.InvariantCulture);
        return new Vector3(x, y, z);
    }

    public static Vector2 DeSerializeVector2(string target)
    {
        string[] split = target.Split(',');
        float x = float.Parse(split[0], CultureInfo.InvariantCulture);
        float y = float.Parse(split[1], CultureInfo.InvariantCulture);
        return new Vector2(x, y);
    }

    public static string ColorToString(Color target)
    {
        return ColorUtility.ToHtmlStringRGB(target);
    }
    public static Color DeSerializeColor(string target)
    {
        bool parseSuccess = ColorUtility.TryParseHtmlString("#" + target, out Color color);
        if (parseSuccess)
        {
            return color;
        }
        return default;
    }
    public static Color DeSerializeColorByHex(string target)
    {
        bool parseSuccess = ColorUtility.TryParseHtmlString(target, out Color color);
        if (parseSuccess)
        {
            return color;
        }
        return default;
    }

    public static int GetProgress(float realVal, float min, float max, float pMin, float pMax)
    {
        return (int)(pMin + (realVal - min) / (max - min) * (pMax - pMin));
    }

    public static float GetRealValue(float progress, float min, float max, float pMin, float pMax)
    {
        return min + (progress - pMin) / (pMax - pMin) * (max - min);
    }

    public static Color GetHighlightColor(Color oldColor)
    {
        Color newColor = oldColor;
        if (newColor.r < 0.2f)
        {
            newColor.r += 0.1f;
        }
        newColor.r *= colorMultiplier.x;

        if (newColor.g < 0.2f)
        {
            newColor.g += 0.1f;
        }
        newColor.g *= colorMultiplier.y;

        if (newColor.b < 0.2f)
        {
            newColor.b += 0.1f;
        }
        newColor.b *= colorMultiplier.z;

        if (newColor.a < 0.5f) newColor.a *= 1.4f;

        return newColor;
    }

    public static string GetJsonName()
    {
        return Random.Range(10000, 99999) + "_"  + Random.Range(10000, 99999) + ".json";
    }


    public static string SaveAudio(string audioName, byte[] audio)
    {
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        if (File.Exists(dataDir + audioName))
        {
            File.Delete(dataDir + audioName);
        }
        Debug.Log("dataDir + fileName====="+ dataDir + audioName);
        FileStream stream = new FileStream(dataDir + audioName, FileMode.Create);
        stream.Write(audio, 0, audio.Length);
        Debug.Log("dataDir + audio.Length=====" + audio.Length);

        stream.Flush();
        stream.Close();
        return dataDir + audioName;
    }

    public static string SaveJsonAndGetPath(string json)
    {
        string fileName = UnityEngine.Random.Range(10000, 99999).ToString();
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        File.WriteAllText(dataDir + fileName, json);
        string FullPath = dataDir + fileName;
        return FullPath;
    }


}