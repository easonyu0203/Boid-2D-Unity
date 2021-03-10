using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Boundery")]
public class Boundery : ScriptableObject
{
    private float _xLimit;
    private float _yLimit;

    public float XLimit { get { CalculateLimit(); return _xLimit; } }
    public float YLimit { get { CalculateLimit(); return _yLimit; } }

    private void Awake()
    {
        CalculateLimit();
    }

    void CalculateLimit()
    {
        //get limits
        _yLimit = Camera.main.orthographicSize;
        _xLimit = _yLimit * Screen.width / Screen.height;
    }
}
