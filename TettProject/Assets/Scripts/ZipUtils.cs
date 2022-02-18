using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using UnityEngine;

public class ZipUtils : MonoBehaviour
{
    public static string zipDir => Application.persistentDataPath + "/U3D/ZipFile/";
    public static string extJsonDir => Application.persistentDataPath + "/U3D/ExtJson/";

 

    ///// <summary>
    ///// ZipFile
    ///// </summary>
    ///// <param name="FilePath">The File You Want To Zip</param>
    ///// <param name="DesPath">ZipFile Target Path</param>
    public static string ZipFile(string FilePath, string DesPath)
    {
        if (!File.Exists(FilePath))
        {
            Debug.Log("The file to be compressed does not exist");
        }

        if (!Directory.Exists(DesPath))
        {
            Directory.CreateDirectory(DesPath);
        }

        string oriFileName = Path.GetFileNameWithoutExtension(FilePath);
        string zipFileFullPath = DesPath + oriFileName + ".zip";
        Debug.Log(zipFileFullPath);
        using (FileStream fs = File.Create(zipFileFullPath))
        {
            using (ZipOutputStream zipStream = new ZipOutputStream(fs))
            {
                using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    ZipEntry zipEntry = new ZipEntry(oriFileName + ".json");
                    zipStream.SetLevel(9);
                    zipStream.PutNextEntry(zipEntry);
                    byte[] buffer = new byte[zipStream.Length];
                    int sizeRead = 0;
                    try
                    {
                        do
                        {
                            sizeRead = stream.Read(buffer, 0, buffer.Length);
                            zipStream.Write(buffer, 0, sizeRead);
                        } while (sizeRead > 0);
                    }
                    catch (Exception err)
                    {
                        Debug.LogException(err);
                        return null;
                    }
                    stream.Close();
                    Debug.Log("Zip Length -- " + zipStream.Length / 1024 + " kb");
                }
                zipStream.Finish();
                zipStream.Close();
            }
            fs.Close();
            File.Delete(FilePath);
            return oriFileName;
        }
    }

    /// <summary> 
    /// 解压功能(下载后直接解压压缩文件到指定目录) 
    /// </summary> 
    /// <param name="wwwStream">www下载转换而来的Stream</param> 
    /// <param name="zipedFolder">指定解压目标目录(每一个Obj对应一个Folder)</param> 
    /// <param name="password">密码</param> 
    /// <returns>解压结果</returns> 
    public static string SaveZipFromByte(byte[] ZipByte)
    {
        //bool result = true;
        FileStream fs = null;
        ZipInputStream zipStream = null;
        ZipEntry ent = null;
        string fileName = "";
        string fullPath = "";

        if (!Directory.Exists(extJsonDir))
        {
            Directory.CreateDirectory(extJsonDir);
        }
        try
        {
            //直接使用 将byte转换为Stream，省去先保存到本地在解压的过程
            Stream stream = new MemoryStream(ZipByte);
            zipStream = new ZipInputStream(stream);
            while ((ent = zipStream.GetNextEntry()) != null)
            {
                if (!string.IsNullOrEmpty(ent.Name))
                {
                    fileName = DataUtils.GetJsonName();
                    fullPath = Path.Combine(extJsonDir, fileName);
                    fullPath = fullPath.Replace('\\', '/');

                    if (fileName.EndsWith("/"))
                    {
                        Directory.CreateDirectory(fileName);
                        continue;
                    }

                    fs = File.Create(fullPath);

                    int size = 2048;
                    byte[] data = new byte[size];
                    while (true)
                    {
                        size = zipStream.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            fs.Write(data, 0, size);//解决读取不完整情况 
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            fs.Dispose();
            string content = File.ReadAllText(fullPath);
            File.Delete(fullPath);
            return content;
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            //result = false;
            return null;
        }
    }
}
