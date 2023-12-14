using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerController : MonoBehaviour
{

    [Header("Object Assignments")]
    [SerializeField] protected GameObject _prefabToSpawn;
    [SerializeField] private float _delayBetweenSpawns;
    [SerializeField] protected float _spawnRadius;

    private float _timeBeforeNextSpawn;

    private void Awake()
    {
        _timeBeforeNextSpawn = _delayBetweenSpawns;
    }

    public void Update()
    {
        _timeBeforeNextSpawn -= Time.deltaTime;
        if (_timeBeforeNextSpawn <= 0 )
        {
            SpawnObject();
            _timeBeforeNextSpawn = _delayBetweenSpawns;
        }
    }

    public abstract void SpawnObject();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }

}
