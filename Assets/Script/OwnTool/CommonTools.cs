using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace OwnTool
{
    public static class CommonTools
    {

        public static void PrintDic<TKey, TValue>(this Dictionary<TKey, TValue> dic)
        {
            if (dic != null)
            {
                foreach (var key in dic.Keys)
                {
                    Debug.Log(dic[key].ToString());
                }
                //Debug.Log(dic.Count);
            }
            else
            {
                Debug.LogError($"{dic}ЮЊПе");
            }
        }

        public static Dictionary<Tkey, TValue> InitDic<Tkey, TValue>(this Dictionary<Tkey, TValue> dic)
        {
            if (dic == null)
            {
                dic = new Dictionary<Tkey, TValue>();
            }
            dic.Clear();
            return dic;
        }
        public static void DestroyChilds(this Transform parent)
        {
            for (int i = parent.childCount; i > 0; i--)
            {
                GameObject.Destroy(parent.GetChild(i-1).gameObject);
            }
        }
    }

}


