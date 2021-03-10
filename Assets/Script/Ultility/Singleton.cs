using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T :Singleton<T>
{
    public static T Instance { get; private set; }
    
    protected virtual void Awake()
    {

        if(Instance == null)
        {
            Instance = (T)this;
        }
        else if(Instance != (T)this)
        {
            Debug.LogError("Try to instantiate multiple singleton object");
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if(Instance == (T)this)
        {
            Destroy(this.gameObject);
        }
    }
}
