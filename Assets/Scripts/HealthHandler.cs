using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{

    [Header("Object Assignments")]
    [SerializeField] private Transform _hpBarScale;
    [Header("Health Properties")]
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public int Health
    {
        set
        {
            _health = value;
            if (_hpBarScale != null)
            {
                _hpBarScale.localScale = new Vector3((float)_health / _maxHealth, 1, 1);
            }
        }
        get => _health;
    }

    public bool IsDead() => Health == 0;
    public float GetHealthRatio() => (float)Health / _maxHealth;
    public int HealHealth(int hpGain) => Health = Mathf.Min(_maxHealth, Health + hpGain);

    /// <summary>
    /// Initializes the enemy at max and current health.
    /// </summary>
    /// <param name="hp">The health to set to.</param>
    public void Initialize(int hp)
    {
        _maxHealth = hp;
        Health = hp;
    }

    /// <summary>
    /// Makes this character take `dmg` amount of damage.
    /// If dead, destroys the character.
    /// </summary>
    /// <param name="dmg"></param>
    public void TakeDamage(int dmg)
    {
        Health = Mathf.Max(Health - dmg, 0);
        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

}
