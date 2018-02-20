using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
        static T _instance;
        public static T instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = GameObject.FindObjectOfType<T>();
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);
        }
}

