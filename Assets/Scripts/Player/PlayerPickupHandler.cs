using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerItemHandler))]
public class PlayerPickupHandler : MonoBehaviour
{

    [Header("Player Properties")]
    [SerializeField] private float _pickupRange;

    private PlayerItemHandler _playerItemHandler;

    private void Awake()
    {
        _playerItemHandler = GetComponent<PlayerItemHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickupable"))
        {
            GameObject obj = collision.gameObject;
            if (obj.TryGetComponent(out PickupableItemHandler pickupableHandler))
            {
                _playerItemHandler.AddItem(pickupableHandler.ItemInfo);
                pickupableHandler.DestroyItem();
            }
        }
    }

}
