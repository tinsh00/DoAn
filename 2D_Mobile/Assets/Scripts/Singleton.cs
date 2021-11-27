
 using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance { get; private set; }

    [SerializeField] bool isDestroyOnLoad = true;

    protected virtual void Awake()
    {
        if (!instance)
        {
            instance = GetComponent<T>();
            if (!isDestroyOnLoad)
                DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
