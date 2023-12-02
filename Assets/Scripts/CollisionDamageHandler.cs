using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageDealer : MonoBehaviour
{

    [Header("Layer Assignments")]
    [SerializeField] private LayerMask _damageableLayer;

    private float _ineffectiveTime = 0.5f;
    private float _lastDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time - _lastDamageTime <= _ineffectiveTime) { return; }
        collision.gameObject.TryGetComponent(out HealthHandler hpHandler);
        if (hpHandler != null)
        {
            hpHandler.TakeDamage(1);
            _lastDamageTime = Time.time;
        }
    }

}
