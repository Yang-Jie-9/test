using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestDel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var path = "Assets/Output/tttt";
        var directoryInfo = new DirectoryInfo(path);
        Debug.Log("path:" + path);
        if (directoryInfo.Exists)
        {
            // directoryInfo.Delete(true);
            Debug.Log("IsValidFolder:" + path);
            UnityEditor.AssetDatabase.DeleteAsset(path);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
