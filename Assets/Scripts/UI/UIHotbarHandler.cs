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

    public Item ItemTest;

    private List<UISlotHandler> _uiSlots = new();

    private void Awake()
    {
        InitializeHotbar();
    }

    /// <summary>
    /// Initialize slots in the hotbar corresponding to the _startingHotbarSlots 
    /// variable. Adds all initialized hotbars to the _uiSlots list.
    /// </summary>
    private void InitializeHotbar()
    {
        for (int i = 0; i < _startingHotbarSlots; i++)
        {
            GameObject hCopy = Instantiate(_hotbarPrefab, _hotbarParentTransform);
            _uiSlots.Add(hCopy.GetComponent<UISlotHandler>());
            SetItemInHotbar(i, ItemTest);
        }
    }

    /// <summary>
    /// Sets the corresponding hotbar slot to contain a item.
    /// </summary>
    /// <param name="itemSlotIdx">The index of the hotbar to set.</param>
    public void SetItemInHotbar(int itemSlotIdx, Item itemInfo)
    {
        UISlotHandler slotHandler = _uiSlots[itemSlotIdx];
        slotHandler.SetItem(itemInfo);
    }

}
