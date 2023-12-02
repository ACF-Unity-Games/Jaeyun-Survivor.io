using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{

    [Header("Health Properties")]
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public bool IsDead() => _health == 0;
    public int HealHealth(int hpGain) => _health = Mathf.Min(_maxHealth, _health + hpGain);

    /// <summary>
    /// Initializes the enemy at max and current health.
    /// </summary>
    /// <param name="hp">The health to set to.</param>
    public void Initialize(int hp)
    {
        _maxHealth = hp;
        _health = hp;
    }

    /// <summary>
    /// Makes this character take `dmg` amount of damage.
    /// If dead, destroys the character.
    /// </summary>
    /// <param name="dmg"></param>
    public void TakeDamage(int dmg)
    {
        _health = Mathf.Max(_health - dmg, 0);
        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

}
