using System.Collections;
using System.Collections.Generic;

public enum GoodsType
{
    UISkin,
    Selection
}
public class GoodsInfo
{
    public int id;
    public string name;
    public int price;
    public GoodsType goodsType;
    public GoodsInfo(int id, string name, int price,GoodsType goodsType)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.goodsType = goodsType;
    }
}
