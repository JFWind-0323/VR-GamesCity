using System.Collections;
using System.Collections.Generic;
using UnityEditor;
public class BackPackData
{
    public Dictionary<int, string> backPackdic;
}
public class GameData
{
    public int fruitScore;
    public int balloonScore;
    public int basketballScore;
}
public class UserData
{
    public int token;
}

public class Data
{
    public static Data instance;
    public static Data Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Data();
            }
            return instance;
        }
    }

    public BackPackData backPackData = new BackPackData();
    public GameData gameData = new GameData();
    public UserData userData = new UserData();


}
