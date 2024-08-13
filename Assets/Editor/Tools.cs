using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UI;
using UnityEditor;
using UnityEngine;

public class Tools
{
    [MenuItem("Tools/UI/关闭")]
    public static void Pop()
    {
        UIManager.Instance.PopPanel();
    }

    [MenuItem("Tools/UI/1.设置")]
    public static void SettingPanel()
    {
        UIManager.Instance.PushPanel(UIType.SettingsPanel);
    }
    [MenuItem("Tools/UI/2.背包")]
    public static void BackPackPanel()
    {
        UIManager.Instance.PushPanel(UIType.BackpackPanel);
    }
    [MenuItem("Tools/UI/3.商店")]
    public static void ShopPanel()
    {
        UIManager.Instance.PushPanel(UIType.ShopPanel);
    }

    [MenuItem("Tools/UI/4.介绍")]
    public static void GameIntroducePanel()
    {
        UIManager.Instance.PushPanel(UIType.GameIntroducePanel);
    }
    [MenuItem("Tools/UI/5.结算")]
    public static void GameOverPanel()
    {
        UIManager.Instance.PushPanel(UIType.GameOverPanel);
    }


}
