using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageHandler : MonoBehaviour
{

    public float IneffectiveTime;
    public int DamageOnCollision;
    public string TagToDamage;

    private float _lastDamageTime;

    public Action OnDealDamage;

    public void Initialize(int damage)
    {
        DamageOnCollision = damage;
        IneffectiveTime = 0.5f;
    }

    /// <summary>
    /// When this collides with something that has a HealthHandler,
    /// deals damage.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject colObject = collision.gameObject;
        if (!colObject.CompareTag(TagToDamage)) { return; }
        if (Time.time - _lastDamageTime <= IneffectiveTime) { return; }
        if (colObject.TryGetComponent(out HealthHandler hpHandler))
        {
            hpHandler.TakeDamage(DamageOnCollision);
            _lastDamageTime = Time.time;
            // Damage this too, if possible
            if (TryGetComponent(out HealthHandler thisHpHandler) && colObject.TryGetComponent(out CollisionDamageHandler otherColDamageHandler))
            {
                thisHpHandler.TakeDamage(otherColDamageHandler.DamageOnCollision);
            }
            OnDealDamage?.Invoke();
        }
    }

}
