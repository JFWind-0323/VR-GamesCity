using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataTools
{
    public static Data data = Data.Instance;
    [MenuItem("Tools/Data/¥Êµµ")]
    public static void SaveData()
    {
        
        string json = JsonUtility.ToJson(data);
        string path = Application.dataPath + "/Data/UserData.json";
        Debug.Log(path);
        File.WriteAllText(path, json);;
    }
    [MenuItem("Tools/Data/÷ÿ÷√¥Êµµ")]
    public static void ResetData()
    {
        data = new Data();
        string json = JsonUtility.ToJson(data);
        string path = Application.dataPath + "/Data/UserData.json";
        File.WriteAllText(path, json);
        Debug.Log(path);
    }
}
