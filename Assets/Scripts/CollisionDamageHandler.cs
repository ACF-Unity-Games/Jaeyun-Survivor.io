using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageHandler : MonoBehaviour
{

    [Header("Tag Assignments")]
    [SerializeField] private string _tagToDamage;

    private float _ineffectiveTime;
    private int _damageOnCollision;
    private float _lastDamageTime;
    public bool IsActive = true;

    public Action OnDealDamage;

    public void Initialize(int damage)
    {
        _damageOnCollision = damage;
        _ineffectiveTime = 0.5f;
    }

    public void Initialize(ItemInfo item)
    {
        _damageOnCollision = item.ItemAtk;
        _ineffectiveTime = item.ItemDisableTime;
    }

    /// <summary>
    /// When this collides with something that has a HealthHandler,
    /// deals damage.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject colObject = collision.gameObject;
        if (!colObject.CompareTag(_tagToDamage)) { return; }
        if (Time.time - _lastDamageTime <= _ineffectiveTime) { return; }
        if (!IsActive) { return; }
        if (colObject.TryGetComponent(out HealthHandler hpHandler))
        {
            hpHandler.TakeDamage(_damageOnCollision);
            _lastDamageTime = Time.time;
            // Damage this too, if possible
            if (TryGetComponent(out HealthHandler thisHpHandler) && colObject.TryGetComponent(out CollisionDamageHandler otherColDamageHandler))
            {
                if (!otherColDamageHandler.IsActive) { return; }
                thisHpHandler.TakeDamage(otherColDamageHandler._damageOnCollision);
            }
            OnDealDamage?.Invoke();
        }
    }

}
