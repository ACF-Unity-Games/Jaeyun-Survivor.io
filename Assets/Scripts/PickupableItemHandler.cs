using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickupableItemHandler : MonoBehaviour
{

    [Header("Item Properties")]
    [SerializeField] private Item _itemInfo;

    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Deletes this item and adds it to the player's
    /// inventory and/or (TODO) backpack.
    /// </summary>
    public void PickUpItem()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InitializeSprite();
    }

    private void InitializeSprite()
    {
        _spriteRenderer.sprite = _itemInfo.ItemSprite;
    }

}
