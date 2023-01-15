using System.Collections.Generic;
using game.controller;
using game.entity;
using game.state;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public State CurrentState { get; set; }

    public List<Enemy> enemies;

    private PlayerController _playerController = new();
    
    private EnemyController _enemyController = new();

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
}
