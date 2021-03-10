using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//the object spawn by spawn Manger need to have some mechanic that it will be control by Spawn Manager
public class ManageBySpawnManager : MonoBehaviour
{
    //Event that Spawn Manager need to know
    public UnityEvent OnDestroyUnityEvent = new UnityEvent();

    private void OnDestroy()
    {
        OnDestroyUnityEvent.Invoke();
    }

}
