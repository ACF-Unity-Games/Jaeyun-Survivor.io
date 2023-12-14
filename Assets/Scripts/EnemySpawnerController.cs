using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : SpawnerController
{

    [Header("Enemy Information")]
    [SerializeField] private EnemyInfo _enemyInfo;


    public override void SpawnObject()
    {
        Vector3 randomness = new(Random.Range(-_spawnRadius, _spawnRadius),
                                     Random.Range(-_spawnRadius, _spawnRadius));
        GameObject obj = Instantiate(_prefabToSpawn, transform.position + randomness, Quaternion.identity);
        obj.GetComponent<EnemyHandler>().SetEnemy(_enemyInfo);
    }

}
