using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageHandler : MonoBehaviour
{

    [Header("Layer Assignments")]
    [SerializeField] private LayerMask _damageableLayer;

    public int DamageOnCollision = 1;

    private float _ineffectiveTime = 0.5f;
    private float _lastDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time - _lastDamageTime <= _ineffectiveTime) { return; }
        collision.gameObject.TryGetComponent(out HealthHandler hpHandler);
        if (hpHandler != null)
        {
            hpHandler.TakeDamage(DamageOnCollision);
            _lastDamageTime = Time.time;
        }
    }

}
