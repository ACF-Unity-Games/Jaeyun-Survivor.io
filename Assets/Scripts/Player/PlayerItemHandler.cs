using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{

    [Header("Prefab Assignments")]
    public GameObject _spinnableItemPrefab;

    private readonly List<ItemInfo> _currentItems = new();
    private readonly List<GameObject> _spawnedSpinningObjects = new();

    public void AddItem(ItemInfo item)
    {
        if (_currentItems.Count >= UIHotbarHandler.Instance.HotbarSlotCount)
        {
            // If we don't have space in the hotbar, put it in the inventory
        }
        else
        {
            // Or else, just put it in the hotbar (in the empty slot)
            _currentItems.Add(item);
            UIHotbarHandler.Instance.AddItemToHotbar(item);
            SpinItemsAroundPlayer();
        }
    }

    private void Awake()
    {
        Debug.Assert(_spinnableItemPrefab.GetComponent<ItemRotateHandler>() != null,
                    "Attached prefab must have a ItemRotateHandler attached!", this);
    }

    private void Start()
    {
        SpinItemsAroundPlayer();
    }

    public void SpinItemsAroundPlayer()
    {
        // Destroy all items, first.
        foreach (GameObject obj in _spawnedSpinningObjects)
        {
            Destroy(obj);
        }
        // Initialize an item for each item in the list.
        // Parent it to this sprite and add it to the spinning objects list.
        for (int i = 0; i < _currentItems.Count; i++)
        {
            ItemInfo item = _currentItems[i];
            GameObject obj = Instantiate(_spinnableItemPrefab, transform);
            _spawnedSpinningObjects.Add(obj);
            ItemRotateHandler irh = obj.GetComponent<ItemRotateHandler>();
            CollisionDamageHandler cdh = obj.GetComponent<CollisionDamageHandler>();
            cdh.DamageOnCollision = item.ItemAtk;
            cdh.IneffectiveTime = item.ItemDisableTime;
            irh.SetSpinningItem(item, transform);
            irh.SetTransformOffset(i * (360 / _currentItems.Count));
        }
    }

}
