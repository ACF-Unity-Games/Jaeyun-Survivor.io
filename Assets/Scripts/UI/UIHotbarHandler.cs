using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotbarHandler : MonoBehaviour
{

    public static UIHotbarHandler Instance;
    [Header("Prefab Assignments")]
    [SerializeField] private GameObject _hotbarPrefab;
    [Header("Object Assignments")]
    [SerializeField] private Transform _hotbarParentTransform;
    [Header("Hotbar Properties")]
    [Tooltip("How many inventory slots the player should have")]
    public int HotbarSlotCount;

    public List<ItemInfo> StartingItems = new();
    public List<UISlotHandler> UISlots = new();

    private void Awake()
    {
        SetSingleton();
        InitializeHotbar();
    }

    /// <summary>
    /// Sets the corresponding hotbar slot to contain a item.
    /// </summary>
    /// <param name="itemSlotIdx">The index of the hotbar to set.</param>
    public void SetItemInHotbar(int itemSlotIdx, ItemInfo itemInfo)
    {
        UISlotHandler slotHandler = UISlots[itemSlotIdx];
        slotHandler.SetItem(itemInfo, 1);
    }

    /// <summary>
    /// Adds an item to the current hotbar.
    /// </summary>
    public UISlotHandler AddItemToHotbar(ItemInfo itemInfo, float healthRatio)
    {
        int idx = -1;
        for (int i = 0; i < UISlots.Count; i++)
        {
            if (UISlots[i].IsEmpty)
            {
                idx = i;
                break;
            }
        }
        // If the index doesn't exist, add to inventory. (TODO)
        // Or else, add the item here in the found slot.
        if (idx == -1)
        {
            return null;
        } else
        {
            UISlots[idx].SetItem(itemInfo, healthRatio);
            return UISlots[idx];
        }
    }

    /// <summary>
    /// Ensure that this object is a singleton (only one exists at a time).
    /// </summary>
    private void SetSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    /// <summary>
    /// Initialize slots in the hotbar corresponding to the _startingHotbarSlots 
    /// variable. Adds all initialized hotbars to the _uiSlots list.
    /// </summary>
    private void InitializeHotbar()
    {
        for (int i = 0; i < HotbarSlotCount; i++)
        {
            GameObject hCopy = Instantiate(_hotbarPrefab, _hotbarParentTransform);
            UISlots.Add(hCopy.GetComponent<UISlotHandler>());
            // If there's a valid item, set it to that. Else, null.
            ItemInfo itemToSetTo = (i < StartingItems.Count ? StartingItems[i] : null);
            SetItemInHotbar(i, itemToSetTo);
        }
    }

}
