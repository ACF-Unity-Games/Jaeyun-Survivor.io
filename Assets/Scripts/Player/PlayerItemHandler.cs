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
            UIHotbarHandler.Instance.AddItemToHotbar(item, 1);
            SpinItemsAroundPlayer();
        }
    }

    private void Awake()
    {
        Debug.Assert(_spinnableItemPrefab.GetComponent<SpinningItemHandler>() != null,
                    "Attached prefab must have a SpinningItemHandler attached!", this);
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
            SpinningItemHandler irh = obj.GetComponent<SpinningItemHandler>();
            CollisionDamageHandler cdh = obj.GetComponent<CollisionDamageHandler>();
            HealthHandler hh = obj.GetComponent<HealthHandler>();
            UISlotHandler ui = UIHotbarHandler.Instance.UISlots[i];
            cdh.OnDealDamage = () =>
            {
                ui.UpdateBGHealth(hh.GetHealthRatio());
            };
            irh.SetSpinningItem(item, ui, transform); 
            cdh.Initialize(item);
            irh.SetTransformOffset(i * (360 / _currentItems.Count));
        }
    }

}
