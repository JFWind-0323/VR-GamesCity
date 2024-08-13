using UnityEngine;

public class MonoSingle<T> : MonoBehaviour where T : MonoSingle<T>
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = GameObject.Find("MonoSingle");
                if (obj == null)
                {
                    obj = new GameObject("MonoSingle");
                }
                instance = obj.GetComponent<T>();
                if (instance == null)
                {
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;

        }

    }
}
