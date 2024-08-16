using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public void Test()
    {
        Debug.Log(1);
    }

    public void OpenShop()
    {
        if (!(UIManager.Instance.GetTopPanel() is MenuPanel))
        {
            UIManager.Instance.PopPanel();
        }
        UIManager.Instance.PushPanel(UIType.ShopPanel);
    }
    public void OpenSettings()
    {
        if (!(UIManager.Instance.GetTopPanel() is MenuPanel))
        {
            UIManager.Instance.PopPanel();
        }
        UIManager.Instance.PushPanel(UIType.SettingsPanel);
    }
    public void OpenBackpack()
    {
        if (!(UIManager.Instance.GetTopPanel() is MenuPanel))
        {
            UIManager.Instance.PopPanel();
        }

        UIManager.Instance.PushPanel(UIType.BackpackPanel);



    }

    public void OpenMenu()
    {
        if (!(UIManager.Instance.GetTopPanel() is MenuPanel))
        {
            UIManager.Instance.PopPanel();
        }
        UIManager.Instance.PushPanel(UIType.MenuPanel);
    }
}
