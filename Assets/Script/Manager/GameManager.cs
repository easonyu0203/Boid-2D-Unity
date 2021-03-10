using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager.Initialize();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
