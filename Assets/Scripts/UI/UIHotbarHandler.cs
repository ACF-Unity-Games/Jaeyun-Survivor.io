using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotbarHandler : MonoBehaviour
{

    [Header("Prefab Assignments")]
    [SerializeField] private GameObject _hotbarPrefab;
    [Header("Object Assignments")]
    [SerializeField] private Transform _hotbarParentTransform;
    [Header("Hotbar Properties")]
    [SerializeField] private int _startingHotbarSlots;

    private void Awake()
    {
        InitializeHotbar();
    }

    /// <summary>
    /// Initialize slots in the hotbar corresponding to the _startingHotbarSlots 
    /// variable.
    /// </summary>
    private void InitializeHotbar()
    {
        for (int i = 0; i < _startingHotbarSlots; i++)
        {
            Instantiate(_hotbarPrefab, _hotbarParentTransform);
        }
    }

}
