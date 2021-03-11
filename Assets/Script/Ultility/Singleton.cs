using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("[Singleton] Instance is null,didn't create a instance yet.");
            return _instance;
        }
    }

    protected virtual void Awake()
    {

        if (_instance == null)
        {
            _instance = (T)this;
        }
        else if (_instance != (T)this)
        {
            Debug.LogError("Try to instantiate multiple singleton object");
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == (T)this)
        {
            Destroy(this.gameObject);
        }
    }
}
