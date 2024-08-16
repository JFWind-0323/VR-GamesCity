using System.Collections;
using System.Collections.Generic;
using OwnTool;
using UI;
using UnityEngine;

public class ShopPanel : BasePanel
{

    string goodsPrefabPath = "Prefabs/GoodsPrefab";
    string infoPath = "CSV/GoodsInfo";
    TextAsset infoAsset;
    string[] infoText;
    public GameObject[] goodsPrefabs;
    public Dictionary<GameObject, GoodsInfo> goodsDic;
    public Dictionary<int, string> goodsPathDic;

    private void Awake()
    {
        goodsPrefabs = Resources.LoadAll<GameObject>(goodsPrefabPath);
        infoAsset = Resources.Load<TextAsset>(infoPath);
        infoText = infoAsset.text.Split("\n");
        InitGoodsDic();
        InitGoodPathDic();
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

        if (goodsPrefabs.Length == 0)
        {
            Debug.LogWarning($"路径：{goodsPrefabPath}下没有预制体");
        }
        for (int i = 0; i < goodsPrefabs.Length; i++)
        {
            string[] row = infoText[i + 1].Split(",");
            int id = int.Parse(row[0].Trim());
            string name = row[1].Trim();
            goodsDic.Add(goodsPrefabs[i], new GoodsInfo(id, name));
        }
    }
    void InitGoodPathDic()
    {
        if (goodsPathDic == null)
        {
            goodsPathDic = new Dictionary<int, string>();
        }
        goodsPathDic.Clear();
        foreach (GameObject go in goodsDic.Keys)
        {
            int id = goodsDic[go].id;
            string path = $"{goodsPrefabPath}/{go.name}";
            goodsPathDic.Add(id, path);

        }
        CommonTools.Instance.PrintDic(goodsPathDic);

    }

  
}
