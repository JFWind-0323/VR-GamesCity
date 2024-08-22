using System.Collections;
using System.Collections.Generic;
using OwnTool;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : BasePanel
{

    string goodsBtnPfbPath = "Prefabs/ButtonPrefab/GoodsBtn";
    string goodPfbPathBase = "Prefabs/GoodsPrefab/";
    string infoPath = "CSV/GoodsInfo";
    string spritePathBase = "Sprites/GoodsSprite/";
    TextAsset infoAsset;
    string[] infoText;
    public GameObject goodsBtnPfb;
    public Dictionary<GameObject, GoodsInfo> uiSkinDic;
    public Dictionary<GameObject, GoodsInfo> selectionDic;
    public Dictionary<int, string> goodsPathDic;

    Transform uiSkinParent;
    Transform selectionParent;

    public override void OnEnter()
    {
        base.OnEnter();
        goodsBtnPfb = Resources.Load<GameObject>(goodsBtnPfbPath);
        infoAsset = Resources.Load<TextAsset>(infoPath);
        infoText = infoAsset.text.Split("\n");

        uiSkinParent = transform.GetChild(0).GetChild(0).transform;
        selectionParent = transform.GetChild(1).GetChild(0).transform;

        InitGoodsDics();
        InitGoodPathDic();


    }
    void InitGoodsDics()
    {
        uiSkinDic = uiSkinDic.InitDic();
        selectionDic = selectionDic.InitDic();

        for (int i = 0; i < infoText.Length - 2; i++)
        {
            string[] row = infoText[i + 1].Split(",");

            int id = int.Parse(row[0].Trim());
            if (CheckIfBeSold(id))
                continue;

            string name = row[1].Trim();
            int price = int.Parse(row[2].Trim());
            int typeID = int.Parse(row[3].Trim());



            Transform parent = transform.GetChild(typeID).GetChild(0).transform;
            GameObject goodsBtn = Instantiate(goodsBtnPfb, parent);
            goodsBtn.name = name;
            Button btn = goodsBtn.GetComponent<Button>();
            Image image = btn.image;

            string spritePath = spritePathBase + name;
            btn.onClick.AddListener(() => GetGoods(id));
            btn.onClick.AddListener(() => btn.enabled = false);
            btn.onClick.AddListener(() => SoundManager.Instance.PlaySoundEffect(SoundsGlobal.Click,2f));

            image.sprite = Resources.Load<Sprite>(spritePath);

            switch (typeID)
            {
                case 0:
                    uiSkinDic.Add(goodsBtn, new GoodsInfo(id, name, price, GoodsType.UISkin));
                    break;
                case 1:

                    selectionDic.Add(goodsBtn, new GoodsInfo(id, name, price, GoodsType.Selection));
                    break;
                default:
                    goodsBtn = null;
                    Debug.LogError("请检查表格是否有误");
                    break;
            }


        }
        uiSkinDic.PrintDic();
        selectionDic.PrintDic();
    }
    void InitGoodPathDic()
    {
        if (goodsPathDic == null)
        {
            goodsPathDic = new Dictionary<int, string>();
        }
        goodsPathDic = goodsPathDic.InitDic();
        foreach (var goods in uiSkinDic.Keys)
        {
            int id = uiSkinDic[goods].id;
            string path = goodPfbPathBase + uiSkinDic[goods].name;
            goodsPathDic.Add(id, path);
        }
        foreach (var goods in selectionDic.Keys)
        {
            int id = selectionDic[goods].id;
            string path = goodPfbPathBase + selectionDic[goods].name;
            goodsPathDic.Add(id, path);
        }
    }

    public void GetGoods(int id)
    {
        Data.Instance.backPackData.goodsDicKvp.Add(new Kvp<int, string> { key = id, value = goodsPathDic[id] });
        //Debug.Log(goodsPathDic[id]);
    }

    public override void OnExit()
    {
        Debug.Log(uiSkinParent);
        uiSkinParent.DestroyChilds();
        selectionParent.DestroyChilds();

        base.OnExit();
    }


    bool CheckIfBeSold(int id)
    {
        foreach (var kvp in Data.Instance.backPackData.goodsDicKvp)
        {

            if (id == kvp.key)
            {
                return true;
            }
        }
        return false;
    }

}
