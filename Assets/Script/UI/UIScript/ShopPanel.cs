using System.Collections.Generic;
using System.Security.Permissions;
using UI;
using UnityEngine;

public class ShopPanel : BasePanel
{
    string goodsPrefabPath = "Prefabs/GoodsPrefab";
    string infoPath = "CSV/GoodsInfo";
    public GameObject[] goodsPrefabs;
    public Dictionary<GameObject, GoodsInfo> goodsDic;

    private void Awake()
    {
        goodsPrefabs = Resources.LoadAll<GameObject>(goodsPrefabPath);
    }


    public override void OnEnter()
    {
        base.OnEnter();

    }
    void InitGoodsDic()
    {
        if (goodsDic == null)
        {
            goodsDic = new Dictionary<GameObject, GoodsInfo>();
        }
        goodsDic.Clear();
        for (int i = 0; i < goodsPrefabs.Length; i++)
        {
            goodsDic.Add(goodsPrefabs[i], new GoodsInfo() );
        }
    }
}
