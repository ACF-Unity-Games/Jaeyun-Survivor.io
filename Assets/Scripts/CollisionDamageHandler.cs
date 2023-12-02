using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageHandler : MonoBehaviour
{

    public float IneffectiveTime;
    public int DamageOnCollision;

    private float _lastDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time - _lastDamageTime <= IneffectiveTime) { return; }
        collision.gameObject.TryGetComponent(out HealthHandler hpHandler);
        if (hpHandler != null)
        {
            hpHandler.TakeDamage(DamageOnCollision);
            _lastDamageTime = Time.time;
        }
    }

}
