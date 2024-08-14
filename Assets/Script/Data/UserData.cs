using System.Collections;
using System.Collections.Generic;
using UnityEditor;
public class BackPackData
{
    public Dictionary<int, string> backPackdic;
}
public class GameData
{

}

public class UserData
{
    public static UserData instance;
    public static UserData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserData();
            }
            return instance;
        }
    }

    public BackPackData backPackData = new BackPackData();


}
