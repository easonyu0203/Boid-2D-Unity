using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] GameObject _spawnManager;
    
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
}
