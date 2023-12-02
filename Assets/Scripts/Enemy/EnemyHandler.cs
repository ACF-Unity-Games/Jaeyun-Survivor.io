using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovementHandler))]
[RequireComponent(typeof(HealthHandler))]
public class EnemyHandler : MonoBehaviour
{

    [Header("Enemy Information")]
    [SerializeField] private EnemyInfo _enemyInfo;

    private EnemyMovementHandler _enemyMovementHandler;
    private HealthHandler _healthHandler;

    private void Awake()
    {
        _enemyMovementHandler = GetComponent<EnemyMovementHandler>();
        _healthHandler = GetComponent<HealthHandler>();
        _enemyMovementHandler.Initialize(_enemyInfo);
        _healthHandler.Initialize(_enemyInfo.MaxHealth);
    }

}
