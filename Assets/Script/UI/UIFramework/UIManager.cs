using System;
using System.Collections.Generic;
using UnityEngine;


namespace UI
{
    //数据加载
    public partial class UIManager : MonoSingle<UIManager>
    {
        readonly string uiPrefabPath = "Prefabs/UIPrefab";

        //所有UIprefab在Reseource下的路径
        public Dictionary<string, string> dicPath;

        public Dictionary<string, BasePanel> dicPanel;

        public Dictionary<UILayer, string> dicLayerName;

        public Dictionary<UILayer, Transform> dicLayer;

        private Stack<BasePanel> stackPanel;

        public Transform canvasTf;


        private void Awake()
        {
            canvasTf = GameObject.FindWithTag("MainCanvas").transform;

            InitPath();
            InitUILayer();
            LoadLayer();
        }
        void InitPath()
        {
            //从UIPrefab文件夹中找到所有UI的预制体
            //将他们的名称和路径键值对添加到dicPath中
            GameObject[] prefabs = Resources.LoadAll<GameObject>(uiPrefabPath);
            dicPath = new Dictionary<string, string>();
            foreach (GameObject item in prefabs)
            {
                if (dicPath.ContainsKey(item.name))
                {
                    dicPath[item.name] = $"Prefabs/UIPrefab/{item.name}";
                }
                else
                {
                    dicPath.Add(item.name, $"Prefabs/UIPrefab/{item.name}");
                }
                Debug.Log(item.name);
            }
        }
        void InitUILayer()
        {
            dicLayerName = new Dictionary<UILayer, string>();
            //遍历枚举，添加进UIlayer字典
            foreach (UILayer item in Enum.GetValues(typeof(UILayer)))
            {
                dicLayerName.Add(item, item.ToString());
                // Debug.Log(item.ToString());
            }
        }
        private void LoadLayer()
        {
            dicLayer = new Dictionary<UILayer, Transform>();
            //创建空物体作为Layer
            foreach (var item in dicLayerName.Keys)
            {
                GameObject layer = new GameObject(dicLayerName[item]);
                RectTransform tf = layer.AddComponent<RectTransform>();
                tf.SetParent(canvasTf);
                UIAnchorManager.Instance.FillTheCanvas(tf);
                dicLayer.Add(item, layer.transform);
            }
        }
    }


    //public void WriteJsonFile(string jsonPath)
    //{
    //    pathData.uiPathData.GetDicPath(dicPath);
    //    string json = JsonUtility.ToJson(pathData);
    //    File.WriteAllText(jsonPath, json);
    //}
    //public Dictionary<string, string> ReadJsonFile(string path)
    //{
    //    if (!File.Exists(path))
    //    {
    //        File.WriteAllText(path, "{}");
    //    }
    //    string json = File.ReadAllText(path);
    //    PathData.Instance.uiPathData = JsonUtility.FromJson<PathData>(json).uiPathData;

    //    Dictionary<string, string> dic = PathData.Instance.uiPathData.dicPath;
    //    return dic;
    //}

    //逻辑
    public partial class UIManager : MonoSingle<UIManager>
    {
        //获取dicPanel中存储的基层BasePanel的类，如果为空，先加载添加进去
        private BasePanel GetPanel(string panelType)
        {
            if (dicPanel == null)
            {
                dicPanel = new Dictionary<string, BasePanel>();
            }
            if (dicPanel.ContainsKey(panelType))
            {
                return dicPanel[panelType];
            }
            else
            {
                string path = string.Empty;
                if (dicPath.ContainsKey(panelType))
                {
                    path = dicPath[panelType];
                    Debug.Log(path);
                }
                else
                {
                    Debug.LogError($"路径：Asset/Resources/{uiPrefabPath} 下没有找到该面板的预制体，或检查预制体的名称与UIType中的枚举是否不一致");
                    return null;
                }


                GameObject go = Resources.Load<GameObject>(path);
                GameObject goPanel = Instantiate(go, canvasTf, false);
                BasePanel panel = goPanel.GetComponent<BasePanel>();
                if (panel == null)
                {
                    panel = goPanel.AddComponent<BasePanel>();
                }
                dicPanel.Add(panelType, panel);
                return panel;
            }
        }
        /// <summary>
        /// 加载面板，不入栈
        /// </summary>
        /// <param name="panelType"> 面板种类 </param>
        public void LoadPanel(UIType panelType)
        {
            string type = panelType.ToString();
            //无返回值的重载
            BasePanel panel = GetPanel(type);
            panel.OnEnter();
        }

        public void LoadPanel(UIType panelType, out BasePanel panel)
        {
            //有返回值的重载
            string type = panelType.ToString();
            panel = GetPanel(type);
            panel.OnEnter();
        }

        /// <summary>
        /// 打开面板，入栈
        /// </summary>
        /// <param name="panelType"> 面板种类 </param>
        public void PushPanel(UIType panelType)
        {
            if (stackPanel == null)
                stackPanel = new Stack<BasePanel>();
            if (stackPanel.Count > 0)
            {
                BasePanel top = stackPanel.Peek();
                top.OnPause();
            }
            BasePanel panel;
            LoadPanel(panelType, out panel);
            stackPanel.Push(panel);
        }

        /// <summary>
        /// 关闭最上层的面板
        /// </summary>
        public void PopPanel()
        {
            if (stackPanel == null)
            {
                stackPanel = new Stack<BasePanel>();
            }

            if (stackPanel.Count <= 0)
            {
                return;
            }

            BasePanel top = stackPanel.Pop();
            top.OnExit();

            if (stackPanel.Count > 0)
            {
                BasePanel panel = stackPanel.Peek();
                panel.OnResume();
            }

        }
        /// <summary>
        /// 获取最上层的面板
        /// </summary>
        /// <returns> 面板的基类 </returns>
        public BasePanel GetTopPanel()
        {
            if (stackPanel.Count > 0)
            {
                return stackPanel.Peek();
            }
            else
            {
                return null;
            }
        }



    }
}