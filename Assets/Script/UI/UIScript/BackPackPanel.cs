using OwnTool;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class BackPackPanel : BasePanel
{
    Dictionary<int, string> goodsDic;
    List<Kvp<int, string>> goodsKvps;
    Transform parent;
    public override void OnEnter()
    {
        base.OnEnter();
        parent = transform.GetChild(0).GetChild(0);
        InitGoodsDic();
        InitBackPack();
    }

    public void InitGoodsDic()
    {
        goodsDic = goodsDic.InitDic();
        goodsKvps = Data.Instance.backPackData.goodsDicKvp;
        foreach (var kvp in goodsKvps)
        {
            goodsDic.Add(kvp.key, kvp.value);
        }
    }

    public void InitBackPack()
    {

        foreach (var path in goodsDic.Values)
        {
            GameObject obj = Resources.Load<GameObject>(path);
            Instantiate(obj, parent);
        }
    }

    public override void OnExit()
    {
        parent.DestroyChilds();
        base.OnExit();
    }
}
