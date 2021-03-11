using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] GameObject _spawnManager;

    protected override void Awake()
    {
        base.Awake();
        UseDefaultValues();
    }

    void Start()
    {

        StartGame();
        
    }

    void StartGame()
    {
        //game start
        //need spawnManager
        Instantiate(_spawnManager);

        //initial spawn setup
        SpawnManager.Instance.Initialize();
    }

    [SerializeField] IntVariable _fishCount;
    [SerializeField] IntVariable _fishCountD;
    [SerializeField] FloatVariable _w1;
    [SerializeField] FloatVariable _w1d;
    [SerializeField] FloatVariable _w2;
    [SerializeField] FloatVariable _w2d;
    [SerializeField] FloatVariable _w3;
    [SerializeField] FloatVariable _w3d;
    [SerializeField] FloatVariable _w4;
    [SerializeField] FloatVariable _w4d;

    void UseDefaultValues()
    {
        _fishCount.Value = _fishCountD.Value;
        _w1.Value = _w1d.Value;
        _w2.Value = _w2d.Value;
        _w3.Value = _w3d.Value ;
        _w4.Value = _w4d.Value;
    }
}
