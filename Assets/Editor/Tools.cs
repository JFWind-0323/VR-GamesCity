using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UI;
using UnityEditor;
using UnityEngine;

public class Tools
{
    [MenuItem("Tools/UI/�ر�")]
    public static void Pop()
    {
        UIManager.Instance.PopPanel();
    }

    [MenuItem("Tools/UI/1.����")]
    public static void SettingPanel()
    {
        UIManager.Instance.PushPanel(UIType.SettingsPanel);
    }
    [MenuItem("Tools/UI/2.����")]
    public static void BackPackPanel()
    {
        UIManager.Instance.PushPanel(UIType.BackpackPanel);
    }
    [MenuItem("Tools/UI/3.�̵�")]
    public static void ShopPanel()
    {
        UIManager.Instance.PushPanel(UIType.ShopPanel);
    }

    [MenuItem("Tools/UI/4.����")]
    public static void GameIntroducePanel()
    {
        UIManager.Instance.PushPanel(UIType.GameIntroducePanel);
    }
    [MenuItem("Tools/UI/5.����")]
    public static void GameOverPanel()
    {
        UIManager.Instance.PushPanel(UIType.GameOverPanel);
    }


}
