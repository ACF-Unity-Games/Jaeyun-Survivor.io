using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageHandler : MonoBehaviour
{

    public float IneffectiveTime;
    public int DamageOnCollision;
    public string TagToDamage;

    private float _lastDamageTime;

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
        // if (collision.gameObject.tag != TagToDamage) { return; }
        if (Time.time - _lastDamageTime <= IneffectiveTime) { return; }
        collision.gameObject.TryGetComponent(out HealthHandler hpHandler);
        if (hpHandler != null)
        {
            hpHandler.TakeDamage(DamageOnCollision);
            _lastDamageTime = Time.time;
        }
    }

}
