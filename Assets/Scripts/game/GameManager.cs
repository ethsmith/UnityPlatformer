using System.Collections.Generic;
using game.controller;
using game.entity;
using game.state;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public StateController stateController = new();

    public List<Enemy> enemies;

    private readonly PlayerController _playerController = new();
    
    private readonly EnemyController _enemyController = new();

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager GetInstance()
    {
        return _instance;
    }
    
    public PlayerController GetPlayerController()
    {
        return _playerController;
    }
    
    public EnemyController GetEnemyController()
    {
        return _enemyController;
    }
    
    public StateController GetStateController()
    {
        return stateController;
    }
}
