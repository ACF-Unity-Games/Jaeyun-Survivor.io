using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovementHandler))]
[RequireComponent(typeof(HealthHandler))]
[RequireComponent(typeof(CollisionDamageHandler))]
public class EnemyHandler : MonoBehaviour
{

    [Header("Enemy Information")]
    [SerializeField] private EnemyInfo _enemyInfo;

    private EnemyMovementHandler _enemyMovementHandler;
    private HealthHandler _healthHandler;
    private CollisionDamageHandler _collisionDamageHandler;

    private void Awake()
    {
        _enemyMovementHandler = GetComponent<EnemyMovementHandler>();
        _healthHandler = GetComponent<HealthHandler>();
        _collisionDamageHandler = GetComponent<CollisionDamageHandler>(); 
    }

    private void Start()
    {
        if (_enemyInfo != null)
        {
            SetEnemy(_enemyInfo);
        }
    }

    public void SetEnemy(EnemyInfo enemyInfo)
    {
        _enemyInfo = enemyInfo;
        _enemyMovementHandler.Initialize(_enemyInfo);
        _healthHandler.Initialize(_enemyInfo.MaxHealth);
        _collisionDamageHandler.Initialize(_enemyInfo.EnemyDamage);
        _healthHandler.OnDeath = (gameObject) =>
        {
            Destroy(gameObject);
        };
    }

}
