using UnityEngine;

public abstract class LazySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    public static T instance
    {
        get
        {
            if (isQuitting)
            {
                return _instance;
            }

            if (null == _instance)
            {
                _instance = GameObject.FindObjectOfType<T>();
                
                if (null == _instance)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    static bool isQuitting;

    public static bool exists { get { return _instance != null; } }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);
    }

    protected virtual void OnApplicationQuit()
    {
        isQuitting = true;
    }
}



