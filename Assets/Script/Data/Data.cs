using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Kvp<Tkey, Tvalue>
{
    public Tkey key;
    public Tvalue value;
}

[System.Serializable]
public class BackPackData
{
    public List<Kvp<int, string>> goodsDicKvp = new List<Kvp<int, string>>();
}
[System.Serializable]
public class GameData
{
    public int fruitScore = 0;
    public int balloonScore = 0;
    public int basketballScore = 0;
}
[System.Serializable]
public class UserData
{
    public int token = 0;
}

[System.Serializable]
public class Data
{
    private static string jsonPath = Application.dataPath + "/Data/UserData.json";
    private static Data instance;
    public static Data Instance
    {
        get
        {
            if (instance == null)
            {
                string json = File.ReadAllText(jsonPath);
                instance = JsonUtility.FromJson<Data>(json);
            }
            return instance;
        }
    }

    public BackPackData backPackData = new BackPackData();
    public GameData gameData = new GameData();
    public UserData userData = new UserData();


}
