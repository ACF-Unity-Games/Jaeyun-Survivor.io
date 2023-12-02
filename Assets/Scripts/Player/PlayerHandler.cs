using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementHandler))]
[RequireComponent(typeof(PlayerItemHandler))]
[RequireComponent(typeof(PlayerPickupHandler))]
[RequireComponent(typeof(HealthHandler))]
public class PlayerHandler : MonoBehaviour
{

    [Header("Player Information")]
    [SerializeField] private int _startingHealth;

    private HealthHandler _healthHandler;

    private void Awake()
    {
        _healthHandler = GetComponent<HealthHandler>();
        _healthHandler.Initialize(_startingHealth);
    }

}
