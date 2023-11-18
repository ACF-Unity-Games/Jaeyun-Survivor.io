using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{

    [Header("Prefab Assignments")]
    public GameObject _spinnableItemPrefab;

    private List<Item> _currentItems = new();
    private List<GameObject> _spawnedSpinningObjects = new();

    public void AddItem(Item item)
    {
        _currentItems.Add(item);
        UIHotbarHandler.Instance.AddItemToHotbar(item);
        SpinItemsAroundPlayer();
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
            Item item = _currentItems[i];
            GameObject obj = Instantiate(_spinnableItemPrefab, transform);
            _spawnedSpinningObjects.Add(obj);
            ItemRotateHandler irh = obj.GetComponent<ItemRotateHandler>();
            irh.SetSpinningItem(item, transform);
            irh.SetTransformOffset(i * (360 / _currentItems.Count));
        }
    }

}
