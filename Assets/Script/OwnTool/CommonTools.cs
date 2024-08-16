using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnTool
{
    public class CommonTools
    {
        public static CommonTools instance;

        public static CommonTools Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonTools();
                }
                return instance;
            }
        }
        public void PrintDic<TKey, TValue>(Dictionary<TKey, TValue> dic)
        {
            if (dic != null)
            {
                foreach (var key in dic.Keys)
                {
                    Debug.Log(dic[key].ToString());
                }
                Debug.Log(dic.Count);
            }
            else
            {
                Debug.LogError($"{dic}ЮЊПе");
            }
        }


    }

}

